using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RSFMEdia.StatisProCardFactory.Models
{
    public class PitcherControl
    {
        public int Year { get; set; }
        public string League { get; set; }
        public string PB { get; set; }
        public decimal HighestERA { get; set; }
    }
}