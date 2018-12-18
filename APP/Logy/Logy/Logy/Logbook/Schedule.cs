using Realms;
using System;
using System.Collections.Generic;
using System.Text;
/// <summary>
/// Author : Jason Crisante
/// Creation Date : 27.11.2018
/// 
/// Modification Date : 30.11.2018
/// Modified by : Jason Crisante
/// </summary>
namespace Logy.Logbook
{
    /// <summary>
    /// Class Schedule that contains the schedule of the user 
    /// </summary>
    public class Schedule : RealmObject
    {
        #region Variables
        public int ID { get; private set; }
        [Ignored]
        public DayOfWeek Day { get; private set;}//Day Of the week

        public string DayString;

        public DateTimeOffset StartHour { get; private set; } //Working starting hour
        public DateTimeOffset EndHour { get; private set; } //Working ending hour
        #endregion

        #region Constructor

        public Schedule()
        {

        }

        public Schedule(DayOfWeek day,DateTime start,DateTime end)
        {
            this.Day = day;
            this.StartHour = start;
            this.EndHour = end;
        }
        #endregion
    }
}
