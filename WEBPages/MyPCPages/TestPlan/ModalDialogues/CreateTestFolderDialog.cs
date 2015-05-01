using OpenQA.Selenium;
using WEBUIautomation.WebElement;
using WEBUIautomation.Wait;
using WEBPages.Extensions;
using WEBPages.BasePageObject;


namespace WEBPages.MyPCPages
{

    using Locators = WEBPages.ContentLocators.Locators.CreateTestFolderDialog;

    public class CreateTestFolderDialog : FirstLevelDialog
    {
        #region The dialog locators

        public override string ViewLocator { get { return Locators.ViewLocator; } }
        public override  By FrameLocator { get { return Locators.FrameLocator; } }

        public CreateTestFolderDialog() : base() { }

        #endregion The dialog locators

        #region UI Web Elements

        WebElement dialogTitle
        { get { return dialog.NewWebElement().ById(Locators.dialogTitleID).ByText(Locators.ViewLocator); } }

        WebElement txtTestFolderName
        { get { return dialog.NewWebElement().ById(Locators.txtTestFolderNameID); } }

        WebElement btnOk
        { get { return dialog.NewWebElement().ById(Locators.btnOkID); } }

        WebElement btnClose
        { get { return dialog.NewWebElement().ById(Locators.btnClose); } }

        WebElement lblMessage
        { get { return dialog.NewWebElement().ByXPath(Locators.lblMessageXPath); } }
        
        #endregion UI Web Elements

        #region Properties


        #endregion Properties

        #region Helpers

        bool IsMessageDisplayed()
        {
            return ! WaitHelper.Try(
                () => dialog.NewWebElement()
                    .ById(Locators.requiredFieldValidatorID)
                    .ByAttribute(WEBUIautomation.Tags.TagAttributes.Style, Locators.noMesaageStyleValue));
        }

        #endregion Helpers

        #region Actions



        /// <summary> Action: Performs click OK button.
        ///     Expected :dialog closes  with creating a folder with name was typed.
        ///     If folder name wasn't typed or it is already exists the dialog will not be closed. 
        ///     </summary>
        public TestPlanPage ClickOkBtn()
        {
            btnOk.Click();
            return new TestPlanPage();
        }

        /// <summary>
        /// Action: Performs click Close button 
        /// Expected: The dialog closed  without creating a folder if folder name was typed
        /// </summary>
        public TestPlanPage ClickCloseBtn()
        {
            btnClose.Click();
            return new TestPlanPage();
        }

        /// <summary>
        /// Action: Performs typing a folder name  to the textBox
        /// Expected: Folder name has been typed to the textBox
        /// </summary>
        /// <param name="folderName">string folderName to be typed to textBox</param>
        public CreateTestFolderDialog TypeFolderName(string folderName)
        {
            txtTestFolderName.SendKeys(folderName);
            return this;
        }

        /// <summary>
        /// Gets warning message
        /// </summary>
        /// <returns></returns>
        public string GetWarningMessage()
        {
            return IsMessageDisplayed() ? lblMessage.Text: string.Empty;            
        }

        /// <summary>
        /// Gets text from TestFolder input element
        /// </summary>
        /// <returns></returns>
        public string GetFolderNameText()
        {
            return txtTestFolderName.Text;
        }
        #endregion Actions
    }
}
