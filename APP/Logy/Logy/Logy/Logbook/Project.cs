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
    /// Class Project that contains project informations
    /// </summary>
    public class Project : RealmObject
    {
        #region variables
        public int ID { get; private set; }
        public string Name { get; private set;}
        public DateTimeOffset StartDate { get; private set; }
        public DateTimeOffset EndDate { get; private set; }
        public string NomMembre { get; private set; }
        public User User { get; private set; }
        public Logbook Logbook { get; private set; }
        [Ignored]
        public List<Schedule> Schedules { get; private set; }

        public IList<int> SchedulesID;
        #endregion

        #region Constructor 

        public Project()
        {
            this.Name = "";
            this.StartDate = DateTime.Now;
            this.User = null;
            this.Schedules = new List<Schedule>();
        }

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
        
        /// <summary>
        /// Add a schedule for the project
        /// </summary>
        /// <param name="schedule"></param>
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
                    DateTimeOffset currentTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
                    if (DateTimeOffset.Compare(currentTime,schedule.StartHour) >= 0 && DateTimeOffset.Compare(currentTime,schedule.EndHour) < 0)
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
