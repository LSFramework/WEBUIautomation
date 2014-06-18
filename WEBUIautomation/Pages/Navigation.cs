using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEBUIautomation.Pages
{
    public class Navigation
    {
        public static void GoTo(Pages page)
        {
            OpenPage(page.ToString());
        }

        public static void GoTo(Configuration configuration)
        {
            OpenPage(configuration.ToString());
        }

        public static void GoTo(Help help)
        {
            OpenPage(help.ToString());
        }

        private static void OpenPage(string inputPage)
        {
            if (inputPage != "Login")
            {
                var pageName = Driver.Instance.FindElementAndWait(By.XPath("//a[@class='dropdown-toggle ng-binding']"), 15);
                if (pageName.Text != inputPage)
                {
                    pageName.Click();
                    var listItem = Driver.Instance.FindElement(By.XPath("//a[@data-toggle='dropdown']/following-sibling::ul[@class='dropdown-menu']//a[contains(text(), '" + inputPage + "')]"));
                    listItem.Click();
                }
                Driver.Instance.FindElementAndWait(By.XPath("//div[@class='alm-splitter-ui-view-container ng-scope']/ui-view/div[div]"), 10);
                //Driver.Wait(2);
            }
            else
            {
                Logout();
            }
        }

        private static void Logout()
        {
            Driver.Instance.FindElementAndWait(By.XPath("//a[@translate='masthead-logout']")).Click();
        }

        private static void OpenHelp(string inputPage)
        { }

        private static void OpenConfig(string inputPage)
        { }
    }
    
    public enum Pages
    {
        Login,
        Defects,
        Home,
        Requirements
    }

    public enum Configuration
    {
        Customization,
        User_Settings
    }

    public enum Help
    {
        Help_on_Requirements,
        Help_on_Defects,
        Help_on_Customization,
        Help_Center,
        Send_feedback,
        About
    }
}
