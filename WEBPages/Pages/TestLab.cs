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
    }
}
