using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RSFMEdia.StatisProCardFactory.Models
{
    public class BatterCardAnalysis
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int NumberOfBatterCardsCreated { get; set; }
    }
}