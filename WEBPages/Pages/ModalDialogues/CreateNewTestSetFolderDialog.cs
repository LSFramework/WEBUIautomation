using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBUIautomation.Utils;

namespace WEBPages.Pages.ModalDialogues
{
    public class CreateNewTestSetFolderDialog:PageBase
    {
        const string position = "CreateNewTestSetFolder";
        
     

        static IWebDriverExt Dialog
        {
            get
            {
                if (driver.CurrentFrame != By.Name(position))
                {
                    driver.SwitchToFrame(By.Name(position));
                }

                return driver;
            }
        }

        static IWebElement txtFolderName
        { get { return Dialog.FindElementAndWait(By.Id("ctl00_ctl00_PageContent_DialogContent_TxtTestSetFolderName")); } }

        static IWebElement btnOK
        { get { return Dialog.FindElementAndWait(By.Id("ctl00_ctl00_PageContent_DialogActions_btnOK")); } }

        static IWebElement btnClose
        { get { return Dialog.FindElementAndWait(By.Id("ctl00_ctl00_PageContent_btnClose")); } }


        public static void TypeFolderName(string folderName)
        {
            txtFolderName.Clear();
            txtFolderName.SendKeys(folderName);
        }

        public static void ClickOK()
        {
            btnOK.Click();
        }

        public static void ClickClose()
        {
            btnClose.Click();
        }

    }
}
