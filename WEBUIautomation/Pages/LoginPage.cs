using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Collections.Generic;
using System.Linq;
using WEBUIautomation.Utils;

namespace WEBUIautomation
{
    public class LoginPage
    {
        private static string domainName;
        private static string projectName;
        private static List<string> beforePopup, afterPopup;

        //Need to move the method to Navigation class
        public static void GoTo(string almAddress, string almPort)
        {
            Driver.Instance.Navigate().GoToUrl(almAddress + @":" + almPort + @"/qcbin/");
            Driver.Instance.FindElement(By.XPath("//a[text()='My Performance Center']")).Click();
        }

        public static void EnterName(string name)
        {
            var nameField = Driver.Instance.FindElement(By.CssSelector("#ctl00_PageContent_txtUserName"));
            nameField.Clear();
            nameField.SendKeys(name);
        }

        public static void EnterPassword(string pass)
        {
            var passField = Driver.Instance.FindElement(By.CssSelector("#ctl00_PageContent_txtPassword"));
            passField.Clear();
            passField.SendKeys(pass);
        }

        public static void Authenticate()
        {
            Driver.Instance.FindElement(By.CssSelector("#ctl00_PageContent_btnAuthenticate")).Click();
        }

        public static void SelectDomain(string domain)
        {
            //using Actions class
            //Actions action = new Actions(Driver.Instance);
            Driver.Wait(4);
            var domainLink = Driver.Instance.FindElementAndWait(By.XPath("//*[@id='ctl00_PageContent_ddlDomains_Input']"));
            //action.MoveToElement(domainLink).Build().Perform();
            domainLink.Click();
            domainName = domain;

            domainLink = Driver.Instance.FindElementAndWait(By.XPath("//div[@id='ctl00_PageContent_ddlDomains_DropDown']//li[contains(text(), '"+ domain +"')]"));
            Driver.Wait(1);
            domainLink.Click();
        }

        public static void SelectProject(string project)
        {
            Driver.Wait(2);
            Driver.Instance.FindElement(By.XPath("//*[@id='ctl00_PageContent_ddlProjects_Input']")).Click();
            projectName = project;
            Driver.Wait(2);
            Driver.Instance.FindElement(By.XPath("//*[@id='ctl00_PageContent_ddlProjects_DropDown']//li[contains(text(), '" + project + "')]")).Click();          
        }

        public static void Submit()
        {
            beforePopup = Driver.Instance.WindowHandles.ToList();
            Driver.Wait(2);
            Driver.Instance.FindElement(By.XPath("//input[@id='ctl00_PageContent_btnLogin']")).Click();

            //Getting focus on the MyPC popup window
            Driver.Wait(5);
            do
            {
                afterPopup = Driver.Instance.WindowHandles.ToList();
            } while (Driver.Instance.WindowHandles.ToList().Count <= 1);

            var result = afterPopup.Except(beforePopup).ToList();
            Driver.Instance.SwitchTo().Window(result[0]);
            Driver.Wait(3);

            Actions mouse = new Actions(Driver.Instance);
            mouse.MoveToElement(Driver.Instance.FindElement(By.XPath("//div[contains(@ng-class, 'selectedLink_TestMgmt')]")))
                .MoveToElement(Driver.Instance.FindElementAndWait(By.XPath("//div[contains(@ng-class, 'selectedLink_TestMgmt')]//li[contains(text(), 'Test Plan')]")))
                .Click()            
                .Build().Perform();           
            
        }

        public static void LoginFlow()
        {
            LoginPage.GoTo(Properties.QCServer, Properties.ServerPort);
            LoginPage.EnterName(Properties.UserName);
            LoginPage.EnterPassword(Properties.UserPassword);
            LoginPage.Authenticate();
            LoginPage.SelectDomain(Properties.DomainName);
            LoginPage.SelectProject(Properties.ProjectName);
            LoginPage.Submit();
        }

        public static void LoginFlow(string almAddress, string almPort, string name, string pass, string domain, string proj)
        {
            LoginPage.GoTo(almAddress, almPort);
            LoginPage.EnterName(name);
            LoginPage.EnterPassword(pass);
            LoginPage.Authenticate();
            LoginPage.SelectDomain(domain);
            LoginPage.SelectProject(proj);
            LoginPage.Submit();            
        }
    }
}
