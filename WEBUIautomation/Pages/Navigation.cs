using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEBUIautomation.Pages
{
    public class Navigation
    {
        //Open the designated page
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
            /*
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
            */

            Actions mouse = new Actions(Driver.Instance);
            mouse.MoveToElement(Driver.Instance.FindElement(By.XPath("//div[@class='linkItem'][ul/li[contains(text(), '" + inputPage + "')]]")))
                .Click()
                .Build()
                .Perform();

            //var tabName = Driver.Instance.FindElementAndWait(By.XPath("//div[@class='linkItem'][ul/li[contains(text(), '" + inputPage + "')]]"));
            //tabName.Click();

            var pageName = Driver.Instance.FindElementAndWait(By.XPath("//div[@class='NewLine mh_Links']//li[contains(@ng-click, 'ChangePerspective')][contains(text(), '" + inputPage + "')]"));
            pageName.Click();
            
        }

        //Click on LogOut button
        public static void Logout()
        {
            Driver.Instance.FindElementAndWait(By.XPath("//div[@ng-click='LogOut()']")).Click();
        }

        private static void OpenHelp(string inputPage)
        { }

        private static void OpenConfig(string inputPage)
        { }

        public static string CurrentPageTitle 
        {
            get 
            {
                Driver.Instance.SwitchTo().Frame(Driver.Instance.FindElement(By.Id("MainTab")));
                
                var pageTitle = Driver.Instance.FindElement(By.XPath("//td[@class='PartTitleStyle']//span[@title]"));

                //Driver.Instance.SwitchTo().DefaultContent();

                return pageTitle.Text;
            }
        }
    }
    
    public enum Pages
    {
        
        Login,
        Defects,
        Home,
        Requirements,
        Start,
        Test_Plan,
        Test_Lab,
        Runs,
        Trending,
        PAL,
        Test_Resources,
        Testing_Hosts,
        Timeslots,
        Topologies,
        Reports
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
