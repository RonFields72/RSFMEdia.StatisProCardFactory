using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FileHelpers;

namespace RSFMEdia.StatisProCardFactory.Models
{
    /// <summary>
    /// Represents the pitching data obtained from Baseball-Reference.com
    /// The data can be exported in .csv format and then uploaded into StatisProCardFactory.
    /// This class is annotated with attributes from the FileHelpers library.
    /// </summary>
    [DelimitedRecord(",")]
    [IgnoreFirst(1)]
    public class PitchingData
    {
        public string Name { get; set; }
        public decimal Age { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public decimal ERA { get; set; }
        public int Games { get; set; }
        public int GamesStarted { get; set; }
        public int GamesFinished { get; set; }
        public int CompleteGames { get; set; }
        public int Shutouts { get; set; }
        public int Saves { get; set; }
        public int InningsPitched { get; set; }
        public int Hits { get; set; }
        public int Runs { get; set; }
        public int EarnedRuns { get; set; }
        public int HR { get; set; }
        public int Walks { get; set; }
        public int IBB { get; set; }
        public int Strikeouts { get; set; }
        public int HBP { get; set; }
        public int Balks { get; set; }
        public int WildPitches { get; set; }
        public int BattersFaced { get; set; }
        public decimal FIP { get; set; }
        public decimal WHIP { get; set; }
    }
}