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
        public string Pos;
        public string Name;
        public decimal Age;
        public int G;
        public int GS;
        public int CG;
        public decimal Inn;
        public int Ch;
        public int PO;
        public int A;
        public int E;
        public int DP;
        public decimal FldPct;
        public int? TZ;
        [FieldOptional]
        public int? PB;
        [FieldOptional]
        public int? WP;
        [FieldOptional]
        public int? SB;
        [FieldOptional]
        public int? CS;
        [FieldOptional]
        public string CSPct;
    }
}