using NUnit.Framework;
using WEBPages.MyPCPages;
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
            Assert.True(startTab.ViewOpened);
        }

        /// <summary>
        /// Step_02_CheckTestingHosts
        /// </summary>
        public void Step_02_CheckTestingHosts()
        { 
     
        }
    }
}
