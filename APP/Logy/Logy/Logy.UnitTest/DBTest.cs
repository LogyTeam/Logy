using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logy.Database;
using System.Collections.Generic;
using Logy.Database.Tables;
using System.IO;
using SQLite;
using Logy.Classes;

namespace Logy.UnitTest
{
    [TestClass]
    public class DBTest
    {
        public void CreateDB()
        {
            DatabaseManager.SetDB("\\DBTest.sqlite");

            SQLiteConnection db = DatabaseManager.GetDB();

            db.Query<Users>("DROP TABLE USERS");
            db.CreateTable<Users>();
        }

        [TestMethod]
        public void TestInsertSingle()
        {
            CreateDB();

            User user1 = new User("user1", "...");
            DatabaseManager.GetDB().Execute("INSERT INTO USERS VALUES(0,\'"+user1.Username+"\', \'"+user1.Email+"\',\'Pa$$w0rd\')");

            int nbUser = DatabaseManager.GetDB().Query<Users>("SELECT * FROM USERS").Count;
            Assert.AreEqual(1, nbUser);
        }

        [TestMethod]
        public void TestInsertMultiple()
        {
            CreateDB();

            List<User> users = new List<User>();
            users.Add(new User("user1", "..."));
            users.Add(new User("user2", "..."));
            users.Add(new User("user3", "..."));
            users.Add(new User("user4", "..."));

            foreach (User u in users)
            {
                DatabaseManager.GetDB().Execute("INSERT INTO Users(Username, Email, Password) VALUES(\"\", \""+u.Email+"\", \"Pa$$w0rd\")");
            }

            int nbUser = DatabaseManager.GetDB().Query<Users>("SELECT * FROM Users").Count;
            Assert.AreEqual(4, nbUser);
        }

        [TestMethod]
        public void TestSelect()
        {
            CreateDB();

            DatabaseManager.GetDB().Execute("INSERT INTO Users(Username, Email, Password) VALUES(\"\", \"User1@gmail.com\", \"MyPassword\")");

            string userPass = DatabaseManager.GetDB().Query<Users>("SELECT * FROM Users")[0].Password;

            Assert.AreEqual("MyPassword", userPass);
        }

        [TestMethod]
        public void TestUpdate()
        {
            CreateDB();

            DatabaseManager.GetDB().Execute("INSERT INTO Users(Username, Email, Password) VALUES(\"User1\", \"User1@gmail.com\", \"MyPassword\")");
            DatabaseManager.GetDB().Execute("UPDATE Users SET Username=? WHERE idUSER=1", "NewUsername");

            string username = DatabaseManager.GetDB().Query<Users>("SELECT * FROM Users")[0].Username;

            Assert.AreEqual("NewUsername", username);
        }

    }
}