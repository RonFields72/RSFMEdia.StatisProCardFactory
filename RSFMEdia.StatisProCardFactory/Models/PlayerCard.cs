using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RSFMEdia.StatisProCardFactory.Models
{
    public class PlayerCard
    {
        public string Year { get; set; }
        public string Team { get; set; }
        public string League { get; set; }
        public string Name { get; set; }
        public string Bats { get; set; }
        public string PositionsAndRatings { get; set; }
        public string Remarks { get; set; }
        public string OBR { get; set; }
        public string SP { get; set; }
        public string HandR { get; set; }
        public string CD { get; set; }
        public string SAC { get; set; }
        public string Inj { get; set; }
        public string BD { get; set; }
        public string BDDouble { get; set; }
        public string BDTriple { get; set; }
        public string BDHomerun { get; set; }
        public string SingleInfield { get; set; }
        public string SingleLeft { get; set; }
        public string SingleCenter { get; set; }
        public string SingleRight { get; set; }
        public string DoubleLeft { get; set; }
        public string DoubleCenter { get; set; }
        public string DoubleRight { get; set; }
        public string TripleCenter { get; set; }
        public string HR { get; set; }
        public string K { get; set; }
        public string W { get; set; }
        public string HBP { get; set; }
        public string Out { get; set; }
        public string Cht { get; set; }
        public int InfoAtBats { get; set; }
        public int InfoRuns { get; set; }
        public int InfoHits { get; set; }
        public int InfoDoubles { get; set; }
        public int InfoTriples { get; set; }
        public int InfoHomerun { get; set; }
        public int InfoRBI { get; set; }
        public int InfoStolenBases { get; set; }
        public int InfoWalks { get; set; }
        public double InfoAVG { get; set; }
        public double InfoSLG { get; set; }
        public double InfoOPS { get; set; }
        
    }
}