using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using WEBUItests.Base_Test;
using WEBPages.MyPCPages.DesignLoadTest;
using WEBPages.BasePageObject;

namespace WEBUItests.TestsDebug
{

#pragma warning disable 1591

    /// <summary>
    /// Adding SLA to test via DLT
    /// </summary>
    [TestFixture]
    [LoginIfNotLogged]
    public class Dlt_AddSLA : WEBUItest
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
