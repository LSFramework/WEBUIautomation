using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBPages.BasePageObject;
using WEBPages.MyPCPages.DesignLoadTest;
using WEBUItests.Base_Test;


namespace WEBUItests.MyPCTests.Test_5_RunningTest
{

#pragma warning disable 1591

    using Variables = WEBUItests.TestVariables.Variables;

    /// <summary>
    /// Running test from TestPlan
    /// </summary>
    [TestFixture] [LoginIfNotLogged]
    public class Dlt_AddSLA: WEBUItest
    {
        DLT dlt;

        string testSetName = Variables.TestLab.testSetName;
        string testSetFolderName = Variables.TestLab.testSetFolderName;

        string tFolderName = Variables.TestPlan.testFolderName;
        string sFolderName = Variables.TestPlan.scriptFolderName;
        string tName = Variables.TestPlan.testName;
        string scriptName = Variables.TestPlan.scriptName;
        string scriptOnDisk = Variables.TestPlan.pathToScript + Variables.TestPlan.scriptName;
        string script = Variables.TestPlan.script;
       
        
        [Test]
        public void Step_01_NavigateSummary()
        {
           dlt = new DLT(new LoadTest(tName));
        }

        [Test]
        public void Step2()
        {
            dlt.Summary.ClickAddNewSlaBtn();
        }

    }

#pragma warning disable 1591
}
