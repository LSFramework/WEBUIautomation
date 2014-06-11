using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEBUIautomation
{
    public class AlmHeader
    {
        //Verfication that Login was successful
        public static bool IsAt
        {
            get
            {                
                //Need to move the 'wait' in a separate method or class
                var header = Driver.Instance.FindElementAndWait(By.XPath("//div[@class='alm-masthead-view-title-container']"), 10);
                if (header.Text == "ALM" || header.Text == "Application Lifecycle Management")
                    return true;
                else
                    return false;
            }
        }
        public static string GetDomainName
        {
            get
            {
                var title = Driver.Instance.FindElement(By.XPath("//button[@class='no-button dropdown-toggle']"));
                return title.Text.Remove(title.Text.IndexOf("/"));
            }
        }
        public static string GetProjectName
        {
            get
            {
                var title = Driver.Instance.FindElement(By.XPath("//button[@class='no-button dropdown-toggle']"));
                return title.Text.Remove(0,title.Text.IndexOf("/")+1);
            }
        }
        public static string GetUsername
        {
            get
            {
                var title = Driver.Instance.FindElementAndWait(By.XPath("//div[@class='fixed-menu-width-content']/a"),10);
                return title.Text;
            }
        }

        public static bool ValidateUsername(string username)
        {
            string title = GetUsername;
            if (title.Contains(username))
                return true;
            else
                return false;
        }

        public static bool ValidateLogin(string domain, string project)
        {
            WebDriverWait wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(10));
            var element = wait.Until<bool>(d =>
            {

                var title = Driver.Instance.FindElementAndWait(By.XPath("//button[@class='no-button dropdown-toggle']"), 10);
                if (title.Text.Contains(domain) && title.Text.Contains(project))
                    return true;
                else
                    return false;
            });
            return element;
        }

        public static void Logout()
        {
            Driver.Instance.FindElement(By.XPath("//li[@class='alm-masthead-view-navigation-link-logout']")).Click();
        }

        public static void ChangeProjectDomain(string project, string domain = "default domain")
        {
            var title = Driver.Instance.FindElementAndWait(By.XPath("//button[@class='no-button dropdown-toggle']"),10);
            if (domain == "default domain")
                domain = title.Text.Remove(title.Text.IndexOf("/"));
            title.Click();

            Actions action = new Actions(Driver.Instance);
            Actions hoverOverProjectMenu = action.MoveToElement(Driver.Instance.FindElement(By.XPath("//li[@ng-repeat='domain in domains']/a[contains(.,'" + domain + "')]")));
            hoverOverProjectMenu.Perform();
            Driver.Instance.FindElement(By.XPath("//li[@ng-repeat='project in domain.projects']/a[contains(@href,'" + domain + "') and contains(@href,'" + project + "')]")).Click();
        }


    }
}
