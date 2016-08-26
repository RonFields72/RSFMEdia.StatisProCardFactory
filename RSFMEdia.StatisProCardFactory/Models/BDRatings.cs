using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RSFMEdia.StatisProCardFactory.Models
{
    public class BDRatings
    {
        public int NumberBD2Bs { get; set; }
        public int NumberBD3Bs { get; set; }
        public int NumberBDHRs { get; set; }
        public string DoublesToCard { get; set; }
        public string TriplesToCard { get; set; }
        public string HomerunsToCard { get; set; }
    }
}