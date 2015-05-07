using System.Linq;
using WEBUIautomation.Extensions;
using WEBUIautomation.WebElement;
using WEBPages.Extensions;
using WEBPages.BasePageObject;


namespace WEBPages.MyPCPages
{
    using Locators= WEBPages.ContentLocators.Locators.MyPCLoginPage;    

    public class MyPCLoginPage: DriverContainer
    {        
        string windowHandle;

        #region WebElements Locators    
      
        WebElement txtUserName          { get { return new WebElement().ById(Locators.txtUserNameID); } }
        WebElement txtPassword          { get { return new WebElement().ById(Locators.txtPasswordID); } }
        WebElement btnAuthenticate      { get { return new WebElement().ById(Locators.btnAuthenticateID); } }
        WebElement ddlDomains_Arrow     { get { return new WebElement().ById(Locators.ddlDomains_ArrowID); } }
        WebElement ddlDomains_Input     { get { return new WebElement().ById(Locators.ddlDomains_InputID); } }
        WebElement ddlDomains_DropDown  { get { return new WebElement().ById(Locators.ddlDomains_DropDownID); } }
        WebElement ddlProjects_Arrow    { get { return new WebElement().ById(Locators.ddlProjects_ArrowID); } }
        WebElement ddlProjects_Input    { get { return new WebElement().ById(Locators.ddlProjects_InputID); } }
        WebElement ddlProjects_DropDown { get { return new WebElement().ById(Locators.ddlProjects_DropDownID); } }
        WebElement btnLogin             { get { return new WebElement().ById(Locators.btnLoginID); } }      

        #endregion WebElemnts       

        #region Actions

        #region Single Actions

        public MyPCLoginPage TypeUserName(string userName)
        {
            txtUserName.SendKeys(userName);
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
            ddlDomains_Arrow.Click();
            ddlDomains_Input.Click();
            ddlDomains_DropDown.SelectListItem(domain).Click();
            return this;         
        }

        public MyPCLoginPage SelectProject(string project)
        {
            ddlProjects_Arrow.Click();
            ddlProjects_Input.Click();
            ddlProjects_DropDown.SelectListItem(project).Click();
            return this;
        }

        public MyPCLoginPage ClickLogin()
        {
            btnLogin.Click();
            return this;
        }

        #endregion Single Actions

        #region Complex Actions

        public MainHead LoginToProject(string userName, string password, string domain, string project)
        {
            windowHandle = driver.CurrentWindowHandle;

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
            string popup = driver.GetNewWindow();
            driver.SwitchTo().Window(popup);
            driver.SwitchTo().Window(windowHandle).Close();
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            driver.SwitchToDefaultContent();
        }

        #endregion Actions
    }        
}
