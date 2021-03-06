﻿using System;
using WEBUIautomation;
using WEBUIautomation.Extensions;
using OpenQA.Selenium;
using WEBPages.MyPCPages;

namespace WEBPages.BasePageObject
{
    using Locators = ContentLocators.Locators.MainHeadPage;

    /// <summary>
    /// 
    /// </summary>
    public sealed class MainTabFrame: FramePageBase
    {
        /// <summary>
        /// Required data to init a Main Tab view
        /// </summary>
        private InitMainTabContext _tabContext { get; set; }

        #region FramePageBase implementation

        /// <summary>
        /// All page-classes contain this one should be located in MainTab frame.
        /// </summary>
        public override By FrameLocator { get { return Locators.MainTabFrame; } }

        /// <summary>
        /// View locator should be name of the view.
        /// </summary>
        public override string ViewLocator { get { return _tabContext.ViewName.GetEnumDescription(); } }

        #endregion FramePageBase implementation

        /// <summary>
        /// Ctor to switch driver on the expected view in MainTab frame.
        /// </summary>
        public MainTabFrame(InitMainTabContext tabContext)
        {
            this._tabContext = tabContext;
            Url = mainTab.Url; 
        }

        /// <summary>
        /// Provides driver has been focused on the view.
        /// </summary>
        public IWebDriverExt mainTab { get {  return navigateTab(); } }


        /// <summary>
        /// Mechanism to switch driver to the view.
        /// </summary>
        /// <exception cref="OpenQA.Selenium.NotFoundException">Throws when a modal dialogue opened</exception>
        private IWebDriverExt navigateTab()
        {
            if (!IsDriverOnTheFrame())
            {
                try
                {
                    driver.SwitchToFrame(FrameLocator);

                    if (driver.FindElement(_tabContext.byKeyElement).Displayed)
                    {
                        driver.CurrentView = ViewLocator;
                        return driver;
                    }
                    else NavigateFromDefaultContent();
                }
                catch (Exception)
                {
                    NavigateFromDefaultContent();
                }
            }

            return driver;
        }

        private void NavigateFromDefaultContent()
        {
            MainHead mainHead = new MainHead();

            mainHead.ShowPerspective(_tabContext.MenuHeader, _tabContext.ViewName);
        }  
      
    }
}
