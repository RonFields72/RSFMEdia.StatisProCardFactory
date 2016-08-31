using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RSFMEdia.StatisProCardFactory.Models;

namespace RSFMEdia.StatisProCardFactory.Business
{
    public class CardFactory
    {
        //public BatterCardAnalysis CreateBatterCards(List<BattingData> batterData, List<FieldingData> fielderData, CardProcessingConfiguration configSettings)
            public CardAnalysis CreateBatterCards(List<BattingData> batterData, CardProcessingConfiguration configSettings)
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

                // positions and ratings
                // newBatterCard.Fielding = 

                // OBR rating
                newBatterCard.OBR = formulas.CalcOBR(batter);

                // SP rating
                newBatterCard.SP = formulas.CalcSPRatingLocal(batter, configSettings);

                // SAC rating 
                newBatterCard.SAC = formulas.CalcSACRatingLocal(batter, configSettings);

                // INJ rating
                newBatterCard.Inj = formulas.CalcINJRating(batter);

                // BD Ratings
                newBatterCard.BDRating = formulas.CalcClassicBDRating(batter);
                var expandedBD = formulas.CalcBDRatings(batter);
                newBatterCard.BDDouble = expandedBD.DoublesToCard;
                newBatterCard.BDTriple = expandedBD.TriplesToCard;
                newBatterCard.BDHomerun = expandedBD.HomerunsToCard;
                newBatterCard.NumberBD2B = expandedBD.NumberBD2Bs;
                newBatterCard.NumberBD3B = expandedBD.NumberBD3Bs;
                newBatterCard.NumberBDHR = expandedBD.NumberBDHRs;

                // placement of hits,outs, etc. on card
                var placement = formulas.PlaceHitsOnCard(batter);

                // the Cht and H&R ratings use the numbers allotted to the card so must be calculated after the card numbers are assigned 
                // Cht
                //newBatterCard.Cht = 
                
                // H&R
                //newBatterCard.HandR = 

                // count the batter card
                process.NumberOfCardsCreated += 1;
                batterCards.Add(newBatterCard);
            }

            // produce PDF version of the cards
            PrintCards(batterCards, configSettings);
            
                        
            // return the analysis
            process.End = DateTime.Now;
            return process;
        }

        private void PrintCards(List<BatterCard> batterCards, CardProcessingConfiguration configSettings)
        {
            
        }
    }
}