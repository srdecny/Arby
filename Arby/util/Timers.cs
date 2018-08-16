using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arby.util
{
    public class UpdateGUITimer : Timer
    {
        // These events will fire only once
        public List<Action> UpdateEventsQueue = new List<Action>();

        // These events will fire every time the timer ticks
        public List<Action> PermanentEvents = new List<Action>();

        public UpdateGUITimer()
        {
            Interval = 100; // 100 ms
            Tick += new EventHandler(timer_Tick);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            var Timer = sender as UpdateGUITimer;
            foreach (var Event in Timer.UpdateEventsQueue.Concat(Timer.PermanentEvents))
            {
                Event();
            }

            Timer.UpdateEventsQueue.Clear();
        }
    }

    public class ScraperTimer : Timer
    {
        public List<Tuple<long, string>> EventsToScrape = new List<Tuple<long, string>>();
        public int ScrapeInterval = 1000; // default value, will be overwritten in settings

        public ScraperTimer()
        {
            Interval = ScrapeInterval;
        }
    }

    public class ArbitrageTimer : Timer
    {
        public int ScrapeInterval = 5000;

        public ArbitrageTimer()
        {
            Interval = ScrapeInterval;
        }
    }
}