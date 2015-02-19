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
    public partial class DesignLoadTest
    {
        public class WorkloadTypeDialog
        {

            #region Private content

            static string position = @"//frame[contains(@src,'Workload.aspx')]";

            static IWebDriverExt _dialog = Driver.Instance;

            static IWebDriverExt dialog
            {
                get
                {
                    if (_dialog.CurrentFrame != By.XPath(position))
                    {
                        _dialog.SwitchToDefaultContent();
                        _dialog.SwitchToFrame(By.XPath(@"//iframe[contains(@ng-src,'PreManageLoadTest.aspx')]"));
                        _dialog.SwitchToFrame(By.XPath(position));
                        if (!_dialog.IsElementPresent(By.Id("RadWindowWrapper_ctl00_PageContent_WorkloadTypeDialog"), 2))
                            _dialog.FindElementAndWait(By.Id("ctl00_PageContent_btnWorkloadType"));
                    }
                    return _dialog;
                }
            }

            static IWebElement _WorkloadTypeDialog
            { get { return dialog.FindElementAndWait(By.Id("RadWindowWrapper_ctl00_PageContent_WorkloadTypeDialog")); } }
            
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
