using System;
using System.Collections.Generic;
using System.Text;

namespace Logy.Logbook
{
    public class User
    {
        private string username;
        private string email;
        List<Project> projects;

        public User(string name,string mail)
        {
            this.username = name;
            this.email = mail;
        }

        private void LoadProject()
        {

        }

        public void CreateProject()
        {

        }

        public void RemoveProject()
        {

        }

        public string GetUsername()
        {
            return this.username;
        }

        public string GetMail()
        {
            return this.email;
        }

        public void ChangeUsername(string username)
        {
            this.username = username;
        }

        public void ChangePassword(string password)
        {
            
        }

    }
}
