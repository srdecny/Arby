using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arby.dataclass
{
    public class SettingsData
    {
        public Property<int> ScraperIntervalTime { get; set; } = new Property<int>();
        public Property<string> MatchbookUsername { get; set; } = new Property<string>();
        public Property<string> MatchbookPassword { get; set; } = new Property<string>();
    }

    public class Property<T>
    {
        public T Value { get; set; }
        public string Description { get; set; }
    }

    public static class SettingsHelper
    {
        public static SettingsData GetDefaultSettingsData()
        {
            SettingsData Settings = new SettingsData();

            Settings.ScraperIntervalTime.Value = 1000;
            Settings.ScraperIntervalTime.Description = "Time in ms between scraper timer ticks";

            Settings.MatchbookPassword.Value = "hunter2";
            Settings.MatchbookPassword.Description = "Password for Matchbook";

            Settings.MatchbookUsername.Value = "AzureDiamond";
            Settings.MatchbookUsername.Description = "Username for Matchbook";

            return Settings;
        }
    }

    
}
