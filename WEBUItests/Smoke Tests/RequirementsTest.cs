using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBUIautomation;
using WEBUIautomation.Pages;
using WEBUIautomation.Utils;

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
             //RequirementsPage.GoTo();
             Navigation.GoTo(Pages.Requirements);
             //Navigation.GoTo(Help.About);
             //Navigation.GoTo(Configuration.Customization);
             Snapshot.Take();  
             //Defect creation flow
             RequirementsPage.AddReq()
                 .SetName("req2")
                 .SetType("Functional")
                 .ClickAdd();

             //Verify by summary that we created the defect 
             //Assert.AreEqual(RequirementsPage.LatestReqName, "", "failed to create the defect");
             
         }
    }
}
