using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBPages.Pages;
using TestStack.BDDfy;

namespace WEBUItests.Smoke_Tests.MyPC
{
    [TestFixture]
    public class Create_Test_Plan_Items : LoginInMypc
    {

        const string expTestSaved = @".//*[@id='ctl00_PageContent_lblStatus'][contains(text(),'Test saved')]";
        const string pathToScript = @"C:\ins\CloudSanityScript.zip";
        string scriptFolder = "scripts_" + Guid.NewGuid().ToString();
        string testFolder = "tests_" + Guid.NewGuid().ToString();
        string testName = "test_" + Guid.NewGuid().ToString();

        #region To Create Test Plan

        public void GivenIAmOnTestPlan()
        {
            IWebElement element = TestPlan.TreePane;
        }

        public void WhenICreateTheFolders()
        {
            TestPlan.CreateNewFolder(testFolder);
            TestPlan.CreateNewFolder(scriptFolder);
        }

        public void AndAddScript()
        {
            TestPlan.UploadScript(pathToScript, scriptFolder);
        }
        public void AndCreateTest()
        {
            TestPlan.CreateNewTest(testName, testFolder);
        }
        public void ThenTheDLTScreenWithWorkloadTypeDialogShouldBeOpened()
        {
            IWebElement element = DesignLoadTest.Workload.WorkloadTypeDialog.btnOK;
            element.Click();
        }

        #endregion  /To Create Test Plan

        [Test]
        public void _CreateTestPlanEntities()
        {
            this.Given(_ => GivenIAmOnTestPlan())
                 .When(_ => WhenICreateTheFolders())
                  .And(_ => AndAddScript())
                  .And(_ => AndCreateTest())
                 .Then(_ => ThenTheDLTScreenWithWorkloadTypeDialogShouldBeOpened())
                 .BDDfy();
        }

    }
}
