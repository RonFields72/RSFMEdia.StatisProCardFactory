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

        private void LoadPage()
        {
            // load teams
            var teamData = new MLBData();
            ddlTeam.DataSource = teamData.Teams;
            ddlTeam.DataTextField = "Name";
            ddlTeam.DataValueField = "Abbreviation";
            ddlTeam.DataBind();

            // load seasons
            var seasons = Convert.ToInt32(ConfigurationProvider.LoadConfigurationValue("numberOfHistoricSeasons").ToString());
            ddlYear.Items.Clear();
            var currentYear = DateTime.Today.Year;
            for (int i = 0; i <= seasons; i++)
            {
                ddlYear.Items.Add((currentYear - i).ToString());
            }
        }

        private void ClearMessages()
        {
            
        }
    }
}