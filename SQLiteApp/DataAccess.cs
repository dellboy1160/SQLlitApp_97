using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteApp
{
    class DataAccess
    {
        public async static void InitializeDatabase()
        { 
            using (SqliteConnection db =
               new SqliteConnection("Filename=sqliteSample.db"))
            {   
                db.Open();
                String tableCommand = "CREATE TABLE IF NOT " +
                    "EXISTS MyTable (cus_id INTEGER PRIMARY KEY, " +
                    "Text_Entry NVARCHAR(50) NULL)";
          
                SqliteCommand createTable = new SqliteCommand(tableCommand, db);
                createTable.ExecuteReader();
            }
            
        }
        public static void AddData(string inputfirst_name)
        {
            using (SqliteConnection db =
                new SqliteConnection("Filename=sqliteSample.db"))

            {
                db.Open();

                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;
                insertCommand.CommandText = "INSERT INTO MyTable VALUES (NULL, @first_name);";
                insertCommand.Parameters.AddWithValue("@first_name", inputfirst_name);
                insertCommand.ExecuteReader();

                db.Close();
            }
        
        }
        public static List<String> GetData()
        {
            List<String> entries = new List<string>();

            using (SqliteConnection db =
               new SqliteConnection("Filename=sqliteSample.db"))
            {
                db.Open();

                SqliteCommand selectCommand = new SqliteCommand
                    ("SELECT Text_Entry from MyTable", db);
                SqliteDataReader query = selectCommand.ExecuteReader();

                while (query.Read())
                {
                    entries.Add(query.GetString(0));
                }
                db.Close();
            }
            return entries;
        }
    }
}
