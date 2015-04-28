﻿using OpenQA.Selenium;
using WEBUIautomation.Utils;
using WEBUIautomation.Extensions;
using WEBUIautomation.Wait;
using WEBUIautomation.WebElement;
using WEBPages.Extensions;

namespace WEBPages.Pages.TestLab.ModalDialogues
{
    using Locators = ContentLocators.Locators.NewTestSetFolderDialog;

    public class NewTestSetFolderDialog :SecondLevelDialog
    {
        #region The dialog locators

        public override string ViewLocator { get { return Locators.ViewLocator; } }

        public override By FrameLocator { get { return Locators.FrameLocator; } } 


        #endregion The dialog locators


        #region UI Web Elements

        WebElement txtFolderName
        { get { return dialog.NewWebElement().ById(Locators.txtFolderNameId); } }

         WebElement btnOK
        { get { return dialog.NewWebElement().ById(Locators.btnOkId); } }

         WebElement btnClose
        { get { return dialog.NewWebElement().ById(Locators.btnCloseId); } }

         WebElement lblMessage
        { get { return dialog.NewWebElement().ByXPath(Locators.lblMessageXPath); } }

        #endregion UI Web Elements

        #region Helpers

         bool IsMessageDisplayed()
        {
            return ! WaitHelper.Try(
                () => dialog.NewWebElement()
                    .ById("ctl00_ctl00_PageContent_DialogContent_RequiredFieldValidator1")
                    .ByAttribute(WEBUIautomation.Tags.TagAttributes.Style, "color:Red;display:none;")
                    );
        }

        #endregion Helpers


        #region Actions

        /// <summary>
        /// Returns string typed in folder name text box
        /// </summary>
        /// <returns></returns>
        public string FolderName
        { get { return txtFolderName.Text; } }

        public string WarningMessage
        {
            get
            {
                if (IsMessageDisplayed())
                    return lblMessage.Text;
                return string.Empty;
            }
        }

        /// <summary>
        /// Action: performs typing the folderName string to folder name textbox
        /// Expected: the folderName string is in the textbox
        /// </summary>
        /// <param name="folderName"></param>
        public NewTestSetFolderDialog TypeFolderName(string folderName)
        {
            txtFolderName.Text=folderName;
            return this;
        }

        /// <summary>
        /// Action: Performs click on OK button
        /// Expected positive case: The dialog closed and new test set folder has been created.
        /// Expected negative case: Relevant warning appears in case of the folder name is empty or folder with typed name already exists.
        /// </summary>
        public ManageTestSetsDialog ClickOKExpectedSuccess()
        {
            btnOK.Click();
            return new ManageTestSetsDialog();
        }   

        /// <summary>
        /// Action: performs click on Close button
        /// Expected: The dialog closed.
        /// </summary>
        public ManageTestSetsDialog ClickClose()
        {
            btnClose.Click();
            return new ManageTestSetsDialog();
        }
              

        #endregion Actions
    }
}