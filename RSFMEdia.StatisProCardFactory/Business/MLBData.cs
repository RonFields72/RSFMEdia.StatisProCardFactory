using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RSFMEdia.StatisProCardFactory.Models;

namespace RSFMEdia.StatisProCardFactory.Business
{
    public class MLBData
    {
        
        public List<MLBTeam> Teams = new List<MLBTeam>()
        {
            new MLBTeam {Name="Arizona Diamondbacks", Abbreviation="ARI", ShortName="Diamondbacks"},
            new MLBTeam {Name="Atlanta Braves", Abbreviation="ATL", ShortName="Braves"},
            new MLBTeam {Name="Baltimore Orioles", Abbreviation="BAL", ShortName="Orioles"},
            new MLBTeam {Name="Boston Red Sox", Abbreviation="BOS", ShortName="Red Sox"},
            new MLBTeam {Name="Chicago Cubs", Abbreviation="CHC", ShortName="Cubs"},
            new MLBTeam {Name="Chicago White Sox", Abbreviation="CWS", ShortName="White Sox"},
            new MLBTeam {Name="Cincinnati Reds", Abbreviation="CIN", ShortName="Reds"},
            new MLBTeam {Name="Cleveland Indians", Abbreviation="CLE", ShortName="Indians"},
            new MLBTeam {Name="Colorado Rockies", Abbreviation="COL", ShortName="Rockies"},
            new MLBTeam {Name="Detroit Tigers", Abbreviation="DET", ShortName="Tigers"},
            new MLBTeam {Name="Houston Astros", Abbreviation="HOU", ShortName="Astros"},
            new MLBTeam {Name="Kansas City Royals", Abbreviation="KCR", ShortName="Royals"},
            new MLBTeam {Name="Los Angeles Angels", Abbreviation="LAA", ShortName="Angels"},
            new MLBTeam {Name="Los Angeles Dodgers", Abbreviation="LAD", ShortName="Dodgers"},
            new MLBTeam {Name="Miami Marlins", Abbreviation="MIA", ShortName="Marlins"},
            new MLBTeam {Name="Milwaukee Brewers", Abbreviation="MIL", ShortName="Brewers"},
            new MLBTeam {Name="Minnesota Twins", Abbreviation="MIN", ShortName="Diamondbacks"},
            new MLBTeam {Name="New York Mets", Abbreviation="NYM", ShortName="Mets"},
            new MLBTeam {Name="New York Yankees", Abbreviation="NYY", ShortName="Yankees"},
            new MLBTeam {Name="Oakland Athletics", Abbreviation="OAK", ShortName="Athletics"},
            new MLBTeam {Name="Philadelphia Phillies", Abbreviation="PHI", ShortName="Phillies"},
            new MLBTeam {Name="Pittsburgh Pirates", Abbreviation="PIT", ShortName="Pirates"},
            new MLBTeam {Name="San Diego Padres", Abbreviation="SDP", ShortName="Padres"},
            new MLBTeam {Name="San Francisco Giants", Abbreviation="SFG", ShortName="Giants"},
            new MLBTeam {Name="Seattle Mariners", Abbreviation="SEA", ShortName="Mariners"},
            new MLBTeam {Name="St. Louis Cardinals", Abbreviation="STL", ShortName="Cardinals"},
            new MLBTeam {Name="Tampa Bay Rays", Abbreviation="TBR", ShortName="Rays"},
            new MLBTeam {Name="Texas Rangers", Abbreviation="TEX", ShortName="Rangers"},
            new MLBTeam {Name="Toronto Blue Jays", Abbreviation="TOR", ShortName="Blue Jays"},
            new MLBTeam {Name="Washington Nationals", Abbreviation="WSN", ShortName="Nationals"}
        };

        public List<MLBTeam> ClassicTeams = new List<MLBTeam>()
        {
            new MLBTeam {Name="Boston Braves", Abbreviation="BOB", ShortName="Braves"},
            new MLBTeam {Name="Brooklyn Dodgers", Abbreviation="BKN", ShortName="Dodgers"},
            new MLBTeam {Name="Florida Marlins", Abbreviation="FLA", ShortName="Marlins"},
            new MLBTeam {Name="Kansas City Athletics", Abbreviation="KCA", ShortName="Athletics"},
            new MLBTeam {Name="Milwaukee Braves", Abbreviation="MIB", ShortName="Braves"},
            new MLBTeam {Name="Montreal Expos", Abbreviation="MON", ShortName="Expos"},
            new MLBTeam {Name="New York Giants", Abbreviation="NYG", ShortName="Giants"},
            new MLBTeam {Name="Seattle Pilots", Abbreviation="SEP", ShortName="Pilots"},
            new MLBTeam {Name="St. Louis Browns", Abbreviation="STB", ShortName="Browns"},
            new MLBTeam {Name="Washington Senators", Abbreviation="WSS", ShortName="Senators"}
        };


        #region Constructors
        public MLBData()
        {
               
        }
        #endregion

        public string FindPositionAbbreviation(int positionNumber)
        {
            string position = string.Empty;

            // return position abbreviation based on scoring numeral
            switch (positionNumber)
            {
                case 1:
                    position = "P";
                    break;
                case 2:
                    position = "C";
                    break;
                case 3:
                    position = "1B";
                    break;
                case 4:
                    position = "2B";
                    break;
                case 5:
                    position = "3B";
                    break;
                case 6:
                    position = "SS";
                    break;
                case 7:
                    position = "LF";
                    break;
                case 8:
                    position = "CF";
                    break;
                case 9:
                    position = "RF";
                    break;
            }
            return position;
        }

        public string FindPositionDescription(string positionAbbreviation)
        {
            string position = string.Empty;

            // return position abbreviation based on scoring numeral
            switch (positionAbbreviation)
            {
                case "P":
                    position = "Pitcher";
                    break;
                case "C":
                    position = "Catcher";
                    break;
                case "1B":
                    position = "First Base";
                    break;
                case "2B":
                    position = "Second Base";
                    break;
                case "3B":
                    position = "Third Base";
                    break;
                case "SS":
                    position = "Shortstop";
                    break;
                case "LF":
                    position = "Left Field";
                    break;
                case "CF":
                    position = "Center Field";
                    break;
                case "RF":
                    position = "Right Field";
                    break;
                case "DH":
                    position = "Designated Hitter";
                    break;
            }
            return position;
        }
    }
}