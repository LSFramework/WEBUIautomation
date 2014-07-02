﻿using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
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

        //Need to move the method to Navigation class
        public static void GoTo(string almAddress)
        {
            Driver.Instance.Navigate().GoToUrl("http://" + almAddress + ".hpswlabs.adapps.hp.com:8080/qcbin");
            Driver.Instance.FindElement(By.XPath("//a[text()='ALM Web Client']")).Click();
        }

        public static void EnterName(string name)
        {
            var nameField = Driver.Instance.FindElement(By.CssSelector("#inputUsername"));
            nameField.Clear();
            nameField.SendKeys(name);
        }

        public static void EnterPassword(string pass)
        {
            var passField = Driver.Instance.FindElement(By.CssSelector("#inputPassword"));
            passField.Clear();
            passField.SendKeys(pass);
        }

        public static void Authenticate()
        {
            Driver.Instance.FindElement(By.CssSelector(".btn.btn-primary.pull-right")).Click();
        }

        public static void SelectDomain(string domain)
        {
            //using Actions class
            Actions action = new Actions(Driver.Instance);
            var domainLink = Driver.Instance.FindElement(By.XPath("//*[@id='s2id_autogen1']"));
            action.MoveToElement(domainLink).Build().Perform();
            domainLink.Click();
            domainName = domain;
            
            domainLink = Driver.Instance.FindElement(By.XPath("//*[contains(@id, 'select2-result-label')][contains(text(), '" + domain + "')]"));
            domainLink.Click();
        }

        public static void SelectProject(string project)
        {
            Driver.Instance.FindElement(By.XPath("//*[@id='s2id_autogen3']")).Click();
            projectName = project;
            Driver.Instance.FindElement(By.XPath("//*[@id='select2-chosen-4'][contains(text(), '" + project + "')]")).Click();
            
        }

        public static void Submit()
        {
            Driver.Instance.FindElement(By.XPath("//button/translate[@key ='lg:web-ui-login-login']")).Click();
        }

        public static void LoginFlow()
        {
            LoginPage.GoTo("myd-vm00450");
            LoginPage.EnterName("sa");
            LoginPage.EnterPassword("");
            LoginPage.Authenticate();
            LoginPage.SelectDomain("OLEG");
            LoginPage.SelectProject("rest");
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
