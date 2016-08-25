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

            // formula is: 
            var theCard = new PlayerCard();
            return theCard;
        }

        public string CalculateClassicBDRating(BattingData playerData)
        {
                if (playerData.HR >= 30)
                {
                return 2.ToString();
                }
                if (playerData.HR >= 20)
                {
                return 1.ToString();
                }
                return 0.ToString();
        }

        public int CalculateHitAndRunRating(PlayerCard playerCard)
        {
            // based on the # of strikeouts on the player card
            // TODO: if player card has no strikeout numbers then H&R=2, if 1 then H&R=1 else 0
            return 0;
        }

        public string CalculateBattingHand(BattingData playerData)
        {
            // init 
            string battingHand = string.Empty;

            // parse last character from players name
            var lastCharacter = playerData.Name.Trim();
            lastCharacter = lastCharacter.Substring(lastCharacter.Length - 1);

            // If last character is an asterisk
            if (lastCharacter == "*")
            {
                battingHand = "L";
            }
            else if (lastCharacter == "#")
            {
                battingHand = "S";
            }
            else
            {
                battingHand = "R";
            }
            return battingHand;
        }

        public string CalculateCht(BattingData playerData, )
        {
            // TODO: account for pitchers


        }
    }
}