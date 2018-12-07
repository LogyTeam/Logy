using System;
using System.Collections.Generic;
using System.Text;

namespace Logy.Logbook
{
    public class Logbook
    {
        private string userName;
        private string userFîrstName;
        List<Activity> activitylist;

        public Logbook()
        {

        }

        public void AddActivity(Activity activity)
        {
            activitylist.Add(activity);
        }

        public void RemoveActivity(Activity activity)
        {
            foreach (Activity activityinlist in activitylist)
            {
                if (activityinlist == activity)
                {
                   activitylist.RemoveAt(activitylist.IndexOf(activityinlist));

                }
            }
        }

        public void SetUserName(string name)
        {
            this.userName = name;
        }
        public void setUserFirstName(string firstname)
        {
            this.userFîrstName = firstname;
        }

        public string GetUserName()
        {
            return this.userName;
        }
        public string GetUserFirstName()
        {
            return this.userFîrstName;
        }
    }
}
