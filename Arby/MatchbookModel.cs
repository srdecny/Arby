using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arby.dataclass;
using Newtonsoft.Json;


namespace Arby
{
    public class MatchbookModel
    {
        // Credentials used for logging into Matchbook
        public MatchbookCredentials Credentials { get; set; }

        // Session received after logging in. Session ID should be included in every API call.
        public Session Session { get; set; }
        public EventInfo PopularEvents { get; set; }

        // Prices of the popular events, displayed when event details are requested. Key is event's ID.
        public Dictionary<long, Event> EventPrices { get; set; }

        // Serves as a main data source for most of the application, basically supplies as a database. Key is event's ID.
        public Dictionary<long, List<MarketSnapshot>> MarketSnapshots {get; set;}

        public MatchbookModel()
        {
            EventPrices = new Dictionary<long, Event>();
            Credentials = new MatchbookCredentials();
            MarketSnapshots = new Dictionary<long, List<MarketSnapshot>>();
        }
    }
}
