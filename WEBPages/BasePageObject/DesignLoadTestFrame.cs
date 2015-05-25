using OpenQA.Selenium;
using WEBPages.BasePageObject;
using WEBPages.ContentLocators;
using WEBUIautomation.Extensions;
using System;
using WEBUIautomation.Utils;
using WEBPages.MyPCPages;

namespace WEBPages.BasePageObject
{
  
    using Locators = ContentLocators.Locators.DesignLoadTestFrame;


    public abstract class DesignLoadTestFrame : FramePageBase
    {
        #region FramePageBase implementation

        public override string ViewLocator { get { return ViewName.GetEnumDescription(); } }

        public override By FrameLocator { get { return Locators.FrameLocator; } }

        #endregion FramePageBase implementation
        
        /// <summary>
        /// Ctor
        /// </summary>
        protected DesignLoadTestFrame() 
        { 
            Url = dltTab.Url; 
        }

        #region DLT Properties

        /// <summary>
        /// The menu item to navigate to a selected Tab e.g. "Groups & Workload"
        /// </summary>
        protected abstract DLTabs ViewName { get; }

        /// <summary>
        /// /// <summary>
        /// The key determinant element should be found by this locator to be sure that an expected view is really opened 
        /// </summary> 
        /// </summary>
        protected abstract By byKeyElement { get; }

        /// <summary>
        /// To navigate driver into right frame
        /// </summary>
        protected IWebDriverExt dltTab
        {
            get
            {
                try
                {
                    if (!IsDriverOnTheFrame())
                    {

                        driver.SwitchToFrame(FrameLocator);
                        if (driver.FindElement(byKeyElement).Displayed)
                        {
                            driver.CurrentView = ViewLocator;
                        }
                        else throw new NotFoundException();
                    }
                }
                catch (Exception)
                {
                    driver.SwitchTo().DefaultContent();
                    MainHead mainHead = new MainHead();
                    if (mainHead.ModalOpened)
                        throw new NotFoundException(Locators.strModalOpenedException);
                    mainHead.ClickDLTTab();
                    driver.SwitchToFrame(FrameLocator);
                    driver.CurrentView = ViewLocator;
                }

                return driver;
            }
        }

        #endregion DLT Properties
    }
}
