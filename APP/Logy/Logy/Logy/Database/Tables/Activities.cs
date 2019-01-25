using Logy.Classes;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logy.Database.Tables
{
    [Table("ACTIVITIES")]
    class Activities : LogyTable<Activity>
    {

        [PrimaryKey, AutoIncrement]
        public int idActivity { get; set; }
        [MaxLength(200)]
        public string Title { get; set; }
        public string Description { get; set; }
        [MaxLength(200)]
        public string Location { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int fk_idLOGBOOK { get; set; }

        public override Activity CreateObject()
        {
            return new Activity(Title, Description, StartDate, EndDate, Location);
        }
    }
}
