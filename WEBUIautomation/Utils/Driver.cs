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
using System.IO;

namespace WEBUIautomation
{
    public class Driver
    {
       private static string startupPath = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName, "drivers");
       public static IWebDriverExt Instance { get; private set;}

       public static void Initialize()
       {
           if (Instance == null)
           {
               Instance = new ChromeDriverExt(startupPath);
               //Instance = new InternetExplorerDriverExt(@"C:\Utils");
               //Instance = new FirefoxDriverExt();
               Instance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
           }
       }

       public static void Close()
       {
           if (Instance != null)
           {
               Thread.Sleep(3000);
               Instance.Dispose();
           }           
       }

       public static void Wait(int seconds)
       {
           Thread.Sleep(seconds * 1000);
       }
    }
}
