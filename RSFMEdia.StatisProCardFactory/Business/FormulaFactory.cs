using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RSFMEdia.StatisProCardFactory.Models;

namespace RSFMEdia.StatisProCardFactory.Business
{
    public class FormulaFactory
    {
        public PlayerCard CalculateBDRating(BattingData playerData, PlayerCard thePlayerCard)
        {
            // adds the BD doubles, triples and HR ranges to the card
            var theCard = new PlayerCard();
            return theCard;
        }

        public PlayerCard CalculateClassicBDRating(BattingData playerData, PlayerCard thePlayerCard)
        {
                if (playerData.HR >= 30)
                {
                    
                }
                if (playerData.HR >= 20)
                {
                   
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