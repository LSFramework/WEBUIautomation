using OpenQA.Selenium;
using WEBPages.Pages.ModalDialogues;
using WEBUIautomation.Utils;

namespace WEBPages.Pages
{
    public class TestLab:PageBase
    {
        const string position = "MainTab";
        


        static IWebDriverExt mainTab
        {
            get
            {
                if (driver.CurrentFrame != By.Id(position))
                {
                    driver.SwitchTo().DefaultContent();
                    MyPCNavigation.ClickMenuItem(MainHeadLinks.TestManagement);
                    MyPCNavigation.ClickMenuItem(MainHeadLinks.TestLab);
                    driver.SwitchToFrame(By.Id(position));
                }
                return driver;
            }
        }

        static IWebElement TestLabToolBar
        { get { return mainTab.FindElementAndWait(By.Id("ctl00_PageContent_ctl00_PageContent_ToolbarPanel")); } }

        static By TestSetToolBar = By.Id("ctl00_PageContent_ctl00_PageContent_ToolbarPanel");

        static IWebElement TestSetToolbar
        { get { return mainTab.FindElementAndWait(By.Id("ctl00_PageContent_WebPartManager1_wp900837272_0a97c3a4_ee43_474f_a160_c828cba88f1d_toolbar")); } }

        static IWebElement btnAssignTest
        { get { return TestSetToolbar.FindElementAndWait(By.XPath(@".//a[contains(@title, 'Assign Test to TestSet')]")); } }

        static IWebElement btnRunTest
        { get { return TestSetToolbar.FindElementAndWait(By.XPath(@".//img[contains(@alt, 'Run Test')]")); } }

        static IWebElement btnManageTestSets
        { get { return TestLabToolBar.FindElementAndWait(By.XPath(".//a[contains(@title, 'Manage Test Sets')]")); } }

        static IWebElement iPC_A_Zone
        { get { return mainTab.FindElementAndWait(By.Id("ctl00_PageContent_iPC_A_Zone")); } }

        public static bool TestLabOpened
        { get { return iPC_A_Zone.Displayed;} }

        public static void SelectTestInGrid(string testName)
        {
            mainTab.FindElementAndWait(By.Id("ctl00_PageContent_iPC_A_Zone")).FindElementAndWait(By.XPath(@"//td[contains(text(), '" + testName + "')]")).Click();
        }

        /// <summary>
        /// Action => Performs click Manage Test Sets button.
        /// Expected => A modal-dialog CrudTestSet.aspx appears.
        /// </summary>
        public static void ClickManageTestSets()
        {
            btnManageTestSets.Click();
        }
    }
}
