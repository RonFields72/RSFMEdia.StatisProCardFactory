using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RSFMEdia.StatisProCardFactory.Models;

namespace RSFMEdia.StatisProCardFactory.Business
{
    public class FormulaHelper
    {
        public int CalculateBDRating(BattingData playerData)
        {
            return 0;
        }

        public int CalculateClassicBDRating(NormalizedPlayer playerData)
        {
                if (playerData.HR >= 30)
                {
                    return 2;
                }
                if (playerData.HR >= 20)
                {
                    return 1;
                }
                return 0;
            
        }
    }
}