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
        public int NumberOfBatterCardsCreated { get; set; }
        public int NumberOfBatterCardsSkipped { get; set; }
        public int NumberOfPitcherCardsCreated { get; set; }
        public int NumberOfPitcherCardsSkipped { get; set; }
    }
}