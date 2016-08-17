using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RSFMEdia.StatisProCardFactory.Business;

namespace RSFMEdia.StatisProCardFactory
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                // clear status messages
                ClearMessages();

                // create application directories
                var fileHelper = new FileHelper();
                fileHelper.CreateDirectory(SPCFConstants.SPCF_MASTER_DIRECTORY);
                fileHelper.CreateDirectory(SPCFConstants.SPCF_OUTPUT_DIRECTORY);
                fileHelper.CreateDirectory(SPCFConstants.SPCF_CSV_DIRECTORY);

                // load the page
                LoadPage();
            }
        }

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
            if (!fuBatting.HasFiles || !fuPitching.HasFiles || !fuFielding.HasFiles)
            {
                // display error to user
                litMessage.Text = BootstrapGenerator.BuildBootstrapAlertWarning("** All three .csv files are required in order to generate player/pitcher cards. **");
            }
            else
            {
                // TODO: make sure the file is a .csv
                // process uploads
            }
        }
        #endregion
    }
}