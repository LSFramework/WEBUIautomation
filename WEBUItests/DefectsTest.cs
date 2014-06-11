using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBUIautomation;

namespace WEBUItests
{
    [TestClass]
    public class DefectsTest : WEBUItest
    {
        [TestMethod]
        public void Create_Defect()
        {
            //Login in WEBui
            LoginPage.LoginFlow();

            Driver.Wait(3);            
            //Open the Defects page
            DefectsPage.GoTo();            
            //Defect creation flow
            DefectsPage.AddDefect("defect2", "3-High");
            
            //Verify by summary that we created the defect 
            //Assert.AreEqual(DefectsPage.LatestDefectSummary, "", "failed to create the defect");
             
        }
    }
}
