﻿using OpenQA.Selenium;
using WEBUIautomation.Utils;
using WEBUIautomation.Extensions;
using WEBUIautomation.Wait;
using WEBUIautomation.WebElement;
using WEBPages.Extensions;

namespace WEBPages.Pages.TestLab.ModalDialogues
{
    using Locators = ContentLocators.Locators.ManageTestSetsDialog;

    /// <summary>
    /// Implements  actions for Manage Test Sets dialog
    /// </summary>
    public partial class ManageTestSetsDialog : FirstLevelDialog
    {       
        #region The dialog locators
               
        public override string ViewLocator { get { return Locators.ViewLocator; } }
        public override By FrameLocator { get { return Locators.FrameLocator; } }
        
        #endregion The dialog locators

        #region Properties

        /// <summary>
        /// returns name of a selected folder in tree.
        /// </summary>
        public string SelectedFolder { get { return dialog.FindSelectedFolder(); } }

        #endregion Properties
        #region UI Web Elements

        WebElement btnNewFolder
        { get { return dialog.NewWebElement().ByClass(Locators.btnNewFolderClassName, false); } }            

         WebElement btnNewTestSet
        { get { return dialog.NewWebElement().ByClass(Locators.btnNewTestSetClassName, false); } }

         WebElement btnDelete
         { get { return dialog.NewWebElement().ByClass(Locators.btnDeleteItemClassName, false); } }

         WebElement treeView
        { get { return dialog.NewWebElement().ById(Locators.treeViewID); } }

         WebElement btnOK
        { get { return dialog.NewWebElement().ById(Locators.btnOkId); } }

         WebElement btnClose
        { get { return dialog.NewWebElement().ById(Locators.btnCloseID); } }

        #endregion UI Web Elements

        #region Actions

        public NewTestSetFolderDialog btnNewFolderClick()
        {
            btnNewFolder.Click();
            return new NewTestSetFolderDialog();
        }

        public ManageTestSetsDialog SelectFolder(string folderName)
        {
            dialog.FindTreeItemByText(folderName).Click();
            return this;
        }

        public NewTestSetDialog btnNewTestSetClick()
        {
            btnNewTestSet.Click();
            return new NewTestSetDialog();
        }

        public ManageTestSetsDialog SelectTestSet(string testSetName)
        {
          dialog.FindTreeItemByText(testSetName).Click();
            return this;
        }

        public TestLabPage CloseBtnClick()
        {
            btnClose.Click();
            return new TestLabPage();
        }

        public ManageTestSetsDialog SelectRootFolder()
        {
            SelectFolder(Locators.TestLabRoot);
            return this;
        }

        public TestLabPage ClickOkBtnExpectedSuccess()
        { 
            btnOK.Click();
            return new TestLabPage();
        }

        public ManageTestSetsDialog TryExpandFolder(string folderName)
        { 
            dialog.TryExpandTreeFolder(folderName);
            return this;
        }

        public bool IsFolderSelected(string folderName)
        {
            return folderName == dialog.FindSelectedFolder();
        }

        

        #endregion Actions
    }
}
