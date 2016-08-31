using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RSFMEdia.StatisProCardFactory.DataLayer;
using RSFMEdia.StatisProCardFactory.Models;

namespace RSFMEdia.StatisProCardFactory.Business
{
    public class FormulaFactory
    {
        #region Properties
        public readonly string BATS_LEFT = "L";
        public readonly string BATS_RIGHT = "R";
        public readonly string BATS_SWITCH = "S";
        #endregion

        #region Helper Methods
        /// <summary>
        /// Removes special characters from the player name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public string ParsePlayerName(string name)
        {
            // remove *, # from name
            var parsedName = name.Trim(new Char[] { '*', '#' });
            return parsedName;
        }

        /// <summary>
        /// Calculates the batting hand.
        /// </summary>
        /// <param name="playerData">The player data.</param>
        /// <returns>R-right, L-left or S-switch</returns>
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

        private int GetNumberOfIBFs(BattingData playerData, int numberOfSinglesOnCard)
        {
            // init
            int numberOfIBFs = 0;

            // make sure the total number of singles is more than 1
            if (numberOfSinglesOnCard > 1)
            {

            }
            else
            {
                // maximum of 1 infield single

            }

            // determine possible number of infields singles based on steals
            if (playerData.SB >= 17)
            {
                numberOfIBFs = 2;
            }
            else if (playerData.SB >= 9)
            {
                numberOfIBFs = 1;
            }
            else
            {
                numberOfIBFs = 0;    
            }
            return numberOfIBFs;
        }

        public int NormalizeStat(int totalGames, int actualGames, int statistic)
        {
            // normalize stat to a full team season
            decimal seasonFactor = (decimal) totalGames / (decimal) actualGames;
            return Convert.ToInt32(seasonFactor * statistic);
        }
        #endregion

        #region OBR Rating
        /// <summary>
        /// Calcs the OBR for a batter using a scoring percentage formula.
        /// </summary>
        /// <param name="playerData">The player data.</param>
        /// <returns></returns>
        public string CalcOBR(BattingData playerData)
        {
            // init
            string obrRating = string.Empty;

            // compute times on base as (Hits + BB + HBP)  
            var timesOnBase = playerData.H + playerData.BB + playerData.HBP;
            if (timesOnBase > 0)
            {
                // compute scoring percentage and compare and assign rating
                var scoringPct = (double) playerData.R / (double) timesOnBase;
                if (scoringPct >= 0.4)
                {
                    obrRating = SPCFConstants.OBR_RATING_A;
                }
                else if (scoringPct >= .375)
                {
                    obrRating = SPCFConstants.OBR_RATING_B;
                }
                else if (scoringPct >= .250)
                {
                    obrRating = SPCFConstants.OBR_RATING_C;
                }
                else if (scoringPct >= .225)
                {
                    obrRating = SPCFConstants.OBR_RATING_D;
                }
                else
                {
                    obrRating = SPCFConstants.OBR_RATING_E;
                }
            }
            else
            {
                obrRating = SPCFConstants.OBR_RATING_E;
            }
            return obrRating;
        }

        /// <summary>
        /// Calcs the OBR for a batter using runs and stolen bases total.
        /// </summary>
        /// <param name="playerData">The player data.</param>
        /// <returns></returns>
        public string CalcOBRUsingRunsAndSBs(BattingData playerData)
        {
            // add runs and stolen bases
            var runsPlusStolenBases = playerData.R + playerData.SB;
            using (var context = new SQLiteContext())
            {
                var obr = context.OBRLookups
                    .Where(ol => ol.RunsPlusStolenBases <= runsPlusStolenBases)
                    .OrderByDescending(ol => ol.RunsPlusStolenBases)
                    .FirstOrDefault();
                return obr.OBR.Trim();
            }
        }

        /// <summary>
        /// Calcs the OBR for a batter using UBR from FanGraphs.
        /// </summary>
        /// <param name="playerData">The player data.</param>
        /// <returns></returns>
        public string CalcOBRUsingUBR(BattingData playerData)
        {
            // TODO: determine how to optionally import UBR from FanGraphs
            // this is only available for modern seasons
            // extract UBR
            // decimal ubrRating = (decimal) playerData.UBR;
            string obrRating = string.Empty;

            // return the OBR based on the UBR (ulitimate base running) rating
            var ubrRating = 5;
            if (ubrRating >= 4) obrRating = SPCFConstants.OBR_RATING_A;
            if (ubrRating >= 1.5) obrRating = SPCFConstants.OBR_RATING_B;
            if (ubrRating >= -1.5) obrRating = SPCFConstants.OBR_RATING_C;
            if (ubrRating >= -4) obrRating = SPCFConstants.OBR_RATING_D;
            if (ubrRating >= -6) obrRating = SPCFConstants.OBR_RATING_E;
            return obrRating;
        }
        #endregion

        #region SP Rating
        /// <summary>
        /// Calcs the SP rating using a database table.
        /// </summary>
        /// <param name="playerData">The player data.</param>
        /// <param name="configSettings">The config settings.</param>
        /// <returns></returns>
        public string CalcSPRating(BattingData playerData, CardProcessingConfiguration configSettings)
        {
            // normalize player stolen base totals to a full season
            var totalGames = configSettings.Wins + configSettings.Losses;
            decimal seasonFactor = (decimal) totalGames / (decimal) playerData.G;
            var normalizedSB = Convert.ToInt32(seasonFactor * playerData.SB);

            using (var context = new SQLiteContext())
            {
                var rating = context.SPLookups
                    .Where(s => s.StolenBases <= normalizedSB)
                    .OrderByDescending(s => s.StolenBases)
                    .FirstOrDefault();
                return rating.SP.Trim();
            }
        }

        /// <summary>
        /// Calcs the SP rating using a local collection that serves as a lookup table.
        /// </summary>
        /// <param name="playerData">The player data.</param>
        /// <param name="configSettings">The config settings.</param>
        /// <returns></returns>
        public string CalcSPRatingLocal(BattingData playerData, CardProcessingConfiguration configSettings)
        {
            // normalize player stolen base totals to a full season
            var totalGames = configSettings.Wins + configSettings.Losses;
            decimal seasonFactor = (decimal) totalGames / (decimal) playerData.G;
            var normalizedSB = Convert.ToInt32(seasonFactor * playerData.SB);

            StatisProData statisPro = new StatisProData();
            var spRating = StatisProData.SPRatings.Where(r => r.StolenBases <= normalizedSB)
                .OrderByDescending(r => r.StolenBases)
                .FirstOrDefault();
            return spRating.SP.Trim();
        }
        #endregion

        #region SAC Rating
        /// <summary>
        /// Calcs the SAC rating using a database table.
        /// </summary>
        /// <param name="playerData">The player data.</param>
        /// <param name="configSettings">The config settings.</param>
        /// <returns></returns>
        public string CalcSACRating(BattingData playerData, CardProcessingConfiguration configSettings)
        {
            // normalize sacrifices to a full season
            var totalGames = configSettings.Wins + configSettings.Losses;
            decimal seasonFactor = (decimal) totalGames / (decimal) playerData.G;
            var normalizedSH = Convert.ToInt32(seasonFactor * playerData.SH);

            using (var context = new SQLiteContext())
            {
                var rating = context.SACLookups
                    .Where(sac => sac.SacrificeHits <= normalizedSH)
                    .OrderByDescending(sac => sac.SacrificeHits)
                    .FirstOrDefault();
                return rating.SAC.Trim();
            }
        }

        /// <summary>
        /// Calcs the SAC rating using a local collection that serves as a lookup table.
        /// </summary>
        /// <param name="playerData">The player data.</param>
        /// <param name="configSettings">The config settings.</param>
        /// <returns></returns>
        public string CalcSACRatingLocal(BattingData playerData, CardProcessingConfiguration configSettings)
        {
            // normalize sacrifices to a full season
            var totalGames = configSettings.Wins + configSettings.Losses;
            decimal seasonFactor = (decimal) totalGames / (decimal) playerData.G;
            var normalizedSH = Convert.ToInt32(seasonFactor * playerData.SH);

            StatisProData statisPro = new StatisProData();
            var sacRating = StatisProData.SACRatings.Where(sac => sac.SacrificeHits <= normalizedSH)
                .OrderByDescending(sac => sac.SacrificeHits)
                .FirstOrDefault();
            return sacRating.SAC.Trim();
        }
        #endregion

        #region INJ Rating
        /// <summary>
        /// Calcs the INJ rating.
        /// </summary>
        /// <param name="playerData">The player data.</param>
        /// <returns></returns>
        public string CalcINJRating(BattingData playerData)
        {
            StatisProData statisPro = new StatisProData();
            var injRating = StatisProData.INJRatings.Where(inj => inj.GamesPlayed <= playerData.G)
                .OrderByDescending(inj => inj.GamesPlayed)
                .FirstOrDefault();
            return injRating.INJ.Trim();
        }
        
        #endregion

        #region BD Ratings
        // 2010 Ichiro (Example)
        // 2B(34), 3B(8), HR(8), H(242)
        // EBH(2B + 3B + HR) = 50
        // EBH % (EBH / H) = 0.207
        // # of doubles = Integer[(34 * 64 * 0.207) / 50] = 9
        // # of triples = Integer[(8 * 64 * 0.207) / 50] = 2
        // # of homeruns = Integer[(8 * 64 * 0.207) / 50] = 2
        // Assign the first 9 numbers to 2B (starting at 11), the next 2 for 3Bs, and the next 2 for HRs.
        // For Ichiro's card, the BD ratings would be: 
        // 2B = 11 - 21(11, 12, 13, 14, 15, 16, 17, 18, 21) 9
        // 3B = 22 - 23(22, 23) 2
        // HR = 24 - 25(24, 25) 2
        /// <summary>
        /// Calcs the expanded BD ratings that were introduced in the third edition of Statis-Pro Baseball.
        /// </summary>
        /// <param name="playerData">The player data.</param>
        /// <returns>BDRatings with both ranges and the actual number of 2Bs,3Bs and HR's alloted.</returns>
        public BDRatings CalcBDRatings(BattingData playerData)
        {
            // create rating object
            BDRatings bd = new BDRatings();

            // calculates the extended BD doubles, triples and HR ranges per the third edition of Statis-Pro Baseball
            if (playerData.H > 0)
            {
                // formula is as follows: 
                // 1) calculate total # of extra base hits (add number of doubles + triples + homeruns)
                var ebh = playerData.Doubles + playerData.Triples + playerData.HR;

                // 2) calculate EBH % (extra base hits dived by total hits)
                var ebhPct = Math.Round((decimal) ebh / (decimal) playerData.H, 3);

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

                // set the actual number of each allotted to the card (base 8 numbering system)
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
                    bd.TriplesToCard = triplesToCard.Count() == 1 ? string.Format("{0}", firstTriple.Base8Number.ToString()) :
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
            }
            else
            {
                // player had no hits 
                bd.NumberBD2Bs = 0;
                bd.NumberBD3Bs = 0;
                bd.NumberBDHRs = 0;
                bd.DoublesToCard = string.Empty;
                bd.HomerunsToCard = string.Empty;
                bd.TriplesToCard = string.Empty;
            }

            return bd;
        }

        /// <summary>
        /// Calculates the classic single number BD rating used in the first and second editions.
        /// </summary>
        /// <param name="playerData">The player batting data.</param>
        /// <returns></returns>
        public string CalcClassicBDRating(BattingData playerData)
        {
            if (playerData.HR >= 30) return "2";
            
            if (playerData.HR >= 20) return "1";

            return "0";
        }
        #endregion

        

        #region HR Rating
        /// <summary>
        /// Calculates the hit and run rating based on the number of strikeouts alloted to the batter card.
        /// </summary>
        /// <param name="playerCard">The player card.</param>
        /// <returns></returns>
        public int CalculateHitAndRunRating(BatterCard playerCard)
        {
            // based on the # of strikeouts on the player card
            // TODO: if player card has no strikeout numbers then H&R=2, if 1 then H&R=1 else 0
            return 0;
        }
        #endregion

        #region Cht Rating
        /// <summary>
        /// Calculates the CHT based on better handedness and HR's.
        /// </summary>
        /// <param name="playerData">The player data.</param>
        /// <param name="thePlayerCard">The player card.</param>
        /// <returns></returns>
        public string CalculateCht(BattingData playerData, BatterCard thePlayerCard)
        {
            // account for pitchers
            if (playerData.Pos == "P" || playerData.Pos == "p") return "P";

            // get batting handedness
            var hand = CalculateBattingHand(playerData);

            // if four HR numbers on card OR if the batter hit at least 15 HR's then the classification is "P"ower


            return "T";
        }
        #endregion

        #region CD Rating(s)
        // TODO: create a formula or formulas for calculating CD by position

        //public string CalculateFieldingRatings(string playerName, List<FieldingData> fielderData)
        //{
        //    // get only fielding data for the current player
        //    var currentFieldingData = fielderData.Where(fd => fd.Name.Trim() == playerName).OrderBy(fd => fd.G);

        //    // TODO: handle pitchers
        //    foreach (var pos in currentFieldingData)
        //    {

        //    }
        //}
        #endregion

        #region Placement
        public BatterCardPlacement PlaceHitsOnCard(BattingData playerData)
        {
            // get batter handedness
            string battingHand = CalculateBattingHand(playerData);

            // create evaluation factor (EF=(AB+HBP+BB)/128)
            var evalFactor = Math.Round((decimal) (playerData.AB + playerData.HBP + playerData.BB) / 128, 1);

            // calculate the number of hits of each kind that need to go on the card (# of hit type divided by the eval factor)
            // singles (subtract 11 from the total to account for pitchers)
            var numberOf1B = playerData.H - playerData.Doubles - playerData.Triples - playerData.HR;
            var numberOf1BToCard = Math.Round((decimal) numberOf1B / evalFactor, 1) - 11;

            // doubles/triples/HR
            var numberOf2BToCard = Math.Round((decimal) playerData.Doubles / evalFactor, 1);
            var numberOf3BToCard = Math.Round((decimal) playerData.Triples / evalFactor, 1);
            var numberOfHRToCard = Math.Round((decimal) playerData.HR / evalFactor, 1);

            // walks (subtract 7 from total to account for pitchers)
            var numberOfBBToCard = Math.Round((decimal) playerData.BB / evalFactor, 1) - 7;

            // strikeouts (subtract 11 from total to account for pitchers)
            var numberOfKToCard = Math.Round((decimal) playerData.SO / evalFactor, 1) - 11;

            // adjust number of HR's by one if classic BD rating is 2
            string classicBD = CalcClassicBDRating(playerData);
            if (classicBD == "2")
            {
                numberOfHRToCard = numberOfHRToCard - 1;
            }

            // finalize number hits on card and convert to integers
            var singles = Convert.ToInt32(Math.Round(numberOf1BToCard, 0));
            var doubles = Math.Round(numberOf2BToCard, 0);
            var triples = Math.Round(numberOf3BToCard, 0);
            var hr = Math.Round(numberOfHRToCard, 0);
            var bb = Math.Round(numberOfBBToCard, 0);
            var k = Math.Round(numberOfKToCard, 0);

            // create ranges
            var possibleIBFs = GetNumberOfIBFs(playerData, singles);
            var nonIBFSingles = singles - possibleIBFs;

            if (singles >= 6)
            {
                // TODO: how to determine L,R,S distribution
                // FORMULA FOR IBF's = If 20 or more SB's then possibly 2, if ten or more then 1, otherwise 0
            }
            else
            {
                // divide singles
            }

            BatterCardPlacement cardTable = new BatterCardPlacement();
            return cardTable;
        }
        #endregion
    }
}