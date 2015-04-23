using OpenQA.Selenium;
using System;
using WEBUIautomation.Utils;

namespace WEBPages.Pages
{
    public class StartTab : DriverContainer, IPage
    {

        #region The page locators

        public string Url { get; private set; }
        public string ViewLocator { get {return"";} }
        public By FrameLocator { get { return By.XPath(""); } }

        IWebDriverExt dialog
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        #endregion The dialog locators

        #region UI Web Elements




        #endregion UI Web Elements

        #region Properties

        public bool Opened
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        #endregion Properties

        #region Helpers




        #endregion Helpers

        #region Actions




        #endregion Actions
    }
}
