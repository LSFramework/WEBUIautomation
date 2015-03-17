using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WEBUIautomation.Utils;

namespace WEBPages.Pages
{
    public class ALMainPage:PageBase
    {
        const string MyPCLink = @"//a[text()='My Performance Center']";

        public static void GoToMyPC(string almAddress, string almPort)
        {           
            driver.Navigate().GoToUrl(almAddress + @":" + almPort + @"/qcbin/loadtest/");
           // Driver.Instance.FindElement(By.XPath(MyPCLink)).Click();

        }
    }
}
