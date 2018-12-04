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
     class Project
    {
        #region variables
        private string name;
        private DateTime startDate;
        private DateTime endDate;
        private string nomMembre;
        private User User;
        private Logbook logbook;
        private List<Schedule> schedules;
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
            this.name = name;
            this.startDate = startDate;
            this.User = user;
        }
        #endregion

        #region public Methods

        #region Set Methods
        /// <summary>
        /// Creation of the logbook
        /// </summary>
        public void CreateLogbook()
        {
            this.logbook = new Logbook();
        }

        /// <summary>
        /// Set or change the end date
        /// </summary>
        /// <param name="date"></param>
        public void SetEndDate(DateTime date)
        {

            this.endDate = date;
        }

        /// <summary>
        /// Set or change the start date
        /// </summary>
        /// <param name="date"></param>
        public void SetStartDate(DateTime date)
        {
            this.startDate = date;
        }
        #endregion

        #region Get Methods
        /// <summary>
        /// Return the logbook of the project
        /// </summary>
        /// <returns></returns>
        public Logbook GetLogbook()
        {
            return this.logbook;
        }

        /// <summary>
        /// Returns the end date of the project
        /// </summary>
        /// <returns></returns>
        public DateTime GetEndDate()
        {
            return this.endDate;
        }

        /// <summary>
        /// Returns the start date of the project
        /// </summary>
        /// <returns></returns>
        public DateTime GetStartDate()
        {
            return this.startDate;
        }
        
        /// <summary>
        /// Returns the schedules's list of the project
        /// </summary>
        /// <returns></returns>
        public List<Schedule> GetSchedules()
        {
            return this.schedules;
        }

        /// <summary>
        /// Returns if the user is in working time
        /// </summary>
        /// <returns>bool</returns>
        public bool IsInWorkingTime()
        {
            foreach (Schedule schedule in schedules)
            {
                if (schedule.Day == DateTime.Now.DayOfWeek)
                {
                    DateTime currentTime = new DateTime(0, 0, 0, DateTime.Now.Hour, DateTime.Now.Minute, 0);
                    if (DateTime.Compare(schedule.startHour, currentTime) >= 0 && DateTime.Compare(schedule.endHour, currentTime) < 0)
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
