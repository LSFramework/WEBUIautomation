using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBUIautomation;

namespace WEBUItests
{
    class DefectsTest : WEBUItest
    {
        [TestMethod]
        public void Post_Defect()
        {
            LoginPage.FlowLogin("sa", "", "VITALII", "vproj");
           /* DefectsPage.GoTo();

            Assert.IsTrue(DefectsPage.IsAt, "failed to login");

            DefectsPage.AddDefect()
                .EnterSummary("")
                .SetSeverity("")
                .Add();

            Assert.AreEqual(DefectsPage.NewDefect, DefectsPage.LastCreatedDefect, "Defect is not created");
            */
        }
    }
}
