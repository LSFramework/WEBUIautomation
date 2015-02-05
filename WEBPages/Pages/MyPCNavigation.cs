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

        public static IWebElement LogoutBtn
        { 
            get 
            {
                return Driver.Instance.FindElementAndWait(By.XPath(Resources.XPathLogoutBtn)); 
            } 
        }

        public static void SwitchToPopup()
        {
            do
            {
               IList<string> afterPopup = Driver.Instance.WindowHandles.ToList();
            } while (Driver.Instance.WindowHandles.ToList().Count <= 1);
            Driver.Instance.SwitchTo().Window(Driver.Instance.WindowHandles.Last());
        }
            
    }
}
