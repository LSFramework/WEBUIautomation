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
<<<<<<< HEAD
            LoginPage.Authenticate();
            LoginPage.SelectDomain("HANAN");
            LoginPage.SelectProject("hanan_drop_9");
            LoginPage.Submit();

            Assert.IsTrue(DashboardPage.IsAt, "failed to login");
=======
            LoginPage.Authenticate();            
            LoginPage.SelectDomain("HANAN");
            LoginPage.SelectProject("hanan_drop_9");            
            LoginPage.Submit();

            Assert.IsTrue(DashboardPage.IsAt, "failed to login");
            
        }

        [TestCleanup]
        public void Cleanup()
        {
            Driver.Cleanup();
>>>>>>> d5e65a9e7b4a4a40172443e8d44bd17e8b2b27d0
        }

    }
}
