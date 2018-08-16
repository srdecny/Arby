using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Arby.dataclass;
using Arby.util;

namespace Arby
{
    partial class ArbyForm : Form
    {
        public void UpdateLoginBox()
        {
            if (Model.Session == null) LoginBox.Text = "Not logged in yet.";
            else { LoginBox.Text = $"Logged in as: {Model.Session.Account.Username}"; LoginButton.Hide(); }
        }

        public void UpdateEventsBox()
        {
            if (Model.PopularEvents != null)
            {
                EventsBox.DataSource = Model.PopularEvents.Events;
                EventsBox.DisplayMember = "Name";
                EventsBox.ValueMember = "Id";
            }
        }

        public void UpdateEventDetailsBox()
        {
            long EventID = Convert.ToInt64(EventsBox.SelectedValue);
            if (EventID == 0)
            {
                GUIHelper.ThrowWarning("Invalid selection", "No item selected!");
            }
            dataGridView1.Rows.Clear();
            dataGridView1.ColumnCount = 5;
            dataGridView1.Columns[0].Name = "Name";
            dataGridView1.Columns[1].Name = "Side";
            dataGridView1.Columns[2].Name = "Side";
            dataGridView1.Columns[3].Name = "Odds";
            dataGridView1.Columns[4].Name = "Volume";
            foreach (var Market in Model.EventPrices[EventID].Markets)
            {
                foreach (var Runner in Market.Runners)
                {
                    foreach (var Price in Runner.Prices)
                    {
                        dataGridView1.Rows.Add(Market.Name, Price.Side, Runner.Name, Price.Odds, Price.AvailableAmount);
                    }
                }
            }

            var results = MatchbookSnapshotConverter.ConvertEventToSnapshot(Model.EventPrices[EventID]);
            if (!(Model.MarketSnapshots.ContainsKey(EventID)))
            {
                Model.MarketSnapshots.Add(EventID, new List<MarketSnapshot>());
            }

            foreach (var Snapshot in results)
            {
                Model.MarketSnapshots[EventID].Add(Snapshot);
            }
        }

        public void UpdateScrapedEvents()
        {
            ScrapedEventsListBox.Items.Clear();
            foreach (var EventToScrape in Scraper.EventsToScrape)
            {
                ScrapedEventsListBox.Items.Add(EventToScrape);
            }

            ScrapedEventsListBox.ValueMember = "Item1"; // Event ID
            ScrapedEventsListBox.DisplayMember = "Item2"; // Event name
        }

        // Add new action to timer that will be called one time only
        public void EnqueueUpdateAction(Action action)
        {
            Timer.UpdateEventsQueue.Add(action);
        }

        public void UpdateSnapshotVisualization()
        {
            SnapshotVisualization.ColumnCount = 2;
            SnapshotVisualization.Columns[0].Name = "Event name";
            SnapshotVisualization.Columns[1].Name = "Scraped snapshots";

            SnapshotVisualization.Rows.Clear();
            lock(Model.MarketSnapshots)
            foreach (var Event in Model.MarketSnapshots)
            {
                if (Event.Value.Count > 0) // at least one snapshot present
                {
                    string EventName = Event.Value[0].Name;
                    SnapshotVisualization.Rows.Add(EventName, Event.Value.Count);
                }
            }
        }

    }
}
