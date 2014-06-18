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
using WEBUIautomation.Utils;

namespace WEBUIautomation
{
    public class Driver
    {
       public static IWebDriverExt Instance { get; private set;}

       public static void Initialize()
       {
           Instance = new InternetExplorerDriverExt(@"C:\Utils");
           Instance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(2));
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
