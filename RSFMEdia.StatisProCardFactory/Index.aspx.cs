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
            // verify that files were uploaded
            // TODO: don't forget to check for all three files
            //if (!fuBatting.HasFiles || !fuPitching.HasFiles || !fuFielding.HasFiles)
            if (!fuBatting.HasFiles)
            {
                // display error to user
                litMessage.Text = MarkupFactory.BuildBootstrapAlertWarning("** All three .csv files are required in order to generate player/pitcher cards. **");
            }
            else
            {
                try
                {
                    // process batting upload
                    if (fuBatting.HasFile)
                    {
                        // generate a file name
                        var battingFilename = string.Format(SPCFConstants.SPCF_CSV_NAMING_BATTING, ddlYear.SelectedValue, ddlTeam.SelectedValue, ddlLeague.SelectedValue);
                        var battingFullPath = SPCFConstants.SPCF_CSV_DIRECTORY + battingFilename;

                        // rename file and save it to the server
                        fuBatting.SaveAs(battingFullPath);

                        // read the batting data
                        var csvEngine = new FileHelperEngine<BattingData>();
                        var batters = csvEngine.ReadFileAsList(battingFullPath);
                        var batter = batters.FirstOrDefault(b => b.Age >= 25);
                        lblTestDisplay1.Text = string.Format("Test random batter: {0}", batter.Name);

                        // process the batting data and create player cards
                        
                    }

                    // process pitching upload
                    if (fuPitching.HasFile)
                    {
                        // generate a file name
                        var pitchingFilename = string.Format(SPCFConstants.SPCF_CSV_NAMING_PITCHING, ddlYear.SelectedValue, ddlTeam.SelectedValue, ddlLeague.SelectedValue);
                        var pitchingFullPath = SPCFConstants.SPCF_CSV_DIRECTORY + pitchingFilename;

                        // rename file and save it to the server
                        fuPitching.SaveAs(pitchingFullPath);

                        // read the pitching data
                        var csvEngine = new FileHelperEngine<PitchingData>();
                        var pitchers = csvEngine.ReadFileAsList(pitchingFullPath);
                        var pitcher = pitchers.FirstOrDefault(b => b.Age >= 31);
                        lblTestDisplay2.Text = string.Format("Test random pitcher: {0}", pitcher.Name);
                    }

                    // process fielding upload
                    if (fuFielding.HasFile)
                    {
                        // generate a file name
                        var fieldingFilename = string.Format(SPCFConstants.SPCF_CSV_NAMING_FIELDING, ddlYear.SelectedValue, ddlTeam.SelectedValue, ddlLeague.SelectedValue);
                        var fieldingFullPath = SPCFConstants.SPCF_CSV_DIRECTORY + fieldingFilename;

                        // rename file and save it to the server
                        fuFielding.SaveAs(fieldingFullPath);

                        // read the fielding data
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