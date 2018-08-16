using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Arby.dataclass;
using Arby.util;

namespace Arby
{
    public partial class SnapshotVisualizer : Form
    {
        Dictionary<long, List<MarketSnapshot>> Database;
        public SnapshotVisualizer(Dictionary<long, List<MarketSnapshot>> database)
        {
            InitializeComponent();
            Database = database;
            GUIHelper.UpdateEventsListBox(EventsBox, Database);
        }

        private void EventsBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            long MatchID = Convert.ToInt64(EventsBox.SelectedValue);
            UpdateRunnersBox(MatchID);

        }

        private void UpdateRunnersBox(long MatchID)
        {
            RunnersBox.Items.Clear();
            foreach (var Runner in Database[MatchID].Select(x => x.Runner).Distinct())
            {
                RunnersBox.Items.Add(Runner);
            }
        }


        private Tuple<double, DateTime> CreateBackDataPoint(MarketSnapshot Snapshot, string Bet)
        {
            double Odds;
            if (Bet == "BACK" && Snapshot.Back.Count > 0)
            {
                Odds = Snapshot.Back[0].Odds;
            }
            else if (Bet == "LAY" && Snapshot.Lay.Count > 0)
            {
                Odds = Snapshot.Lay[0].Odds;
            }
            else
            {
                return null;
            }
            DateTime Time = Snapshot.Time;
            Tuple<double, DateTime> DataPoint = new Tuple<double, DateTime>(Odds, Time);
            return DataPoint;

        }

        private void RunnersBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateGraph();
        }

        private void UpdateGraph()
        {
            string SelectedRunner = RunnersBox.SelectedItem as string;
            if (SelectedRunner == null) return; // not selected yet

            long MatchID = Convert.ToInt64(EventsBox.SelectedValue);
            var Data = Database[MatchID];
            MatchPriceChart.Series.Clear();

            Series Line = new Series();
            Line.ChartType = SeriesChartType.Line;
            Line.Name = SelectedRunner;

            foreach (var Snapshot in Data.Where(x => x.Runner == SelectedRunner))
            {
                var DataPoint = CreateBackDataPoint(Snapshot, BetTypeBox.SelectedItem as string);
                if (DataPoint != null)
                {
                    Line.Points.AddXY(DataPoint.Item2, DataPoint.Item1);
                }
            }

            MatchPriceChart.Series.Add(Line);
            MatchPriceChart.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Seconds;
            MatchPriceChart.ChartAreas[0].AxisX.Interval = 0;
            MatchPriceChart.ChartAreas[0].RecalculateAxesScale();
        }

        private void BetTypeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateGraph();
        }
    }
}
