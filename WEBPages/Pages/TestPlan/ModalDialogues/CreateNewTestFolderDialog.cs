using OpenQA.Selenium;
using System;
using WEBUIautomation.Utils;
using WEBUIautomation.WebElement;
using WEBUIautomation.Extensions;
using WEBUIautomation.Wait;
using WEBPages.Extensions;

namespace WEBPages.Pages.TestPlan.ModalDialogues
{
    public class CreateNewTestFolderDialog : DriverContainer ,IPage
    {
        #region The dialog locators

        public string Url { get; private set; }
        public string ViewLocator {get{return  "Create New Test Folder";} }
        public By FrameLocator{ get { return By.XPath(@".//iframe[contains(@ng-src,'CreateNewTestFolder.aspx')]");}}


        IWebDriverExt dialog
        {
            get
            {
                if (!IsDriverOnTheView(FrameLocator, ViewLocator))
                {
                    driver.SwitchToDefaultContent();
                    driver.SwitchToFrame(FrameLocator);
                    driver.CurrentView = ViewLocator;
                }
                return driver;
            }
        }

        public CreateNewTestFolderDialog()
        {
            Url = dialog.Url;
        }

        #endregion The dialog locators

        #region UI Web Elements

        WebElement dialogTitle
        { get { return dialog.NewWebElement().ById("dialogTitle").ByText("Create New Test Folder"); } }

        WebElement txtInputFolderName
        { get { return dialog.NewWebElement().ById("ctl00_ctl00_PageContent_DialogContent_TxtTestFolderName"); } }

        WebElement btnOk
        { get { return dialog.NewWebElement().ById("ctl00_ctl00_PageContent_DialogActions_btnOK"); } }

        WebElement btnClose
        { get { return dialog.NewWebElement().ById("ctl00_ctl00_PageContent_btnClose"); } }

        WebElement lblMessage
        { get { return dialog.NewWebElement().ByXPath(@".//*[@id='ctl00_ctl00_PageContent_DialogContent_RequiredFieldValidator1']//font"); } }
        
        #endregion UI Web Elements

        #region Properties

        public bool Opened
        {
            get
            {
                return WaitHelper.Try(() => dialog.NewWebElement()
             .ById("ctl00_ctl00_PageContent_DialogContent_PanelCreateNewTestFolder"));
            }
        }

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

        /// <summary>
        /// Action: Performs click OK button 
        /// Expected :dialog closes  with creating a folder with name was typed
        /// If folder name wasn't typed or it is already exists the dialog will not be closed.
        /// </summary>
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
        public CreateNewTestFolderDialog TypeFolderName(string folderName)
        {
            txtInputFolderName.Text = folderName;
            return this;
        }

        /// <summary>
        /// Gets warning message
        /// </summary>
        /// <returns></returns>
        public string GetWarningMessage()
        {
            if (IsMessageDisplayed())
                return lblMessage.Text;
            return string.Empty;
        }

        #endregion Actions
    }
}
