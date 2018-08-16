using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Arby.dataclass
{
    public enum MarketTypes : int { OUTRIGHT };
    public enum BetTypes : int { BACK, LAY};

    public class MarketSnapshot
    {
        public DateTime Time { get; set; }
        public long MatchID { get; set; }
        public string Runner { get; set; }
        public string Name { get; set; }
        public MarketTypes Market { get; set; }
        public List<Offer> Back { get; set; }
        public List<Offer> Lay { get; set; }
        public MarketSnapshot()
        {
            Time = new DateTime(DateTime.Now.ToFileTimeUtc());
            Back = new List<Offer>();
            Lay = new List<Offer>();
        }
    }

    public class Offer
    {
        // potential memory issue here? (Should be int)
        public double Odds { get; set; }
        public double Volume { get; set; }
        public Offer(double odds, double volume)
        {
            Odds = odds;
            Volume = volume;
        }
    }
}
    