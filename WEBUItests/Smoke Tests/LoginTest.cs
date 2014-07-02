using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WEBUIautomation;
using System.Threading;
using WEBUIautomation.Utils;

namespace WEBUItests
{
    [TestClass]
    public class LoginTest : WEBUItest
    {
        [TestMethod]
        public void Login_In_Webui()
        {
            LoginPage.GoTo(Properties.QCServer, Properties.ServerPort);
            LoginPage.EnterName(Properties.UserName);
            Snapshot.Take("snapshot1");
            LoginPage.EnterPassword(Properties.UserPassword);
            LoginPage.Authenticate();
            LoginPage.SelectDomain(Properties.DomainName);
            LoginPage.SelectProject(Properties.ProjectName);
            Snapshot.Take();
            LoginPage.Submit();

            Assert.IsTrue(DashboardPage.IsAt, "failed to login");
            Assert.AreEqual(DashboardPage.Project, "vproj", "Wrong project");
                            
        }

    }
}
