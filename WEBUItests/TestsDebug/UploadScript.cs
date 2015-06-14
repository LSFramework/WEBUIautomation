using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBPages.MyPCPages;
using WEBUItests.Base_Test;

namespace WEBUItests.TestsDebug
{


#pragma warning disable 1591

    
    [TestFixture]
    [LoginIfNotLogged]
    public class UploadScript_PASSED : WEBUItest   
    {
        private string scriptFolderName = Variables.TestPlan.scriptFolderName;
        private string script = Variables.TestPlan.script;
        private string pathToScript = string.Format("{0}{1}", Variables.TestPlan.pathToScript , Variables.TestPlan.scriptName);


        /// <summary>
        /// Upload script to test plan folder
        /// </summary>
        [Test]
        public void Step_03_UploadScript([Range(0, 10)] int iteration)
        {
            TestPlanFunctionality testPlanFunctionality = new TestPlanFunctionality();
            testPlanFunctionality.UploadScript(scriptFolderName, pathToScript);
        }

    }

#pragma warning disable 1591


}
