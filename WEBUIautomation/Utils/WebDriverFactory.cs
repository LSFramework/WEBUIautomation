using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEBUIautomation.Utils
{
    public static class WebDriverFactory
    {
        public static IWebDriverExt[] Drivers =
        {
            new InternetExplorerDriverExt(@"C:\Utils"),
            new ChromeDriverExt(@"C:\Utils"),
            new FirefoxDriverExt()
        };
    }
}
