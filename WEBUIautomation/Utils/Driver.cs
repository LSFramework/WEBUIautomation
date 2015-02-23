using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.PhantomJS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using WEBUIautomation.Utils;
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium.Remote;
using System.Drawing;

namespace WEBUIautomation
{
    public class Driver
    {
        public static IWebDriverExt Instance { get; private set;}
        //public static ICapabilities Capabilities { get; private set; }

        public static void Initialize()
        {
            FirefoxProfile properties = new FirefoxProfile();
            properties.SetPreference("profile", "default");

            
            ieOptions.EnsureCleanSession = true;

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

           // Instance = new ChromeDriverExt(@"C:\Utils");
            Instance = StartIEDriver();
              //new InternetExplorerDriverExt(@"C:\Utils", ieOptions);            
            //Instance = new FirefoxDriverExt();

            //Setting Implicit Wait timeout
            Instance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(1));
        }

        private static IWebDriverExt StartIEDriver()
        {
            InternetExplorerOptions ieOptions = new InternetExplorerOptions();
            ieOptions.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
            ieOptions.EnsureCleanSession = true;
            var driver = new InternetExplorerDriverExt(@"C:\Utils", ieOptions);
            driver.Close();
            driver = new InternetExplorerDriverExt(@"C:\Utils", ieOptions);
            return driver;
        }


        //Set Browser resolution
        public static void SetBrowserResolution(int width, int height)
        {
            Instance.Manage().Window.Position = new Point(0, 0);
            Instance.Manage().Window.Size = new Size(width, height);
            //Instance.Manage().Window.Maximize();
        }

        //Maximize Browser window
        public static void BrowserMaximize()
        {
            Instance.Manage().Window.Maximize();
        }

        //Close Driver
        public static void Close()
        {
            Instance.Dispose();
        }
        
        //Thread sleep
        public static void Wait(int seconds)
       {
           Thread.Sleep(seconds * 1000);
       }
    }
}
