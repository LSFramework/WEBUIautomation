using NUnit.Framework;
using WEBPages.MyPCPages;
using WEBPages.MyPCPages.DesignLoadTest;
using WEBPages.MyPCPages.Online;
using WEBPages.MyPCPages.TestRunDialog;
using WEBUIautomation.Wait;
using WEBUItests.Base_Test;
using WEBUItests.TestVariables;

namespace WEBUItests.MyPCTests.Test_4_DesignLoadTest
{

    /// <summary>
    /// DLT
    /// </summary>
    [TestFixture]
    public class DesignLoadTest: WEBUItest
    {

        #region Variables

        TestPlanFunctionality testPlanFunctionality;
        DLT dlt;

        string testSetName          = Variables.TestLab.testSetName;
        string testSetFolderName    = Variables.TestLab.testSetFolderName;

        string tFolderName          = Variables.TestPlan.testFolderName;
        string sFolderName          = Variables.TestPlan.scriptFolderName;
        string tName                = Variables.TestPlan.testName;
        
        string scriptZipName        = Variables.TestPlan.scriptName;
        string scriptOnDisk         = Variables.TestPlan.pathToScript + Variables.TestPlan.scriptName;
        string script               = Variables.TestPlan.script;

        #endregion Variables

        #region TestSteps

        /// <summary>
        /// Create new LoadTest And Navigate Dlt
        /// </summary>
        [Test]
        public void Step_0_NavigateDltByCreatingTest()
        {
            testPlanFunctionality = new TestPlanFunctionality();
            dlt = testPlanFunctionality.CreateTest(tFolderName, tName, testSetFolderName, testSetName);
        }


        /// <summary>
        /// Set ComplexByLTByNumber Workload mode
        /// </summary>
        [Test]
        public void Step_01_SetWorkloadMode_ComplexByLTByNumber()
        {
            dlt.Workload.SetWorkloadMode(WorkloadMode.ComplexByLTByNumber);
        }


        /// <summary>
        /// Add one LG
        /// </summary>
        [Test]
        public void Step_02_AddLGToDlt()
        {
            dlt.Workload.AddNumberOfLGs(1);
        }

        /// <summary>
        /// Add a script to LoadTest
        /// </summary>
        [Test]
        public void Step_03_AddScriptToDlt()
        {
            dlt.Workload.AddScript(sFolderName, script);
        }


        /// <summary>
        /// Collaps Scripts Tree Panel
        /// </summary>
        [Test]
        public void Step_04_CloseScriptsPane()
        {
            dlt.Workload.CollapseScriptsSlidingPane();
        }


        /// <summary>
        /// Save the test
        /// </summary>
        [Test]
        public void Step_05_SaveTest()
        {
            dlt.Workload.Save();
            WaitHelper.Wait(3000); // To see result
        }

        /// <summary>
        /// Open SAL window
        /// </summary>
        [Test]
        public void Step_06_AddSLA()
        {
            dlt.Summary.SetSLA();
        }


        /// <summary>
        /// Save the test with SLA 
        /// </summary>
        [Test]
        public void Step_07_SaveTest()
        {
            dlt.Workload.Save();
            WaitHelper.Wait(3000); // Just to see result
        }


        /// <summary>
        /// Run the test
        /// </summary>
        [Test]
        public void Step_09_RunTest()
        {
            dlt.Workload.Run();
            WaitHelper.Wait(3000); // Just to see result
        }

        /// <summary>
        /// Online
        /// </summary>
        [Test]
        public void Step_10_GetOnlineScreen()
        {
            StartRunDialog start = new StartRunDialog();
            start.StartRunTestIfAvailable();

          //  WaitHelper.Wait(TimeSpan.FromMinutes(3).Milliseconds); // <=Sould be replaced for Initialization Form 


            OnlineScreen online = new OnlineScreen(dlt.LoadTest);
            online.WaitForTestFinished();
            online.CloseButtonClick();
        }

        /// <summary>
        /// Navigate Sart tab
        /// </summary>
        [Test]
        public void Step_11_NavigateToStartTab()
        {
            StartTab startTab = new StartTab();
        }

        /// <summary>
        /// 
        /// </summary>
        public void Step_12_SelectFinishedRun()
        { 
            //
        }

        #endregion TestSteps

    }
}
