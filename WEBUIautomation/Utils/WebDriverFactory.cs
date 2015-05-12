using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEBUIautomation.Utils
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
                    return new FirefoxDriverExt(new FirefoxProfile());

                default:
                    return new FirefoxDriverExt(new FirefoxProfile());
            }
        }
    }
}
