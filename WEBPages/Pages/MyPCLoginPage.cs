using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBUIautomation;
using WEBUIautomation.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using WEBPages.Properties;

namespace WEBPages.Pages
{
    //Contains the methods to complete Login MyPC
    public class MyPCLoginPage
    {

        private static List<string> beforePopup, afterPopup;

        public static void EnterName(string name)
        {
            var nameField = Driver.Instance.FindElement(By.CssSelector(Resources.CssUserNameSelector));
            nameField.Clear();
            nameField.SendKeys(name);
        }

        public static void EnterPassword(string pass)
        {
            var passField = Driver.Instance.FindElement(By.CssSelector(Resources.CssPasswordSelector));
            passField.Clear();
            passField.SendKeys(pass);
        }

        public static void Authenticate()
        {
            Driver.Instance.FindElement(By.CssSelector(Resources.CssBtnAuthSelector)).Click();
        }

        public static void SelectDomain(string domain)
        {
            Driver.Wait(4);
            var domainLink = Driver.Instance.FindElementAndWait(By.XPath(Resources.xPathDomainSelector));
            domainLink.Click();

            domainLink = Driver.Instance.FindElementAndWait(By.XPath(Resources.xPathDomainsDropDownList + domain + "')]"));
            Driver.Wait(1);
            domainLink.Click();
        }

        public static void SelectProject(string project)
        {
            Driver.Wait(2);
            Driver.Instance.FindElement(By.XPath(Resources.xPathProjectSelector)).Click();
            Driver.Wait(2);
            Driver.Instance.FindElement(By.XPath(Resources.xPathProjectsDropDownList + project + "')]")).Click();
        }

        public static void Submit()
        {
            beforePopup = Driver.Instance.WindowHandles.ToList();
            Driver.Wait(2);
            Driver.Instance.FindElement(By.XPath(Resources.xPathLoginBtn)).Click();

            //Getting focus on the MyPC popup window
            Driver.Wait(5);
            do
            {
                afterPopup = Driver.Instance.WindowHandles.ToList();
            } while (Driver.Instance.WindowHandles.ToList().Count <= 1);

            var result = afterPopup.Except(beforePopup).ToList();
            Driver.Instance.SwitchTo().Window(result[0]);
            Driver.Wait(3);       
        }               
    }
}
