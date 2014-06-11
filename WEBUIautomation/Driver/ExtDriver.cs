﻿using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Remote;

namespace WEBUIautomation
{
    public interface IExtWebDriver : IWebDriver
    {
        IWebElement FindElementAndWait(By by, Int32 seconds);
    }

    public class ExtFirefoxDriver : FirefoxDriver, IExtWebDriver
    {
        public IWebElement FindElementAndWait(By by, Int32 seconds)
        {
            WebDriverWait wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(seconds));
            var element = wait.Until<IWebElement>(d =>
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

    public class ExtInternetExplorerDriver : InternetExplorerDriver, IExtWebDriver
    {
        public IWebElement FindElementAndWait(By by, Int32 seconds)
        {
            WebDriverWait wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(seconds));
            var element = wait.Until<IWebElement>(d =>
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

    public class ExtChromeDriver : ChromeDriver, IExtWebDriver
    {
        public IWebElement FindElementAndWait(By by, Int32 seconds)
        {
            WebDriverWait wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(seconds));
            var element = wait.Until<IWebElement>(d =>
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

    public class ExtRemoteWebDriver : RemoteWebDriver, IExtWebDriver
    {
        public ExtRemoteWebDriver(ICapabilities desiredCapabilities) : base (desiredCapabilities) { }
        public ExtRemoteWebDriver(ICommandExecutor commandExecutor, ICapabilities desiredCapabilities) : base (commandExecutor, desiredCapabilities) { }
        public ExtRemoteWebDriver(Uri remoteAddress, ICapabilities desiredCapabilities) : base (remoteAddress, desiredCapabilities) { }
        public ExtRemoteWebDriver(Uri remoteAddress, ICapabilities desiredCapabilities, TimeSpan commandTimeout) : base (remoteAddress, desiredCapabilities, commandTimeout) { }

        public IWebElement FindElementAndWait(By by, Int32 seconds)
        {
            WebDriverWait wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(seconds));
            var element = wait.Until<IWebElement>(d =>
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