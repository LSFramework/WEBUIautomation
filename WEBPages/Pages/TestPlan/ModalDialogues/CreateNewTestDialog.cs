using OpenQA.Selenium;
using System;
using WEBUIautomation.Utils;
using WEBUIautomation.WebElement;
using WEBUIautomation.Extensions;
using WEBPages.Extensions;

namespace WEBPages.Pages.TestPlan.ModalDialogues
{
    public class CreateNewTestDialog : DriverContainer, IPage
    {

        #region The dialog locators

        public string Url { get { return ""; } }
        public string ViewLocator { get { return ""; } }
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

        public WebElement txtNewTestName
        { get { return dialog.NewWebElement().ById("ctl00_ctl00_PageContent_DialogContent_txtNewTestName"); } }

        public WebElement cmbTestSetTree
        { get { return dialog.NewWebElement().ById("ctl00_ctl00_PageContent_DialogContent_TestSetTree_ComboTree"); } }

        public WebElement btnCreateNewOK
        { get { return dialog.NewWebElement().ById("ctl00_ctl00_PageContent_DialogActions_btnCreateNewOK"); } }

        public WebElement btnClose
        { get { return dialog.NewWebElement().ById("ctl00_ctl00_PageContent_btnClose"); } }

        public WebElement btnHelp
        { get { return dialog.NewWebElement().ById("ctl00_ctl00_PageContent_btnHelp"); } }


        #endregion UI Web Elements

        #region Properties

        public static bool Opened
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
