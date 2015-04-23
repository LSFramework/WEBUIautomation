using System;
using WEBUIautomation.Utils;
using WEBUIautomation.Extensions;
using WEBUIautomation.WebElement;
using WEBPages.ContentLocators;
using OpenQA.Selenium;
using WEBUIautomation.Wait;

namespace WEBPages.Pages.BasePageObject
{
    public abstract class MainTabFrame: FramePageBase
    {
        #region MainTabFrame abstract memebers

        //The main tab menu item to select a child menu item e.g. "Test Management"
        protected abstract MainHead_Links MenuHeader { get; }

        //The menu item to navigate to a selected View e.g. "Test Plan"
        protected abstract Perspectives ViewName { get; }

        //An element should be found byElement  to check that an expected view is really opened       
        protected abstract By byElement { get; }

        #endregion MainTabFrame abstract memebers

        #region FramePageBase implementation

        //All page-classes inherit this one should be located in MainTab frame.
        public override By FrameLocator { get { return Locators.MainHeadPage.MainTabFrame; } }

        // View locator should be name of the view.
        public override string ViewLocator { get { return ViewName.GetEnumDescription(); } }

        #endregion FramePageBase implementation

        //Ctor to switch driver on the expected view in MainTab frame.
        protected MainTabFrame() { Url = mainTab.Url; }

        //Mechanism to switch driver to the view.
        protected IWebDriverExt mainTab
        {
            get
            {
                if (!IsDriverOnTheFrame())
                {
                    try
                    {
                        driver.SwitchToFrame(FrameLocator);
                        driver.FindElement(byElement);
                        driver.CurrentView = ViewLocator;
                    }
                    catch (Exception)
                    {
                        driver.SwitchTo().DefaultContent();
                        MainHead mainHead = new MainHead();
                        mainHead.ShowPerspective(MenuHeader, ViewName);                     
                    }
                }

                return driver;
            }
        }  
      
    }
}
