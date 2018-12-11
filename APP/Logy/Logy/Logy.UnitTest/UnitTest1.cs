using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logy.Logbook;

namespace Logy.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddProjectTest()
        {
            User user = new User("user1", "user@mail");

            user.CreateProject("project1", new DateTime(2018, 12, 11));

            int nbProjects = user.Projects.Count;

            Assert.AreEqual(1, nbProjects);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void AddSameNameProject()
        {
            User user = new User("user1", "user@mail");

            user.CreateProject("project1", new DateTime(2018, 12, 11));
            user.CreateProject("project1", new DateTime(2018, 12, 11));
        }

        [TestMethod]
        public void RemoveProjectTest()
        {
            User user = new User("user1", "user@mail");

            user.CreateProject("project1", new DateTime(2018, 12, 11));
            user.CreateProject("project2", new DateTime(2018, 12, 11));

            user.RemoveProject(user.Projects[0]);

            int nbProjects = user.Projects.Count;

            Assert.AreEqual(1, nbProjects);
        }

        [TestMethod]
        public void CreateLogbookTest()
        {
            User user = new User("user1", "user@mail");

            user.CreateProject("project1", new DateTime(2018, 12, 11));
            user.Projects[0].CreateLogbook();

            Assert.AreEqual(0, user.Projects[0].Logbook.Activitylist.Count);
        }

        [TestMethod]
        public void WorkingHourTest()
        {
            User user = new User("user1", "user@mail");
            Project project = user.CreateProject("project1", new DateTime(2018, 12, 11));

            project.AddSchedule(new Schedule(DayOfWeek.Tuesday, new DateTime(0, 0, 0, 8, 0, 0), new DateTime(0, 0, 0, 17, 0, 0)));

            Assert.AreEqual(true, project.IsInWorkingTime());
        }

        [TestMethod]
        public void EndActivityTest()
        {
            User user = new User("user1", "user@mail");
            Project project = user.CreateProject("project1", new DateTime(2018, 12, 11));

            Activity myActivity = new Activity("my activity", "C'était bien", new DateTime(2018, 12, 11, 8, 50, 0));

            project.Logbook.AddActivity(myActivity);
            myActivity.EndActivity();

            Assert.AreEqual(DateTime.Now, myActivity.GetEndHour());
        }

    }
}
