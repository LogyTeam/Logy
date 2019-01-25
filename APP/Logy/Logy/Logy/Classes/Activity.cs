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
namespace Logy.Classes
{
    /// <summary>
    /// Class Activity that contains activity's informations
    /// </summary>
    public class Activity
    {
        #region variables
        public int ID { get; private set; }
        public string Title {get;set;}//Title of the activity
        public string Description {get;set;}//Description of the activity
        public DateTime StartHour {get; private set;}//Start hour of the activity
        public DateTime EndHour { get; private set;}//End hour of the activity
        #endregion

        #region Constructor

        public Activity()
        {
            this.Title = "";
            this.Description = "";
            this.StartHour = DateTime.Now;
        }

        /// <summary>
        /// Constructor of the class
        /// </summary>
        /// <param name="title"></param>
        /// <param name="description"></param>
        /// <param name="startHour"></param>
        public Activity(string title,string description,DateTime startHour)
        {
            this.Title = title;
            this.Description = description;
            this.StartHour = startHour;
        }

        public Activity(string title, string description, DateTime startHour, DateTime endHour)
        {
            this.Title = title;
            this.Description = description;
            this.StartHour = startHour;
            this.EndHour = endHour;
        }
        #endregion

        #region public Methods

        #region Set Methods
        /// <summary>
        /// Set the end hour of the activity
        /// </summary>
        public void EndActivity()
        {
            this.EndHour = DateTime.Now;
        }

        /// <summary>
        /// Set or change the start hour of the activity
        /// </summary>
        /// <param name="hour"></param>
        public void SetStartHour(DateTime hour)
        {
            this.StartHour = hour;
        }

        /// <summary>
        /// Set or change the end hour of the activity
        /// </summary>
        /// <param name="hour"></param>
        public void SetEndHour(DateTime hour)
        {
            this.EndHour = hour;
        }

        #endregion

        #endregion
    }
}
