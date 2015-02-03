using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBPages.Properties;
using WEBUIautomation;
using WEBUIautomation.Utils;

namespace WEBPages.Pages
{
    public class MyPCNavigation
    {
        public static void Logout()
        {
            Driver.Instance.FindElementAndWait(By.XPath(Resources.XPathLogoutBtn)).Click();          
        }
    }
}
