using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEBUIautomation.Pages
{
    public class PLoginPage
    {
        static string[] appNames = { "Projects", "Deliverables", "Design Approvals", "Inspiration" };
        static int number = 0;

        public static void Login()
        { 
            Driver.Instance.Url = "https://podio.com/market/";
        }

        public static void Search(string sWord)
        {
            var searchField = Driver.Instance.FindElement(By.XPath("//*[@id='query']"));
            searchField.SendKeys(sWord);
            Driver.Instance.FindElement(By.XPath("//*[@class='button-new blue']")).Click();

            //var packages = Driver.Instance.FindElementAndWait(By.XPath("app-store-share pack"));
        }

        public static bool IsPackExists(string projectName)
        {
            
            var packageName = Driver.Instance.FindElementAndWait(By.XPath("//*[@class='app-store-share pack']//h3//a[contains(text(), '" + projectName + "')]"), 10);
            
            return true;
        }

        public static bool IsAppExists(string projectName)
        {
            var packageName = Driver.Instance.FindElementAndWait(By.XPath("//*[@class='app-store-share app']//a[contains(text(),'Projects')]"), 10);

            return true;
        }

        public static bool AppsExist(string[] names)
        {
            var elements = Driver.Instance.FindElements(By.XPath("//*[@class='app-store-share app']//h3//a"));
            
            foreach (var element in elements)
            {
                if (names.Contains(element.Text))
                    number++;
            }

            if (number == 6)
                return true;
            else
                return false;
        }

    }
}
