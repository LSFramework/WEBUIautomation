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
        const string expMyPcOpened = ".//*[@id='MastheadDiv']/div[1]/div[1]/span";
        const string expMyPCLogin = "Performance Center";
        const string expTestSaved = @".//*[@id='ctl00_PageContent_lblStatus'][contains(text(),'Test saved')]";

        const string pathToScript = @"C:\ins\CloudSanityScript.zip";
                
        string scriptFolder = "scripts_" + Guid.NewGuid().ToString();
        string testFolder = "tests_" + Guid.NewGuid().ToString();
        string testName = "test_" + Guid.NewGuid().ToString();
        string expScriptName = "CloudSanityScript";


        [Test]
        public void Test1Go_To_MyPC()
        {
            ALMainPage.GoToMyPC(Properties.QCServer, Properties.ServerPort);
            Assert.AreEqual(expMyPCLogin, Driver.Instance.Title);
            }
        [Test]
        public void Test2Login_To_MyPC()
        {
            MyPCLoginPage.UserNameField.Clear();
            MyPCLoginPage.UserNameField.SendKeys(Properties.UserName);
            //MyPCLoginPage.PasswordField.Clear();
            //MyPCLoginPage.PasswordField.SendKeys(Properties.UserPassword);
            MyPCLoginPage.AuthenticateBtn.Click();
            MyPCLoginPage.DomainSelector.Click();
            MyPCLoginPage.Domains_DropDown.SelectItem(Properties.DomainName).Click();
            MyPCLoginPage.ProjectSelector.Click();
            MyPCLoginPage.Projects_DropDown.SelectItem(Properties.ProjectName).Click();           
            MyPCLoginPage.LoginBtn.Click();
            MyPCNavigation.SwitchToPopup();
            Assert.AreEqual(true, Driver.Instance.IsElementPresent(By.XPath(expMyPcOpened), 10));
        }

        [Test]
        public void Test3CreateTestPlanHierarchy()
        {
            TestPlan.CreateNewFolder(testFolder);
            TestPlan.CreateNewFolder(scriptFolder);
            TestPlan.UploadScript(pathToScript, scriptFolder);
            TestPlan.CreateNewTest(testName, testFolder);
            System.Threading.Thread.Sleep(3000);
            DesignLoadTest.Workload.WorkloadTypeDialog.btnOK.Click();
            DesignLoadTest.Tabs.tabGroupsAndWorkload.Click();
            DesignLoadTest.Workload.ScriptsTreeSlidingPane.SelectScript(expScriptName, scriptFolder);
            DesignLoadTest.Workload.GroupsAndWorkloadPane.row0GroupsGrid.Click();
            DesignLoadTest.Workload.ScriptsTreeSlidingPane.CloseScriptsTree();
            DesignLoadTest.Workload.GroupsAndWorkloadPane.inputNumberOfLGs.SendKeys("1");
            DesignLoadTest.Workload.GroupsAndWorkloadPane.row0GroupsGrid.Click();
            DesignLoadTest.ActionsFrame.btnSave.Click();
            Assert.AreEqual(true, Driver.Instance.IsElementPresent(By.XPath(expTestSaved), 10));
            MyPCNavigation.CloseDLT_Tab();
        }

        [Test]
        public void Test4AssignTestToTestSet()
        {
            TestLab.btnAssignTest.Click();
            AssignTestDialog.ComboTreeInput.Click();
            AssignTestDialog.SelectTest(testName, testFolder);
            AssignTestDialog.btnOk.Click();
        }

        [Test]
        public void Test5RunTest()
        {
            TestLab.SelectTestInGrid(testName);
            TestLab.btnRunTest.Click();
        }


    }
}
