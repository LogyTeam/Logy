using Logy.Database;
using Logy.Database.Tables;
using SQLite;
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
    /// Class User that contains user informations
    /// </summary>
    public class User
    {
        #region Variables
        public int id { get; private set; }
        public string Username { get; private set; } //Username of the user
        //public string Password { get; private set;}
        public string Email { get; private set;} //Email of the user
        public List<Project> Projects {get; private set;} //Projects of the user

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor of the class
        /// </summary>
        /// <param name="name"></param>
        /// <param name="mail"></param>
        public User(int i,string mail, string username)
        {
            this.id = i;
            this.Email = mail;
            this.Username = username;
            LoadProject();
        }
        #endregion

        #region publics methods

        #region Project methods
        /// <summary>
        /// Search all projects of the user in the database
        /// </summary>
        private void LoadProject()
        {
            List<Projects> DBprojects = DatabaseManager.GetDB().Query<Projects>("SELECT * FROM PROJECTS where fk_idUSER ="+ id);
            List<Project> projects = new List<Project>();

            foreach (Projects p in DBprojects)
            {
                projects.Add(p.CreateObject());
            }

            this.Projects = projects;
        }

        /// <summary>
        /// Method for create a new project for the user
        /// </summary>
        /// <param name="project"></param>
        public Project CreateProject(string name , DateTime StartDate)
        {
            Project project = new Project(name, StartDate, this);

            if (this.Projects.Find(x => x.Name == name) == null)
            {
                DatabaseManager.GetDB().Execute("INSERT into PROJECTS(fk_idUSER,Name,Description,StartDate,fk_idLOGBOOK) VALUES("+ App.user.id + ", '" +name +"', '', "+ StartDate +"");
            }
            else
            {
                throw new Exception("Il y a déja un projet du meme nom");
            }
            return project;
        }
        
        /// <summary>
        /// Method for remove a project of the user
        /// </summary>
        /// <param name="project"></param>
        public void RemoveProject(Project project)
        {
            Projects.Remove(project);

        }
        #endregion

        #region Set methods


        /// <summary>
        /// Method that change the username of the user
        /// </summary>
        /// <param name="username"></param>
        public void ChangeUsername(string username)
        {
            this.Username = username;
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
