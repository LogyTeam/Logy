﻿using System;
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
        public int ID { get; private set; }
        public string UserName {get; private set;} //Contains the logbook's username
        public string UserFîrstName {get; private set;} //Contains the logbook's user firstname
        public List<Activity> Activitylist {get; private set;} //Contains the logbooks's activities

        public IList<int> ActivityID;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public Logbook()
        {
            this.Activitylist = new List<Activity>();
        }
        #endregion

        #region public methods

        /// <summary>
        /// Add a activity in the list
        /// </summary>
        /// <param name="activity"></param>
        public void AddActivity(Activity activity)
        {
            Activitylist.Add(activity);
        }

        /// <summary>
        /// Remove a activity in the list
        /// </summary>
        /// <param name="activity"></param>
        public void RemoveActivity(Activity activity)
        {
            foreach (Activity activityinlist in Activitylist)
            {
                if (activityinlist == activity)
                {
                   Activitylist.RemoveAt(Activitylist.IndexOf(activityinlist));

                }
            }
        }

        /// <summary>
        /// Set the logbook's username 
        /// </summary>
        /// <param name="name"></param>
        public void SetUserName(string name)
        {
            this.UserName = name;
        }

        /// <summary>
        /// Set the logbook's user firstname
        /// </summary>
        /// <param name="firstname"></param>
        public void SetUserFirstName(string firstname)
        {
            this.UserFîrstName = firstname;
        }

        /// <summary>
        /// Get the logbook's username
        /// </summary>
        /// <returns></returns>
        public string GetUserName()
        {
            return this.UserName;
        }
        /// <summary>
        ///         Get the logbook's user firstname
        /// </summary>
        /// <returns></returns>
        public string GetUserFirstName()
        {
            return this.UserFîrstName;
        }
        #endregion
    }
}
