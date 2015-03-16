using NUnit.Framework;
using WEBUIautomation.Utils;
using WEBPages.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using WEBUIautomation;
using System;
using System.Threading;
using TestStack.BDDfy;

namespace WEBUItests.Smoke_Tests
{
    [TestFixture]
    public class LoginInMypc : WEBUItest //BrowsersTestBase //
    {

        #region Private Constatns

        const string expMyPcOpened = "MastheadDiv";      
        
        //string expScriptName = "CloudSanityScript";

        #endregion Private Constatns

        #region SetUp

        [SetUp]
        public void ThisTestSetUp()        
        {
            base.SetUp();
            this.Given(_ => GivenIAmOnLoginPerformanceCenterPage())
                .When(_ => WhenIFeelAllRequiredFields())
                .And(_ => AndClickTheLoginButton())
                .Then(_ => ThenIShouldBeLoggedInPerformanceCenter())
                .BDDfy(); 
        }
        
        #endregion

        #region Helpers methods to test functionality

        #region To login
        
        public void GivenIAmOnLoginPerformanceCenterPage()
        {
            ALMainPage.GoToMyPC(Properties.QCServer, Properties.ServerPort);
        }

        public void WhenIFeelAllRequiredFields()
        {
            MyPCLoginPage.TypeUserName(Properties.UserName);
            MyPCLoginPage.TypePassword(Properties.UserPassword);
            MyPCLoginPage.ClickAuthenticate();
            MyPCLoginPage.SelectDomain(Properties.DomainName);
            MyPCLoginPage.SelectProject(Properties.ProjectName);
        }

        public void AndClickTheLoginButton()
        {
            MyPCLoginPage.ClickLogin();
        }

        public void ThenIShouldBeLoggedInPerformanceCenter()
        {
            MyPCNavigation.SwitchToPopup();
            Assert.True( // Check that userName, Domain and Project are shown on page as expected
                MyPCNavigation.GetDomainName().Contains(Properties.DomainName)
            &&  MyPCNavigation.GetProjectName().Contains(Properties.ProjectName)
            &&  MyPCNavigation.GetUserLoggedIn().Contains(Properties.UserName));
        }
       
        #endregion /To Login

   

        #region To Delete All from Test Plan

        public void WhenIObserveTheTestPlanTree()
        {
            TestPlan.ExpandTreeAndFillItemsLists();
        }

        private void ThenIDeleteAllItemsFromTestPlanTree()
        {
            TestPlan.CleanTestPlanTree();
        }

        #endregion /To Delete All from Test Plan

        #endregion Helpers methods to test functionality

        #region Tests



        //void _CleanAllFromTestPlan()
        //{
        //    this.Given(_ => GivenIAmOnTestPlan())
        //        .When(_ => WhenIObserveTheTestPlanTree())
        //        .Then(_ => ThenIDeleteAllItemsFromTestPlanTree())
        //        .BDDfy();
        //}

        

        //[Test]
        // public void CreateTestPlanEntities()
        // {
        //     //_CreateTestPlanEntities();
        //     //_CleanAllFromTestPlan();
        // }


        #endregion Tests


        //[Test ]
        //public void Test1PlanCRUD()
        //{
        //    TestPlan.CreateNewFolder(testFolder);
        //    TestPlan.CreateNewFolder(scriptFolder);
        //    TestPlan.UploadScript(pathToScript, scriptFolder);
        //    TestPlan.CreateNewTest(testName, testFolder);
        //    System.Threading.Thread.Sleep(3000);
        //    this.BDDfy();
        //}
        //[Test]
        //public void Test2DLT()
        //{
        //    DesignLoadTest.Workload.WorkloadTypeDialog.btnOK.Click();
        //    DesignLoadTest.Tabs.tabGroupsAndWorkload.Click();
        //    DesignLoadTest.Workload.ScriptsTreeSlidingPane.SelectScript(expScriptName, scriptFolder);
        //    DesignLoadTest.Workload.GroupsAndWorkloadPane.row0GroupsGrid.Click();
        //    DesignLoadTest.Workload.ScriptsTreeSlidingPane.CloseScriptsTree();
        //    DesignLoadTest.Workload.GroupsAndWorkloadPane.inputNumberOfLGs.SendKeys("1");
        //    DesignLoadTest.Workload.GroupsAndWorkloadPane.row0GroupsGrid.Click();
        //    DesignLoadTest.ActionsFrame.btnSave.Click();
        //    Assert.AreEqual(true, Driver.Instance.IsElementPresent(By.XPath(expTestSaved), 10));
        //    MyPCNavigation.CloseDLT_Tab();
        //    this.BDDfy();
        //}


        //[Test]
        //public void Test3AssignTestToTestSet()
        //{
        //    TestLab.btnAssignTest.Click();
        //    AssignTestDialog.ComboTreeInput.Click();
        //    AssignTestDialog.SelectTest(testName, testFolder);
        //    AssignTestDialog.btnOk.Click();
        //    Driver.Wait(1);
        //    this.BDDfy();
        //}

        //[Test]
        //public void Test4RunTest()
        //{
        //    MyPCNavigation.btnRefresh.Click();
        //    TestLab.SelectTestInGrid(testName);
        //    TestLab.btnRunTest.Click();
        //    StartRunDialog.btnRun.Click();
        //    Driver.Wait(60);
        //    this.BDDfy();
        //}

        //public void ClearTestPlan()
        //{
        //    MyPCNavigation.Home.Click();
        //    TestPlan.DeleteNode(expScriptName);
        //    TestPlan.DeleteNode(scriptFolder);
        //    TestPlan.DeleteNode(testName);
        //    TestPlan.DeleteNode(testFolder);
        //    MyPCNavigation.LogoutBtn.Click();
        //    this.BDDfy();
        //}


        [TearDown]
        public void thisTearDown()
        {
           // ClearTestPlan();
            base.TearDown();
        }
    }
}
