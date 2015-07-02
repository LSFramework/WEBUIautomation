using OpenQA.Selenium.Firefox;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace WEBUIautomation
{
    public class WebDriverFactory
    {
        public IWebDriverExt Create(Browsers browser)
        {
            switch (browser)
            {
                case Browsers.ie:
                    return new InternetExplorerDriverExt();

                case Browsers.chrome:
                    return new ChromeDriverExt();

                case Browsers.firefox:
                        return CreateFirefoxInstance();
                  
                default:                  
                        return CreateFirefoxInstance();                   
            }
        }

        private FirefoxDriverExt CreateFirefoxInstance()
        {
            IEnumerable<int> pidsBefore = Process.GetProcessesByName("firefox").Select(p => p.Id);

            FirefoxDriverExt firefox = new FirefoxDriverExt(new FirefoxProfile());

            IEnumerable<int> pidsAfter = Process.GetProcessesByName("firefox").Select(p => p.Id);

            IEnumerable<int> newFirefoxPids = pidsAfter.Except(pidsBefore);

             if( newFirefoxPids.Any())
             {
                 firefox.PID = newFirefoxPids.First();
             }

             return firefox;
        }
    }
}
