using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arby.dataclass
{
    [XmlRoot(ElementName = "Odds")]
    public class Odds
    {
        [XmlAttribute(AttributeName = "Id")]
        public string Id { get; set; }
        [XmlAttribute(AttributeName = "Name")]
        public string Name { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "Bet")]
    public class Bet
    {
        [XmlElement(ElementName = "Odds")]
        public List<Odds> Odds { get; set; }
        [XmlAttribute(AttributeName = "Id")]
        public string Id { get; set; }
        [XmlAttribute(AttributeName = "Info")]
        public string Info { get; set; }
        [XmlAttribute(AttributeName = "TypeId")]
        public string TypeId { get; set; }
        [XmlAttribute(AttributeName = "Name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "Value")]
        public string Value { get; set; }
        [XmlAttribute(AttributeName = "Note")]
        public string Note { get; set; }
    }

    [XmlRoot(ElementName = "Bets")]
    public class Bets
    {
        [XmlElement(ElementName = "Bet")]
        public List<Bet> Bet { get; set; }
    }

    [XmlRoot(ElementName = "Match")]
    public class Match
    {
        [XmlElement(ElementName = "Bets")]
        public Bets Bets { get; set; }
        [XmlAttribute(AttributeName = "Id")]
        public string Id { get; set; }
        [XmlAttribute(AttributeName = "Name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "MatchDate")]
        public string MatchDate { get; set; }
        [XmlAttribute(AttributeName = "HasLiveMatch")]
        public string HasLiveMatch { get; set; }
        [XmlAttribute(AttributeName = "HasVideoStream")]
        public string HasVideoStream { get; set; }
        [XmlElement(ElementName = "Teams")]
        public Teams Teams { get; set; }
    }

    [XmlRoot(ElementName = "Tournament")]
    public class Tournament
    {
        [XmlElement(ElementName = "Match")]
        public List<Match> Match { get; set; }
        [XmlAttribute(AttributeName = "Id")]
        public string Id { get; set; }
        [XmlAttribute(AttributeName = "Name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "Note")]
        public string Note { get; set; }
    }

    [XmlRoot(ElementName = "Category")]
    public class Category
    {
        [XmlElement(ElementName = "Tournament")]
        public List<Tournament> Tournament { get; set; }
        [XmlAttribute(AttributeName = "Id")]
        public string Id { get; set; }
        [XmlAttribute(AttributeName = "Name")]
        public string Name { get; set; }
    }

    [XmlRoot(ElementName = "Team")]
    public class Team
    {
        [XmlAttribute(AttributeName = "Id")]
        public string Id { get; set; }
        [XmlAttribute(AttributeName = "Name")]
        public string Name { get; set; }
    }

    [XmlRoot(ElementName = "Teams")]
    public class Teams
    {
        [XmlElement(ElementName = "Team")]
        public List<Team> Team { get; set; }
    }

    [XmlRoot(ElementName = "BettingData")]
    public class BettingData
    {
        [XmlElement(ElementName = "Category")]
        public List<Category> Category { get; set; }
        [XmlAttribute(AttributeName = "Provider")]
        public string Provider { get; set; }
        [XmlAttribute(AttributeName = "Type")]
        public string Type { get; set; }
        [XmlAttribute(AttributeName = "GeneratedAt")]
        public string GeneratedAt { get; set; }
        [XmlAttribute(AttributeName = "Server")]
        public string Server { get; set; }
        [XmlAttribute(AttributeName = "Lang")]
        public string Lang { get; set; }
    }

}
