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
<<<<<<< HEAD
           //comments
           //123
=======
           //comment
>>>>>>> 487682f162e381a4cd1873c0361b80f0de60b4b6
           Instance = new FirefoxDriver();
           Instance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
       }

       public static void Close()
       {
           Thread.Sleep(3000);
           Instance.Dispose();
       }
    }
}
