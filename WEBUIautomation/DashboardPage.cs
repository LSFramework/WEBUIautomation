using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WEBUIautomation
{
    public class DashboardPage
    {

        public static string Project { 
            
            get
            {
                var projectName = Driver.Instance.FindElement(By.XPath("//button[@class='no-button dropdown-toggle']"));
                return projectName.Text.Remove(0, projectName.Text.IndexOf("/") + 1);
            }
        }
        
        public static bool IsAt
        {
            get
            {
<<<<<<< HEAD

                WebDriverWait wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(15));
                var header = wait.Until<IWebElement>(d =>
                    {
                        var headers = Driver.Instance.FindElements(By.CssSelector("h1.alm-masthead-view-title.visible-desktop-minimum.visible-desktop-low.ng-binding"));
                        if (headers.Count > 0)
                            return headers[0];
                        else
                            return null;
                    });

                if (header.Text == "ALM")
=======
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
>>>>>>> 1a781b81c3d66549f671aebe5954a00e08991c07
                    return true;
                else
                    return false;
            } 
        }

        
    }
}
