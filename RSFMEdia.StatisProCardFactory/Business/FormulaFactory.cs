using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RSFMEdia.StatisProCardFactory.Models;

namespace RSFMEdia.StatisProCardFactory.Business
{
    public class FormulaFactory
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

        public int CalculateHandRRating(PlayerCard playerCard)
        {
            // based on the # of strikeouts on the player card
            // TODO: if player card has no strikeout numbers then H&R=2, if 1 then H&R=1 else 0
            return 0;
        }
    }
}