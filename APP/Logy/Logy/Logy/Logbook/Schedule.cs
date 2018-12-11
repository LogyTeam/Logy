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
    public class Schedule
    {
        #region Variables
        public DayOfWeek Day; //Day Of the week
        public DateTime startHour; //Working starting hour
        public DateTime endHour; //Working ending hour
        #endregion
    }
}
