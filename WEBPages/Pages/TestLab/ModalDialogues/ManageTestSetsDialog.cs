using OpenQA.Selenium;
using WEBUIautomation.Utils;
using WEBUIautomation.Extensions;
using WEBUIautomation.Wait;
using WEBUIautomation.WebElement;
using WEBPages.Extensions;

namespace WEBPages.Pages.TestLab.ModalDialogues
{
    /// <summary>
    /// Implements  actions for Manage Test Sets dialog
    /// </summary>
    public partial class ManageTestSetsDialog : DriverContainer, IPage
    {       
        #region The dialog locators

        public string Url { get; private set; }
        public string ViewLocator { get { return "Manage Test Sets Dialog"; } }
        public By FrameLocator { get { return By.XPath(@".//iframe[contains(@ng-src,'CrudTestSet.aspx')]"); } }

        public ManageTestSetsDialog()
        {
            Url = dialog.Url;
        }


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

        #endregion The dialog locators

        #region Properties

        public bool Opened
        {
            get
            {
                return WaitHelper.Try(
                    () => dialog.NewWebElement()
                        .ById("ctl00_ctl00_PageContent_DialogContent_PanelCreateNewTestSet")
                        );                                   
            }
        }

        #endregion 

        #region UI Web Elements

         WebElement btnNewFolder
        { get { return dialog.NewWebElement().ByXPath(@".//*[contains(@class, 'newFolderButton')]"); } }

         WebElement btnNewTestSet
        { get { return dialog.NewWebElement().ByXPath(@".//*[contains(@class, 'newItemButton')]"); } }

         WebElement btnDelete
        { get { return dialog.NewWebElement().ByXPath(@".//*[contains(@class, 'deleteButton')]"); } }

         WebElement treeView
        { get { return dialog.NewWebElement().ById("ctl00_ctl00_PageContent_DialogContent_TestSetTreeControl_GenericTreeView1_RadTreeView1"); } }

         WebElement btnOK
        { get { return dialog.NewWebElement().ById("ctl00_ctl00_PageContent_DialogActions_btnOK"); } }

         WebElement btnClose
        { get { return dialog.NewWebElement().ById("ctl00_ctl00_PageContent_btnClose"); } }

        #endregion UI Web Elements

        #region Actions

        public NewTestSetFolderDialog NewFolderBtnClickExpectedSuccess()
        {
            btnNewFolder.Click();
            return new NewTestSetFolderDialog();
        }

        public ManageTestSetsDialog SelectFolder(string folderName)
        {
            dialog.FindTreeItemByText(folderName).Click();
            return this;
        }

        public NewTestSetDialog CreateNewTestSetClick()
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
            SelectFolder("Root");
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

        #endregion Actions
    }
}
