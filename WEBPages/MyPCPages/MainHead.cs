using OpenQA.Selenium;
using WEBUIautomation.Utils;
using WEBUIautomation.Extensions;
using WEBUIautomation.WebElement;
using WEBPages.BasePageObject;
using WEBPages.Extensions;
using WEBPages.ContentLocators;

namespace WEBPages.MyPCPages
{
    using Locators = WEBPages.ContentLocators.Locators.MainHeadPage;
   
    public class MainHead: FramePageBase
    {
        #region Page Locators      

        private By MainTabFrame { get { return Locators.MainTabFrame; } }

        public override By FrameLocator { get { return Locators.FrameLocator; } }

        public override string ViewLocator { get { return Locators.ViewLocator; } }        

        public bool PageCanGetFocus()
        { 
            return driver.CurrentFrame == FrameLocator || driver.CurrentFrame == MainTabFrame; 
        }

        public bool ModalOpened
        {
            get
            {
                WebElement body = new WebElement().ByXPath(Locators.bodyXPath);
                return body.GetAttribute(WEBUIautomation.Tags.TagAttributes.Class) == Locators.ModalOpened;
            }
        }

        protected IWebDriverExt mainPage
        {
            get 
            {
                if (driver.CurrentFrame != FrameLocator)
                {   
                    driver.SwitchToDefaultContent();
                    if (ModalOpened)
                        throw new NotFoundException(Locators.ExceptionString);
                }
                driver.CurrentView = ViewLocator;
                return driver;            
            }
        }


        #endregion // Page Locator

        #region Elements Locators

        #region Main Head Title Elements

        WebElement lblUser { get { return mainPage.NewWebElement().ByXPath(Locators.lblUserXPath); } }

        WebElement lblDomain { get { return mainPage.NewWebElement().ByXPath(Locators.lblDomainXPath); } }

        WebElement lblProject { get { return mainPage.NewWebElement().ByXPath(Locators.lblProjectXPath); } }

        WebElement btnLogout { get { return mainPage.NewWebElement().ByXPath(Locators.btnLogoutXPath); } }

        #endregion  Main Head Title Elements

        #region Main Head Tabs Elements Locators

        private  WebElement tabHome { get { return mainPage.NewWebElement().ByXPath(Locators.tabHomeXPath); } }

        private  WebElement btnCloseDLT { get { return mainPage.NewWebElement().ByXPath(Locators.btnCloseDLTXPath); } }

        #endregion  Main Head Tabs Elements Locators

        #region Main Head Links Elements Locators

        #region Links

        WebElement mhLink(MainHead_Links mhLink)
        {
            return mainPage.NewWebElement().ByText(mhLink.GetEnumDescription());
        }

        WebElement menu(Perspectives menuItem)
        {
            return mainPage.NewWebElement().ByText(menuItem.GetEnumDescription());
        }

        #endregion Links

        #region Refresh Section
        /// <summary>
        /// Refresh Button
        /// </summary>
        private  WebElement btnRefresh 
        { get { return mainPage.NewWebElement().ByXPath(Locators.btnRefreshXPath); } }

        /// <summary>
        /// Auto refresh menu
        /// </summary>
        private  WebElement menuAutoRefresh
        {
            get
            {
                return mainPage.NewWebElement()
                    .ByTagName(WEBUIautomation.Tags.TagNames.Div)
                    .ByClass(Locators.menuAutoRefreshClass);
            }
        }

        /// <summary>
        /// Auto refresh On 
        /// </summary>
        private  WebElement menuItemAutoRefreshOn
        {
            get
            {
                return mainPage.NewWebElement()
                    .ByTagName(WEBUIautomation.Tags.TagNames.Span)
                    .ByText(Locators.menuItemAutoRefreshOnText);
            }
        }
        /// <summary>
        /// Auto refresh Off
        /// </summary>
        private  WebElement menuItemAutoRefreshOff
        {
            get
            {
                return mainPage.NewWebElement()
                    .ByTagName(WEBUIautomation.Tags.TagNames.Span)
                    .ByText(Locators.menuItemAutoRefreshOffText);
            }
        }
       
        #endregion Refresh Section

        #endregion // Main Head Links Elements Locators
        
        #endregion //Elements Locators

        #region Main Head Actions

        #region Main Head Title Actions

        public void ClickLogout()
        {
            btnLogout.Click();
        }

        public  string GetDomainName()
        {
           return lblDomain.Text;
        }

        public  string GetProjectName()
        {
            return lblProject.Text;
        }

        public  string GetUserLoggedIn()
        {
            return lblUser.Text;
        }

        #endregion Main Head Title

        #region Main Head Tabs Actions

        public  void CloseDLT_Tab()
        {
            btnCloseDLT.Click();
        }

        public  void ClickHomeTab()
        {
            tabHome.Click();
        }

        #endregion Main Head Tabs Actions

        #region Main Head Links Actions

        public MainHead ClickRefresh()
        {
            btnRefresh.Click();
            return this;
        }

        public StartTab ShowStart()
        {
            MenuItemClick(Perspectives.Start);
            driver.CurrentView = Perspectives.Start.GetEnumDescription();
            return this as StartTab;
        }

        public void ShowPerspective(MainHead_Links menuHeader, Perspectives viewName)
        {
            MenuHeaderMouseOver(menuHeader).MenuItemClick(viewName);
            driver.SwitchToFrame(MainTabFrame);
            driver.CurrentView = viewName.GetEnumDescription();
        }

        public MainHead MenuHeaderMouseOver(MainHead_Links menuHeader)
        {
            mainPage.NewWebElement()
                .ByText(menuHeader.GetEnumDescription())
                .MouseOver();
            return this;
        }

        public void MenuItemClick(Perspectives viewName)
        {
            mainPage.NewWebElement()
                .ByText(viewName.GetEnumDescription())
                .Click();
        }

        #endregion Main Head Links Actions

        #endregion // DriverContainer Actions
    }   
}
