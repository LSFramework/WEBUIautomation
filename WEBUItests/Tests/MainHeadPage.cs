//using NUnit.Framework;
//using WEBUItests.Base_Test;
//using WEBPages.MyPCPages;

//namespace WEBUItests.MyPCTests.Test_1_Sanity
//{
//    /// <summary>
//    /// Checks access to perspectives from Main Head Page
//    /// </summary>
//    [TestFixture]
//    public class Test_1_MainHeadPage_Navigation : WEBUItest
//    {

//        /// <summary>
//        /// Navigates to Test Lab
//        /// </summary>
//        [Test]
//        public void Step_1_NavigateToTestLab()
//        {
//           TestLabPage testLabPage = new TestLabPage();
//           Assert.True(testLabPage.ViewOpened);
//        }

//        /// <summary>
//        /// Navigates to Test Plan
//        /// </summary>
//        [Test]
//        public void Step_2_NavigateToTestPlan()
//        {
//            TestPlanPage testPlanPage = new TestPlanPage();
//            Assert.True(testPlanPage.ViewOpened);
//        }

//        /// <summary>
//        /// Start tab
//        /// </summary>
//        [Test]
//        public void Step_3_NavigateToStart()
//        {
//            StartTab startTab = new StartTab();
//            Assert.True(startTab.ViewOpened);
//        }


//        /// <summary>
//        /// Navigate to Runs Perspective
//        /// </summary>
//        [Test]
//        public void Step_4_NavigateToRuns()
//        {
//            TestRunsPage testRunsPage = new TestRunsPage();
//            Assert.True(testRunsPage.ViewOpened);
//        }

//        /// <summary>
//        /// Navigate to Performance Trending Perspective
//        /// </summary>
//        [Test]
//        public void Step_5_NavigateToTrending()
//        {
//            TrendingPage trendingPage = new TrendingPage();
//            Assert.True(trendingPage.ViewOpened);
//        }

//        /// <summary>
//        /// Step_6_NavigateToPal
//        /// </summary>
//        [Test]
//        public void Step_6_NavigateToPal()
//        {
//            PalPage palPage = new PalPage();
//            Assert.True(palPage.ViewOpened);
//        }

//        /// <summary>
//        /// Step_7_NavigateToTestResources
//        /// </summary>
//        [Test]
//        public void Step_7_NavigateToTestResources()
//        {
//            TestResources testResources = new TestResources();
//            Assert.True(testResources.ViewOpened);
//        }
//    }
//}
