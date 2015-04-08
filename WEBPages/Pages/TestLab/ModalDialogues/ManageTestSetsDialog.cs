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
    /// <summary>
    /// Implements  actions for Manage Test Sets dialog
    /// </summary>
    public  class ManageTestSetsDialog: DriverContainer
    {       
        #region The dialog locators
       
        const string viewLocator = "Manage Test Sets Dialog";
        const string frameLocator = @".//iframe[contains(@ng-src,'CrudTestSet.aspx')]";
        
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

        #region Properties

        public static bool Opened
        {
            get
            {
                return WaitHelper.Try(() => dialog.NewWebElement()
                        .ById("ctl00_ctl00_PageContent_DialogContent_PanelCreateNewTestSet"));                                   
            } 
        }

        #endregion 

        #region UI Web Elements

        private static WebElement btnNewFolder
        { get { return dialog.NewWebElement().ByXPath(@".//*[contains(@class, 'newFolderButton')]"); } }

        private static WebElement btnNewTestSet
        { get { return dialog.NewWebElement().ByXPath(@".//*[contains(@class, 'newItemButton')]"); } }

        private static WebElement btnDelete
        { get { return dialog.NewWebElement().ByXPath(@".//*[contains(@class, 'deleteButton')]"); } }

        private static WebElement radTreeView
        { get { return dialog.NewWebElement().ById("ctl00_ctl00_PageContent_DialogContent_TestSetTreeControl_GenericTreeView1_RadTreeView1"); } }

        private static WebElement btnOK
        { get { return dialog.NewWebElement().ById("ctl00_ctl00_PageContent_DialogActions_btnOK"); } }

        private static WebElement btnClose
        { get { return dialog.NewWebElement().ById("ctl00_ctl00_PageContent_btnClose"); } }

        #endregion UI Web Elements

        #region Actions

        public static void CreateNewFolderClick()
        {
            btnNewFolder.Click();
        }

        public static void SelectFolder(string folderName)
        {
          dialog.FindFolder(folderName).Click();
        }

        public static void CreateNewTestSetClick()
        {
          btnNewTestSet.Click();      
        }

        public static void SelectTestSet(string testSetName)
        {
          dialog.FindTestSet(testSetName).Click();     
        }

        public static void CloseBtnClick()
        {
            btnClose.Click();
        }

        public static void SelectRootFolder()
        {
            SelectFolder("Root");
        }

        public static void ClickOkBtn()
        { 
            btnOK.Click(); 
        }

        public static bool TryExpandFolder(string folderName)
        { 
            return dialog.TryExpandTreeFolder(folderName); 
        }

        #endregion Actions

    }
}
