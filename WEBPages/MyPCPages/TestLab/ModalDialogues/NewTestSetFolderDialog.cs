using OpenQA.Selenium;
using WEBUIautomation.Utils;
using WEBUIautomation.Extensions;
using WEBUIautomation.Wait;
using WEBUIautomation.WebElement;
using WEBPages.Extensions;
using WEBPages.BasePageObject;

namespace WEBPages.MyPCPages
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
        { get { return dialog.GetElement().ById(Locators.txtFolderNameId); } }
        
        #endregion UI Web Elements

        #region Actions

        /// <summary>
        /// Returns string typed in folder name text box
        /// </summary>
        /// <returns></returns>
        public string FolderName
        { get { return txtFolderName.Text; } }

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
            btnOk.Click();
            return new ManageTestSetsDialog();
        }   

        /// <summary>
        /// Action: performs click on Shutdown button
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
