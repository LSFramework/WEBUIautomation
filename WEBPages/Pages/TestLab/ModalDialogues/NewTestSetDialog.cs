using OpenQA.Selenium;
using WEBUIautomation.Utils;
using WEBUIautomation.Extensions;
using WEBUIautomation.WebElement;
using WEBUIautomation.Wait;

namespace WEBPages.Pages.TestLab.ModalDialogues
{
    public class NewTestSetDialog: DriverContainer
    {
        #region The dialog locators

        public string Url { get; private set; }

        public string ViewLocator { get { return "Create New Performance Test Set"; } }
        
        public static By FrameLocator {get {return By.Name("CreateNewTestSet");}}

        public NewTestSetDialog()
        {
            Url = dialog.Url;
        }

        IWebDriverExt dialog
        {
            get
            {
                if (!IsDriverOnTheView(FrameLocator, ViewLocator))
                {
                    driver.SwitchToFrame(FrameLocator);
                    driver.CurrentView = ViewLocator;
                }
                return driver;
            }
        }
        
        #endregion The dialog locators

        #region UI Web Elements

         WebElement txtTestSetName
        { get { return dialog.NewWebElement().ById("ctl00_ctl00_PageContent_DialogContent_TxtTestSetName"); } }

         WebElement btnOK
        { get { return dialog.NewWebElement().ById("ctl00_ctl00_PageContent_DialogActions_btnOK"); } }

         WebElement btnClose
        { get { return dialog.NewWebElement().ById("ctl00_ctl00_PageContent_btnClose"); } }

         WebElement lblMessage
        { get { return dialog.NewWebElement().ByXPath(@".//*[@id='ctl00_ctl00_PageContent_DialogContent_RequiredFieldValidator1']//font"); } }

        #endregion UI Web Elements

        #region Properties

        public  bool Opened
        { get
            { return WaitHelper.Try(()=>dialog.NewWebElement()
                .ById("ctl00_ctl00_PageContent_DialogContent_PanelCreateNewTestSet"));         
            }       
        }

        #endregion Properties

        #region Helpers

         bool IsMessageDisplayed()
        {
            return !WaitHelper.Try(
                () => dialog.NewWebElement()
                    .ById("ctl00_ctl00_PageContent_DialogContent_RequiredFieldValidator1")
                    .ByAttribute(WEBUIautomation.Tags.TagAttributes.Style, "color:Red;display:none;")
                    );
        }

        #endregion Helpers

        #region Actions

        #region Single Actions

        public NewTestSetDialog TypeTestSetName(string testSetName)
        {
            txtTestSetName.Text = testSetName;
            return this;
        }

        public NewTestSetDialog ClickOKExpectingFailure()
        {
            btnOK.Click();
            return this;            
        }

        public ManageTestSetsDialog ClickOkExpectingSucces()
        {
             btnOK.Click();
             return new ManageTestSetsDialog();
        }

        public ManageTestSetsDialog ClickClose()
        {
            btnClose.Click();
            return new ManageTestSetsDialog();
        }

        public  string GetWarningMessage()
        {
            if (IsMessageDisplayed())
                return lblMessage.Text;
            return string.Empty;
        }

        #endregion Single Actions


        #region Complex Action




        #endregion Complex Action

        #endregion Actions

    }
}
