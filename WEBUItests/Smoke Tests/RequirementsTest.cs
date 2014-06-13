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
    public class RequirementsTest : WEBUItest
    {
         [TestMethod]
         public void Create_Requirement()
         {
             LoginPage.LoginFlow();
             //Open the Defects page
             RequirementsPage.GoTo();
             
             //Defect creation flow
             RequirementsPage.AddReq();
             /*
             RequirementsPage.SetName("");
             RequirementsPage.SetParent("");
             RequirementsPage.setType("");
             RequirementsPage.ClickAdd();
             
             //Verify by summary that we created the defect 
             Assert.AreEqual(RequirementsPage.LatestReqName, "", "failed to create the defect");
             */
         }
    }
}
