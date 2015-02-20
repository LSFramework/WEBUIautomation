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
    partial class DesignLoadTest
    {
        public partial class Workload
        {
            public class WorkloadTypeDialog
            {
                #region Private content
                
                static IWebElement _WorkloadTypeDialog
                { get { return WorkloadFrame.FindElementAndWait(By.Id("ctl00_PageContent_WorkloadTypeDialog_C")); } }
                
                #endregion

                #region Content to select WorkloadType

                public static IWebElement imgBtnSimpleByLT
                { get { return _WorkloadTypeDialog.FindElementAndWait(By.XPath(".//*[@id='ctl00_PageContent_WorkloadTypeDialog_C_WorkloadCntrl_imgBtnSimpleByLT']")); } }

                public static IWebElement chkSimpleByLTByNumber
                { get { return _WorkloadTypeDialog.FindElementAndWait(By.XPath(".//*[@id='ctl00_PageContent_WorkloadTypeDialog_C_WorkloadCntrl_chkSimpleByLTByNumber']")); } }

                public static IWebElement chkSimpleByLTByPrecentage
                { get { return _WorkloadTypeDialog.FindElementAndWait(By.XPath(".//*[@id='ctl00_PageContent_WorkloadTypeDialog_C_WorkloadCntrl_chkSimpleByLTByPrecentage']")); } }

                public static IWebElement imgBtnSimpleByGroup
                { get { return _WorkloadTypeDialog.FindElementAndWait(By.XPath(".//*[@id='ctl00_PageContent_WorkloadTypeDialog_C_WorkloadCntrl_imgBtnSimpleByGroup']")); } }

                public static IWebElement imgBtnComplexByLT
                { get { return _WorkloadTypeDialog.FindElementAndWait(By.XPath(".//*[@id='ctl00_PageContent_WorkloadTypeDialog_C_WorkloadCntrl_imgBtnComplexByLT']")); } }

                public static IWebElement chkComplexByLTByNumber
                { get { return _WorkloadTypeDialog.FindElementAndWait(By.XPath(".//*[@id='ctl00_PageContent_WorkloadTypeDialog_C_WorkloadCntrl_chkComplexByLTByNumber']")); } }

                public static IWebElement chkComplexByLTByPrecentage
                { get { return _WorkloadTypeDialog.FindElementAndWait(By.XPath(".//*[@id='ctl00_PageContent_WorkloadTypeDialog_C_WorkloadCntrl_chkComplexByLTByPrecentage']")); } }
                public static IWebElement imgBtnComplexByGroup
                { get { return _WorkloadTypeDialog.FindElementAndWait(By.XPath(".//*[@id='ctl00_PageContent_WorkloadTypeDialog_C_WorkloadCntrl_imgBtnComplexByGroup']")); } }

                #endregion

                #region Actions Pane

                public static IWebElement btnOK
                { get { return _WorkloadTypeDialog.FindElementAndWait(By.XPath(".//*[@id='ctl00_PageContent_WorkloadTypeDialog_C_WorkloadCntrl_btnOk']")); } }

                public static IWebElement btnCancel
                { get { return _WorkloadTypeDialog.FindElementAndWait(By.XPath(".//*[@id='ctl00_PageContent_WorkloadTypeDialog_C_WorkloadCntrl_btnCancel'] ")); } }

                public static IWebElement btnHelp
                { get { return _WorkloadTypeDialog.FindElementAndWait(By.XPath(".//*[@id='ctl00_PageContent_WorkloadTypeDialog_C_WorkloadCntrl_btnHelp'] ")); } }

                #endregion  Actions Pane
            }
        }
    }
}