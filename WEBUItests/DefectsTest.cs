using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBUIautomation;

namespace WEBUItests
{
    class DefectsTest
    {
        [TestMethod]
        public void Post_Defect()
        {
            DefectsPage.GoTo();

            Assert.IsTrue(DefectsPage.IsAt, "failed to login");

            DefectsPage.AddDefect()
                .EnterSummary("")
                .SetSeverity("")
                .Add();

            Assert.AreEqual(DefectsPage.NewDefect, DefectsPage.LastCreatedDefect, "Defect is not created");

        }
    }
}
