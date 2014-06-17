using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
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

    //extended Diver class with FindElementAndWait method
    public class FirefoxDriverExt : FirefoxDriver, IWebDriverExt
    {
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

    //extended Diver class with FindElementAndWait method
    public class ChromeDriverExt : ChromeDriver, IWebDriverExt
    {
        //public ChromeDriverExt(string path): base(string path);
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
