using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logy.Logbook;

namespace Logy.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Activity act = new Activity("ui", "Je suis une activité", new DateTime(1, 1, 1));

            Assert.AreEqual("ui", act.GetTitle());
        }
    }
}
