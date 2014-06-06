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

        public static bool IsAt
        {
            get
            {
                //wait
                WebDriverWait wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(10));
                var header1 = wait.Until<IWebElement>(d =>
                {
                    var headers = Driver.Instance.FindElements(By.CssSelector("h1.alm-masthead-view-title.visible-desktop-minimum.visible-desktop-low.ng-binding"));
                    if (headers.Count > 0)
                        return headers[0];
                    else
                        return null;
                });
                
                if (header1.Text == "ALM")
                    return true;
                else
                    return false;
            } 
        }
    }
}
