using OpenQA.Selenium;
using WEBUIautomation.Utils;
using WEBUIautomation.Extensions;
using WEBUIautomation.WebElement;
using WEBPages.BasePageObject;
using WEBPages.Extensions;
using WEBPages.ContentLocators;
using System;
using System.Diagnostics.Contracts;

namespace WEBPages.MyPCPages
{
    using Locators = WEBPages.ContentLocators.Locators.MainHeadPage;
    using WEBUIautomation.Wait;

    public class MainHead: FramePageBase
    {
        #region Page Locators      

        private By MainTabFrame { get { return Locators.MainTabFrame; } }

        public override By FrameLocator { get { return Locators.FrameLocator; } }

        public override string ViewLocator { get { return Locators.ViewLocator; } }        

        //public bool PageCanGetFocus()
        //{ 
        //    return driver.CurrentFrame == FrameLocator || driver.CurrentFrame == MainTabFrame; 
        //}

        public bool ModalOpened
        {
            get
            {
                WebElement body = mainPage.GetElement().ByXPath(Locators.bodyXPath);
                return body.GetAttribute(WEBUIautomation.Tags.TagAttributes.Class) == Locators.ModalOpened;
            }
        }

        protected IWebDriverExt mainPage
        {
            get 
            {
                return Navigate();           
            }
        }

        private IWebDriverExt Navigate()
        {
            if (driver.CurrentFrame != FrameLocator)
            {
                driver.SwitchToDefaultContent();

                if (ModalOpened)
                {
                    WaitHelper.WithTimeout(TimeSpan.FromSeconds(5)).WaitFor(() => !ModalOpened);
                }
            }
            driver.CurrentView = ViewLocator;
            
            return driver;
        }


        #endregion // Page Locator

        #region Elements Locators

        #region Main Head Title Elements

        WebElement lblUser { get { return mainPage.GetElement().ByXPath(Locators.lblUserXPath); } }

        WebElement lblDomain { get { return mainPage.GetElement().ByXPath(Locators.lblDomainXPath); } }

        WebElement lblProject { get { return mainPage.GetElement().ByXPath(Locators.lblProjectXPath); } }

        WebElement btnLogout { get { return mainPage.GetElement().ByXPath(Locators.btnLogoutXPath); } }

        #endregion  Main Head Title Elements

        #region Main Head Tabs Elements Locators

        private WebElement tabHome      { get { return mainPage.GetElement().ByXPath(Locators.tabHomeXPath); } }

        private WebElement btnCloseDLT  { get { return mainPage.GetElement().ByXPath(Locators.btnCloseDLTXPath); } }        

        public WebElement DltTab (string testName)
        {
            Contract.Assume(testName != string.Empty, "testName cannot be empty");

            driver.SwitchToDefaultContent();

            return new WebElement()
                .ByXPath(Locators.tabItemXPath)
                .ByAttribute(WEBUIautomation.Tags.TagAttributes.Title, testName, false);
        }

        public bool IsDltShown(string testName)
        {

            string fullTitleValue =GetDltTabFullTitleValue(testName);
            driver.WaitReadyState();
            WebElement dltFrame = mainPage.GetElement().ByXPath(Locators.dltIFrameXPath(fullTitleValue));

            string currentDltFrameClassValue = dltFrame.GetAttribute(WEBUIautomation.Tags.TagAttributes.Class);

            return  currentDltFrameClassValue == Locators.shownDltFrameClassValue;

        }

        public string GetDltTabFullTitleValue(string testName)
        {
            return DltTab(testName).GetAttribute(WEBUIautomation.Tags.TagAttributes.Title);
        }

        public WebElement TestExecutionTab(string runName)
        {
            throw new NotImplementedException("TBD");
        }


        #endregion  Main Head Tabs Elements Locators

        #region Main Head Links Elements Locators

        #region Links

        private WebElement mhLink(MainHead_Links mhLink)
        {
            return mainPage.GetElement().ByText(mhLink.GetEnumDescription());
        }

        private WebElement menu(Perspectives menuItem)
        {
            return mainPage.GetElement().ByText(menuItem.GetEnumDescription());
        }

        #endregion Links


        //
        #region Refresh Section

        /// <summary>
        /// Refresh Button
        /// </summary>
        private  WebElement btnRefresh 
        { get { return mainPage.GetElement().ByXPath(Locators.btnRefreshXPath); } }

        /// <summary>
        /// Auto refresh menu
        /// </summary>
        private  WebElement menuAutoRefresh
        {
            get
            {
                return mainPage.GetElement()
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
                return mainPage.GetElement()
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
                return mainPage.GetElement()
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

        public void ClickDLTTab(string testName)
        {
            DltTab(testName).Click();
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
            if (driver.CurrentView != viewName.GetEnumDescription())
            {
                MenuHeaderMouseOver(menuHeader).MenuItemClick(viewName);
                driver.SwitchToFrame(MainTabFrame);
                driver.CurrentView = viewName.GetEnumDescription();
            }
        }

        public MainHead MenuHeaderMouseOver(MainHead_Links menuHeader)
        {
            mainPage.GetElement()
                .ByText(menuHeader.GetEnumDescription())
                .MouseOver();
            return this;
        }

        public void MenuItemClick(Perspectives viewName)
        {
            mainPage.GetElement()
                .ByText(viewName.GetEnumDescription())
                .Click();
        }

        #endregion Main Head Links Actions

        #endregion // DriverContainer Actions
    }   
}
