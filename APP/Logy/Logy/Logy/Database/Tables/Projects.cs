using Logy.Classes;
using Logy.View;
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
            //User u = DatabaseManager.GetDB().Query<Users>("SELECT * FROM USERS WHERE idUSER="+fk_idUSER)[0].CreateObject();

            List<Logbooks> logs = DatabaseManager.GetDB().Query<Logbooks>("SELECT * FROM LOGBOOK WHERE fk_idPROJECT="+idPROJECT);
            Logbook log = null;

            if(logs.Count > 0)
            {
                log = logs[0].CreateObject();
            }

            return new Project(idPROJECT, Name, StartDate, App.user, EndDate, new List<Schedule>(), log);
        }
    }
}
