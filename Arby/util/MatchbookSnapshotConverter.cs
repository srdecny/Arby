using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace Arby.dataclass
{
     public static class MatchbookSnapshotConverter
    {
        public static List<MarketSnapshot> ConvertEventToSnapshot(Event MatchbookEvent)
        {
            List<MarketSnapshot> SnapshotList = new List<MarketSnapshot>();
            foreach (var Market in MatchbookEvent.Markets)
            {
                if (Market.Name != "Match Odds" && Market.Name != "Winner") return SnapshotList;
               
               foreach (var Runner in Market.Runners)
                {
                    MarketSnapshot Snapshot = new MarketSnapshot();
                    Snapshot.MatchID = MatchbookEvent.Id;
                    Snapshot.Runner = Runner.Name;
                    Snapshot.Market = MarketTypes.OUTRIGHT;
                    Snapshot.Name = MatchbookEvent.Name;
                    Snapshot.Time = DateTime.Now;

                    foreach (var Price in Runner.Prices)
                    {
                        if (Price.Side == "lay")
                        {
                            Snapshot.Lay.Add(new Offer(Price.Odds, Price.AvailableAmount));
                        }
                        else if (Price.Side == "back")
                        {
                            Snapshot.Back.Add(new Offer(Price.Odds, Price.AvailableAmount));
                        }
                        else
                        {
                            throw new ArgumentException($"Price type was not expected : {Price.Side}");
                        }
                    }

                    SnapshotList.Add(Snapshot);
                }
            }
            return SnapshotList;
        }
    }
}
