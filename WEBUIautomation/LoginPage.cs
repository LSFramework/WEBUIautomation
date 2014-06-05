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
    public class LoginPage
    {
        private static string domainName;
        private static string projectName;

        public static void SelectWebui()
        {
            Driver.Instance.Navigate().GoToUrl("http://myd-vm00944.hpswlabs.adapps.hp.com:8080/qcbin");
            Driver.Instance.FindElement(By.XPath("//a[@href='ui']")).Click();
        }

        public static void EnterName(string name)
        {
            var nameField = Driver.Instance.FindElement(By.XPath("//*[@id='inputUsername']"));
            nameField.Clear();
            nameField.SendKeys(name);
        }

        public static void EnterPassword(string pass)
        {
            var passField = Driver.Instance.FindElement(By.XPath("//*[@id='inputPassword']"));
            passField.Clear();
            passField.SendKeys(pass);
        }

        public static void Authenticate()
        {
            Driver.Instance.FindElement(By.XPath("//button/translate[@key ='lg:web-ui-login-authenticate']")).Click();
        }

        public static void SelectDomain(string domain)
        {
            Driver.Instance.FindElement(By.XPath("//*[@id='s2id_autogen1']")).Click();
            domainName = domain;
            Driver.Instance.FindElement(By.XPath("//*[@id='select2-drop']//div[contains(text(), '" + domain + "')]")).Click();
        }

        public static void SelectProject(string project)
        {
            Driver.Instance.FindElement(By.XPath("//*[@id='s2id_autogen3']")).Click();
            projectName = project;
            Driver.Instance.FindElement(By.XPath("//*[@id='select2-drop']//div[contains(text(), '" + project + "')]")).Click();
        }

        public static void Submit()
        {
            Driver.Instance.FindElement(By.XPath("//button/translate[@key ='lg:web-ui-login-login']")).Click();
        }
    }
}
