using NUnit.Framework;
using WEBPages.MyPCPages;
using WEBUIautomation.Utils;
using WEBUItests.Base_Test;
using WEBUItests.BrowserStack;

namespace WEBUItests.MyPCTests.Start
{

    /// <summary>
    /// Start Page Test
    /// </summary>
    [TestFixture]
    public class StartPage : BrowsersTestBase// WEBUItest
    {
        StartTab startTab;

        /// <summary>
        /// Navigate to Start Tab
        /// </summary>
        [Test]
        [Description("Navigate to Start Tab")]
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