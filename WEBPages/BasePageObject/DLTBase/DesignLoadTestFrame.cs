using OpenQA.Selenium;
using WEBUIautomation.Extensions;
using System;
using WEBUIautomation.Utils;
using WEBPages.MyPCPages;
using WEBPages.Extensions;
using WEBUIautomation.WebElement;

namespace WEBPages.BasePageObject
{
    using Locators = ContentLocators.Locators.DesignLoadTestFrame;


    /// <summary>
    /// Responsible for navigation to main Dlt frame by testName
    /// </summary>
    public sealed class DesignLoadTestFrame : FramePageBase
    {
        #region LoadTest

        /// <summary>
        /// Required data for DLT.
        /// DLT can not exist without a test
        /// </summary>
        public LoadTest LoadTest { get; private set; }

        private string testName { get { return LoadTest[TestAttributes.TestName]; } }

        MainHead mainHead = new MainHead();

        #endregion //LoadTest

        #region FramePageBase implementation

        public override string ViewLocator { get { return viewLocator(); } }

        private string viewLocator()
        {

          return string.Format("{0} {1}", "DLT main tab", testName);
        }

        public override By FrameLocator { get { return frameLocator(); } }

        private By _frameLocator;

        private By frameLocator()
        {
            if (_frameLocator == null)
            {
                string fullTitle = mainHead.GetDltTabFullTitleValue(testName);

                if (fullTitle != string.Empty)
                {
                    string strLocator = string.Format(@".//iframe[@name = '{0}']", fullTitle);
                    _frameLocator = By.XPath(strLocator);
                }
                else
                {
                    string strLocator = string.Format(@".//iframe[contains(@name, '{0}']", testName);
                    _frameLocator = By.XPath(strLocator);
                }
            }
            
            return _frameLocator;
        }



        #endregion //FramePageBase implementation

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="loadTest"></param>
        public DesignLoadTestFrame(LoadTest loadTest)
        {
            this.LoadTest = loadTest;
            this.Url = dltMainFrame.Url; 
        }

        #region DLT Properties

        /// <summary>
        /// To navigate driver into DLT frame
        /// </summary>
        public IWebDriverExt dltMainFrame { get { return navigateDltTab(); } }

        #endregion DLT Properties

        /// <summary>
        /// Navigation mechanism. Returns driver was navigated to main Dlt Frame
        /// </summary>
        /// <returns></returns>
        private IWebDriverExt navigateDltTab()
        {
            if (!IsDriverOnTheFrame())
            {
                driver.WaitReadyState();

                if (mainHead.IsDltShown(testName))
                {
                    driver.SwitchToFrame(FrameLocator);
                    driver.CurrentView = ViewLocator;
                }
                else
                {
                    mainHead.ClickDLTTab(testName);
                    driver.SwitchToFrame(FrameLocator);
                    driver.CurrentView = ViewLocator;
                }
            }

            return driver;
        }

        public IWebDriverExt WorkloadTabsFrame 
        { 
            get 
            { 
                if(driver.CurrentFrame!=Locators.TabsFrameLocator)
                    return dltMainFrame.SwitchToFrame(Locators.TabsFrameLocator);
                
                return driver;
            } 
        }

        public IWebDriverExt WorkloadFrame (WorkloadContext context)
        {
            string viewName = context.ViewName.GetEnumDescription();

            if (driver.CurrentView != viewName && driver.CurrentFrame != Locators.WorkloadFrameLocator)
            {
                WorkloadTabsFrame.GetElement().ByTagName(WEBUIautomation.Tags.TagNames.Span).ByText(viewName).Click();
                dltMainFrame.SwitchToFrame(Locators.WorkloadFrameLocator);
                driver.CurrentView = viewName;
            }

            return driver;
        }

        public IWebDriverExt ActionsFrame  
        { 
            get 
            { 
                if(driver.CurrentFrame!= Locators.ActionsFrameLocator)
                    return dltMainFrame.SwitchToFrame(Locators.ActionsFrameLocator);

                return driver;
            } 
        }
    }
}
