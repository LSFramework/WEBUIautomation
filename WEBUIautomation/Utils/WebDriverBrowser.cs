using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using WEBUIautomation.Utils;

namespace WEBUIautomation
{
    /// <summary>
    /// Contains all functionality relating to launching the webdriver browsers.
    /// </summary>
    public class WebDriverBrowser
    {
        public IWebDriver LaunchBrowser(Browser browser)
        {
            IWebDriver driver;
            switch (browser)
            {
                case Browser.IE: driver = StartIEDriver();
                    break;

                case Browser.Chrome: driver = new ChromeDriverExt(@"C:\Utils");
                    break;

                default:
                       FirefoxProfile profile = new FirefoxProfile();
                       profile.SetPreference("profile", "default");                    
                       driver = new FirefoxDriverExt(profile);                 
                    break;
            }

            driver.Manage().Cookies.DeleteAllCookies();

            return driver as IWebDriverExt;
        }

        private IWebDriver StartIEDriver()
        {
            InternetExplorerOptions ieOptions = new InternetExplorerOptions();
            ieOptions.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
            ieOptions.EnsureCleanSession = true;
            var driver = new InternetExplorerDriverExt(@"C:\Utils", ieOptions);
            return driver;
        }
    }
}
