using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBUIautomation;
using WEBUIautomation.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using WEBUIautomation.Extensions;
using WEBUIautomation.WebElement;
using System.Threading;
using WEBUIautomation.Wait;


namespace WEBPages.Pages
{
    //Contains the methods to complete Login MyPC
    public class MyPCLoginPage: DriverContainer
    {
        #region WebElements Locators               

        private static WebElement txtUserName { get { return new WebElement().ById("ctl00_PageContent_txtUserName"); } }

        private static WebElement txtPassword { get { return new WebElement().ById("ctl00_PageContent_txtPassword");}}

        private static WebElement btnAuthenticate { get { return new WebElement().ById("ctl00_PageContent_btnAuthenticate");}}

        private static WebElement arrDomains { get { return new WebElement().ById("ctl00_PageContent_ddlDomains_Arrow");}}

        private static WebElement inpDomains { get { return new WebElement().ById("ctl00_PageContent_ddlDomains_Input");}}

        private static WebElement ddlDomains{ get { return new WebElement().ById("ctl00_PageContent_ddlDomains_DropDown");}}

        private static WebElement arrProjects{ get { return new WebElement().ById("ctl00_PageContent_ddlProjects_Arrow");}}

        private static WebElement inpProjects { get { return new WebElement().ById("ctl00_PageContent_ddlProjects_Input");}}

        private static WebElement ddlProjects { get { return new WebElement().ById("ctl00_PageContent_ddlProjects_DropDown");}}

        private static WebElement btnLogin { get { return new WebElement().ById("ctl00_PageContent_btnLogin"); } }      


        #endregion WebElemnts

        #region Actions

        #region Single Actions

        public static void TypeUserName(string userName)
        {
            txtUserName.SendKeys(userName);
        }

        public static void TypePassword(string password)
        {
            txtPassword.SendKeys(password);
        }

        public static void ClickAuthenticate()
        {
           btnAuthenticate.Click();
           ///wait for user Authentication response
           WaitHelper.Try(() => arrDomains.Exists());  
        }

        public static void SelectDomain(string domain)
        {
            arrDomains.Click();
            inpDomains.Click();
            ddlDomains.SelectItem(domain).Click();

            WaitHelper.Try(()=>arrProjects.Exists());            
        }

        public static void SelectProject(string project)
        {
            arrProjects.Click();
            inpProjects.Click();
            ddlProjects.SelectItem(project).Click();
        }

        public static void ClickLogin()
        {
            btnLogin.Click();
        }

        #endregion Single Actions

        #region Complex Actions

        public static void LoginToProject(string userName, string password, string domain, string project)
        {
            TypeUserName(userName);
            TypePassword(password);
            ClickAuthenticate();
            SelectDomain(domain);
            SelectProject(project);
            ClickLogin();
            SwitchToPopup();    
        }

        #endregion Complex Actions

        public static void SwitchToPopup()
        {
            string popup = driver.NewWindow();
            driver.SwitchTo().Window(popup);
            driver.SwitchTo().Window(driver.WindowHandles.First()).Close();
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            driver.SwitchToDefaultContent();
        }

        #endregion Actions
    }        
}
