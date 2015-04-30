using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBPages.Pages;
using WEBPages.Pages.TestPlan;
using WEBPages.Pages.TestPlan.ModalDialogues;
using WEBUItests.Base_Test;
using WEBUItests.TestVariables;

namespace WEBUItests.MyPCTests.Test_3_TestManagement_TestPlan
{
  
    /// <summary>
    /// Creates Test plan items
    /// </summary>
    [TestFixture][LoginIfNotLogged]
    public class TestPlan:WEBUItest
    {

        MainHead mainHead = new MainHead();
        TestPlanPage testPlan;
        CreateTestFolderDialog createTestFolderDialog;

        string tFolderName = Variables.TestPlan.testFolderName;
        string sFolderName = Variables.TestPlan.scriptFolderName;
        string tName = Variables.TestPlan.testName;
        string subject = Variables.TestPlan.subjectFolder;



        /// <summary>
        /// Navigate to Test Plan perspective
        /// </summary>
        [Test]
        public void Step_1_NavigateToTestPlan()
        {
            testPlan = new TestPlanPage();
            Assert.True(testPlan.Opened);
        }


        /// <summary>
        /// Select Subject Folder on tree
        /// </summary>
        [Test]
        public void Step_2_SelectSubjectFolder()
        {
            testPlan.SelectSubjectFolder();
           Assert.True(testPlan.IsFolderSelected("Subject"));
        }

        /// <summary>
        /// Open Ceate New Test Folder Dialog
        /// </summary>
        [Test]
        public void Step_3_OpenCreateFolderDailog()
        {
            createTestFolderDialog = testPlan.OpenCreateNewFolderDialog(subject);
            Assert.True(createTestFolderDialog.Opened);
        }

        /// <summary>
        /// Type Folder name
        /// </summary>
        [Test]
        public void Step_4_TypeNewFolderName()
        {
            createTestFolderDialog.TypeFolderName(tFolderName);
            Assert.AreEqual(createTestFolderDialog.GetFolderNameText(), tFolderName);
        }
        /// <summary>
        /// Confirm Create Folder and check the dialogue has been closed.
        /// </summary>
        [Test]
        public void Step_5_Confirm()
        {
            testPlan=createTestFolderDialog.ClickOkBtn();           
            Assert.False(createTestFolderDialog.Opened);
          
        }

        /// <summary>
        /// Check has Test Plan opened
        /// </summary>
        [Test]
        public void Step_6_CheckTestPlanOpened()
        {
            Assert.True(testPlan.Opened);
        }

        /// <summary>
        /// Check if the new folder selected in the testplan tree
        /// </summary>
        [Test]
        public void Step_7_CheckIsFolderCreated()
        {
            Assert.True(testPlan.IsFolderSelected(tFolderName));
        }

    }
}
