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
        public string Pos { get; set; }
        public string Name { get; set; }
        public decimal Age { get; set; }
        public int G { get; set; }
        public int GS { get; set; }
        public int CG { get; set; }
        public decimal Inn { get; set; }
        public int Ch { get; set; }
        public decimal PO { get; set; }
        public int A { get; set; }
        public int E { get; set; }
        public int DP { get; set; }
        public decimal FldPct { get; set; }
        public int? TZ { get; set; }
        public int? PB { get; set; }
        public int? WP { get; set; }
        public int? SB { get; set; }
        public int? CS { get; set; }
        public int? CSPct { get; set; }
        public int? UZR { get; set; }
    }
}