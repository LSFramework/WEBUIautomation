using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBUIautomation;
using WEBUIautomation.Utils;

namespace WEBPages.Pages
{
    public class DesignLoadTest
    {
        #region DLT Frames

        public static void SelectWorkloadType()
        {
                MyPCNavigation.SwitchToFrame(@"//iframe[contains(@ng-src,'PreManageLoadTest.aspx')]");
                MyPCNavigation.SwitchToFrame(@"//*[@id='workload')]");
               // Driver.Instance.FindElementAndWait(By.XPath(@"//*[@id='workload')]"));   
                OKBtn.Click();
        }

        public static IWebElement OKBtn
            {get {return Driver.Instance.FindElementAndWait(By.XPath(".//*[@id='ctl00_PageContent_WorkloadTypeDialog_C_WorkloadCntrl_btnOk']"));} }

        public static IWebElement CancelBtn
            { get { return Driver.Instance.FindElementAndWait(By.XPath(".//*[@id='ctl00_PageContent_WorkloadTypeDialog_C_WorkloadCntrl_btnCancel'] ")); } }
   
        #endregion

    }
}
