using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml;
using System.Xml.Serialization;
using Arby.util;
using Arby.dataclass;

namespace Arby
{
    public partial class FortunaFeed : Form
    {
        public MatchbookModel Model;
        private List<Tuple<long, long>> WatchedEvents = new List<Tuple<long, long>>();
        private ArbitrageTimer Timer = new ArbitrageTimer();

        public FortunaFeed(MatchbookModel model)
        {   
            Model = model;
            InitializeComponent();
            Timer.Tick += new EventHandler(WatchedEvents_Tick);
            Timer.Start();
        }

        private async Task<BettingData> GetNewFeedData()
        {
            using (XmlReader Reader = XmlReader.Create("http://ext.ifortuna.cz/xmldata", new XmlReaderSettings() {Async = true}))
            {
                XmlSerializer Serializer = new XmlSerializer(typeof(BettingData));
                try
                {
                    await Reader.ReadAsync();
                    return (BettingData)Serializer.Deserialize(Reader);

                }
                catch (WebException Ex)
                {
                    GUIHelper.ThrowWarning("Web error", "Error accessing iFortuna XML feed. Check internet connection and/or feed avaliability.");
                    return null;
                }


            }
        }

        private async void FindFortunaEventsByName()
        {
            BindingSource Events = new BindingSource();
            BettingData FortunaEvents = await GetNewFeedData();
            if (FortunaEvents == null) return;
            foreach (var Category in FortunaEvents.Category)
            {
                foreach (var Tournament in Category.Tournament)
                {
                    foreach (var Match in Tournament.Match)
                    {
                        foreach (var Event in GetMatchPrices(Match))
                        {
                            Event.EventName = Match.Name;
                            Event.TournamentName = Tournament.Name;
                            Event.ID = Convert.ToInt64(Match.Id);
                            Events.Add(Event);
                        }
                    }
                }
            }

            SearchResultsView.Columns.Clear();
            SearchResultsView.AutoGenerateColumns = false;
            foreach (var Column in FortunaEventHelper.GenerateColumns())
            {
                SearchResultsView.Columns.Add(Column);
            }

            SearchResultsView.Columns[4].Visible = false; // don't show match ID 
            SearchResultsView.DataSource = Events;
        }

        private void FindEventsButton_Click(object sender, EventArgs e)
        {
            FindFortunaEventsByName();
        }


        private List<FortunaEvent> GetMatchPrices(Match FortunaMatch)
        {
            List<FortunaEvent> Events = new List<FortunaEvent>();
            List<string> Runners = new List<string>(FortunaMatch.Name.Split('-'));
            Runners.Insert(0, "draw"); // 1 - home, 0 - tie, 2 - away
            Dictionary<int, string> RunnerNames = Runners.Select((s, i) => new {s, i})
                .ToDictionary(x => x.i, x => x.s);

            foreach (var Bet in FortunaMatch.Bets.Bet.Where(bet => bet.Name == "zápas")) // only outright market
            {
                foreach (var Odd in Bet.Odds.Where(x => x.Text != null)) // only actual offers
                {
                    double Odds = double.Parse(Odd.Text, CultureInfo.InvariantCulture);

                    switch (Odd.Name)
                    {
                        case "0":
                            Events.Add(new FortunaEvent("", "", RunnerNames[0], Odds, 0));
                            break;
                        case "1":
                            Events.Add(new FortunaEvent("", "", RunnerNames[1], Odds, 0));
                            break;
                        case "2":
                            Events.Add(new FortunaEvent("", "", RunnerNames[2], Odds, 0));
                            break;
                        default:
                            break; // we don't care about other combinatons, like draw or home win 
                    }
                }
            }

            return Events;
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            FilterFortunaEvents(EventNameBox.Text);
        }

        private void FilterFortunaEvents(string MatchName)
        {
            SearchResultsView.CurrentCell = null;
            foreach (DataGridViewRow Row in SearchResultsView.Rows)
            {
                Row.Visible = false;
                if (Row.Cells[1].Value.ToString().Contains(MatchName))
                {
                    Row.Visible = true;
                }
            }
        }

        private void UpdateScrapedEventsBox()
        {
            List<string> DataSource = new List<string>();
            foreach (var Event in Model.MarketSnapshots.Values)
            {
                if (Event.Count > 0)
                {
                    DataSource.Add(Event[0].Name);
                }
            }

            ScrapedEventsBox.DataSource = DataSource;
        }

        private void UpdateScrapedEventsButton_Click(object sender, EventArgs e)
        {
            UpdateScrapedEventsBox();
        }

        private void AddToArbitrageButton_Click(object sender, EventArgs e)
        {
            AddToWatchedEvents();
        }

        private void AddToWatchedEvents()
        {
            if (SearchResultsView.SelectedRows.Count != 1 || ScrapedEventsBox.SelectedValue == null)
            {
                GUIHelper.ThrowWarning("Item error", "Wrong items selected!");
            }
            else
            {
                string MatchbookIDName = ScrapedEventsBox.SelectedItem.ToString();
                long MatchbookID = Model.MarketSnapshots.Where(pair => pair.Value[0].Name == MatchbookIDName)
                    .Select(pair => pair.Key).First();
                long FortunaID = (long)SearchResultsView.SelectedRows[0].Cells[4].Value;
                Tuple<long, long> NewEvent = new Tuple<long, long>(MatchbookID, FortunaID);

                if (WatchedEvents.Contains(NewEvent))
                {
                    GUIHelper.ThrowWarning("Item error", "Events are already being watched!");
                }
                else
                {
                    WatchedEvents.Add(new Tuple<long, long>(MatchbookID, FortunaID));
                    ArbitrageEventsBox.DataSource = WatchedEvents;
                }
            }
        }

        private async void CheckWatchedEvents()
        {
            if (WatchedEvents.Count == 0) return;
            BettingData FortunaEvents = await GetNewFeedData();
            if (FortunaEvents == null) return;
            foreach (var EventsToWatch in WatchedEvents)
            {
                Match FortunaMatch = FortunaEventHelper.GetMatchByID(EventsToWatch.Item2, FortunaEvents);
                var FortunaUnflattenedOdds =
                    FortunaMatch.Bets.Bet.Select(x => x.Odds.Select(y => Convert.ToDouble(y.Text, CultureInfo.InvariantCulture)).ToList()).ToList();
                List<double> FortunaOdds = FortunaUnflattenedOdds.SelectMany(x => x).ToList(); // 0 - home, 1 - tie, 2 - away

                int ScrapedEventsCount = Model.MarketSnapshots[EventsToWatch.Item1].Count();

                List<MarketSnapshot> MatchbookOffers = Model.MarketSnapshots[EventsToWatch.Item1].Skip(Math.Max(0, ScrapedEventsCount - 3)).ToList();
                foreach (var offer in MatchbookOffers)
                {
                    if (offer.Lay.Count == 0)
                    {
                        return; // no lay offers
                    }
                }

                List<double> MatchbookOdds = MatchbookOffers.Select(x => x.Lay.First()).Select(x => x.Odds).ToList();
                for (int i = 0; i < MatchbookOdds.Count; i++)
                {
                    if (FortunaOdds[i] > MatchbookOdds[i])
                    {
                        switch (i)
                        {
                            case 0:
                                GUIHelper.ThrowWarning("Arbitrage", $"Arbitrage detected at Home wins market! Home Matchbook odds: {MatchbookOdds[i]}, Fortuna odds: {FortunaOdds[i]}");
                                break;
                            case 1:
                                GUIHelper.ThrowWarning("Arbitrage", $"Arbitrage detected at Tie wins market! Home Matchbook odds: {MatchbookOdds[i]}, Fortuna odds: {FortunaOdds[i]}");
                                break;
                            case 2:
                                GUIHelper.ThrowWarning("Arbitrage", $"Arbitrage detected at Away wins market! Home Matchbook odds: {MatchbookOdds[i]}, Fortuna odds: {FortunaOdds[i]}");
                                break;
                            default:
                                GUIHelper.ThrowWarning("Arbitrage", $"Some kind of arbitrage found! Home Matchbook odds: {MatchbookOdds[i]}, Fortuna odds: {FortunaOdds[i]}");
                                break;

                        }
                    }
                }
            }

        }
        private void WatchedEvents_Tick(object sender, EventArgs e)
        {
            CheckWatchedEvents();
        }


        private void RemoveFromArbitrageButton_Click(object sender, EventArgs e)
        {
            RemoveFromWatchedEvents();
        }

        private void RemoveFromWatchedEvents()
        {
            if (ArbitrageEventsBox.SelectedItem == null)
            {
                GUIHelper.ThrowWarning("Item error", "No item selected!");
            }
            else
            {
                Tuple<long, long> EventToRemove = (Tuple<long, long>) ArbitrageEventsBox.SelectedItem;
                WatchedEvents.Remove(EventToRemove);
                ArbitrageEventsBox.DataSource = null;
                ArbitrageEventsBox.DataSource = WatchedEvents;
            }
        }
    }
}
