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
        //public IWebDriverExt LaunchBrowser(Browsers browser)
        //{
        //    IWebDriverExt driver;
           
        //    switch (browser)
        //    {
        //        case Browsers.ie: 
        //            driver = StartInternetExplorer();
        //            break;

        //        case Browsers.chrome: 
        //            driver = StartChrome();
        //            break;

        //        default:
        //            driver = StartFirefox();                 
        //            break;
        //    }

        //    driver.Manage().Cookies.DeleteAllCookies();

        //    return driver as IWebDriverExt;
        //}

        //FirefoxDriverExt StartFirefox()
        //{
        //    FirefoxProfile profile = new FirefoxProfile();
        //    profile.SetPreference("profile", "default");

        //    WaitProfile waitProfile = new WaitProfile(TimeSpan.FromSeconds(20), TimeSpan.FromMilliseconds(50));

        //    return new FirefoxDriverExt(profile);//profile, waitProfile);
        // }

        //ChromeDriverExt StartChrome()
        // {
        //     var chromeOptions = new ChromeOptions();
        //     var defaultDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\..\Local\Google\Chrome\User Data\Default";

        //     if (Directory.Exists(defaultDataFolder))
        //     {
        //         WaitHelper.Try(() => DirectoryHelper.ForceDelete(defaultDataFolder));
        //     }

        //     WaitProfile waitProfile = new WaitProfile(TimeSpan.FromSeconds(10), TimeSpan.FromMilliseconds(500));

        //     return new ChromeDriverExt(Directory.GetCurrentDirectory(), chromeOptions, TimeSpan.FromSeconds(10), waitProfile);
        // }

        //InternetExplorerDriverExt StartInternetExplorer()
        // {
        //     var internetExplorerOptions = new InternetExplorerOptions
        //     {
        //         IntroduceInstabilityByIgnoringProtectedModeSettings = true,
        //         EnsureCleanSession = true,
        //         InitialBrowserUrl = "about:blank",
        //         EnableNativeEvents = true
        //     };

        //     WaitProfile waitProfile = new WaitProfile(TimeSpan.FromSeconds(10), TimeSpan.FromMilliseconds(50));

        //     return new InternetExplorerDriverExt(Directory.GetCurrentDirectory(), internetExplorerOptions, waitProfile);
        // }

        public static Browsers getBrowserFromString(string strBrowser)
         {
             return (Browsers)Enum.Parse(typeof(Browsers), strBrowser);
         }
    }
}
