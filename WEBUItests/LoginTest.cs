﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WEBUIautomation;

namespace WEBUItests
{
    [TestClass]
    public class LoginTest : WEBUItest
    {
        [TestMethod]
        public void Login_In_Webui()
        {
            LoginPage.SelectWebui(Properties.QCServer);

            LoginPage.EnterName(Properties.UserName);
            LoginPage.EnterPassword(Properties.UserPasswod);

            LoginPage.Authenticate();
            LoginPage.SelectDomain(Properties.Domain);
            LoginPage.SelectProject(Properties.ProjectName);
            LoginPage.Submit();

            Assert.IsTrue(AlmHeader.IsAt, "failed to login");
            Assert.IsTrue(AlmHeader.CheckValidLogin(Properties.Domain, Properties.ProjectName), "wrong domain/project");
        }
        
        [TestMethod]
        public void Change_ProjectDomain()
        {
            Login_In_Webui();
            // All below requires a fix, because if you switch between domains/projects it not don;t hide head bar (issue with IsAt) 
            //and update of project title is slow (it make a issue for CheckValidLogin method: it takes a wrong parameters)
            AlmHeader.ChangeProjectDomain("vuds_1", "ALEXG"); 

            Assert.IsTrue(AlmHeader.IsAt, "failed to login");
            Assert.IsTrue(AlmHeader.CheckValidUsername(Properties.UserName), "wrong username");
            //Assert.IsTrue(AlmHeader.CheckValidLogin("OLEG", "Sanity"), "wrong domain/project"); // still issue (
        }        

    }
}
