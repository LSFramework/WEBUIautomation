﻿using System;
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

            Assert.IsTrue(DashboardPage.IsAt, "failed to login");
            
        }

        [TestCleanup]
        public void Cleanup()
        {
            Driver.Cleanup();
        }
    }
}
