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
    public class StartRunDialog
    {
        static string position = @".//iframe[contains(@ng-src,'StartRun.aspx')]";
        static IWebDriverExt driver = Driver.Instance;

        static IWebDriverExt runTestDialog
        {
            get
            {
                if (driver.CurrentFrame != By.XPath(position))
                {
                    driver.SwitchToDefaultContent();
                    driver.SwitchToFrame(By.XPath(position));
                }
                return driver;
            }
        }

        public static IWebElement btnRun
        { get { return runTestDialog.FindElementAndWait(By.Id("ctl00_PageContent_btnRun")); } }

    }
}
