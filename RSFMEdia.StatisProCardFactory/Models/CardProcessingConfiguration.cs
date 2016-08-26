using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RSFMEdia.StatisProCardFactory.Models
{
    public class CardProcessingConfiguration
    {
        public string Year { get; set; }
        public string League { get; set; }
        public string TeamName { get; set; }
        public string TeamAbbrev { get; set; }
        public string Manager { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public bool UseUBR { get; set; }
        public bool UseUZR { get; set; }
        public bool UseTZ { get; set; }
    }
}