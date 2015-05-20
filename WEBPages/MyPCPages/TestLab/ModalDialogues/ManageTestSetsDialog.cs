using OpenQA.Selenium;
using WEBUIautomation.WebElement;
using WEBPages.Extensions;
using WEBPages.BasePageObject;

namespace WEBPages.MyPCPages
{
    using Locators = ContentLocators.Locators.ManageTestSetsDialog;
    

    /// <summary>
    /// Implements  actions for Manage Test Sets dialog
    /// </summary>
    public partial class ManageTestSetsDialog : FirstLevelDialog
    {       
        #region The dialog locators

        public override By FrameLocator { get { return Locators.FrameLocator; } }        
        public override string ViewLocator { get { return Locators.ViewLocator; } }
        
        #endregion The dialog locators

        #region Properties

        /// <summary>
        /// returns name of a selected folder in tree.
        /// </summary>
        public string SelectedFolder { get { return dialog.FindSelectedFolder(); } }

        #endregion Properties

        #region UI Web Elements

        private WebElement btnNewFolder { get { return dialog.GetElement().ByClass(Locators.btnNewFolderClassName, false); } }

        private WebElement btnNewTestSet { get { return dialog.GetElement().ByClass(Locators.btnNewTestSetClassName, false); } }

        private WebElement btnDelete { get { return dialog.GetElement().ByClass(Locators.btnDeleteItemClassName, false); } }

        private WebElement treeView { get { return dialog.GetElement().ById(Locators.treeViewID); } }

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
            btnOk.Click();
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
