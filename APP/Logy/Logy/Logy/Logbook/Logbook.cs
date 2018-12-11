using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// Author : Jason Crisante
/// Creation Date : 27.11.2018
/// 
/// Modification Date : 04.12.2018
/// Modified by : Jason Crisante
/// </summary>

namespace Logy.Logbook
{
    /// <summary>
    /// Class Logbook that contains user's logbook information
    /// </summary>
    public class Logbook
    {
        #region variables
        private string userName; //Contains the logbook's username
        private string userFîrstName; //Contains the logbook's user firstname
        private List<Activity> activitylist; //Contains the logbooks's activities
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public Logbook()
        {

        }
        #endregion

        #region public methods

        /// <summary>
        /// Add a activity in the list
        /// </summary>
        /// <param name="activity"></param>
        public void AddActivity(Activity activity)
        {
            activitylist.Add(activity);
        }

        /// <summary>
        /// Remove a activity in the list
        /// </summary>
        /// <param name="activity"></param>
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

        /// <summary>
        /// Set the logbook's username 
        /// </summary>
        /// <param name="name"></param>
        public void SetUserName(string name)
        {
            this.userName = name;
        }

        /// <summary>
        /// Set the logbook's user firstname
        /// </summary>
        /// <param name="firstname"></param>
        public void setUserFirstName(string firstname)
        {
            this.userFîrstName = firstname;
        }

        /// <summary>
        /// Get the logbook's username
        /// </summary>
        /// <returns></returns>
        public string GetUserName()
        {
            return this.userName;
        }
        /// <summary>
        ///         Get the logbook's user firstname
        /// </summary>
        /// <returns></returns>
        public string GetUserFirstName()
        {
            return this.userFîrstName;
        }
        #endregion
    }
}
