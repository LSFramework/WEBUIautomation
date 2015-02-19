﻿using NUnit.Framework;
using WEBUIautomation.Utils;
using WEBPages.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using WEBUIautomation;
using System;
using System.Threading;

namespace WEBUItests.Smoke_Tests
{
    [TestFixture]
    public class LoginInMypc : WEBUItest
    {
        const string pathToScript = @"C:\ins\CloudSanityScript.zip";

        [Test]
        public void Login_In_MyPC()
        {
            ALMainPage.GoToMyPC(Properties.QCServer, Properties.ServerPort);
            MyPCLoginPage.UserNameField.Clear();
            MyPCLoginPage.UserNameField.SendKeys(Properties.UserName);
            MyPCLoginPage.PasswordField.Clear();
            MyPCLoginPage.PasswordField.SendKeys(Properties.UserPassword);
            MyPCLoginPage.AuthenticateBtn.Click();
            MyPCLoginPage.DomainSelector.Click();
            MyPCLoginPage.Domains_DropDown.SelectItem(Properties.DomainName).Click();
            MyPCLoginPage.ProjectSelector.Click();
            MyPCLoginPage.Projects_DropDown.SelectItem(Properties.ProjectName).Click();           
            MyPCLoginPage.LoginBtn.Click();
            MyPCNavigation.SwitchToPopup();
            TestPlan.CreateNewFolder("tests_" + Guid.NewGuid().ToString());
            TestPlan.CreateNewFolder("scripts_" + Guid.NewGuid().ToString());
            TestPlan.UploadScript(pathToScript);
            TestPlan.CreateNewTest("performance_test1_" + Guid.NewGuid().ToString());
            System.Threading.Thread.Sleep(3000);
            DesignLoadTest.WorkloadTypeDialog.btnOK.Click();
            DesignLoadTest.Tabs.tabGroupsAndWorkload.Click();
           
        }
        
    }
}
