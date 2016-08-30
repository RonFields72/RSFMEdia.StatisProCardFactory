using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RSFMEdia.StatisProCardFactory.Models
{
    public class CardAnalysis
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int NumberOfCardsCreated { get; set; }
    }
}