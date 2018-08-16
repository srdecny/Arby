using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arby.dataclass
{
    class FortunaEvent
    {
        public string TournamentName { get; set; }
        public string EventName { get; set; }
        public string Runner { get; set; }
        public double Odds { get; set; }
        public long ID { get; set; }

        public FortunaEvent(string tournamentName, string eventName, string runner, double odds, long id)
        {
            TournamentName = tournamentName;
            EventName = eventName;
            Runner = runner;
            Odds = odds;
            ID = id;
        }
    }

    public static class FortunaEventHelper
    {
        public static List<DataGridViewColumn> GenerateColumns()
        {
            List<DataGridViewColumn> Columns = new List<DataGridViewColumn>();

            foreach (var Property in typeof(FortunaEvent).GetProperties())
            {
                DataGridViewColumn NewColumn = new DataGridViewColumn();
                NewColumn.DataPropertyName = Property.Name;
                NewColumn.Name = Property.Name;
                NewColumn.CellTemplate = new DataGridViewTextBoxCell();
                Columns.Add(NewColumn);
            }
            return Columns;
        }

        public static Match GetMatchByID(long id, BettingData data)
        {
            var Matches = from category in data.Category
                from tournament in category.Tournament
                from match in tournament.Match
                from bet in match.Bets.Bet
                where bet.Id == id.ToString()
                select match;
            return Matches.First();
        }
    }



}
