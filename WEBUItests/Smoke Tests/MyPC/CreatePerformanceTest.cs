using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBUIautomation;
using WEBUIautomation.Pages;

namespace WEBUItests.Smoke_Tests.MyPC
{
    class CreatePerformanceTest : WEBUItest
    {
        [Test]
        public void createPerfTest()
        {
            LoginPage.LoginFlow();
            Navigation.GoTo(Pages.Topologies);
            Driver.Wait(7);
            Assert.AreEqual("Topologies", Navigation.CurrentPageTitle);
            //Navigation.Logout();
        }
    }
}
