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
    /// Class Project that contains project informations
    /// </summary>
    public class Project
    {
        #region variables
        public string Name { get; private set;}
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public string NomMembre { get; private set; }
        public User User { get; private set; }
        public Logbook Logbook { get; private set; }
        public List<Schedule> Schedules { get; private set; }
        #endregion

        #region Constructor 
        /// <summary>
        /// Constructor of the class
        /// </summary>
        /// <param name="name"></param>
        /// <param name="startDate"></param>
        /// <param name="user"></param>
        public Project(string name, DateTime startDate,User user)
        {
            this.Name = name;
            this.StartDate = startDate;
            this.User = user;
            this.Schedules = new List<Schedule>();
            CreateLogbook();
        }
        #endregion

        #region public Methods

        #region Set Methods
        /// <summary>
        /// Creation of the logbook
        /// </summary>
        public void CreateLogbook()
        {
            this.Logbook = new Logbook();
        }

        public void AddSchedule(Schedule schedule)
        {
            Schedules.Add(schedule);
        }
        #endregion

        #region Get Methods

        /// <summary>
        /// Returns if the user is in working time
        /// </summary>
        /// <returns>bool</returns>
        public bool IsInWorkingTime()
        {
            foreach (Schedule schedule in Schedules)
            {
                if (schedule.Day == DateTime.Now.DayOfWeek)
                {
                    DateTime currentTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
                    if (DateTime.Compare(currentTime,schedule.StartHour) >= 0 && DateTime.Compare(currentTime,schedule.EndHour) < 0)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
        #endregion

        #endregion
    }
}
