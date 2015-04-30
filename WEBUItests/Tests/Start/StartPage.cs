using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBPages.Pages;
using WEBUItests.Base_Test;

namespace WEBUItests.MyPCTests.Start
{

    /// <summary>
    /// Start Page Test
    /// </summary>
    [TestFixture] [LoginIfNotLogged]
    public class StartPage : WEBUItest
    {
        StartTab startTab;
       
        /// <summary>
        /// Navigate to Start Tab
        /// </summary>
        [Test]
        public void Step_01_NavigateToStartTab()
        {
            startTab = new StartTab();
            Assert.True(startTab.Opened);
        }

        public void Step_02_CheckTestingHosts()
        { 
          ///  
        }
    }
}
