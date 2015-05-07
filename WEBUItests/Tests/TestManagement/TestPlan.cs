using NUnit.Framework;
using WEBPages.MyPCPages;
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
        TestPlanPage testPlan;
        CreateTestFolderDialog createTestFolderDialog;
        TestPlanActions testPlanAction;


        string tFolderName  = Variables.TestPlan.testFolderName;
        string sFolderName  = Variables.TestPlan.scriptFolderName;
        string tName        = Variables.TestPlan.testName;
        string subject      = Variables.TestPlan.subjectFolder;


        /// <summary>
        /// Navigate to Test Plan perspective
        /// </summary>
        [Test]
        public void Step_1_NavigateToTestPlan()
        {
            testPlan = new TestPlanPage();
            Assert.True(testPlan.ViewOpened);
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
            Assert.True(createTestFolderDialog.ViewOpened);
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
            Assert.False(createTestFolderDialog.ViewOpened);
          
        }

        /// <summary>
        /// Check has Test Plan opened
        /// </summary>
        [Test]
        public void Step_6_CheckTestPlanOpened()
        {
            Assert.True(testPlan.ViewOpened);
        }

        /// <summary>
        /// Check if the new folder selected in the testplan tree
        /// </summary>
        [Test]
        public void Step_7_CheckIsFolderCreated()
        {
            Assert.True(testPlan.IsFolderSelected(tFolderName));
        }
        
        /// <summary>
        /// Creates folder to save the loadtest scripts.
        /// Checks is folder has been created successfully and it has been selected in Test Plan tree.
        /// </summary>
        [Test]
        public void Step_8_CreateScriptsFolder()
        {
            testPlanAction = new TestPlanActions();
            testPlanAction.CreateFolder(sFolderName);
            Assert.True(testPlanAction.IsFolderSelected(sFolderName));
        }


        /// <summary>
        /// Check the same of Step 8 from Test Plan object.
        /// </summary>
        [Test]
        public void Step_9_checkFromTestPlanObject()
        { 
            Assert.True(testPlan.IsFolderSelected(sFolderName));
        }
    }
}
