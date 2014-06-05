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
                //Need to move the 'wait' in a separate method or class
=======
                var header = Driver.Instance.FindAndWait(By.XPath("//div[@class='alm-masthead-view-title-container']"), 1);
                if (header.Text == "ALM" || header.Text == "Application Lifecycle Management")
                    return true;
                else
                    return false;

                /*
>>>>>>> d5e65a9e7b4a4a40172443e8d44bd17e8b2b27d0
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
