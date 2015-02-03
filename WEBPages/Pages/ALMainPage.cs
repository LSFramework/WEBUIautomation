using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBPages.Properties;
using WEBUIautomation;

namespace WEBPages.Pages
{
    public class ALMainPage
    {
        public static void GoToMyPC(string almAddress, string almPort)
        { 
            Driver.Instance.Navigate().GoToUrl(almAddress + @":" + almPort + @"/qcbin/");
            Driver.Instance.FindElement(By.XPath(Resources.MyPCLink)).Click();
        }
    }
}
