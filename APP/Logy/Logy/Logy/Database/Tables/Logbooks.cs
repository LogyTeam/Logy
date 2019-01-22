using Logy.Classes;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logy.Database.Tables
{
    [Table("LOGBOOK")]
    class Logbooks : LogyTable<Logbook>
    {

        [PrimaryKey, AutoIncrement]
        public int idLogbook { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string FirstName { get; set; }

        public override Logbook CreateObject()
        {
            List<Activity> activities = new List<Activity>();

            return new Logbook(Name, FirstName, activities);
        }
    }
}
