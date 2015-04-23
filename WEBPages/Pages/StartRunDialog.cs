using OpenQA.Selenium;
using WEBUIautomation.Utils;
using WEBUIautomation.Extensions;
using WEBUIautomation.WebElement;
using WEBPages.Extensions;

namespace WEBPages.Pages
{
    public class StartRunDialog: DriverContainer
    {
        const string position = @".//iframe[contains(@ng-src,'StartRun.aspx')]";        

        IWebDriverExt dialog
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
        
        WebElement btnRun
        { get { return dialog.NewWebElement().ById("ctl00_PageContent_btnRun"); } }

        public StartRunDialog ClickRunBtn()
        {
            btnRun.Click();
            return this;
        }

    }
}
