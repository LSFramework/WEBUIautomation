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
    public class Driver
    {
        public static IExtWebDriver Instance { get; private set; }

        public static void Initialize()
        {
            Instance = new ExtFirefoxDriver();
            Instance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
        }

        public static void Cleanup()
        {
            if (Instance != null)
                Instance.Dispose();
        }
    }
}
