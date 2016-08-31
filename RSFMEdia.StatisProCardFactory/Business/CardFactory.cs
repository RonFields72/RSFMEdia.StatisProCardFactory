using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RSFMEdia.StatisProCardFactory.Models;

namespace RSFMEdia.StatisProCardFactory.Business
{
    public class CardFactory
    {
        #region Properties
        private CardProcessingConfiguration configSettings;
        #endregion

        #region Constructors
        public CardFactory(CardProcessingConfiguration configurationSettings)
        {
            this.configSettings = configurationSettings;
        }
        #endregion

        // TODO: public BatterCardAnalysis CreateBatterCards(List<BattingData> batterData, List<FieldingData> fielderData)
        public CardAnalysis CreateBatterCards(List<BattingData> batterData)
        {
            // init process statistics
            var process = new CardAnalysis();
            process.Start = DateTime.Now;

            // create card collection
            var batterCards = new List<BatterCard>();

            // process each batter and load the player card collection to be printed
            foreach (var batter in batterData)
            {
                // create a new player card
                BatterCard newBatterCard = new BatterCard();
                FormulaFactory formulas = new FormulaFactory();

                // set statistics (placed at bottom of the card)
                newBatterCard.InfoAtBats = batter.AB.ToString();
                newBatterCard.InfoHits = batter.H.ToString();
                newBatterCard.InfoDoubles = batter.Doubles.ToString();
                newBatterCard.InfoTriples = batter.Triples.ToString();
                newBatterCard.InfoHomeruns = batter.HR.ToString();
                newBatterCard.InfoStolenBases = batter.SB.ToString();
                newBatterCard.InfoWalks = batter.BB.ToString();
                newBatterCard.InfoRBI = batter.RBI.ToString();
                newBatterCard.InfoRuns = batter.R.ToString();
                newBatterCard.InfoAVG = batter.BA.ToString();
                newBatterCard.InfoOPS = batter.OPS.ToString();
                newBatterCard.InfoSLG = batter.SLG.ToString();

                // attributes
                newBatterCard.Name = formulas.ParsePlayerName(batter.Name);
                newBatterCard.Age = Math.Round(batter.Age, 0).ToString();
                newBatterCard.Team = configSettings.TeamName.Trim();
                newBatterCard.League = configSettings.League;
                newBatterCard.Year = configSettings.Year;

                // fielding positions and ratings
                // newBatterCard.Fielding = 

                // special remarks
                newBatterCard.Remarks = formulas.CalcRemarks(batter, configSettings);

                // OBR rating
                newBatterCard.OBR = formulas.CalcOBR(batter);

                // SP rating
                newBatterCard.SP = formulas.CalcSPRatingLocal(batter, configSettings);

                // SAC rating 
                newBatterCard.SAC = formulas.CalcSACRatingLocal(batter, configSettings);

                // INJ rating
                newBatterCard.Inj = formulas.CalcINJRating(batter);

                // BD Ratings
                newBatterCard.BDRating = formulas.CalcClassicBDRating(batter, this.configSettings);
                var expandedBDRatings = formulas.CalcBDRatings(batter);
                newBatterCard.BDDouble = expandedBDRatings.DoublesToCard;
                newBatterCard.BDTriple = expandedBDRatings.TriplesToCard;
                newBatterCard.BDHomerun = expandedBDRatings.HomerunsToCard;
                newBatterCard.NumberBD2B = expandedBDRatings.NumberBD2Bs;
                newBatterCard.NumberBD3B = expandedBDRatings.NumberBD3Bs;
                newBatterCard.NumberBDHR = expandedBDRatings.NumberBDHRs;

                // placement of hits,outs, etc. on card
                var placement = formulas.PlaceHitsOnCard(batter, this.configSettings);
                newBatterCard.Single1BF = placement.Single1BF;
                newBatterCard.Single1B7 = placement.Single1B7;
                newBatterCard.Single1B8 = placement.Single1B8;
                newBatterCard.Single1B9 = placement.Single1B9;
                newBatterCard.Double2B7 = placement.Double2B7;
                newBatterCard.Double2B8 = placement.Double2B8;
                newBatterCard.Double2B9 = placement.Double2B9;
                newBatterCard.Triple3B8 = placement.Triple3B8;
                newBatterCard.HR = placement.HR;
                newBatterCard.W = placement.W;
                newBatterCard.K = placement.K;
                newBatterCard.HBP = placement.HBP;
                newBatterCard.Out = placement.Out;

                // Cht
                newBatterCard.Cht = formulas.CalculateCht(batter, placement.NumberHR, this.configSettings);

                // H&R
                newBatterCard.HandR = formulas.CalculateHitAndRunRating(placement.NumberK); 

                // count the batter card
                process.NumberOfCardsCreated += 1;
                batterCards.Add(newBatterCard);
            }

            // produce PDF version of the cards
            PrintCards(batterCards, this.configSettings);
            
                        
            // return the analysis
            process.End = DateTime.Now;
            return process;
        }

        public void CreatePitcherCards()
        {

        }

        private void PrintCards(List<BatterCard> batterCards, CardProcessingConfiguration configSettings)
        {
            
        }
    }
}