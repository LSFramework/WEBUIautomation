using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBUIautomation.Utils;

namespace WEBPages.Pages.ModalDialogues
{
    public class CreateNewTestSetDialog:PageBase
    {
        const string position = "CreateNewTestSet";

        
        
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

        static IWebElement txtTestSetName
        { get { return Dialog.FindElementAndWait(By.Id("ctl00_ctl00_PageContent_DialogContent_TxtTestSetName")); } }

        static IWebElement btnOK
        { get { return Dialog.FindElementAndWait(By.Id("ctl00_ctl00_PageContent_DialogActions_btnOK")); } }

        static IWebElement btnClose
        { get { return Dialog.FindElementAndWait(By.Id("ctl00_ctl00_PageContent_btnClose")); } }


        public static void TypeTestSetName(string testSetName)
        {
            txtTestSetName.Clear();
            txtTestSetName.SendKeys(testSetName);
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
