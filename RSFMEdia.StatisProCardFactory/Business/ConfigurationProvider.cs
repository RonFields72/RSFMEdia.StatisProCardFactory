using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace RSFMEdia.StatisProCardFactory.Business
{
    public class ConfigurationProvider
    {
        public static string LoadConfigurationValue(string configurationName)
        {
            string configString = WebConfigurationManager.AppSettings[configurationName];

            if (!string.IsNullOrEmpty(configString))
            {
                return configString;
            }
            else
            {
                return string.Empty;
            }
        }

        public static string LoadConnectionString(string connectionStringName)
        {
            string connectionString = WebConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString.ToString();
            if (!string.IsNullOrEmpty(connectionString))
            {
                return connectionString;
            }
            else
            {
                return string.Empty;
            }
        }
    }
}