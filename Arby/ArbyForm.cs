using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Remoting.Messaging;
using System.Threading.Tasks;
using System.Windows.Forms;
using Arby.util;
using Arby.dataclass;

namespace Arby
{
    public partial class ArbyForm : Form
    {
        MatchbookController Controller;
        MatchbookModel Model;
        UpdateGUITimer Timer;
        ScraperTimer Scraper;
        SettingsData Settings;

        public ArbyForm()
        {
            InitializeComponent();
            Model = new MatchbookModel();
            Controller = new MatchbookController();
            Controller.Model = Model;
            Controller.Form = this;
            Settings = SettingsHelper.GetDefaultSettingsData();
            Timer = new UpdateGUITimer();
            Scraper = new ScraperTimer();


            UpdateSettings();
            Timer.Start();
            Scraper.Tick += new EventHandler(scraper_Tick);
            Scraper.Start();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await Controller.LogIn();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            await Controller.GetPopularMarkets();
        }

        private void scraper_Tick(object sender, EventArgs e)
        {
            // Scrape all events in queue
            ScraperTimer Timer = sender as ScraperTimer;
            Parallel.ForEach(Timer.EventsToScrape, (EventTuple) =>
            {
                Controller.ScrapeEvent(EventTuple.Item1);
            });
        }

        private async void getPricesButton_Click(object sender, EventArgs e)
        {
            long EventID = Convert.ToInt64(EventsBox.SelectedValue);
            if (EventID == 0)
            {
                GUIHelper.ThrowWarning("No item", "No item selected!");
            }
            else
            {
                if (Model.EventPrices.ContainsKey(EventID)) Model.EventPrices.Remove(EventID);
                await Controller.GetEventPrices(EventID);
            }
        }

        private void ScraperButton_Click(object sender, EventArgs e)
        {
            long EventID = Convert.ToInt64(EventsBox.SelectedValue);
            if (EventID == 0)
            {
                GUIHelper.ThrowWarning("Item error", "No item was selected!");
            }
            else if (Scraper.EventsToScrape.Select(x => x.Item1).Contains(EventID))
            {
                GUIHelper.ThrowWarning("Item error", "Event is already being scraped!");
            }
            else
            {
                Tuple<long, string> EventToScrape = new Tuple<long, string>(EventID, EventsBox.GetItemText(EventsBox.SelectedItem));
                Scraper.EventsToScrape.Add(EventToScrape);
                Timer.UpdateEventsQueue.Add(UpdateScrapedEvents);
            }
        }

        private void UpdateSnapshotView_Click(object sender, EventArgs e)
        {
            Timer.UpdateEventsQueue.Add(UpdateSnapshotVisualization);
        }

        private void SnapshotManagerButton_Click(object sender, EventArgs e)
        {
            SnapshotManager Manager = new SnapshotManager(Model.MarketSnapshots);
            Manager.ShowDialog();
            Model.MarketSnapshots = Manager.WorkspaceDatabase;
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SnapshotVisualizer Visualizer = new SnapshotVisualizer(Model.MarketSnapshots);
            Visualizer.Show();
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            SettingsManager Manager = new SettingsManager(Settings);
            Manager.ShowDialog();
            Settings = Manager.SettingsData;
            UpdateSettings();
        }

        /*
         * Has to be called whenever the setting is changed to propagate the changes
         */
        private void UpdateSettings()
        {
            Scraper.Stop();
            Scraper.ScrapeInterval = Settings.ScraperIntervalTime.Value;
            Scraper.Start();
            Model.Credentials.password = Settings.MatchbookPassword.Value;
            Model.Credentials.username = Settings.MatchbookUsername.Value;
        }

        private void ScraperRemoveButton_Click(object sender, EventArgs e)
        {
            Tuple<long, string> Event = (Tuple<long, string>)ScrapedEventsListBox.SelectedItem;
            if (Event == null)
            {
                GUIHelper.ThrowWarning("Item error", "No item was selected!");
            }
            else
            {
                long EventID = Event.Item1;

                if (!(Scraper.EventsToScrape.Select(x => x.Item1).Contains(EventID)))
                {
                    GUIHelper.ThrowWarning("Item error", "Event was not being scraped!");
                }
                else
                {
                    Scraper.EventsToScrape.Remove(Scraper.EventsToScrape.Find(x => x.Item1 == EventID));
                    Timer.UpdateEventsQueue.Add(UpdateScrapedEvents);
                }
            }
        }

        private void FortunaFeedButton_Click(object sender, EventArgs e)
        {
            FormCollection OpenForms = Application.OpenForms;
            foreach (var Form in OpenForms)
            {
                if (Form is FortunaFeed)
                {
                    var FortunaForm = (FortunaFeed) Form;
                    FortunaForm.Focus();
                    return;
                }
            }
            // FortunaFeed form not open
            FortunaFeed NewFortunaForm = new FortunaFeed(Model);
            NewFortunaForm.Show();
        }
    }
}
