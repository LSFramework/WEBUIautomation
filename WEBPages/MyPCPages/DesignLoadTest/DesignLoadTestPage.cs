using OpenQA.Selenium;
using WEBPages.BasePageObject;
using WEBPages.ContentLocators;
using WEBUIautomation.Extensions;

namespace WEBPages.MyPCPages.DesignLoadTest
{

    using WEBUIautomation.Utils;
using Locators = ContentLocators.Locators.DesignLoadTest;

    public abstract class DesignLoadTestFrame : FramePageBase
    {
        #region FramePageBase implementation

        public override string ViewLocator { get { return ViewName.GetEnumDescription(); } }

        public override By FrameLocator { get { return Locators.FrameLocator; } }

        #endregion FramePageBase implementation

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
        /// Ctor
        /// </summary>
        protected DesignLoadTestFrame() 
        { 
            Url = dltTab.Url; 
        }

        protected IWebDriverExt dltTab
        {
            get
            {
                if (!IsDriverOnTheFrame())
                {
                    driver.SwitchToFrame(FrameLocator);
                    ///To Be Done
                }

                return driver;
            }
        }

        #endregion DLT Properties
    }
}
