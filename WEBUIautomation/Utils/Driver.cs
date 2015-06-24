using System;
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
                instance = instance.Shutdown();

                WebDriverFactory factory = new WebDriverFactory();
                
                instance = factory.Create(browser);                                
            }
        }
    }
}
