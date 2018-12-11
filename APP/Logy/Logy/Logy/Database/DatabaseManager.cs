using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using System.IO;

namespace Logy.Database
{
    /// <summary>
    /// Class used for Database interaction
    /// </summary>
    class DatabaseManager
    {
        private static string _sqliteFile = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal)+"logyDB.sqlite";

        /// <summary>
        /// Connection to the database
        /// </summary>
        /// <returns></returns>
        public static SQLiteConnection Connect()
        {
            if (!File.Exists(_sqliteFile))
            {
                SQLiteConnection.CreateFile(_sqliteFile);
                MountDatabase();
            }

            try
            {
                SQLiteConnection connection = new SQLiteConnection(_sqliteFile);
                connection.Open();

                return connection;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        /// <summary>
        /// Create the default database structure
        /// </summary>
        private static void MountDatabase()
        {
            SQLiteConnection connection = Connect();
            string script = File.ReadAllText(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "CreateDatabase.sql");

            SQLiteCommand command = new SQLiteCommand(script, connection);
            command.ExecuteNonQuery();

            command = new SQLiteCommand("insert into user values(0, \"Dorian\", \"ui\", \"pass\")", connection);
            command.ExecuteNonQuery();
        }

        /// <summary>
        /// Send a select query to the SQLiteDatabase
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public static List<Dictionary<string, string>> Select(string query)
        {
            SQLiteConnection dbConnection;
            if ((dbConnection = Connect()) != null)
            {
                SQLiteCommand selectQuery = new SQLiteCommand(query, dbConnection);
                SQLiteDataReader reader = selectQuery.ExecuteReader();

                List<Dictionary<string, string>> results = new List<Dictionary<string, string>>();

                while (reader.Read())
                {
                    Dictionary<string, string> line = new Dictionary<string, string>();

                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        line.Add(reader.GetName(i), reader[i].ToString());
                    }

                    results.Add(line);
                }
                reader.Close();
                dbConnection.Close();

                return results;

            }
            return new List<Dictionary<string, string>>();
        }

    }
}
