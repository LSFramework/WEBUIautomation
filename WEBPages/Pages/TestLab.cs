using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBUIautomation;
using WEBUIautomation.Utils;

namespace WEBPages.Pages
{
    public class TestLab
    {
        private const string position = "MainTab";
        private static IWebDriverExt _mainTab = Driver.Instance;

        private static IWebDriverExt mainTab
        {
            get
            {
                if (_mainTab.CurrentFrame != By.Id(position))
                {
                    _mainTab.SwitchTo().DefaultContent();
                    MyPCNavigation.TestManagement.Click();
                    MyPCNavigation.TestManagement.SelectItem("Test Lab").Click();
                    _mainTab = Driver.Instance.SwitchToFrame(By.Id(position));
                }
                return _mainTab;
            }
        }

        private static IWebElement TestSetToolbar
        { get { return mainTab.FindElementAndWait(By.Id("ctl00_PageContent_WebPartManager1_wp900837272_0a97c3a4_ee43_474f_a160_c828cba88f1d_toolbar")); } }

        public static IWebElement btnAssignTest
        { get { return TestSetToolbar.FindElementAndWait(By.XPath(@".//a[contains(@title, 'Assign Test to TestSet')]")); } }

        public static IWebElement btnRunTest
        { get { return TestSetToolbar.FindElementAndWait(By.XPath(@".//span[contains(text(), 'Run Test')]")); } } 


        public static void SelectTestInGrid(string testName)
        {
            mainTab.FindElementAndWait(By.Id("ctl00_PageContent_iPC_A_Zone")).FindElementAndWait(By.XPath(@"//td[contains(text(), '" + testName + "')]")).Click();
        }

    }
}
