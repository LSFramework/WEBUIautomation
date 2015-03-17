using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBUIautomation.Utils;

namespace WEBPages.Pages.ModalDialogues
{
    /// <summary>
    /// Implements  actions to create/update/delete Test Sets 
    /// </summary>
    public  class ManageTestSetsDialog:PageBase
    {
        const string position = @".//iframe[contains(@ng-src,'CrudTestSet.aspx')]";

        static IWebDriverExt Dialog
        {
            get
            {
                if (driver.CurrentFrame != By.XPath(position))
                {
                    driver.SwitchToDefaultContent();
                    driver.SwitchToFrame(By.XPath(position));
                }

                return driver;
            }
        }


        #region UI Web Elements

        private static IWebElement btnNewFolder
        { get { return Dialog.FindElementAndWait(By.XPath(@".//*[contains(@class, 'newFolderButton')]")); } }

        private static IWebElement btnNewTestSet
        { get { return Dialog.FindElementAndWait(By.XPath(@".//*[contains(@class, 'newItemButton')]")); } }

        private static IWebElement btnDelete
        { get { return Dialog.FindElementAndWait(By.XPath(@".//*[contains(@class, 'deleteButton')]")); } }

        private static IWebElement radTreeView
        { get { return Dialog.FindElementAndWait(By.Id("ctl00_ctl00_PageContent_DialogContent_TestSetTreeControl_GenericTreeView1_RadTreeView1")); } }

        private static IWebElement btnOK
        { get { return Dialog.FindElementAndWait(By.Id("ctl00_ctl00_PageContent_DialogActions_btnOK")); } }

        private static IWebElement btnClose
        { get { return Dialog.FindElementAndWait(By.Id("ctl00_ctl00_PageContent_btnClose")); } }

        #endregion UI Web Elements

        #region Actions

        /// <summary>
        /// Creates a test set folder under Root folder
        /// </summary>
        /// <param name="folderName">Name of the folder to be created</param>
        public static void CreateNewFolderClick()
        {
            radTreeView.SelectItem("Root","span").Click();
            btnNewFolder.Click();//==>> CreateNewTestSetFolderDialog appears
        }

        public static void SelectFolderInTree(string folderName)
        {
            radTreeView.ClickItem(folderName, "span");
        }


        public static void CreateNewTestSetClick()
        {
            btnNewTestSet.Click();
        }


        public static void CloseBtnClick()
        {
            btnClose.Click();
        }


        #endregion Actions

    }
}
