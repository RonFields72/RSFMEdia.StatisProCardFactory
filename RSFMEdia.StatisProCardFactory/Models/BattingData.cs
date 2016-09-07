using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FileHelpers;

namespace RSFMEdia.StatisProCardFactory.Models
{
    /// <summary>
    /// Represents the batting data obtained from Baseball-Reference.com
    /// UBR is obtained from FanGraphs.
    /// The data can be exported in .csv format and then uploaded into StatisProCardFactory.
    /// This class is annotated with attributes from the FileHelpers library.
    /// </summary>
    [DelimitedRecord(",")]
    [IgnoreFirst(1)]
    public class BattingData
    {
        public string Pos { get; set; }
        public string Name { get; set; }
        public decimal Age { get; set; }
        public int G { get; set; }
        public int PA { get; set; }
        public int AB { get; set; }
        public int R { get; set; }
        public int H { get; set; }
        public int Doubles { get; set; }
        public int Triples { get; set; }
        public int HR { get; set; }
        public int RBI { get; set; }
        public int SB { get; set; }
        public int CS { get; set; }
        public int BB { get; set; }
        public int SO { get; set; }
        public decimal? BA { get; set; }
        public decimal OBP { get; set; }
        public decimal SLG { get; set; }
        public decimal OPS { get; set; }
        public int TB { get; set; }
        public int GDP { get; set; }
        public int HBP { get; set; }
        public int SH { get; set; }
        public int SF { get; set; }
        public int IBB { get; set; }
    }
}