using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;


namespace Arby.dataclass
{
    public partial class EventInfo
    {
        [JsonProperty("events")]
        public List<Event> Events { get; set; }

        [JsonProperty("markets")]
        public List<Market> Markets { get; set; }

    }

    public partial class Event
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("sport-id")]
        public long SportId { get; set; }

        [JsonProperty("start")]
        public DateTimeOffset Start { get; set; }

        [JsonProperty("in-running-flag")]
        public bool InRunningFlag { get; set; }

        [JsonProperty("allow-live-betting")]
        public bool AllowLiveBetting { get; set; }

        [JsonProperty("category-id")]
        public long[] CategoryId { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("volume")]
        public long Volume { get; set; }

        [JsonProperty("markets")]
        public Market[] Markets { get; set; }

        [JsonProperty("meta-tags")]
        public MetaTag[] MetaTags { get; set; }
    }

    public partial class Market
    {
        [JsonProperty("event-id")]
        public long EventId { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("runners")]
        public Runner[] Runners { get; set; }

        [JsonProperty("start")]
        public DateTimeOffset Start { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("market-type")]
        public string MarketType { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("in-running-flag")]
        public bool InRunningFlag { get; set; }

        [JsonProperty("allow-live-betting")]
        public bool AllowLiveBetting { get; set; }

        [JsonProperty("volume")]
        public long Volume { get; set; }

        [JsonProperty("handicap", NullValueHandling = NullValueHandling.Ignore)]
        public double? Handicap { get; set; }
    }

    public partial class Runner
    {
        [JsonProperty("withdrawn")]
        public bool Withdrawn { get; set; }

        [JsonProperty("prices")]
        public Price[] Prices { get; set; }

        [JsonProperty("event-id")]
        public long EventId { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("market-id")]
        public long MarketId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        // [JsonProperty("status")]
        // public Status Status { get; set; }

        [JsonProperty("volume")]
        public long Volume { get; set; }

        [JsonProperty("event-participant-id")]
        public long EventParticipantId { get; set; }

        [JsonProperty("handicap", NullValueHandling = NullValueHandling.Ignore)]
        public double? Handicap { get; set; }
    }

    public partial class Price
    {
        [JsonProperty("available-amount")]
        public double AvailableAmount { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("odds-type")]
        public string OddsType { get; set; }

        [JsonProperty("odds")]
        public double Odds { get; set; }

        [JsonProperty("decimal-odds")]
        public double DecimalOdds { get; set; }

        [JsonProperty("side")]
        public string Side { get; set; }

        [JsonProperty("exchange-type")]
        public string ExchangeType { get; set; }
    }

    public partial class MetaTag
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("url-name")]
        public string UrlName { get; set; }
    }
}