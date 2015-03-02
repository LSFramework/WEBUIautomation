using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBUIautomation;
using WEBUIautomation.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;


namespace WEBPages.Pages
{
    //Contains the methods to complete Login MyPC
    public class MyPCLoginPage
    {
        public static IWebElement LoginBtn
        { get { return Driver.Instance.FindElementAndWait(By.Id("ctl00_PageContent_btnLogin")); } }

        public static IWebElement UserNameField
        { get { return Driver.Instance.FindElementAndWait(By.Id("ctl00_PageContent_txtUserName")); } }

        public static IWebElement PasswordField
        { get { return Driver.Instance.FindElementAndWait(By.Id("ctl00_PageContent_txtPassword")); } }

        public static IWebElement AuthenticateBtn
        { get { return Driver.Instance.FindElementAndWait(By.Id("ctl00_PageContent_btnAuthenticate")); } }

        public static IWebElement DomainSelector
        {get {
            
            return Driver.Instance.FindElementAndWait(By.Id("ctl00_PageContent_ddlDomains_Input")); }}

        public static IWebElement Domains_DropDown
        {get{ return Driver.Instance.FindElementAndWait(By.Id("ctl00_PageContent_ddlDomains_DropDown")); } }

        public static IWebElement ProjectSelector
        {get {return Driver.Instance.FindElementAndWait(By.Id("ctl00_PageContent_ddlProjects_Input"));}}

        public static IWebElement Projects_DropDown
        {get {return Driver.Instance.FindElementAndWait(By.Id("ctl00_PageContent_ddlProjects_DropDown"));}}                    
    }        
}
