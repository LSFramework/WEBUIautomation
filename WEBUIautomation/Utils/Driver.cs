using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.PhantomJS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using WEBUIautomation.Utils;
using OpenQA.Selenium.Support.Events;

namespace WEBUIautomation
{
    public class Driver
    {
       public static IWebDriverExt Instance { get; private set;}

       public static void Initialize()
       {
           var firingDriver = new EventFiringWebDriverExt(new PhantomJSDriverExt(@"C:\Utils"));
           firingDriver.ExceptionThrown += Snapshot.TakeScreenshotOnException;
           
           Instance = firingDriver;
           Instance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(2));
       }

       public static void Close()
       {
           Instance.Dispose();
       }

       public static void Wait(int seconds)
       {
           Thread.Sleep(seconds * 1000);
       }
    }
}
