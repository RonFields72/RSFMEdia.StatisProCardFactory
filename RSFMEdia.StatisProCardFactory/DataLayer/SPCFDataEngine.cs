using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SQLite;
using RSFMEdia.StatisProCardFactory.Business;
using RSFMEdia.StatisProCardFactory.Models;

namespace RSFMEdia.StatisProCardFactory.DataLayer
{
    public class SPCFDataEngine
    {
        SQLiteConnection _DBConnection;
        string _databasePath = string.Format("{0}{1}", SPCFConstants.SPCF_DB_DIRECTORY, "SPCFData.sqlite");
        string _connectionString = string.Format("Data Source={0}{1}; Version=3;", SPCFConstants.SPCF_DB_DIRECTORY, "SPCFData.sqlite");
        string _skinnyConnectionString = string.Format("Data Source={0}{1};", SPCFConstants.SPCF_DB_DIRECTORY, "SPCFData.sqlite");

        /// <summary>
        /// Creates the database requirements for Statis-Pro Card Factory.
        /// </summary>
        public void CreateDB()
        {
            FileHelper fileMagic = new FileHelper();
            if (!fileMagic.FileExists(_databasePath))
            {
                SQLiteConnection.CreateFile(_databasePath);

                // create the tables in the SQLite database
                using (_DBConnection = new SQLiteConnection(_connectionString))
                {
                    // open the connection
                    _DBConnection.Open();

                    // PB table
                    string createPBTableSQL = "CREATE TABLE IF NOT EXISTS SPCF_PB (Year INT, League varchar(10), PB varchar(10), HighestERA decimal)";
                    SQLiteCommand createPBCommand = new SQLiteCommand(createPBTableSQL, _DBConnection);
                    createPBCommand.ExecuteNonQuery();

                    // TODO: create more lookup tables here
                }
            }
        }

        public PitcherControlFactor GetPB()
        {
            using (var conn = new SQLiteContext(this._skinnyConnectionString))
            { 
                // linq test query
                var thePB = conn.PitcherControlFactor
                    .Where(pb => pb.PB == "2-9")
                    .FirstOrDefault();

                return thePB;
            }
        }

        // Inserts some values in the highscores table.
        // As you can see, there is quite some duplicate code here, we'll solve this in part two.
        //void fillTable()
        //{
        //    string sql = "INSERT INTO SCPF_PB (Year, League, PB, HighestERA) values (1984, 'NL', '2-9', 2.01)";
        //    SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
        //    command.ExecuteNonQuery();
        //    sql = "insert into highscores (name, score) values ('Myself', 6000)";
        //    command = new SQLiteCommand(sql, m_dbConnection);
        //    command.ExecuteNonQuery();
        //    sql = "insert into highscores (name, score) values ('And I', 9001)";
        //    command = new SQLiteCommand(sql, m_dbConnection);
        //    command.ExecuteNonQuery();
        //}

        // Writes the highscores to the console sorted on score in descending order.
        //void printHighscores()
        //{
        //    string sql = "select * from highscores order by score desc";
        //    SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
        //    SQLiteDataReader reader = command.ExecuteReader();
        //    while (reader.Read())
        //        Console.WriteLine("Name: " + reader["name"] + "\tScore: " + reader["score"]);
        //    Console.ReadLine();
        //}

        /// <summary>
        /// Get the PB Range for a pitcher given the year, league and ERA
        /// </summary>
        /// <param name="year"></param>
        /// <param name="league"></param>
        /// <param name="era"></param>
        /// <returns></returns>
        //public PitcherControl GetPB(int year, string league, decimal era)
        //{
        //    using (_DBConnection = new SQLiteConnection(_connectionString))
        //    {
        //        // open the connection
        //        _DBConnection.Open();

        //        // get the PB range for the given year
        //    }
        //}
    }
}