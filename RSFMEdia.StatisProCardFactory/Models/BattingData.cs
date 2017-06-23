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
        public string Pos;
        public string Name;
        public decimal Age;
        public int G;
        public int PA;
        public int AB;
        public int R;
        public int H;
        public int Doubles;
        public int Triples;
        public int HR;
        public int RBI;
        public int SB;
        public int CS;
        public int BB;
        public int SO;
        public decimal? BA;
        public decimal? OBP;
        public decimal? SLG;
        public decimal? OPS;
        public int TB;
        public int GDP;
        public int HBP;
        public int SH;
        public int SF;
        public int IBB;
        [FieldOptional]
        public int? UBR;
    }
}