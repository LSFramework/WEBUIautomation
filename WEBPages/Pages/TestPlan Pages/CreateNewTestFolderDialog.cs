using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBUIautomation.Utils;

namespace WEBPages.Pages.TestPlan_Pages
{

    public static class CreateNewTestFolderDialog
    {
        
        #region Dialog locator

        const string position = @".//iframe[contains(@ng-src,'CreateNewTestFolder.aspx')]";

        static IWebDriverExt driver= Driver.Instance;

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

        #endregion

        #region Items' Locators

        const string txtInputFolderName = "ctl00_ctl00_PageContent_DialogContent_TxtTestFolderName";

        const string btnOk = "ctl00_ctl00_PageContent_DialogActions_btnOK";

        const string btnClose = "ctl00_ctl00_PageContent_btnClose";

        #endregion //Items' Locators

        #region Actions


        /// <summary>
        /// Performs typing the name of a folder to textBox
        /// </summary>
        /// <param name="folderName">string folderName to be typed to textBox</param>
        public static void TypeFolderName(string folderName)
        {
            Dialog.FindElementAndWait(By.Id(txtInputFolderName)).Clear();
            Dialog.FindElementAndWait(By.Id(txtInputFolderName)).SendKeys(folderName);
        }


        /// <summary>
        /// Performs click OK button that closes dialog with creating of a folder of folder name was typed
        /// If folder name wasn't typed dialog will not be closed.
        /// </summary>
        public static void ClickOk() 
        {
            Dialog.FindElementAndWait(By.Id(btnOk)).Click();
        }


        /// <summary>
        /// Closes dialog without creating of a folder if folder name was typed
        /// </summary>
        public static void ClickClose()
        {
            Dialog.FindElementAndWait(By.Id(btnClose));
        }

        #endregion // Actions
    }

}
