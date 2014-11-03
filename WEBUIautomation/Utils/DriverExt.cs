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
        //Using default WebDriverWait timeout
        IWebElement FindElementAndWait(By by);
        //Can specify WebDriverWait timeout
        IWebElement FindElementAndWait(By by, int seconds);
    }

    //extended FirefoxDriver class with FindElementAndWait method
    public class FirefoxDriverExt : FirefoxDriver, IWebDriverExt
    {
        public FirefoxDriverExt() : base() { }
        public FirefoxDriverExt(FirefoxProfile profile) : base(profile) { }

        //Using default WebDriverWait timeout
        public IWebElement FindElementAndWait(By by)
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

        public bool IsElementPresent(By by, int seconds)
        {
            DriverWait.Instance.Timeout = TimeSpan.FromSeconds(seconds);

            var element = DriverWait.Instance.Until<IWebElement>(d =>
            {
                var elements = Driver.Instance.FindElements(by);
                if (elements.Count > 0)
                    return elements[0];
                else
                    return null;
            });

            return element != null;
        }

        //Can specify WebDriverWait timeout
        public IWebElement FindElementAndWait(By by, int seconds)
        {
            DriverWait.Instance.Timeout = TimeSpan.FromSeconds(seconds);

            var element = DriverWait.Instance.Until<IWebElement>(d => {
                var elements = Driver.Instance.FindElements(by);
                if (elements.Count > 0)
                    return elements[0];
                else
                    return null;
            });
            return element;
        }
    }

    //extended ChromeDriver class with FindElementAndWait method
    public class ChromeDriverExt : ChromeDriver, IWebDriverExt
    {
        //Constructor inherited from the base class
        public ChromeDriverExt(string path) : base(path) { }
        //Using default WebDriverWait timeout
        public IWebElement FindElementAndWait(By by)
        {
            var element = DriverWait.Instance.Until<IWebElement>(driver =>
            {
                var elements = driver.FindElements(by);
                if (elements.Count > 0)
                    return elements[0];
                else
                    return null;
            });
            return element;
        }

        //Can specify WebDriverWait timeout
        public IWebElement FindElementAndWait(By by, int seconds)
        {
            DriverWait.Instance.Timeout = TimeSpan.FromSeconds(seconds);

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
    }

    //extended InternetExplorerDriver class with FindElementAndWait method
    public class InternetExplorerDriverExt : InternetExplorerDriver, IWebDriverExt
    {
        //Constructor inherited from the base class
        public InternetExplorerDriverExt(string path) : base(path) { }
        //Using default WebDriverWait timeout
        public IWebElement FindElementAndWait(By by)
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

        //Can specify WebDriverWait timeout
        public IWebElement FindElementAndWait(By by, int seconds)
        {
            DriverWait.Instance.Timeout = TimeSpan.FromSeconds(seconds);

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
    }

    //extended PhantomJSDriver class with FindElementAndWait method
    public class PhantomJSDriverExt : PhantomJSDriver, IWebDriverExt
    {
        //Constructor inherited from the base class
        public PhantomJSDriverExt(string path) : base(path) { }
        //Using default WebDriverWait timeout
        public IWebElement FindElementAndWait(By by)
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

        //Can specify WebDriverWait timeout
        public IWebElement FindElementAndWait(By by, int seconds)
        {
            DriverWait.Instance.Timeout = TimeSpan.FromSeconds(seconds);

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
    }

    //extended EventFiringWebDriver class with FindElementAndWait method
    public class EventFiringWebDriverExt : EventFiringWebDriver, IWebDriverExt
    {
        //Constructor inherited from the base class
        public EventFiringWebDriverExt(IWebDriver parentDriver) : base(parentDriver) { }
        //Using default WebDriverWait timeout
        public IWebElement FindElementAndWait(By by)
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

        //Can specify WebDriverWait timeout
        public IWebElement FindElementAndWait(By by, int seconds)
        {
            DriverWait.Instance.Timeout = TimeSpan.FromSeconds(seconds);

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
    }
}
