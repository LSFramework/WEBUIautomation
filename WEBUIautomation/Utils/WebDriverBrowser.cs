using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Safari;
using System;
using System.Configuration;
using WEBUIautomation.Utils;

namespace WEBUIautomation
{
    /// <summary>
    /// Contains all functionality relating to launching the webdriver browsers.
    /// </summary>
    public class WebDriverBrowser
    {
        public static Browser getBrowserFromString(string name)
        {
            return (Browser)Enum.Parse(typeof(Browser), name);
        }

        public static IWebDriverExt LaunchBrowser(Browser browser)
        {
            IWebDriverExt driver;
            switch (browser)
            {
                case Browser.IE:
                    driver = StartIEDriver();
                    break;
                case Browser.Chrome:
                    driver = new ChromeDriverExt(@"C:\Utils");
                    break;
                default:
                    driver = new FirefoxDriverExt();
                    break;
            }

            driver.Manage().Cookies.DeleteAllCookies();
            return driver as IWebDriverExt;
        }

        private static IWebDriverExt StartIEDriver()
        {
            InternetExplorerOptions ieOptions = new InternetExplorerOptions();
            ieOptions.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
            ieOptions.EnsureCleanSession = true;
            var driver = new InternetExplorerDriverExt(@"C:\Utils", ieOptions);
            return driver;
        }
    }
}
