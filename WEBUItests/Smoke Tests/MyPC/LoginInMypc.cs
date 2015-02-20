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
<<<<<<< HEAD
        
        string scriptFolder = "scripts" + Guid.NewGuid().ToString();
        string testFolder = "tests" + Guid.NewGuid().ToString();
        string testName = "test1" + Guid.NewGuid().ToString();
        
=======
        string scriptFolder = "scripts_" + Guid.NewGuid().ToString();
        string testFolder = "tests_" + Guid.NewGuid().ToString();
        string testName = "test_" + Guid.NewGuid().ToString();
        string expScriptName = "CloudSanityScript";

>>>>>>> origin/PC_1250
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
<<<<<<< HEAD

            TestPlan.CreateNewFolder(testFolder);
            TestPlan.CreateNewFolder(scriptFolder);
            //TestPlan.UploadScript(pathToScript, scriptFolder);
            TestPlan.CreateNewTest(testName);
=======
            TestPlan.CreateNewFolder(testFolder);
            TestPlan.CreateNewFolder(scriptFolder);
            TestPlan.UploadScript(pathToScript, scriptFolder);
            TestPlan.CreateNewTest(testName, testFolder);
>>>>>>> origin/PC_1250
            System.Threading.Thread.Sleep(3000);
            DesignLoadTest.Workload.WorkloadTypeDialog.btnOK.Click();
            DesignLoadTest.Tabs.tabGroupsAndWorkload.Click();
            DesignLoadTest.Workload.ScriptsTreeSlidingPane.SelectScript(expScriptName, scriptFolder);
            DesignLoadTest.Workload.GroupsAndWorkloadPane.row0GroupsGrid.Click();           
            DesignLoadTest.Workload.GroupsAndWorkloadPane.inputNumberOfLGs.SendKeys("1");
            DesignLoadTest.Workload.GroupsAndWorkloadPane.row0GroupsGrid.Click();
            DesignLoadTest.ActionsFrame.btnSave.Click();                    
        }
        
    }
}
