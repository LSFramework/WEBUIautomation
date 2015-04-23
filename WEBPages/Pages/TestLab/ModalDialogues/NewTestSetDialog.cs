using OpenQA.Selenium;
using WEBUIautomation.Utils;
using WEBUIautomation.Extensions;
using WEBUIautomation.WebElement;
using WEBUIautomation.Wait;
using WEBPages.Extensions;

namespace WEBPages.Pages.TestLab.ModalDialogues
{
    using Locators = ContentLocators.Locators.NewTestSetDialog;

    public class NewTestSetDialog : SecondLevelDialog
    {
        #region The dialog locators

        public override string ViewLocator { get { return Locators.ViewLocator; } }

        public override By FrameLocator { get { return Locators.FrameLocator; } }        
        
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

        public string GetWarningMessage()
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
