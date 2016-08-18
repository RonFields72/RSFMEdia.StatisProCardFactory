﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RSFMEdia.StatisProCardFactory.Business;
using FileHelpers;
using RSFMEdia.StatisProCardFactory.Models;

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
                        var batter = batters.FirstOrDefault(b => b.Rank == "6");
                        lblTestDisplay1.Text = batter.Name;
                    }

                    // process pitching upload
                    if (fuPitching.HasFile)
                    {
                        // generate a file name
                        var pitchingFilename = string.Format(SPCFConstants.SPCF_CSV_NAMING_PITCHING, ddlYear.SelectedValue, ddlTeam.SelectedValue, ddlLeague.SelectedValue);
                        var pitchingFullPath = SPCFConstants.SPCF_CSV_DIRECTORY + pitchingFilename;

                        // rename file and save it to the server
                        fuBatting.SaveAs(pitchingFullPath);
                    }

                    // process fielding upload
                    if (fuFielding.HasFile)
                    {
                        // generate a file name
                        var fieldingFilename = string.Format(SPCFConstants.SPCF_CSV_NAMING_FIELDING, ddlYear.SelectedValue, ddlTeam.SelectedValue, ddlLeague.SelectedValue);
                        var fieldingFullPath = SPCFConstants.SPCF_CSV_DIRECTORY + fieldingFilename;

                        // rename file and save it to the server
                        fuBatting.SaveAs(fieldingFullPath);
                    }
                }
                catch (Exception why)
                {
                    litMessage.Text = MarkupFactory.BuildBootstrapAlertWarning(string.Format("** Error uploading data: {0} **", why.Message));
                }
            }
        }
        #endregion
    }
}