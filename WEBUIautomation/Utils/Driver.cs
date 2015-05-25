using System;
using System.Threading;
using System.Drawing;
using WEBUIautomation.Extensions;

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

        private static Object Instancelocker = new object();
       
        public static void Initialize(Browsers browser)
        {
            lock (Instancelocker)
            {
                instance.Shutdown();

                WebDriverFactory factory = new WebDriverFactory();
                
                instance = factory.Create(browser);
                  
                instance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
                instance.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(10));
                instance.Manage().Timeouts().SetScriptTimeout(TimeSpan.FromSeconds(2));                  
            }
        }
    }
}
