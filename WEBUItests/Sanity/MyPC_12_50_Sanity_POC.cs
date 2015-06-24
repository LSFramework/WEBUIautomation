using NUnit.Framework;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBPages.MyPCPages;
using WEBPages.MyPCPages.DesignLoadTest;
using WEBPages.MyPCPages.Online;
using WEBPages.MyPCPages.TestRunDialog;
using WEBUIautomation.Utils;
using WEBUIautomation.Wait;
using WEBUItests.Base_Test;
using WEBUItests.TestVariables;

namespace WEBUItests.Sanity
{


    /// <summary>
    /// Sanity
    /// </summary>
    [TestFixture]
    public class MyPC_12_50_Sanity_POC : BrowsersTestBase
    {
        private MainHead mainHead = new MainHead();
        private TestLabPage testLabPage;
        private ManageTestSetsDialog dlgMngTestSets;
        private NewTestSetFolderDialog dlgCreateTestFolder;
        private NewTestSetDialog dlgCreateTesSet;
        private TestPlanFunctionality testPlanFunctionality;
        private DLT dlt;


        private RunTimeVariables variables = new RunTimeVariables();

        private string testSetFolderName { get { return variables.testSetFolderName; } }
        private string testSetName { get { return variables.testSetName; } }
        private string testFolderName { get { return variables.testFolderName; } }
        private string scriptFolderName { get { return variables.scriptFolderName; } }
        private string testName { get { return variables.testName; } }
        private string scriptName = StaticVariables.TestPlan.scriptName;
        private string scriptOnDisk = StaticVariables.TestPlan.pathToScript + StaticVariables.TestPlan.scriptName;
        private string script = StaticVariables.TestPlan.script;
        private TimeSpan duration = TimeSpan.FromMinutes(1);


        /// <summary>
        /// Navigate to Test Lab perspective
        /// </summary>
        [Test]
        public void Step_01_NavigateToTestLab()
        {
            testLabPage = new TestLabPage();
            Assert.True(testLabPage.ViewOpened);
        }

        /// <summary>
        /// Open Manage Test Sets Dialog
        /// </summary>
        [Test]
        public void Step_02_ClickManageTestSets()
        {
            dlgMngTestSets = testLabPage.ClickManageTestSets();
            Assert.True(dlgMngTestSets.ViewOpened);
        }

        /// <summary>
        /// Select "Root" Folder
        /// </summary>
        [Test]
        public void Step_03_SelectRootFolder()
        {
            dlgMngTestSets = dlgMngTestSets.SelectRootFolder();
            Assert.AreEqual("Root", dlgMngTestSets.SelectedFolder);
        }

        /// <summary>
        /// Open a new test set folder dialog
        /// </summary>
        [Test]
        public void Step_04_OpenNewTestSetFolderDialog()
        {
            dlgCreateTestFolder = dlgMngTestSets.btnNewFolderClick();
            Assert.True(dlgCreateTestFolder.ViewOpened);
        }

        /// <summary>
        /// Type folder name to input field. 
        /// Checks that input field was filled.
        /// </summary>
        [Test]
        public void Step_05_TypeFolderName()
        {
            dlgCreateTestFolder = dlgCreateTestFolder.TypeFolderName(testSetFolderName);
            Assert.AreEqual(testSetFolderName, dlgCreateTestFolder.FolderName);
        }

        /// <summary>
        /// Confirm creating of the folder. 
        /// Checks that "Create test folder dialog" closed and the "Manage test sets dialog" has focus. 
        /// </summary>
        [Test]
        public void Step_06_ConfirmCreateTestFolder()
        {
            dlgMngTestSets = dlgCreateTestFolder.ClickOKExpectedSuccess();
            Assert.True(dlgMngTestSets.ViewOpened);
        }

        /// <summary>
        /// Select the created folder in tree.
        /// Checks that folder is selected.
        /// </summary>
        [Test]
        public void Step_07_CheckIsFolderCreated()
        {
            dlgMngTestSets.SelectFolder(testSetFolderName);
            Assert.AreEqual(testSetFolderName, dlgMngTestSets.SelectedFolder);
        }

        /// <summary>
        /// Open New Test Set Dialog
        /// Checks that Create Folder dialog opened.
        /// </summary>
        [Test]
        public void Step_08_OpenNewTestSetDialog()
        {
            dlgCreateTesSet = dlgMngTestSets.btnNewTestSetClick();
            Assert.True(dlgCreateTesSet.ViewOpened);
        }

        /// <summary>
        /// Type test set name.
        /// Checks that input field was filled.
        /// </summary>
        [Test]
        public void Step_09_TypeTestSetName()
        {
            dlgCreateTesSet.TypeTestSetName(testSetName);
            Assert.AreEqual(testSetName, dlgCreateTesSet.TestSetName);
        }

        /// <summary>
        /// Confirm creating of the test set. 
        /// Checks that "Create test set dialog" closed and the "Manage test sets dialog" has focus. 
        /// </summary>
        [Test]
        public void Step_10_ConfirmCreateTestSet()
        {
            dlgMngTestSets = dlgCreateTesSet.ClickOkExpectingSucces();
            Assert.True(dlgMngTestSets.ViewOpened);
        }


        /// <summary>
        /// Select test set in tree and close the "Manage test sets dialog"
        /// Checks that Tes Lab perspective got focus.
        /// </summary>
        [Test]
        public void Step_11_SelectTestSet()
        {
            testLabPage = dlgMngTestSets.SelectTestSet(testSetFolderName, testSetName);
            Assert.True(testLabPage.ViewOpened);
        }       


        /// <summary>
        /// Navigate to Test Plan perspective
        /// </summary>
        [Test]
        public void Step_12_NavigateToTestPlan()
        {
            
            testPlanFunctionality = new TestPlanFunctionality();
            Assert.True(testPlanFunctionality.ViewOpened);
        }


        /// <summary>
        /// Creates folder to save the loadtest scripts.
        /// Checks is folder has been created successfully and it has been selected in Test Plan tree.
        /// </summary>
        [Test]
        public void Step_13_CreateScriptsFolder()
        {
            testPlanFunctionality.CreateFolder(scriptFolderName);
        }

        /// <summary>
        /// Upload script to test plan folder
        /// </summary>
        [Test]
        public void Step_14_UploadScript()
        {
            testPlanFunctionality.UploadScript(scriptFolderName, scriptOnDisk);
        }

        /// <summary>
        /// Creates folder to save the loadtest scripts.
        /// Checks is folder has been created successfully and it has been selected in Test Plan tree.
        /// </summary>
        [Test]
        public void Step_15_CreateTestsFolder()
        {
           
            testPlanFunctionality.CreateFolder(testFolderName);
        }


        /// <summary>
        /// Create new LoadTest And Navigate Dlt
        /// </summary>
        [Test]
        public void Step_16_NavigateDltByCreatingTest()
        {
        
            dlt = testPlanFunctionality.CreateTest(testFolderName, testName, testSetFolderName, testSetName);
        }


        /// <summary>
        /// Set ComplexByLTByNumber Workload mode
        /// </summary>
        [Test]
        public void Step_17_SetWorkloadMode_ComplexByLTByNumber()
        {
            dlt.Workload.SetWorkloadMode(WorkloadMode.ComplexByLTByNumber);
        }


        /// <summary>
        /// Add one LG
        /// </summary>
        [Test]
        public void Step_18_AddLGToDlt()
        {
            dlt.Workload.AddNumberOfLGs(1);
        }

        /// <summary>
        /// Add a script to LoadTest
        /// </summary>
        [Test]
        public void Step_19_AddScriptToDlt()
        {
            dlt.Workload.AddScript(scriptFolderName, script);
        }


        /// <summary>
        /// Collaps Scripts Tree Panel
        /// </summary>
        [Test]
        public void Step_20_CloseScriptsPane()
        {
            dlt.Workload.CollapseScriptsSlidingPane();
        }


        /// <summary>
        /// Change duratuon of the performance test
        /// </summary>
        [Test]
        public void Step_21_ChangeDuration()
        {
            dlt.Workload.SetDuration(duration);
        }

        /// <summary>
        /// Save the test
        /// </summary>
        [Test]
        public void Step_21_SaveTest()
        {
            dlt.Workload.Save();
            WaitHelper.Wait(3000); // To see result
        }

        /// <summary>
        /// Open SAL window
        /// </summary>
        [Test]
        public void Step_22_AddSLA()
        {
            dlt.Summary.SetSLA();
        }


        /// <summary>
        /// Save the test with SLA 
        /// </summary>
        [Test]
        public void Step_23_SaveTest()
        {
            dlt.Workload.Save();
            WaitHelper.Wait(3000); // Just to see result
        }


        /// <summary>
        /// Run the test
        /// </summary>
        [Test]
        public void Step_24_RunTest()
        {
            dlt.Workload.Run();
            WaitHelper.Wait(3000); // Just to see result
        }

        /// <summary>
        /// Online
        /// </summary>
        [Test]
        public void Step_25_GetOnlineScreen()
        {
            StartRunDialog start = new StartRunDialog();
            start.StartRunTestIfAvailable();         

            OnlineScreen online = new OnlineScreen(dlt.LoadTest);
            online.WaitForTestFinished();
            online.CloseButtonClick();
        }

        /// <summary>
        /// Navigate Sart tab
        /// </summary>
        [Test]
        public void Step_26_NavigateToStartTab()
        {
            StartTab startTab = new StartTab();
        }

        /// <summary>
        /// Performs click on logout button
        /// </summary>
        [Test]
        public void Step_Last_Logout()
        {
            if (Driver.Instance != null)
                mainHead.ClickLogout();
        }
    }
}
