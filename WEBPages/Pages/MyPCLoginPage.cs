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
using OpenQA.Selenium.Remote;


namespace WEBPages.Pages
{
    //Contains the methods to complete Login MyPC
    public class MyPCLoginPage: DriverContainer
    {
        #region WebElements Locators               

        WebElement txtUserName { get { return new WebElement().ById("ctl00_PageContent_txtUserName"); } }

        WebElement txtPassword { get { return new WebElement().ById("ctl00_PageContent_txtPassword");} }

        WebElement btnAuthenticate { get { return new WebElement().ById("ctl00_PageContent_btnAuthenticate");}}

        WebElement arrDomains { get { return new WebElement().ById("ctl00_PageContent_ddlDomains_Arrow");}}

        WebElement inpDomains { get { return new WebElement().ById("ctl00_PageContent_ddlDomains_Input");}}

        WebElement ddlDomains{ get { return new WebElement().ById("ctl00_PageContent_ddlDomains_DropDown");}}

        WebElement arrProjects{ get { return new WebElement().ById("ctl00_PageContent_ddlProjects_Arrow");}}

        WebElement inpProjects { get { return new WebElement().ById("ctl00_PageContent_ddlProjects_Input");}}

        WebElement ddlProjects { get { return new WebElement().ById("ctl00_PageContent_ddlProjects_DropDown");}}

        WebElement btnLogin { get { return new WebElement().ById("ctl00_PageContent_btnLogin"); } }      

        #endregion WebElemnts

        #region Actions

        #region Single Actions

        public MyPCLoginPage TypeUserName(string userName)
        {
            txtUserName.ById("ctl00_PageContent_txtUserName").SendKeys(userName);
            return this;
        }

        public MyPCLoginPage TypePassword(string password)
        {
            txtPassword.SendKeys(password);
            return this;
        }

        public MyPCLoginPage ClickAuthenticate()
        {
           btnAuthenticate.Click();           
           return this;       
        }

        public MyPCLoginPage SelectDomain(string domain)
        {
            arrDomains.Click();
            inpDomains.Click();
            ddlDomains.SelectItem(domain).Click();
            return this;         
        }

        public MyPCLoginPage SelectProject(string project)
        {
            arrProjects.Click();
            inpProjects.Click();
            ddlProjects.SelectItem(project).Click();
            return this;
        }

        public MyPCLoginPage ClickLogin()
        {
            btnLogin.Click(false);
            return this;
        }

        #endregion Single Actions

        #region Complex Actions

        public MainHead LoginToProject(string userName, string password, string domain, string project)
        {
            TypeUserName(userName)
            .TypePassword(password)
            .ClickAuthenticate()
            .SelectDomain(domain)
            .SelectProject(project)
            .ClickLogin()
            .SwitchToPopup();
            return new MainHead();
        }

        #endregion Complex Actions

        void SwitchToPopup()
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
