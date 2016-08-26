using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SQLite;
using System.Data;
using RSFMEdia.StatisProCardFactory.Business;

namespace RSFMEdia.StatisProCardFactory.DataLayer
{
    /// <summary>
    /// SQLite Database helper class. Adapted from a great article at Dream.In.Code by brennydoogles.
    /// </summary>
    public class SQLiteDb
    {
        string dbConnection;
        string dbPath;
        string dbSkinnyConnection;

        #region Constructors
        /// <summary>
        /// Default Constructor for SQLiteDb Class.
        /// </summary>
        public SQLiteDb()
        {
            dbConnection = string.Format("Data Source={0}{1}; Version=3;", SPCFConstants.SPCF_DB_DIRECTORY, "SPCFData.sqlite");
            dbPath = string.Format("{0}{1}", SPCFConstants.SPCF_DB_DIRECTORY, "SPCFData.sqlite");
            dbSkinnyConnection = string.Format("Data Source={0}{1};", SPCFConstants.SPCF_DB_DIRECTORY, "SPCFData.sqlite");
        }

        /// <summary>
        /// Single param constructor for specifying the DB file.
        /// </summary>
        /// <param name="inputFile">The File containing the DB</param>
        public SQLiteDb(String inputFile)
        {
            dbConnection = String.Format("Data Source={0}", inputFile);
        }

        /// <summary>
        /// Single Param Constructor for specifying advanced connection string options.
        /// </summary>
        /// <param name="connectionOpts">A dictionary containing all desired options and their values</param>
        public SQLiteDb(Dictionary<String, String> connectionOpts)
        {
            String str = "";
            foreach (KeyValuePair<String, String> row in connectionOpts)
            {
                str += String.Format("{0}={1}; ", row.Key, row.Value);
            }
            str = str.Trim().Substring(0, str.Length - 1);
            dbConnection = str;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Run a query against the Database.
        /// </summary>
        /// <param name="sql">The SQL to run</param>
        /// <returns>A DataTable containing the result set.</returns>
        public DataTable GetDataTable(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                SQLiteConnection cnn = new SQLiteConnection(dbConnection);
                cnn.Open();
                SQLiteCommand mycommand = new SQLiteCommand(cnn);
                mycommand.CommandText = sql;
                SQLiteDataReader reader = mycommand.ExecuteReader();
                dt.Load(reader);
                reader.Close();
                cnn.Close();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return dt;
        }

        /// <summary>
        /// Interact with the database for purposes other than a query.
        /// </summary>
        /// <param name="sql">The SQL to be run.</param>
        /// <returns>An Integer containing the number of rows updated.</returns>
        public int ExecuteNonQuery(string sql)
        {
            SQLiteConnection cnn = new SQLiteConnection(dbConnection);
            cnn.Open();
            SQLiteCommand mycommand = new SQLiteCommand(cnn);
            mycommand.CommandText = sql;
            int rowsUpdated = mycommand.ExecuteNonQuery();
            cnn.Close();
            return rowsUpdated;
        }

        /// <summary>
        /// Retrieve single items from the DB.
        /// </summary>
        /// <param name="sql">The query to run.</param>
        /// <returns>A string.</returns>
        public string ExecuteScalar(string sql)
        {
            SQLiteConnection cnn = new SQLiteConnection(dbConnection);
            cnn.Open();
            SQLiteCommand mycommand = new SQLiteCommand(cnn);
            mycommand.CommandText = sql;
            object value = mycommand.ExecuteScalar();
            cnn.Close();
            if (value != null)
            {
                return value.ToString();
            }
            return "";
        }

        /// <summary>
        /// Update rows in the DB.
        /// </summary>
        /// <param name="tableName">The table to update.</param>
        /// <param name="data">A dictionary containing column names and their new values.</param>
        /// <param name="where">The where clause for the update statement.</param>
        /// <returns>A boolean true or false to signify success or failure.</returns>
        public bool Update(String tableName, Dictionary<String, String> data, String where)
        {
            String vals = "";
            Boolean returnCode = true;
            if (data.Count >= 1)
            {
                foreach (KeyValuePair<String, String> val in data)
                {
                    vals += String.Format(" {0} = '{1}',", val.Key.ToString(), val.Value.ToString());
                }
                vals = vals.Substring(0, vals.Length - 1);
            }
            try
            {
                this.ExecuteNonQuery(String.Format("UPDATE {0} SET {1} WHERE {2};", tableName, vals, where));
            }
            catch
            {
                returnCode = false;
            }
            return returnCode;
        }

        /// <summary>
        /// Delete rows from the DB.
        /// </summary>
        /// <param name="tableName">The table from which to delete.</param>
        /// <param name="where">The where clause for the delete.</param>
        /// <returns>A boolean true or false to signify success or failure.</returns>
        public bool Delete(String tableName, String where)
        {
            bool returnCode = true;
            try
            {
                this.ExecuteNonQuery(String.Format("DELETE FROM {0} WHERE {1};", tableName, where));
            }
            catch
            {
                returnCode = false;
            }
            return returnCode;
        }

        /// <summary>
        /// Insert into the DB.
        /// </summary>
        /// <param name="tableName">The table into which to insert the data.</param>
        /// <param name="data">A dictionary containing the column names and data for the insert.</param>
        /// <returns>A boolean true or false to signify success or failure.</returns>
        public bool Insert(String tableName, Dictionary<String, String> data)
        {
            String columns = "";
            String values = "";
            Boolean returnCode = true;
            foreach (KeyValuePair<String, String> val in data)
            {
                columns += String.Format(" {0},", val.Key.ToString());
                values += String.Format(" '{0}',", val.Value);
            }
            columns = columns.Substring(0, columns.Length - 1);
            values = values.Substring(0, values.Length - 1);
            try
            {
                this.ExecuteNonQuery(String.Format("INSERT INTO {0}({1}) VALUES({2});", tableName, columns, values));
            }
            catch
            {
                returnCode = false;
            }
            return returnCode;
        }

        /// <summary>
        /// Delete all data from the DB.
        /// </summary>
        /// <returns>A boolean true or false to signify success or failure.</returns>
        public bool ClearDB()
        {
            DataTable tables;
            try
            {
                tables = this.GetDataTable("SELECT NAME FROM SQLITE_MASTER WHERE type='table' order by NAME;");
                foreach (DataRow table in tables.Rows)
                {
                    this.ClearTable(table["NAME"].ToString());
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Clear all data from a specific table.
        /// </summary>
        /// <param name="table">The name of the table to clear.</param>
        /// <returns>A boolean true or false to signify success or failure.</returns>
        public bool ClearTable(String table)
        {
            try
            {
                this.ExecuteNonQuery(String.Format("DELETE FROM {0};", table));
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region Statis-Pro Card Factory Methods
        /// <summary>
        /// Creates the database requirements for Statis-Pro Card Factory.
        /// </summary>
        public void CreateApplicationDb()
        {
            FileHelper fileMagic = new FileHelper();
            if (!fileMagic.FileExists(this.dbPath))
            {
                // create the database if it doesn't already exist
                SQLiteConnection.CreateFile(this.dbPath);

                // create the tables in the SQLite database (if they don't already exist)
                // PB lookup table
                string createPBTableSQL = "CREATE TABLE IF NOT EXISTS SPCF_PBLookup (ID INTEGER PRIMARY KEY AUTOINCREMENT, Year INT NOT NULL, League varchar(10) NOT NULL, PB varchar(10) NOT NULL, HighestERA decimal NOT NULL)";
                var pbRows = ExecuteNonQuery(createPBTableSQL);

                // SAC lookup table
                string sacTableSQL = "CREATE TABLE IF NOT EXISTS SPCF_SACLookup (ID INTEGER PRIMARY KEY AUTOINCREMENT, SacrificeHits INT NOT NULL, SAC varchar(10) NOT NULL)";
                var sacRows = ExecuteNonQuery(sacTableSQL);

                // SP lookup table
                string spTableSQL = "CREATE TABLE IF NOT EXISTS SPCF_SPLookup (ID INTEGER PRIMARY KEY AUTOINCREMENT, StolenBases INT NOT NULL, SP varchar(10) NOT NULL)";
                var spRows = ExecuteNonQuery(spTableSQL);

                // OBR lookup table
                string obrTableSQL = "CREATE TABLE IF NOT EXISTS SPCF_OBRLookup (ID INTEGER PRIMARY KEY AUTOINCREMENT, RunsPlusStolenBases INT NOT NULL, OBR varchar(10) NOT NULL)";
                var obrRows = ExecuteNonQuery(obrTableSQL);

                // Catcher throwing lookup
                string cArmTableSQL = "CREATE TABLE IF NOT EXISTS SPCF_CatcherThrowRatingLookup (ID INTEGER PRIMARY KEY AUTOINCREMENT, CaughtStealingPercent INT NOT NULL, Rating varchar(10) NOT NULL)";
                var cArmRows = ExecuteNonQuery(cArmTableSQL);

                // Outfielder throwing lookup
                string ofArmTableSQL = "CREATE TABLE IF NOT EXISTS SPCF_OutfielderThrowRatingLookup (ID INTEGER PRIMARY KEY AUTOINCREMENT, Assists INT NOT NULL, Rating varchar(10) NOT NULL)";
                var ofArmRows = ExecuteNonQuery(ofArmTableSQL);

                // SIngles to Pitcher Cards
                string pitcherSinglesTableSQL = "CREATE TABLE IF NOT EXISTS SPCF_SinglesToPitcherLookup (ID INTEGER PRIMARY KEY AUTOINCREMENT, HitsPerInningLow DECIMAL NOT NULL, HitsPerInningHigh DECIMAL NOT NULL,  " +
                        "PB2to9 INT NOT NULL, PB2to8 INT NOT NULL, PB2to7 INT NOT NULL, PB2to6 INT NOT NULL, PB2to5 INT NOT NULL )";
                var pitcherSinglesRows = ExecuteNonQuery(pitcherSinglesTableSQL);

                // SIngles to Pitcher Cards
                string pitcherBBandKTableSQL = "CREATE TABLE IF NOT EXISTS SPCF_BBAndKToPitcherLookup (ID INTEGER PRIMARY KEY AUTOINCREMENT, BBKPerInningLow DECIMAL NOT NULL, BBKPerInningHigh DECIMAL NOT NULL,  " +
                        "PB2to9 INT NOT NULL, PB2to8 INT NOT NULL, PB2to7 INT NOT NULL, PB2to6 INT NOT NULL, PB2to5 INT NOT NULL )";
                var pitcherBBKRows = ExecuteNonQuery(pitcherBBandKTableSQL);

                // 1B Fielding lookup table
                string firstBaseTableSQL = "CREATE TABLE IF NOT EXISTS SPCF_Fielding1BLookup (ID INTEGER PRIMARY KEY AUTOINCREMENT, FieldingPctLow DECIMAL NOT NULL, FieldingPctHigh DECIMAL NOT NULL,  " +
                        "ErrorRating varchar(10))";
                var fielding1BRows = ExecuteNonQuery(firstBaseTableSQL);

                // 3B Fielding lookup table
                string thirdBaseTableSQL = "CREATE TABLE IF NOT EXISTS SPCF_Fielding3BLookup (ID INTEGER PRIMARY KEY AUTOINCREMENT, FieldingPctLow DECIMAL NOT NULL, FieldingPctHigh DECIMAL NOT NULL,  " +
                        "ErrorRating varchar(10))";
                var fielding3BRows = ExecuteNonQuery(thirdBaseTableSQL);

                // OF Fielding lookup table
                string ofTableSQL = "CREATE TABLE IF NOT EXISTS SPCF_FieldingOFLookup (ID INTEGER PRIMARY KEY AUTOINCREMENT, FieldingPctLow DECIMAL NOT NULL, FieldingPctHigh DECIMAL NOT NULL,  " +
                        "ErrorRating varchar(10))";
                var fieldingOFRows = ExecuteNonQuery(ofTableSQL);

                // 2B, SS, C and P fielding lookup table
                string ifTableSQL = "CREATE TABLE IF NOT EXISTS SPCF_FieldingIFLookup (ID INTEGER PRIMARY KEY AUTOINCREMENT, FieldingPctLow DECIMAL NOT NULL, FieldingPctHigh DECIMAL NOT NULL,  " +
                        "ErrorRating varchar(10))";
                var fieldingIFRows = ExecuteNonQuery(ifTableSQL);
            }
        }
        #endregion

        // DELETE EXAMPLE
        //db = new SQLiteDatabase();
        //String playerID = "12";
        //db.Delete("PLAYER", String.Format("ID = {0}", playerID));

        // UPDATE USAGE:
        //db = new SQLiteDatabase();
        //Dictionary<String, String> data = new Dictionary<String, String>();
        //DataTable rows;
        //data.Add("NAME", nameTextBox.Text);
        //data.Add("POSITION", positionTextBox.Text);
        //data.Add("BATS", batsTextBox.Text);
        //data.Add("TEAM", teamTextBox.Text);
        //try
        //{
        // db.Update("PLAYER", data, String.Format("PLAYER.ID = {0}", this.playerID));
        //}
        //catch(Exception crap)
        //{
        // MessageBox.Show(crap.Message);
        //}

        // INSERT USAGE:
        //db = new SQLiteDatabase();
        //Dictionary<String, String> data = new Dictionary<String, String>();
        //data.Add("NAME", nameTextBox.Text);
        //data.Add("DESCRIPTION", descriptionTextBox.Text);
        //data.Add("PREP_TIME", prepTimeTextBox.Text);
        //data.Add("COOKING_TIME", cookingTimeTextBox.Text);
        //data.Add("COOKING_DIRECTIONS", "Placeholder");
        //try
        //{
        //  db.Insert("RECIPE", data);
        //}
        //catch(Exception crap)
        //{
        // MessageBox.Show(crap.Message);
        //}

        //try
        //{
        // db = new SQLiteDatabase();
        //        DataTable recipe;
        //        String query = "select NAME \"Name\", DESCRIPTION \"Description\",";
        //        query += "PREP_TIME \"Prep Time\", COOKING_TIME \"Cooking Time\"";
        // query += "from RECIPE;";
        // recipe = db.GetDataTable(query);
        // // The results can be directly applied to a DataGridView control
        // recipeDataGrid.DataSource = recipe;
        // /*
        // // Or looped through for some other reason
        // foreach (DataRow r in recipe.Rows)
        // {
        //  MessageBox.Show(r["Name"].ToString());
        //  MessageBox.Show(r["Description"].ToString());
        //  MessageBox.Show(r["Prep Time"].ToString());
        //  MessageBox.Show(r["Cooking Time"].ToString());
        // }

        // */
        //}
        //catch(Exception fail)
        //{
        // String error = "The following error has occurred:\n\n";
        //    error += fail.Message.ToString() + "\n\n";
        // MessageBox.Show(error);

        //    this.Close();
        //    }
        //}
    }
}