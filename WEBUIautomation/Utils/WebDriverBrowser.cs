using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.IO;
using WEBUIautomation.Utils;
using WEBUIautomation.Wait;

namespace WEBUIautomation
{
    /// <summary>
    /// Contains all functionality relating to launching the webdriver browsers.
    /// </summary>
    public class WebDriverBrowser
    {
        public Browsers SelectedBrowser
        {
            get;
            private set;
        }

        public IWebDriverExt LaunchBrowser(Browsers browser)
        {
            IWebDriverExt driver;
            SelectedBrowser = browser;
            switch (browser)
            {
                case Browsers.InternetExplorer: 
                    driver = StartInternetExplorer();//StartIEDriver();
                    break;

                case Browsers.Chrome: 
                    driver = StartChrome();//new ChromeDriverExt(Directory.GetCurrentDirectory());
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
            var driver = new InternetExplorerDriverExt(Directory.GetCurrentDirectory(), ieOptions);
            return driver;
        }

        public static Browsers getBrowserFromString(string strBrowser)
        {
            return (Browsers)Enum.Parse(typeof(Browsers), strBrowser);       
        }

        static FirefoxDriverExt StartFirefox()
        {
            var firefoxProfile = new FirefoxProfile
            {
                AcceptUntrustedCertificates = true,
                EnableNativeEvents = true
            };

            return new FirefoxDriverExt(firefoxProfile);
         }

        static ChromeDriverExt StartChrome()
         {
             var chromeOptions = new ChromeOptions();
             var defaultDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\..\Local\Google\Chrome\User Data\Default";

             if (Directory.Exists(defaultDataFolder))
             {
                 WaitHelper.Try(() => DirectoryHelper.ForceDelete(defaultDataFolder));
             }

             return new ChromeDriverExt(Directory.GetCurrentDirectory(), chromeOptions);
         }

        static InternetExplorerDriverExt StartInternetExplorer()
         {
             var internetExplorerOptions = new InternetExplorerOptions
             {
                 IntroduceInstabilityByIgnoringProtectedModeSettings = true,
                 EnsureCleanSession = true,
                 InitialBrowserUrl = "about:blank",
                 EnableNativeEvents = true
             };

             return new InternetExplorerDriverExt(Directory.GetCurrentDirectory(), internetExplorerOptions);
         }
    }
}
