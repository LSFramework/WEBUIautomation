using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WEBUIautomation;
using System.Threading;

namespace WEBUItests
{
    [TestClass]
    public class LoginTest : WEBUItest
    {
        [TestMethod]
        public void Login_In_Webui()
        {
            LoginPage.GoTo("myd-vm04186");
            LoginPage.EnterName("sa");
            LoginPage.EnterPassword("");
            LoginPage.Authenticate();
            LoginPage.SelectDomain("VITALII");
            LoginPage.SelectProject("vproj");
            LoginPage.Submit();

            Assert.IsTrue(DashboardPage.IsAt, "failed to login");
            Assert.AreEqual(DashboardPage.Project, "vproj", "Wrong project");
                  
        }

    }
}
