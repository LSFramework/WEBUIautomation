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
    public class CreateNewTestSetFolderDialog: DriverContainer
    {
        #region The dialog locators

        const string viewLocator = "Create New Test Set Folder";
        const string frameLocator = "CreateNewTestSetFolder";
        
        static IWebDriverExt dialog
        {
            get
            {
                if (!IsDriverOnTheView(By.Name(frameLocator), viewLocator))
                {
                    driver.SwitchToFrame(By.Name(frameLocator));
                    driver.CurrentView = viewLocator;
                }

                return driver;
            }
        }

        #endregion The dialog locators

        #region UI Web Elements

        static WebElement txtFolderName
        { get { return dialog.NewWebElement().ById("ctl00_ctl00_PageContent_DialogContent_TxtTestSetFolderName"); } }

        static WebElement btnOK
        { get { return dialog.NewWebElement().ById("ctl00_ctl00_PageContent_DialogActions_btnOK"); } }

        static WebElement btnClose
        { get { return dialog.NewWebElement().ById("ctl00_ctl00_PageContent_btnClose"); } }

        static WebElement lblMessage
        { get { return dialog.NewWebElement().ByXPath(@".//*[@id='ctl00_ctl00_PageContent_DialogContent_RequiredFieldValidator1']//font"); } }

        #endregion UI Web Elements

        #region Helpers

        static bool IsMessageDisplayed()
        {
            return ! WaitHelper.Try(
                () => dialog.NewWebElement()
                    .ById("ctl00_ctl00_PageContent_DialogContent_RequiredFieldValidator1")
                    .ByAttribute(WEBUIautomation.Tags.TagAttributes.Style, "color:Red;display:none;")
                    );
        }

        #endregion Helpers

        #region Properties

        public static bool Opened
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
        public static string GetFolderName()
        {
            return txtFolderName.Text;
        }

        /// <summary>
        /// Action: performs typing the folderName string to folder name textbox
        /// Expected: the folderName string is in the textbox
        /// </summary>
        /// <param name="folderName"></param>
        public static void TypeFolderName(string folderName)
        {
            txtFolderName.Text=folderName;
        }

        /// <summary>
        /// Action: Performs click on OK button
        /// Expected positive case: The dialog closed and new test set folder has been created.
        /// Expected negative case: Relevant warning appears in case of the folder name is empty or folder with typed name already exists.
        /// </summary>
        public static void ClickOK()
        {
            btnOK.Click();
        }

        /// <summary>
        /// Action: performs click on Close button
        /// Expected: The dialog closed.
        /// </summary>
        public static void ClickClose()
        {
            btnClose.Click();
        }

        public static string GetWarningMessage()
        {
            if (IsMessageDisplayed())
                return lblMessage.Text;
            return string.Empty;
        }

        #endregion Actions
    }
}
