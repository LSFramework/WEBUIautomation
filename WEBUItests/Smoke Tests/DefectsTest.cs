﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBUIautomation;
using WEBUIautomation.Pages;

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

           //Open the Defects page
            //DefectsPage.GoTo();
            Navigation.GoTo(Pages.Defects);

            //Defect creation flow with chained method
            DefectsPage.AddDefectDialog()
                .SetSummary("defect3")
                .SetSeverity("3-High")
                .Add();

            Navigation.GoTo(Pages.Login);
            
            //Verify by summary that we created the defect 
            //Assert.AreEqual(DefectsPage.LatestDefectSummary, "", "failed to create the defect");             
        }
    }
}