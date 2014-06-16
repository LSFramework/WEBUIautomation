using OpenQA.Selenium;
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
        public IWebElement FindElementAndWait(By by, WebDriverWait wait);
    }

    //extended Diver class with FindElementAndWait method
    public class FirefoxDriverExt : FirefoxDriver, IWebDriverExt
    {
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
}
