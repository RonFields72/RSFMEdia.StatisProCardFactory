﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FileHelpers;

namespace RSFMEdia.StatisProCardFactory.Models
{
    /// <summary>
    /// Represents the batting data obtained from Baseball-Reference.com or FanGraphs.
    /// The data can be exported in .csv format and then uploaded into StatisProCardFactory.
    /// This class is annotated with attributes from the FileHelpers library.
    /// </summary>
    [DelimitedRecord(",")]
    [IgnoreFirst(1)]
    public class BattingData
    {
        public string Name { get; set; }
        public decimal Age { get; set; }
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
        public decimal BattingAVG { get; set; }
        public decimal OBP { get; set; }
        public decimal SLG { get; set; }
        public decimal OPS { get; set; }
        public int TotalBases { get; set; }
        public int GIDP { get; set; }
        public int HBP { get; set; }
        public int SacrificeHits { get; set; }
        public int SacrificeFlys { get; set; }
        public int IBB { get; set; }
        public decimal UBR { get; set; }
    }
}