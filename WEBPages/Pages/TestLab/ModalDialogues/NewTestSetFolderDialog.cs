using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBUIautomation.Utils;
using WEBUIautomation.Extensions;
using WEBUIautomation.Wait;
using WEBUIautomation.WebElement;

namespace WEBPages.Pages.TestLab.ModalDialogues
{
    public class NewTestSetFolderDialog : DriverContainer, IPage
    {
        #region The dialog locators

        public string Url { get; private set; }

        public string ViewLocator { get { return "Create New Test Set Folder"; } }

        public By FrameLocator { get { return By.Name("CreateNewTestSetFolder"); } }      

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

        #region  Ctor

        public NewTestSetFolderDialog()
        {
            Url = dialog.Url;
        }

        #endregion

        #region UI Web Elements

        WebElement txtFolderName
        { get { return dialog.NewWebElement().ById("ctl00_ctl00_PageContent_DialogContent_TxtTestSetFolderName"); } }

         WebElement btnOK
        { get { return dialog.NewWebElement().ById("ctl00_ctl00_PageContent_DialogActions_btnOK"); } }

         WebElement btnClose
        { get { return dialog.NewWebElement().ById("ctl00_ctl00_PageContent_btnClose"); } }

         WebElement lblMessage
        { get { return dialog.NewWebElement().ByXPath(@".//*[@id='ctl00_ctl00_PageContent_DialogContent_RequiredFieldValidator1']//font"); } }

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

        #region Properties

        public  bool Opened
        {
            get {
                return WaitHelper.Try(()=>dialog.NewWebElement()
                .ById("ctl00_ctl00_PageContent_DialogContent_PanelCreateNewTestSetFolder")); 
            }
        }

        #endregion Properties

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
