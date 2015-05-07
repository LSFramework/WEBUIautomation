using System;
using WEBUIautomation.Utils;
using WEBUIautomation.Extensions;
using WEBPages.ContentLocators;
using OpenQA.Selenium;
using WEBPages.MyPCPages;

namespace WEBPages.BasePageObject
{
    using Locators = ContentLocators.Locators.MainHeadPage;
    

    public abstract class MainTabFrame: FramePageBase
    {
        #region MainTabFrame abstract memebers

        // Summary:
        //       The main tab menu item to select a child menu item e.g. "Test Management"        
        protected abstract MainHead_Links MenuHeader { get; }

        /// <summary>
        /// The menu item to navigate to a selected View e.g. "Test Plan"
        /// </summary>
        protected abstract Perspectives ViewName { get; }

        /// <summary>
        /// The key determinant element should be found by this locator to be sure that an expected view is really opened 
        /// </summary>    
        protected abstract By byKeyElement { get; }

        #endregion MainTabFrame abstract memebers

        #region FramePageBase implementation

        /// <summary>
        /// All page-classes inherit this one should be located in MainTab frame.
        /// </summary>
        public override By FrameLocator 
        { get { return Locators.MainTabFrame; } }

        /// <summary>
        /// View locator should be name of the view.
        /// </summary>
        public override string ViewLocator 
        { get { return ViewName.GetEnumDescription(); } }

        #endregion FramePageBase implementation


        /// <summary>
        /// Ctor to switch driver on the expected view in MainTab frame.
        /// </summary>
        protected MainTabFrame() 
        { Url = mainTab.Url; }

        /// <summary>
        /// Mechanism to switch driver to the view.
        /// </summary>
        /// <exception cref="OpenQA.Selenium.NotFoundException">Thrown when a modal dialogue opened</exception>
        protected IWebDriverExt mainTab
        {
            get
            {
                if (!IsDriverOnTheFrame())
                {
                    try
                    {

                        driver.SwitchToFrame(FrameLocator);
                        if (driver.FindElement(byKeyElement).Displayed)
                        {
                            driver.CurrentView = ViewLocator;
                        }
                        else throw new NotFoundException();
                    }
                    catch (Exception)
                    {
                        driver.SwitchTo().DefaultContent();
                        MainHead mainHead = new MainHead();
                        if(mainHead.ModalOpened)
                            throw new NotFoundException(Locators.ExceptionString);
                        mainHead.ShowPerspective(MenuHeader, ViewName);
                    }
                }

                return driver;
            }
        }  
      
    }
}
