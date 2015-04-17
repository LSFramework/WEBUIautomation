using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBUIautomation.Utils;
using WEBUIautomation.Extensions;

namespace WEBPages.Pages.TestPlan.ModalDialogues
{
    #region Create New Test dialog

    public class CreateNewTestDialog: DriverContainer
    {
        public static IWebElement txtNewTestName
        { get { return driver.FindElementAndWait(By.Id("ctl00_ctl00_PageContent_DialogContent_txtNewTestName")); } }

        public static IWebElement cmbTestSetTree
        { get { return driver.FindElementAndWait(By.Id("ctl00_ctl00_PageContent_DialogContent_TestSetTree_ComboTree")); } }

        public static IWebElement btnCreateNewOK
        { get { return driver.FindElementAndWait(By.Id("ctl00_ctl00_PageContent_DialogActions_btnCreateNewOK")); } }

        public static IWebElement btnClose
        { get { return driver.FindElementAndWait(By.Id("ctl00_ctl00_PageContent_btnClose")); } }

        public static IWebElement btnHelp
        { get { return driver.FindElementAndWait(By.Id("ctl00_ctl00_PageContent_btnHelp")); } }
    }

    #endregion
}
