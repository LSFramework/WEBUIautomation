using OpenQA.Selenium;
using System;
using WEBUIautomation.Utils;

namespace WEBPages.Pages
{
    public class BlankPageClass : DriverContainer, IPage
    {

        #region The dialog locators

        public string Url { get; private set; }
        public string ViewLocator { get;private set; }
        public By FrameLocator { get; private set; }

        IWebDriverExt dialog
        {
            get
            {
                throw  new NotImplementedException();
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
