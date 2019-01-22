using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Logy.Database.Tables;
using SQLite;

namespace Logy.Database
{

    /// <summary>
    /// Class used for Database interaction
    /// </summary>
    public class DatabaseManager
    {
        static string DBFileName = "/Logy.sqlite";

        public static void SetDB(string db)
        {
            DBFileName = db;
        }

        private static void CreateDB()
        {
            if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + DBFileName))
            {
                File.Create(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + DBFileName);
            }

            SQLiteConnection db = new SQLiteConnection(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + DBFileName, false);
            
            db.CreateTable<Users>();
            db.CreateTable<Projects>();
            db.CreateTable<Logbooks>();
            db.CreateTable<Activities>();

        }

        /// <summary>
        /// Get the database
        /// </summary>
        /// <returns></returns>
        public static SQLiteConnection GetDB()
        {
            
            CreateDB();
            
            try
            {
                SQLiteConnection db = new SQLiteConnection(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + DBFileName, false);
                return db;
            }
            catch (Exception e)
            {
                return null;
            }

        }
    }
}
