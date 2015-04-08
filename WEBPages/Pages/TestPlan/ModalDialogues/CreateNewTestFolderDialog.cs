using OpenQA.Selenium;
using System;
using WEBUIautomation.Utils;
using WEBUIautomation.WebElement;
using WEBUIautomation.Extensions;
using WEBUIautomation.Wait;

namespace WEBPages.Pages.TestPlan.ModalDialogues
{
    public class CreateNewTestFolderDialog : DriverContainer
    {
        #region The dialog locators

        const string viewLocator = "Create New Test Folder";
        const string frameLocator = @".//iframe[contains(@ng-src,'CreateNewTestFolder.aspx')]";

        static IWebDriverExt dialog
        {
            get
            {
                if (!IsDriverOnTheView(By.XPath(frameLocator), viewLocator))
                {
                    driver.SwitchToDefaultContent();
                    driver.SwitchToFrame(By.XPath(frameLocator));
                    driver.CurrentView = viewLocator;
                }
                return driver;
            }
        }

        #endregion The dialog locators

        #region UI Web Elements

        static WebElement dialogTitle
        { get { return dialog.NewWebElement().ById("dialogTitle").ByText("Create New Test Folder"); } }

        static WebElement txtInputFolderName
        { get { return dialog.NewWebElement().ById("ctl00_ctl00_PageContent_DialogContent_TxtTestFolderName"); } }

        static WebElement btnOk
        { get { return dialog.NewWebElement().ById("ctl00_ctl00_PageContent_DialogActions_btnOK"); } }

        static WebElement btnClose
        { get { return dialog.NewWebElement().ById("ctl00_ctl00_PageContent_btnClose"); } }

        static WebElement lblMessage
        { get { return dialog.NewWebElement().ByXPath(@".//*[@id='ctl00_ctl00_PageContent_DialogContent_RequiredFieldValidator1']//font"); } }
        
        #endregion UI Web Elements

        #region Properties

        public static bool Opened
        {
            get
            {
                return WaitHelper.Try(() => dialog.NewWebElement()
             .ById("ctl00_ctl00_PageContent_DialogContent_PanelCreateNewTestFolder"));
            }
        }

        #endregion Properties

        #region Helpers

        static bool IsMessageDisplayed()
        {
            return !WaitHelper.Try(
                () => dialog.NewWebElement()
                    .ById("ctl00_ctl00_PageContent_DialogContent_RequiredFieldValidator1")
                    .ByAttribute(WEBUIautomation.Tags.TagAttributes.Style, "color:Red;display:none;")
                    );
        }

        #endregion Helpers

        #region Actions

        /// <summary>
        /// Action: Performs click OK button 
        /// Expected :dialog closes  with creating a folder with name was typed
        /// If folder name wasn't typed or it is already exists the dialog will not be closed.
        /// </summary>
        public static void ClickOkBtn()
        {
            btnOk.Click();
        }

        /// <summary>
        /// Action: Performs click Close button 
        /// Expected: The dialog closed  without creating a folder if folder name was typed
        /// </summary>
        public static void ClickCloseBtn()
        {
            btnClose.Click();
        }

        /// <summary>
        /// Action: Performs typing a folder name  to the textBox
        /// Expected: Folder name has been typed to the textBox
        /// </summary>
        /// <param name="folderName">string folderName to be typed to textBox</param>
        public static void TypeFolderName(string folderName)
        {
            txtInputFolderName.Text = folderName;
        }

        /// <summary>
        /// Gets warning message
        /// </summary>
        /// <returns></returns>
        public static string GetWarningMessage()
        {
            if (IsMessageDisplayed())
                return lblMessage.Text;
            return string.Empty;
        }

        #endregion Actions
    }
}
