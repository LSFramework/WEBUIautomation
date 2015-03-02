using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Threading;
using OpenQA.Selenium.Remote;
using System.Drawing;

namespace WEBUIautomation.Utils
{
    public class Driver
    {
        public static IWebDriverExt Instance { get; private set;}
        
        public static ICapabilities Capabilities
        {
            get
            {
                return (Instance as RemoteWebDriver).Capabilities;
            }
        }

        public static void Initialize()
        {
            FirefoxProfile properties = new FirefoxProfile();
            properties.SetPreference("profile", "default");
            Instance = WebDriverBrowser.LaunchBrowser(Browser.IE);
            #region
            //Object for Snapshot class
            //var snap = new Snapshot();
            //Object for Logger class
            //var logger = new Logger();
            //Binding driver to the EventFiringDriver
            //var firingDriver = new EventFiringWebDriverExt(new FirefoxDriverExt());

            //Adding TakeScreenshotOnException event to Driver ExceptionThrown listener
            //firingDriver.ExceptionThrown += snap.TakeScreenshotOnException;
            //Adding LogOnException event to Driver ExceptionThrown listener
            //firingDriver.ExceptionThrown += logger.LogOnException;

            //Initializing WebDriver object
            //Instance = firingDriver;

            //Instance = new ChromeDriverExt(@"C:\Utils");
            //Instance = StartIEDriver();
            //Instance = new FirefoxDriverExt();

            //Setting Implicit Wait timeout
            #endregion
            Instance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(1));
        }

        public static void Initialize(Browser browser)
        {
            Instance = WebDriverBrowser.LaunchBrowser(browser);
        }
        

        //Set Browser resolution
        public static void SetBrowserResolution(int width, int height)
        {
            Instance.Manage().Window.Position = new Point(0, 0);
            Instance.Manage().Window.Size = new Size(width, height);            
        }

        //Maximize Browser window
        public static void BrowserMaximize()
        {
            Instance.Manage().Window.Maximize();
        }

        //Close Driver
        public static void Close()
        {
            Instance.Quit();
            Instance.Dispose();
            Instance = null;
        }
        
        //Thread sleep
        public static void Wait(int seconds)
       {
           Thread.Sleep(seconds * 1000);
       }
    }
}
