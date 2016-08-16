using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RSFMEdia.StatisProCardFactory.Business
{
    public class SPCFConstants
    {
        public static readonly string SPCF_MASTER_DIRECTORY = @"C:\StatisProCardFactory\";
        public static readonly string SPCF_OUTPUT_DIRECTORY = @"C:\StatisProCardFactory\Cards\";
        public static readonly string SPCF_CSV_DIRECTORY = @"C:\StatisProCardFactory\csv\";
        public static readonly string SPCF_CSV_NAMING_BATTERS = "{0}-{1}-batter-data.csv";
        public static readonly string SPCF_CSV_NAMING_PITCHERS = "{0}-{1}-pitcher-data.csv";
        public static readonly string SPCF_CSV_NAMING_FIELDERS = "{0}-{1}-fielding-data.csv";
    }
}