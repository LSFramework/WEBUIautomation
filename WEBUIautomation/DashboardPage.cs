using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEBUIautomation
{
    public class DashboardPage
    {
        //Verfication that Login was successful
        public static bool IsAt
        {
            get
            {
<<<<<<< HEAD
                var header = Driver.Instance.FindElementAndWait(By.XPath("//div[@class='alm-masthead-view-title-container']"), 10);
=======

                //Need to move the 'wait' in a separate method or class

                var header = Driver.Instance.FindAndWait(By.XPath("//div[@class='alm-masthead-view-title-container']"), 1);
>>>>>>> 6eb813ab15dd0b62143f04de68a520cd6c9b50c7
                if (header.Text == "ALM" || header.Text == "Application Lifecycle Management")
                    return true;
                else
                    return false;
            }
        }

<<<<<<< HEAD
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
                return title.Text.Remove(0,title.Text.IndexOf("/"));
=======
                /*

                WebDriverWait wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(10));

                var header1 = wait.Until<IWebElement>(d =>
                {
                    var headers = Driver.Instance.FindElements();
                    if (headers.Count > 0)
                        return headers[0];
                    else
                        return null;
                });

                if (header1.Text == "ALM" || header1.Text == "Application Lifecycle Management")
                    return true;
                else
                    return false;
                 */ 
>>>>>>> 6eb813ab15dd0b62143f04de68a520cd6c9b50c7
            }
        }

        public static bool CheckDomainAndProject(string domain, string project)
        {
            var title = Driver.Instance.FindElement(By.XPath("//button[@class='no-button dropdown-toggle']"));
            if (title.Text.Contains(domain) && title.Text.Contains(project))
                return true;
            else
                return false;
        }

        public static void ChangeProjectDomain(string project, string domain = "default domain")
        {
            var title = Driver.Instance.FindElement(By.XPath("//button[@class='no-button dropdown-toggle']"));
            if (domain == "default domain")
                domain = title.Text.Remove(title.Text.IndexOf("/"));
            title.Click();
            Driver.Instance.FindElement(By.XPath("//li[@ng-repeat='domain in domains']/a[contains(.,'" + domain + "')]")).Click();
            Driver.Instance.FindElement(By.XPath("//li[@ng-repeat='project in domain.projects']/a[contains(@href,'" + domain + "') and contains(@href,'" + project + "')]")).Click();
        }
    }
}
