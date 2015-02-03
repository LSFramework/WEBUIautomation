using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEBUIautomation.Utils
{
   
    //extended IWebDriver interface with FindElementAndWait method
    public interface IWebDriverExt : IWebDriver
    {
       
    }

    public static class RemoteWebDriverExt
    {
        private static IWebElement FindElementByLocator(this IWebDriverExt iWebDriverExt,By by)
        {
            var element = DriverWait.Instance.Until<IWebElement>(d =>
            {
                var elements = Driver.Instance.FindElements(by);
                if (elements.Count > 0)
                    return elements[0];
                else
                    return null;
            });
            return element;
        }

        public static IWebElement FindElementAndWait(this IWebDriverExt iWebDriverExt, By by)
        {
            return  FindElementByLocator(iWebDriverExt,by);            
        }

        public static bool IsElementPresent(this IWebDriverExt iWebDriverExt, By by, int seconds)
        {
            DriverWait.Instance.Timeout = TimeSpan.FromSeconds(seconds);
            return FindElementByLocator(iWebDriverExt, by) != null;      
        }

        public static IWebElement FindElementAndWait(this IWebDriverExt iWebDriverExt, By by, int seconds)
        {
            DriverWait.Instance.Timeout = TimeSpan.FromSeconds(seconds);
            return FindElementByLocator(iWebDriverExt, by);
        }
    }

    //extended FirefoxDriver class with FindElementAndWait method
    public class FirefoxDriverExt : FirefoxDriver, IWebDriverExt
    {
        public FirefoxDriverExt() : base() { }
        public FirefoxDriverExt(FirefoxProfile profile) : base(profile) { }
    }

    //extended ChromeDriver class with FindElementAndWait method
    public class ChromeDriverExt : ChromeDriver, IWebDriverExt
    {
        //Constructor inherited from the base class
        public ChromeDriverExt(string path) : base(path) { }
    }

    //extended InternetExplorerDriver class with FindElementAndWait method
    public class InternetExplorerDriverExt : InternetExplorerDriver, IWebDriverExt
    {
        //Constructor inherited from the base class
        public InternetExplorerDriverExt(string path) : base(path) { }
    }

    //extended PhantomJSDriver class with FindElementAndWait method
    public class PhantomJSDriverExt : PhantomJSDriver, IWebDriverExt
    {
        //Constructor inherited from the base class
        public PhantomJSDriverExt(string path) : base(path) { }
    }

    //extended EventFiringWebDriver class with FindElementAndWait method
    public class EventFiringWebDriverExt : EventFiringWebDriver, IWebDriverExt
    {
        //Constructor inherited from the base class
        public EventFiringWebDriverExt(IWebDriver parentDriver) : base(parentDriver) { }      
    }
}
