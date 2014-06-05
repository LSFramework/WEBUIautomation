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
            LoginPage.SelectWebui();
            
            LoginPage.EnterName("sa");
            LoginPage.EnterPassword("");

            LoginPage.Authenticate();
            LoginPage.SelectDomain("HANAN");
            LoginPage.SelectProject("hanan_drop_9");
            LoginPage.Submit();

            Assert.IsTrue(DashboardPage.IsAt, "failed to login");

            LoginPage.Authenticate();            
            LoginPage.SelectDomain("HANAN");
            LoginPage.SelectProject("hanan_drop_9");            
            LoginPage.Submit();

            Assert.IsTrue(DashboardPage.IsAt, "failed to login");
            
        }

    }
}
