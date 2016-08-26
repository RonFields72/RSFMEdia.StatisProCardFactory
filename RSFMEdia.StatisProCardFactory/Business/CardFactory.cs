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
            public BatterCardAnalysis CreateBatterCards(List<BattingData> batterData, CardProcessingConfiguration configSettings)
        {
            // init process statistics
            var process = new BatterCardAnalysis();
            process.Start = DateTime.Now;

            // process each batter
            foreach (var batter in batterData)
            {
                // create a new player card
                PlayerCard newBatterCard = new PlayerCard();
                FormulaFactory formulas = new FormulaFactory();

                // set statistics
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


                // BD Ratings
                newBatterCard.BDRating = formulas.CalculateClassicBDRating(batter);
                var expandedBD = formulas.CalculateBDRatings(batter);



                //newBatterCard.Cht = 
            }

            // end the process
            process.End = DateTime.Now;

            // return the analysis
            return process;
        }
    }
}