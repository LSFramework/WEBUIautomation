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
        string scriptName   = Variables.TestPlan.scriptName;
        string scriptOnDisk = Variables.TestPlan.pathToScript + Variables.TestPlan.scriptName; 


        /// <summary>
        /// Navigate to Test Plan perspective
        /// </summary>
        [Test]
        public void Step_01_NavigateToTestPlan()
        {
            testPlan = new TestPlanPage();
            Assert.True(testPlan.ViewOpened);
        }

        /// <summary>
        /// Select Subject Folder on tree
        /// </summary>
        [Test]
        public void Step_02_SelectSubjectFolder()
        {
            testPlan.SelectSubjectFolder();
           Assert.True(testPlan.IsFolderSelected("Subject"));
        }

        /// <summary>
        /// Open Ceate New Test Folder Dialog
        /// </summary>
        [Test]
        public void Step_03_OpenCreateFolderDailog()
        {
            createTestFolderDialog = testPlan.OpenCreateNewFolderDialog(subject);
            Assert.True(createTestFolderDialog.ViewOpened);
        }

        /// <summary>
        /// Type Folder name
        /// </summary>
        [Test]
        public void Step_04_TypeNewFolderName()
        {
            createTestFolderDialog.TypeFolderName(tFolderName);
            Assert.AreEqual(createTestFolderDialog.GetFolderNameText(), tFolderName);
        }
        /// <summary>
        /// Confirm Create Folder and check the dialogue has been closed.
        /// </summary>
        [Test]
        public void Step_05_Confirm()
        {
            testPlan=createTestFolderDialog.ClickOkBtn();
            Assert.False(createTestFolderDialog.ViewOpened);
          
        }

        /// <summary>
        /// Check has Test Plan opened
        /// </summary>
        [Test]
        public void Step_06_CheckTestPlanOpened()
        {
            Assert.True(testPlan.ViewOpened);
        }

        /// <summary>
        /// Check if the new folder selected in the testplan tree
        /// </summary>
        [Test]
        public void Step_07_CheckIsFolderCreated()
        {
            Assert.True(testPlan.IsFolderSelected(tFolderName));
        }
        
        /// <summary>
        /// Creates folder to save the loadtest scripts.
        /// Checks is folder has been created successfully and it has been selected in Test Plan tree.
        /// </summary>
        [Test]
        public void Step_08_CreateScriptsFolder()
        {
            testPlanAction = new TestPlanActions();
            testPlanAction.CreateFolder(sFolderName);
            Assert.True(testPlanAction.IsFolderSelected(sFolderName));
        }

        /// <summary>
        /// Check the same of Step 8 from Test Plan object.
        /// </summary>
        [Test]
        public void Step_09_checkFromTestPlanObject()
        { 
            Assert.True(testPlan.IsFolderSelected(sFolderName));
        }

        /// <summary>
        /// Upload script to test plan folder
        /// </summary>
        [Test]
        public void Step_10_UploadScript()
        {
            testPlanAction.UploadScript(sFolderName, scriptOnDisk);
        }
    }
}
