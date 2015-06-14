using NUnit.Framework;
using WEBPages.MyPCPages;
using WEBPages.MyPCPages.DesignLoadTest;
using WEBUItests.Base_Test;
using WEBUItests.TestVariables;

namespace WEBUItests.MyPCTests.Test_3_TestManagement_TestPlan
{
  
    /// <summary>
    /// Creates Test plan items
    /// </summary>
    [TestFixture][LoginIfNotLogged]
    public class TestPlan : WEBUItest
    {
       
        TestPlanFunctionality testPlanFunctionality;

        string testSetName = Variables.TestLab.testSetName;
        string testSetFolderName = Variables.TestLab.testSetFolderName;

        string tFolderName  = Variables.TestPlan.testFolderName;
        string sFolderName  = Variables.TestPlan.scriptFolderName;
        string tName        = Variables.TestPlan.testName;
        string scriptName   = Variables.TestPlan.scriptName;
        string scriptOnDisk = Variables.TestPlan.pathToScript + Variables.TestPlan.scriptName;
        string script       = Variables.TestPlan.script;


        /// <summary>
        /// Navigate to Test Plan perspective
        /// </summary>
        [Test]
        public void Step_01_NavigateToTestPlan()
        {
            //testPlan = new TestPlanPage();
            testPlanFunctionality = new TestPlanFunctionality();
            Assert.True(testPlanFunctionality.ViewOpened);
        }

       
        /// <summary>
        /// Creates folder to save the loadtest scripts.
        /// Checks is folder has been created successfully and it has been selected in Test Plan tree.
        /// </summary>
        [Test]
        public void Step_02_CreateScriptsFolder()
        {
            testPlanFunctionality.CreateFolder(sFolderName);
        }

        /// <summary>
        /// Upload script to test plan folder
        /// </summary>
        [Test]
        public void Step_03_UploadScript()
        {
            testPlanFunctionality.UploadScript(sFolderName, scriptOnDisk);
        }

        /// <summary>
        /// Creates folder to save the loadtest scripts.
        /// Checks is folder has been created successfully and it has been selected in Test Plan tree.
        /// </summary>
        [Test]
        public void Step_04_CreateTestsFolder()
        {
            //testPlanFunctionality = new TestPlanFunctionality();
            testPlanFunctionality.CreateFolder(tFolderName);
        }

        
    }
}
