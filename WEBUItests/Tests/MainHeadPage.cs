using NUnit.Framework;
using WEBPages.Pages;
using WEBPages.Pages.TestLab;
using WEBPages.Pages.TestPlan;
using WEBUItests.Base_Test;
using WEBPages.ContentLocators;
using WEBPages.Pages.Runs;
using WEBPages.Pages.Trending;

namespace WEBUItests.MyPCTests.Test_1_Sanity
{
    /// <summary>
    /// Checks access to perspectives from Main Head Page
    /// </summary>
    [TestFixture][LoginIfNotLogged]
    public class Test_1_MainHeadPage_Navigation : WEBUItest
    {

        /// <summary>
        /// Navigates to Test Lab
        /// </summary>
        [Test]
        public void Step_1_NavigateToTestLab()
        {
           TestLabPage testLabPage = new TestLabPage();
           Assert.True(testLabPage.Opened);
        }

        /// <summary>
        /// Navigates to Test Plan
        /// </summary>
        [Test]
        public void Step_2_NavigateToTestPlan()
        {
            TestPlanPage testPlanPage = new TestPlanPage();
            Assert.True(testPlanPage.Opened);
        }

        /// <summary>
        /// Start tab
        /// </summary>
        [Test]
        public void Step_3_NavigateToStart()
        {
            StartTab startTab = new StartTab();
            Assert.True(startTab.Opened);
        }


        /// <summary>
        /// Navigate to Runs Perspective
        /// </summary>
        [Test]
        public void Step_4_NavigateToRuns()
        {
            TestRunsPage testRunsPage = new TestRunsPage();
            Assert.True(testRunsPage.Opened);
        }

        /// <summary>
        /// Navigate to Performance Trending Perspective
        /// </summary>
        [Test]
        public void Step_5_NavigateToTrending()
        {
            TrendingPage trendingPage = new TrendingPage();
            Assert.True(trendingPage.Opened);
        }
    }
}
