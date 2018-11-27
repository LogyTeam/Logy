using System;
using System.Collections.Generic;
using System.Text;

namespace Logy.Logbook
{
    class Activity
    {
        private string title;
        private string description;
        private DateTime startHour;
        private DateTime endHour;
        private string location;

        public Activity(string title,string description,DateTime startHour)
        {
            this.title = title;
            this.description = description;
            this.startHour = startHour;
        }

        public void EndActivity(DateTime endHour)
        {
            this.endHour = endHour;
        }

        public void SetTitle(string title)
        {
            this.title = title;
        }
        public void SetDescription(string description)
        {
            this.description = description;
        }

    }
}
