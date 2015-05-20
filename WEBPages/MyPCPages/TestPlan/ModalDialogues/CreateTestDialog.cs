using OpenQA.Selenium;
using System;
using WEBUIautomation.Utils;
using WEBUIautomation.WebElement;
using WEBUIautomation.Extensions;
using WEBPages.Extensions;
using WEBPages.BasePageObject;

namespace WEBPages.MyPCPages
{

    using Locators = WEBPages.ContentLocators.Locators.CreateTestDialog;

    public class CreateTestDialog : FirstLevelDialog
    {
        #region The dialog locators
        
        public override string ViewLocator { get { return Locators.ViewLocator; } }

        public override By FrameLocator { get { return Locators.FrameLocator; } }


        #endregion The dialog locators

        #region UI Web Elements

        WebElement txtNewTestName
        { get { return dialog.GetElement().ById(Locators.txtNewTestNameID); } }

        WebElement cmbTestSetTree
        { get { return dialog.GetElement().ById(Locators.cmbTestSetTreeID); } }

        WebElement btnCreateNewOK
        { get { return dialog.GetElement().ById(Locators.btnCreateNewOKID); } }

        WebElement btnHelp
        { get { return dialog.GetElement().ById(Locators.btnHelpID); } }


        #endregion UI Web Elements

        #region Helpers




        #endregion Helpers

        #region Actions


        public CreateTestDialog TypeTestName(string testName)
        {
            txtNewTestName.SendKeys(testName);
            return this;
        }

        /// <summary>
        /// Gets warning message
        /// </summary>
        /// <returns></returns>
        public string GetWarningMessage()
        {
            return IsMessageDisplayed() ? lblMessage.Text : string.Empty;
        }

        /// <summary>
        /// Gets text from TestFolder input element
        /// </summary>
        /// <returns></returns>
        public string GetTestNameText()
        {
            return txtNewTestName.Text;
        }

        #endregion Actions
    }
}
