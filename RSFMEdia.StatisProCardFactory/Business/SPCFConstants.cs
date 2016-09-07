using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RSFMEdia.StatisProCardFactory.Business
{
    public class SPCFConstants
    {
        public static readonly string SPCF_MASTER_DIRECTORY = @"C:\StatisProCardFactory\";
        public static readonly string SPCF_OUTPUT_DIRECTORY = @"C:\StatisProCardFactory\cards\";
        public static readonly string SPCF_CSV_DIRECTORY = @"C:\StatisProCardFactory\csv\";
        public static readonly string SPCF_DB_DIRECTORY = @"C:\StatisProCardFactory\db\";
        public static readonly string SPCF_CSV_NAMING_BATTING = "{0}-{1}-{2}-batting-data.csv";
        public static readonly string SPCF_CSV_NAMING_PITCHING = "{0}-{1}-{2}-pitching-data.csv";
        public static readonly string SPCF_CSV_NAMING_FIELDING = "{0}-{1}-{2}-fielding-data.csv";
        public static readonly string SPCF_CSV_NAMING_PBDATA = "{0}-{1}-pb-data.csv";
        public static readonly string SPCF_OUTPUT_NAMING_BATTER = "{0}-{1}-{2}-batter-output.pdf";

        // OBR rating
        public static readonly string OBR_RATING_A = "A";
        public static readonly string OBR_RATING_B = "B";
        public static readonly string OBR_RATING_C = "C";
        public static readonly string OBR_RATING_D = "D";
        public static readonly string OBR_RATING_E = "E";

        
    }
}