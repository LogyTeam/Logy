using System;
using System.Collections.Generic;
using System.Text;

namespace Logy.Logbook
{
    public class Project
    {
        private string name;
        private DateTime startDate;
        private DateTime endDate;
        private string nomMembre;
        private User User;
        private Logbook logbook;
        List<Schedule> schedules;

        public Project(string name, DateTime startDate,User user)
        {
            this.name = name;
            this.startDate = startDate;
            this.User = user;
        }

        public void CreateLogbook()
        {
            this.logbook = new Logbook();
        }

        public void SetEndDate(DateTime date)
        {

        }

        public void SetStartDate(DateTime date)
        {

        }

        public Logbook GetLogbook()
        {
            return this.logbook;
        }

        public DateTime GetEndDate()
        {
            return this.endDate;
        }

        public DateTime GetStartDate()
        {
            return this.startDate;
        }

        public List<Schedule> GetSchedules()
        {
            return this.schedules;
        }
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
    }
}
