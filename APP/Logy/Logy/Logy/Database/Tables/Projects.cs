using Logy.Classes;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logy.Database.Tables
{
    [Table("PROJECTS")]
    class Projects : LogyTable<Project>
    {

        [PrimaryKey, AutoIncrement]
        public int idPROJECT { get; set; }
        public int fk_idUSER { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
      //public int fk_idSCHEDULE { get; set; }

        public override Project CreateObject()
        {
            SQLiteConnection sql = DatabaseManager.GetDB();
            User u = sql.Query<Users>("SELECT * FROM USERS WHERE idUSER="+fk_idUSER)[0].CreateObject();
            sql.Close();

            sql = DatabaseManager.GetDB();
            Logbook log = DatabaseManager.GetDB().Query<Logbooks>("SELECT * FROM LOGBOOK WHERE fk_idPROJECT="+idPROJECT)[0].CreateObject();
            sql.Close();

            return new Project(idPROJECT, Name, StartDate, u, EndDate, new List<Schedule>(), log);
        }
    }
}
