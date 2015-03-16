using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBUIautomation.Utils;

namespace WEBPages.Pages.TestPlan_Pages
{
    #region Create New Test Dialog

    public static class CreateNewTestDialog
    {
        public static IWebElement txtNewTestName
        { get { return Driver.Instance.FindElementAndWait(By.Id("ctl00_ctl00_PageContent_DialogContent_txtNewTestName")); } }

        public static IWebElement cmbTestSetTree
        { get { return Driver.Instance.FindElementAndWait(By.Id("ctl00_ctl00_PageContent_DialogContent_TestSetTree_ComboTree")); } }

        public static IWebElement btnCreateNewOK
        { get { return Driver.Instance.FindElementAndWait(By.Id("ctl00_ctl00_PageContent_DialogActions_btnCreateNewOK")); } }

        public static IWebElement btnClose
        { get { return Driver.Instance.FindElementAndWait(By.Id("ctl00_ctl00_PageContent_btnClose")); } }

        public static IWebElement btnHelp
        { get { return Driver.Instance.FindElementAndWait(By.Id("ctl00_ctl00_PageContent_btnHelp")); } }

    }

    #endregion
}
