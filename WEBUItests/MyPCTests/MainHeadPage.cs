using NUnit.Framework;
using WEBPages.Pages;
using WEBPages.Pages.TestLab;
using WEBPages.Pages.TestPlan;
using WEBUItests.Base_Test;

namespace WEBUItests.MyPCTests.Test_1_Sanity
{
    /// <summary>
    /// Checks access to perspectives from Main Head Page
    /// </summary>
    [TestFixture]
    [LoginIfNotLogged]
    public class Test_1_MainHeadPage : WEBUItest
    {        
        /// <summary>
        /// Navigates to Test Lab
        /// </summary>
        [Test]
        public void Step_1_NavigateToTestLab()
        {
            MainHead.NavigateToTestLab();
            Assert.True(TestLab.TestLabOpened);
        }

        /// <summary>
        /// Navigates to Test Plan
        /// </summary>
        [Test]
        public void Step_2_NavigateToTestPlan()
        {
           MainHead.NavigateToTestPlan();
           Assert.True(TestPlan.Opened);
        }
    }
}
