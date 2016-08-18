using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FileHelpers;

namespace RSFMEdia.StatisProCardFactory.Models
{
    /// <summary>
    /// Represents the batting data obtained from Baseball-Reference.com
    /// The data can be exported in .csv format and then uploaded into StatisProCardFactory.
    /// This class is annotated with attributes from the FileHelpers library.
    /// </summary>
    [DelimitedRecord(",")]
    [IgnoreFirst(1)]
    public class FieldingData
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public decimal Age { get; set; }
        public int Games { get; set; }
        public int GamesStarted { get; set; }
        public int CompleteGames { get; set; }
        public decimal Innings { get; set; }
        public int Chances { get; set; }
        public decimal PutOuts { get; set; }
        public int Assists { get; set; }
        public int Errors { get; set; }
        public int DoublePlays { get; set; }
        public decimal FieldingPercentage { get; set; }
        public int PassedBalls { get; set; }
        public int WildPitches { get; set; }
        public int StolenBases { get; set; }
        public int CaughtStealing { get; set; }
        public int CaughtStealingPercentage { get; set; }
    }
}