using System;
using System.Threading;
using System.Drawing;

namespace WEBUIautomation.Utils
{
    public class Driver
    {
        public static IWebDriverExt Instance 
        { 
            get { return instance ; } 
            set { instance = value; } 
        }
        
        private static IWebDriverExt instance;

        static Object Instancelocker = new object();
       
        public static void Initialize(Browsers browser)
        {
            lock (Instancelocker)
            {
                instance = null;

                WebDriverBrowser brow = new WebDriverBrowser();
                instance = brow.LaunchBrowser(browser) as IWebDriverExt;
                instance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
                instance.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(10));
                instance.Manage().Timeouts().SetScriptTimeout(TimeSpan.FromSeconds(2));                  
            }
        }

        //Set Browsers resolution
        public static void SetBrowserResolution(int width, int height)
        {
            instance.Manage().Window.Position = new Point(0, 0);
            instance.Manage().Window.Size = new Size(width, height);            
        }

        //Maximize Browsers window
        public static void BrowserMaximize()
        {
            instance.Manage().Window.Maximize();
        }

        //Close Driver
        public static void Close()
        {
            if (Instance == null) return;
            
                instance.Quit();
                instance.Dispose();
                instance = null;            
        }
        
        //Thread sleep
        public static void Wait(int millisecondsTimeout)
       {
           Thread.Sleep(millisecondsTimeout);
       }
    }
}
