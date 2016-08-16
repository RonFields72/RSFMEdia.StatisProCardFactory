using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RSFMEdia.StatisProCardFactory.Models
{
    /// <summary>
    /// Represents the player data obtained from Baseball-Reference.com
    /// The data can be exported in .csv format and then uploaded into StatisProCardFactory.
    /// </summary>
    public class PlayerData
    {
        public string Rank { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public int Age { get; set; }
        public int Games { get; set; }
        public int PlateAppearances { get; set; }
        public int AtBats { get; set; }
        public int Runs { get; set; }
        public int Hits { get; set; }
        public int Doubles { get; set; }
        public int Triples { get; set; }
        public int HR { get; set; }
        public int RBI { get; set; }
        public int StolenBases { get; set; }
        public int CaughtStealing { get; set; }
        public int Walks { get; set; }
        public int Strikeouts { get; set; }
        public Double BattingAVG { get; set; }
        public Double OBP { get; set; }
        public Double SLG { get; set; }
        public double OPS { get; set; }
        public int TotalBases { get; set; }
        public int GIDP { get; set; }
        public int HBP { get; set; }
        public int SacrificeHits { get; set; }
        public int SacrificeFlys { get; set; }
        public int IBB { get; set; }
        public string Remarks { get; set; }
    }
}