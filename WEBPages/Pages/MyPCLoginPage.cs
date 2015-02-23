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
        # region Xpaths values as constants
        const string CssUserNameSelector = @"#ctl00_PageContent_txtUserName";
        const string CssPasswordSelector = @"#ctl00_PageContent_txtPassword";

        const string CssBtnAuthSelector	= @"#ctl00_PageContent_btnAuthenticate";        
            
        const string xPathDomainSelector =  @"//*[@id='ctl00_PageContent_ddlDomains_Input']";
        const string xPathProjectSelector = @"//*[@id='ctl00_PageContent_ddlProjects_Input']";

        const string xPathProjectsDropDownList = @".//*[@id='ctl00_PageContent_ddlProjects_DropDown']/div/ul";
        const string xPathDomainsDropDownList = @".//*[@id='ctl00_PageContent_ddlDomains_DropDown']/div/ul";

        const string xPathLoginBtn = @"//input[@id='ctl00_PageContent_btnLogin']";

        #endregion

        public static IWebElement LoginBtn
        {get {return Driver.Instance.FindElementAndWait(By.XPath(xPathLoginBtn));}}

        public static IWebElement UserNameField
        { get { return Driver.Instance.FindElementAndWait(By.CssSelector(CssUserNameSelector)); } }

        public static IWebElement PasswordField
        { get { return Driver.Instance.FindElementAndWait(By.CssSelector(CssPasswordSelector)); } }

        public static IWebElement AuthenticateBtn
        { get { return Driver.Instance.FindElementAndWait(By.CssSelector(CssBtnAuthSelector)); } }

        public static IWebElement DomainSelector
        {
            get
            {

              // Driver.Wait(1);
              // Driver.Instance.WaitForVisible(By.XPath(xPathDomainSelector), 10);
               return Driver.Instance.FindElementAndWait(By.XPath(xPathDomainSelector));        
            }
        }

        public static IWebElement Domains_DropDown
        {
            get 
            { 

               // Driver.Wait(1);
                //Driver.Instance.WaitForVisible(By.XPath(xPathDomainsDropDownList),10);
                return Driver.Instance.FindElementAndWait(By.XPath(xPathDomainsDropDownList)); 
            } 
        }

        public static IWebElement ProjectSelector
        {
            get
            {
                //Driver.Wait(1);
                //Driver.Instance.WaitForVisible(By.XPath(xPathProjectSelector), 10);
                return Driver.Instance.FindElementAndWait(By.XPath(xPathProjectSelector));
            }
        }

        public static IWebElement Projects_DropDown
        {
            get
            {
                //Driver.Wait(1);
                //Driver.Instance.WaitForVisible(By.XPath(xPathProjectsDropDownList), 10);
                return Driver.Instance.FindElementAndWait(By.XPath(xPathProjectsDropDownList));
            }
        }                    
    }

    
}
