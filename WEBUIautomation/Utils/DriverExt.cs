﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
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

    //extended ChromeDriver class with FindElementAndWait method
    public class ChromeDriverExt : ChromeDriver, IWebDriverExt
    {
        //Constructor inherited from the base class
        public ChromeDriverExt(string path) : base(path) { }
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

    //extended RemoteDriver class with FindElementAndWait method
    public class RemoteWebDriverExt : RemoteWebDriver, IWebDriverExt
    {
        //Constructor inherited from the base class
        public RemoteWebDriverExt(ICapabilities desiredCapabilities) : base (desiredCapabilities) { }
        public RemoteWebDriverExt(ICommandExecutor commandExecutor, ICapabilities desiredCapabilities) : base (commandExecutor, desiredCapabilities) { }
        public RemoteWebDriverExt(Uri remoteAddress, ICapabilities desiredCapabilities) : base (remoteAddress, desiredCapabilities) { }
        public RemoteWebDriverExt(Uri remoteAddress, ICapabilities desiredCapabilities, TimeSpan commandTimeout) : base (remoteAddress, desiredCapabilities, commandTimeout) { }

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