using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Arby.dataclass;


namespace Arby.util
{
    static class GUIHelper
    {
        /*
         * A helper function that populates given ListBox control with supplied data.
         * Selects match's name as as displayed item and it's id as value.
         */
        public static void UpdateEventsListBox(ListBox Box, Dictionary<long, List<MarketSnapshot>> Data)
        {
            List<Tuple<string, long>> EventNames = new List<Tuple<string, long>>();
            foreach (var Event in Data)
            {
                if (Event.Value.Count() > 0)
                {
                    EventNames.Add(new Tuple<string, long>(Event.Value[0].Name, Event.Key));
                }
            }
            Box.ValueMember = "Item2";
            Box.DisplayMember = "Item1";
            Box.DataSource = EventNames;
        }

        /*
         * Displays a warning screen for the user.
         */
        public static void ThrowWarning(string title, string body)
        {
            MessageBox.Show(body, title, MessageBoxButtons.OK);
        }
    }
}
