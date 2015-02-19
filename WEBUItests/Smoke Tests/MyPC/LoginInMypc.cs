using NUnit.Framework;
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


        string scriptFolder = "scripts" + Guid.NewGuid().ToString();
        string testFolder = "tests" + Guid.NewGuid().ToString();
        string testName = "test1" + Guid.NewGuid().ToString();
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
            TestPlan.CreateNewFolder(testFolder);
            TestPlan.CreateNewFolder(scriptFolder);
            TestPlan.UploadScript(pathToScript, scriptFolder);
            TestPlan.CreateNewTest(testName);
            System.Threading.Thread.Sleep(3000);
            DesignLoadTest.WorkloadTypeDialog.btnOK.Click();
            DesignLoadTest.Tabs.tabGroupsAndWorkload.Click();
           
        }
        
    }
}
