using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WEBUIautomation;
using System.Threading;

namespace WEBUItests
{
    [TestClass]
    public class LoginTest
    {
        [TestInitialize]
        public void Initialize()
        {
            Driver.Initialize();
        }

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

            //Thread.Sleep(5000);
            Assert.IsTrue(DashboardPage.IsAt, "failed to login");
            
        }
    }
}
