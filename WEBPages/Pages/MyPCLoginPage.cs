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
    public class MyPCLoginPage:PageBase
    {
        #region WebElements Locators               

       const string txtUserName= "ctl00_PageContent_txtUserName";

       const string txtPassword = "ctl00_PageContent_txtPassword";

       const string btnAuthenticate = "ctl00_PageContent_btnAuthenticate";

       const string arrDomains = "ctl00_PageContent_ddlDomains_Arrow";

       const string inpDomains = "ctl00_PageContent_ddlDomains_Input";

       const string ddlDomains="ctl00_PageContent_ddlDomains_DropDown";

       const string arrProjects = "ctl00_PageContent_ddlProjects_Arrow";

       const string inpProjects="ctl00_PageContent_ddlProjects_Input";

       const string ddlProjects = "ctl00_PageContent_ddlProjects_DropDown";

       const string btnLogin = "ctl00_PageContent_btnLogin";
       
        #endregion WebElemnts

        #region Actions

        public static void TypeUserName(string userName)
        {

            driver.FindElementAndWait(By.Id(txtUserName)).Clear();
            driver.FindElementAndWait(By.Id(txtUserName)).SendKeys(userName);
        }

        public static void TypePassword(string password)
        {
          
            driver.FindElementAndWait(By.Id(txtPassword)).Clear();
            driver.FindElementAndWait(By.Id(txtPassword)).SendKeys(password);
        }

        public static void ClickAuthenticate()
        {
            driver.FindElementAndWait(By.Id(btnAuthenticate)).Click(); 
        }

        public static void SelectDomain(string domain)
        {
            driver.FindElementAndWait(By.Id(arrDomains)).Click();
            driver.FindElementAndWait(By.Id(inpDomains)).Click();
            driver.FindElementAndWait(By.Id(ddlDomains)).SelectItem(domain).Click();
        }

        public static void SelectProject(string project)
        {
            driver.FindElementAndWait(By.Id(arrProjects)).Click();
            driver.FindElementAndWait(By.Id(inpProjects)).Click();
            driver.FindElementAndWait(By.Id(ddlProjects)).SelectItem(project).Click();
        }

        public static void ClickLogin()
        {
            driver.FindElementAndWait(By.Id(btnLogin)).Click();
        }

        public static void LoginToProject(string userName, string password, string domain, string project)
        {
            TypeUserName(userName);
            TypePassword(password);
            ClickAuthenticate();
            SelectDomain(domain);
            SelectProject(project);
            ClickLogin();
        
            MyPCNavigation.SwitchToPopup();    
        }

        #endregion Actions

    }        
}
