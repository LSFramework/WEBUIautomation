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
        //Opening the ALM main page. Click on the WEBUI link
        public static void GoTo(string Server, string Port="8080")
        {
            Driver.Instance.Navigate().GoToUrl(Server+":"+ Port +"/qcbin");
            Driver.Instance.FindElement(By.XPath("//a[@href='ui']")).Click();
        }

        //Enter name credenatials
        public static void EnterName(string name)
        {
            var nameField = Driver.Instance.FindElement(By.XPath("//*[@id='inputUsername']"));
            nameField.Clear();
            nameField.SendKeys(name);
        }

        //Enter password credentials
        public static void EnterPassword(string pass)
        {
            var passField = Driver.Instance.FindElement(By.XPath("//*[@id='inputPassword']"));
            passField.Clear();
            passField.SendKeys(pass);
        }

        //Click on the 'Authenticate button'
        public static void Authenticate()
        {
            Driver.Instance.FindElement(By.XPath("//button/translate[@key ='lg:web-ui-login-authenticate']")).Click();
        }

        //Select 'Domain' from a dropdown list
        public static void SelectDomain(string domain)
        {
            Driver.Instance.FindElement(By.XPath("//*[@id='s2id_autogen1']")).Click();
            Driver.Instance.FindElement(By.XPath("//*[@id='select2-drop']//div[contains(text(), '" + domain + "')]")).Click();
        }

        //Select 'Project' from a dropdown list
        public static void SelectProject(string project)
        {
            Driver.Instance.FindElement(By.XPath("//*[@id='s2id_autogen3']")).Click();
            Driver.Instance.FindElement(By.XPath("//*[@id='select2-drop']//div[contains(text(), '" + project + "')]")).Click();
        }

        //Cick on the 'submit' button
        public static void Submit()
        {
            Driver.Instance.FindElement(By.XPath("//button/translate[@key ='lg:web-ui-login-login']")).Click();
        }

        public static void LoginFlow()
        {
            LoginPage.GoTo(Properties.QCServer);
            LoginPage.EnterName(Properties.UserName);
            LoginPage.EnterPassword(Properties.UserPasswod);
            LoginPage.Authenticate();
            LoginPage.SelectDomain(Properties.Domain);
            LoginPage.SelectProject(Properties.ProjectName);
            LoginPage.Submit();
        }

        public static void LoginFlow(string ALMaddress, string name, string pass, string domain, string proj)
        {
            LoginPage.GoTo(ALMaddress);
            LoginPage.EnterName(name);
            LoginPage.EnterPassword(pass);
            LoginPage.Authenticate();
            LoginPage.SelectDomain(domain);
            LoginPage.SelectProject(proj);
            LoginPage.Submit();
        }
    }
}
