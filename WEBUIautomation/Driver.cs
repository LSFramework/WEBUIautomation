using OpenQA.Selenium;
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
       public static IWebDriver Instance { get; private set;}

       public static void Initialize()
       {
           Instance = new FirefoxDriver();
           Instance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
       }

       public static void Close()
       {
           Thread.Sleep(3000);
           Instance.Dispose();
       }

       public static void Wait(int seconds)
       {
           Thread.Sleep(seconds * 1000);
       }
    }
}
