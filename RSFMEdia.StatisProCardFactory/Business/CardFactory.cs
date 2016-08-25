using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RSFMEdia.StatisProCardFactory.Models;

namespace RSFMEdia.StatisProCardFactory.Business
{
    public class CardFactory
    {
        public BatterCardAnalysis CreateBatterCards(List<BattingData> batterData, CardProcessingConfiguration configSettings)
        {
            // init process statistics

            // process each batter
            foreach (var batter in batterData)
            {
                // create a new player card
                PlayerCard newBatterCard = new PlayerCard();
                FormulaFactory formulas = new FormulaFactory();

                // set static properties
                // bats
                newBatterCard.InfoAtBats = batter.AtBats.ToString();
                newBatterCard.InfoAVG = batter.BattingAVG.ToString();
                newBatterCard.InfoDoubles = batter.Doubles.ToString();


                newBatterCard.Cht = 
            }
        }
    }
}