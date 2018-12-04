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
    /// Class Activity that contains activity's informations
    /// </summary>
    class Activity
    {
        #region variables
        private string title;       //Title of the activity
        private string description; //Description of the activity
        private DateTime startHour; //Start hour of the activity
        private DateTime endHour;   //End hour of the activity
        private string location;    //Location of the activity
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor of the class

        /// </summary>
        /// <param name="title"></param>
        /// <param name="description"></param>
        /// <param name="startHour"></param>
        public Activity(string title,string description,DateTime startHour)
        {
            this.title = title;
            this.description = description;
            this.startHour = startHour;
        }
        #endregion

        #region public Methods

        #region Set Methods
        /// <summary>
        /// Set the end hour of the activity
        /// </summary>
        /// <param name="endHour"></param>
        public void EndActivity(DateTime endHour)
        {
            this.endHour = endHour;
        }

        /// <summary>
        /// Set or change the title of the activity
        /// </summary>
        /// <param name="title"></param>
        public void SetTitle(string title)
        {
            this.title = title;
        }

        /// <summary>
        ///Set or change the description
        /// </summary>
        /// <param name="description"></param>
        public void SetDescription(string description)
        {
            this.description = description;
        }

        /// <summary>
        /// Set or change the start hour of the activity
        /// </summary>
        /// <param name="hour"></param>
        public void SetStartHour(DateTime hour)
        {
            this.startHour = hour;
        }

        /// <summary>
        /// Set or change the end hour of the activity
        /// </summary>
        /// <param name="hour"></param>
        public void SetEndHour(DateTime hour)
        {
            this.endHour = hour;
        }

        /// <summary>
        /// Set or change the location of the activity
        /// </summary>
        /// <param name="location"></param>
        public void SetLocation(string location)
        {
            this.location = location;
        }

        #endregion

        #region Get Methods
        /// <summary>
        /// Return the title of the activity 
        /// </summary>
        /// <returns>String title</returns>
        public string GetTitle()
        {
            return this.title;
        }

        /// <summary>
        /// Return the description of the activity 
        /// </summary>
        /// <returns></returns>
        public string GetDescription()
        {
            return this.description;
        }

        /// <summary>
        /// Return the start hour of the activity
        /// </summary>
        /// <returns></returns>
        public DateTime GetStartHour()
        {
            return this.startHour;
        }

        /// <summary>
        /// Return the end hour of the activity
        /// </summary>
        /// <returns></returns>
        public DateTime GetEndHour()
        {
            return this.endHour;
        }

        /// <summary>
        /// return the location of the activity
        /// </summary>
        /// <returns></returns>
        public string GetLocation()
        {
            return this.location;
        }
        #endregion
        #endregion
    }
}
