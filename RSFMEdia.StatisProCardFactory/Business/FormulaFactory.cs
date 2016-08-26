using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RSFMEdia.StatisProCardFactory.Models;

namespace RSFMEdia.StatisProCardFactory.Business
{
    public class FormulaFactory
    {
        public BDRatings CalculateBDRatings(BattingData playerData)
        {
            // calculates the extended BD doubles, triples and HR ranges per the third edition of Statis-Pro Baseball

            // formula is as follows: 
            // 1) calculate total # of extra base hits (add number of doubles + triples + homeruns)
            var ebh = playerData.Doubles + playerData.Triples + playerData.HR;

            // 2) calculate EBH % (extra base hits dived by total hits)
            var ebhPct = Math.Round( (decimal) ebh / (decimal) playerData.H, 3);

            // 3) calculate number of BD doubles to the card (multiply # of doubles by 64 and then multiply that by the EBH% then divide by number of extra base hits (EBH)
            var numberOf2Bs = Convert.ToInt32((playerData.Doubles * 64 * ebhPct) / ebh);

            // 4) calculate number of BD triples to the card (multiply # of triples by 64 and then multiply that by the EBH% then divide by number of extra base hits (EBH)
            var numberOf3Bs = Convert.ToInt32((playerData.Triples * 64 * ebhPct) / ebh);

            // 5) calculate number of BD homeruns to the card (multiply # of triples by 64 and then multiply that by the EBH% then divide by number of extra base hits (EBH)
            var numberOfHRs = Convert.ToInt32((playerData.HR * 64 * ebhPct) / ebh);

            // 6) assign the corresponding amount of numbers to the player card
            var doublesToCard = StatisProData.NumberConversions.Take(numberOf2Bs);
            var triplesToCard = StatisProData.NumberConversions.Skip(numberOf2Bs).Take(numberOf3Bs);
            var hrsToCard = StatisProData.NumberConversions.Skip(numberOf2Bs + numberOf3Bs).Take(numberOfHRs);

            // create the BD ratings in the form of a string and set the actual number of each allotted to the card (base 8 numbering system)
            BDRatings bd = new BDRatings();
            bd.NumberBD2Bs = numberOf2Bs;
            bd.NumberBD3Bs = numberOf3Bs;
            bd.NumberBDHRs = numberOfHRs;

            // doubles
            if (doublesToCard.Count() > 0)
            {
                var firstDouble = doublesToCard.First();
                var lastDouble = doublesToCard.Last();
                // account for one or more doubles double
                bd.DoublesToCard = doublesToCard.Count() == 1 ? string.Format("{0}", firstDouble.Base8Number.ToString()) : 
                    string.Format("{0} - {1}", firstDouble.Base8Number.ToString(), lastDouble.Base8Number.ToString());
            }
            else
            {
                bd.DoublesToCard = string.Empty;
            }

            // triples
            if (triplesToCard.Count() > 0)
            {
                var firstTriple = triplesToCard.First();
                var lastTriple = triplesToCard.Last();
                // account for one or more triples
                bd.TriplesToCard = triplesToCard.Count( ) == 1 ? string.Format("{0}", firstTriple.Base8Number.ToString()) :
                    string.Format("{0} - {1}", firstTriple.Base8Number.ToString(), lastTriple.Base8Number.ToString());
            }
            else
            {
                bd.TriplesToCard = string.Empty;
            }

            // homers
            if (hrsToCard.Count() > 0)
            {
                var firstHR = hrsToCard.First();
                var lastHR = hrsToCard.Last();
                // account for one or more homeruns
                bd.HomerunsToCard = hrsToCard.Count() == 1 ? string.Format("{0}", firstHR.Base8Number.ToString()) :
                    string.Format("{0} - {1}", firstHR.Base8Number.ToString(), lastHR.Base8Number.ToString());
            }
            else
            {
                bd.HomerunsToCard = string.Empty;
            }
            return bd;
            // 2010 Ichiro (Example)
            // 2B(34), 3B(8), HR(8), H(242)
            // EBH(2B + 3B + HR) = 50
            // EBH % (EBH / H) = 0.207
            // BDDoubles = Integer[(34 * 64 * 0.207) / 50] = 9
            // BDTriples = Integer[(8 * 64 * 0.207) / 50] = 2
            // BDHomeruns = Integer[(8 * 64 * 0.207) / 50] = 2
            // Assign the first 9 numbers to 2B (starting at 11), the next 2 for 3Bs, and the next 2 for HRs.
            // For the Ichiro's card, the BD ratings would be: 
            //2B – 11 - 21(11, 12, 13, 14, 15, 16, 17, 18, 21) 9
            //3B – 22 - 23(22, 23) 2
            //HR – 24 - 25(24, 25) 2
        }

        public string CalculateClassicBDRating(BattingData playerData)
        {
            if (playerData.HR >= 30) return "2";
            
            if (playerData.HR >= 20) return "1";

            return "0";
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

        public string CalculateCht(BattingData playerData, PlayerCard thePlayerCard)
        {
            // account for pitchers
            if (playerData.Pos == "P") return "P";

            // get batting handedness
            var hand = CalculateBattingHand(playerData);

            // if four HR numbers on card OR if the batter hit at least 15 HR's then the classification is "P"ower


            return "T";
        }

        public string ParsePlayerName(string name)
        {
            // remove *, # from name
            var parsedName = name.Trim(new Char[] { '*', '#' });
            return parsedName;
        }

        //public string CalculateFieldingRatings(string playerName, List<FieldingData> fielderData)
        //{
        //    // get only fielding data for the current player
        //    var currentFieldingData = fielderData.Where(fd => fd.Name.Trim() == playerName).OrderBy(fd => fd.G);

        //    // TODO: handle pitchers
        //    foreach (var pos in currentFieldingData)
        //    {
                
        //    }
        //}
    }
}