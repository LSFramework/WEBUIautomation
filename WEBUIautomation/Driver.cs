﻿using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace WEBUIautomation
{
    public class Driver : IExtWebDriver
    {
        public static IWebDriver Instance { get; private set; }

        WebDriverWait wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(10));

        public static void Initialize()
        {
            Instance = new FirefoxDriver();
            Instance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
        }

        public IWebElement FindElementAndWait(By m, Int32 seconds)
        {
            var element = wait.Until<IWebElement>(d =>
            {
                var elements = Instance.FindElements(m);
                if (elements.Count > 0)
                    return elements[0];
                else
                    return null;
            });
            return element;
        }
    
        public static void Cleanup()
        {
            if (Instance != null)
                Instance.Dispose();
        }
    }
}
