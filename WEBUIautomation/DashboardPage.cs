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

                var header = Driver.Instance.FindAndWait(By.XPath("//div[@class='alm-masthead-view-title-container']"), 1);
                if (header.Text == "ALM" || header.Text == "Application Lifecycle Management")
                    return true;
                else
                    return false;

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
            }
        }
    }
}
