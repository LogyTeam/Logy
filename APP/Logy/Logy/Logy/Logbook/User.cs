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
    /// Class User that contains user informations
    /// </summary>
     class User
    {
        #region Variables
        private string username; //Username of the user
        private string email; //Email of the user
        private List<Project> projects; //Projects of the user
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor of the class
        /// </summary>
        /// <param name="name"></param>
        /// <param name="mail"></param>
        public User(string name,string mail)
        {
            this.username = name;
            this.email = mail;
        }
        #endregion

        #region publics methods

        #region Project methods
        /// <summary>
        /// Search all projects of the user in the database
        /// </summary>
        private void LoadProject()
        {

        }

        /// <summary>
        /// Method for create a new project for the user
        /// </summary>
        /// <param name="project"></param>
        public void CreateProject(Project project)
        {
            this.projects.Add(project);
        }
        
        /// <summary>
        /// Method for remove a project of the user
        /// </summary>
        /// <param name="project"></param>
        public void RemoveProject(Project project)
        {
            foreach (Project projectinlist in projects)
            {
                if (projectinlist == project)
                {
                    projects.RemoveAt(projects.IndexOf(projectinlist));            
                }
            }
        }
        #endregion

        #region Get methods

        /// <summary>
        /// Get the username of the user
        /// </summary>
        /// <returns></returns>
        public string GetUsername()
        {
            return this.username;
        }


        /// <summary>
        /// Get the email of the user
        /// </summary>
        /// <returns></returns>
        public string GetMail()
        {
            return this.email;
        }

        #endregion

        #region Set methods

        /// <summary>
        /// Method that change the username of the user
        /// </summary>
        /// <param name="username"></param>
        public void ChangeUsername(string username)
        {
            this.username = username;
        }


        /// <summary>
        /// Method that change the password of the user
        /// </summary>
        /// <param name="username"></param>
        public void ChangePassword(string password)
        {
            //TODO : Implémentation du change password avec BDD

        }
        #endregion

        #endregion

    }
}
