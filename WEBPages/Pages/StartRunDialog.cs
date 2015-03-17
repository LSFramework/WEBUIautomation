using OpenQA.Selenium;
using WEBUIautomation.Utils;

namespace WEBPages.Pages
{
    public class StartRunDialog
    {
        const string position = @".//iframe[contains(@ng-src,'StartRun.aspx')]";
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
