using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FileHelpers;
using RSFMEdia.StatisProCardFactory.Business;
using RSFMEdia.StatisProCardFactory.DataLayer;
using RSFMEdia.StatisProCardFactory.Models;

namespace RSFMEdia.StatisProCardFactory
{
    public partial class Index : System.Web.UI.Page
    {
        #region Properties
        public string ErrorMessage
        {
            get { return ViewState["ErrorMessage"].ToString(); }
            set { ViewState["ErrorMessage"] = value; }
        }
        #endregion

        #region Page Events
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                // clear status messages
                ClearMessages();

                // load the page
                LoadPage();
            }
        }
        #endregion

        #region Private Methods
        private void LoadPage()
        {
            LoadTeams();
            LoadSeasons();

            // set config defaults
            tbMinimumAB.Text = "1";
            tbMinimumIP.Text = "1";
        }

        private void LoadSeasons()
        {
            // load seasons
            ddlYear.Items.Clear();
            var seasons = Convert.ToInt32(ConfigurationProvider.LoadConfigurationValue("numberOfHistoricSeasons").ToString());
            var currentYear = DateTime.Today.Year;
            for (int i = 0; i <= seasons; i++)
            {
                ddlYear.Items.Add((currentYear - i).ToString());
            }
        }

        private void LoadTeams()
        {
            // load teams
            ddlTeam.Items.Clear();
            var teamData = new MLBData();
            ddlTeam.DataSource = teamData.Teams;
            ddlTeam.DataTextField = "Name";
            ddlTeam.DataValueField = "Abbreviation";
            ddlTeam.DataBind();
        }

        private void ClearMessages()
        {
            litMessage.Text = string.Empty;
        }

        private void ResetInputs()
        {
            LoadSeasons();
            LoadTeams();
            tbLosses.Text = string.Empty;
            tbWins.Text = string.Empty;
            tbManager.Text = string.Empty;
            fuBatting.Dispose();
            fuPitching.Dispose();
            fuFielding.Dispose();
        }
        #endregion

        #region Control Events
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            // verify that input was complete/correct
            if (!InputIsValid())
            {
                // display error to user
                litMessage.Text = MarkupFactory.BuildBootstrapAlertWarning(string.Format("** Error processing uploaded files: {0} **", ErrorMessage));
            }
            else
            {
                try
                {
                    // load processing info
                    var processingData = new CardProcessingConfiguration();
                    processingData.League = ddlLeague.SelectedValue;
                    processingData.Year = ddlYear.SelectedValue;
                    processingData.TeamName = ddlTeam.SelectedItem.ToString();
                    processingData.TeamAbbrev = ddlTeam.SelectedValue;
                    processingData.Manager = tbManager.Text.Trim();
                    processingData.Wins = Convert.ToInt32(tbWins.Text);
                    processingData.Losses = Convert.ToInt32(tbLosses.Text);
                    processingData.UseTZ = cbUseTZ.Checked ? true : false;
                    processingData.UseUBR = cbUseUBR.Checked ? true : false;
                    processingData.UseUZR = cbUseUZR.Checked ? true : false;
                    processingData.MinimumAB = !string.IsNullOrEmpty(tbMinimumAB.Text) ? Convert.ToInt32(tbMinimumAB.Text) : 1;
                    processingData.MinimumIP = !string.IsNullOrEmpty(tbMinimumIP.Text) ? Convert.ToInt32(tbMinimumIP.Text) : 1;


                    // process batting upload
                    if (fuBatting.HasFile)
                    {
                        // generate a file name
                        var battingFilename = string.Format(SPCFConstants.SPCF_CSV_NAMING_BATTING, ddlYear.SelectedValue, ddlTeam.SelectedValue, ddlLeague.SelectedValue);
                        var battingFullPath = SPCFConstants.SPCF_CSV_DIRECTORY + battingFilename;

                        // rename file and save it to the server
                        fuBatting.SaveAs(battingFullPath);
                        
                        // read the batter data into the collection
                        var csvEngine = new FileHelperEngine<BattingData>();
                        var batters = csvEngine.ReadFileAsList(battingFullPath);

                        // TEST:read the batting data
                        var batter = batters.FirstOrDefault(b => b.Age >= 25);
                        lblTestDisplay1.Text = string.Format("Test random batter: {0}", batter.Name);

                        // process the batting data and create player cards
                        CardFactory card = new CardFactory(processingData);
                        var analysis = card.CreateBatterCards(batters);

                        // display process report
                        var analysisReport = string.Format("Process started at {0} and ended at {1}. {2} batter cards were created and {3} batter cards were skipped. **",
                            analysis.Start.ToShortDateString(), analysis.End.ToShortDateString(), analysis.NumberOfBatterCardsCreated.ToString(), analysis.NumberOfBatterCardsSkipped.ToString());
                        litMessage.Text = MarkupFactory.BuildBootstrapAlertSuccess(analysisReport);
                    }

                    // process pitching upload
                    if (fuPitching.HasFile)
                    {
                        // generate a file name
                        var pitchingFilename = string.Format(SPCFConstants.SPCF_CSV_NAMING_PITCHING, ddlYear.SelectedValue, ddlTeam.SelectedValue, ddlLeague.SelectedValue);
                        var pitchingFullPath = SPCFConstants.SPCF_CSV_DIRECTORY + pitchingFilename;

                        // rename file and save it to the server
                        fuPitching.SaveAs(pitchingFullPath);

                        // TEST:read the pitching data
                        var csvEngine = new FileHelperEngine<PitchingData>();
                        var pitchers = csvEngine.ReadFileAsList(pitchingFullPath);
                        var pitcher = pitchers.FirstOrDefault(b => b.Age >= 31);
                        lblTestDisplay2.Text = string.Format("Test random pitcher: {0}", pitcher.Name);
                    }

                    // process fielding upload
                    // TODO: process the fielding file with the batting file
                    if (fuFielding.HasFile)
                    {
                        // generate a file name
                        var fieldingFilename = string.Format(SPCFConstants.SPCF_CSV_NAMING_FIELDING, ddlYear.SelectedValue, ddlTeam.SelectedValue, ddlLeague.SelectedValue);
                        var fieldingFullPath = SPCFConstants.SPCF_CSV_DIRECTORY + fieldingFilename;

                        // rename file and save it to the server
                        fuFielding.SaveAs(fieldingFullPath);

                        // TEST:read the fielding data
                        var csvEngine = new FileHelperEngine<FieldingData>();
                        var fielders = csvEngine.ReadFileAsList(fieldingFullPath);
                        var fielder = fielders.FirstOrDefault(b => b.Name.Contains("Tony"));
                        lblTestDisplay3.Text = string.Format("Test random fielder: {0}", fielder.Name);
                    }
                }
                catch (Exception why)
                {
                    litMessage.Text = MarkupFactory.BuildBootstrapAlertWarning(string.Format("** Error uploading data: {0} **", why.Message));
                }
            }
        }

        private bool InputIsValid()
        {
            // TODO: don't forget to check for all three files
            //if (!fuBatting.HasFiles || !fuPitching.HasFiles || !fuFielding.HasFiles)
            if (!fuBatting.HasFiles)
            {
                ErrorMessage = "** All three .csv files are required in order to generate player/pitcher cards. **";
                return false;
            }
            return true;
        }
        #endregion

        protected void btnTest_Click(object sender, EventArgs e)
        {
            // test data pull using LINQ and  
            string testERA = string.Empty;
            using (var context = new SQLiteContext())
            {
                var stuff = context.PBLookups;
                foreach (var range in stuff)
                {
                    testERA += range.HighestERA.ToString();
                }
            }
            lblTestDisplay4.Text = testERA.Trim();
        }
    }
}