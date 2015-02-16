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

        public class WorkloadTypeDialog
        {
            static string position = @"//frame[contains(@src,'Workload.aspx')]";
            
            static IWebDriverExt _dialog=Driver.Instance;

            static IWebDriverExt dialog
            {
                get{
                    if (_dialog.CurrentFrame != By.XPath(position))
                    {
                        _dialog.SwitchToDefaultContent();
                        _dialog.SwitchToFrame(By.XPath(@"//iframe[contains(@ng-src,'PreManageLoadTest.aspx')]"));
                        _dialog.SwitchToFrame(By.XPath(position));
                    }
                    return _dialog;
                }
            }

            #region Content to select WorkloadType
            
            public static IWebElement imgBtnSimpleByLT
            { get { return dialog.FindElementAndWait(By.XPath(".//*[@id='ctl00_PageContent_WorkloadTypeDialog_C_WorkloadCntrl_imgBtnSimpleByLT']")); } }

            public static IWebElement chkSimpleByLTByNumber
            { get { return dialog.FindElementAndWait(By.XPath(".//*[@id='ctl00_PageContent_WorkloadTypeDialog_C_WorkloadCntrl_chkSimpleByLTByNumber']")); } }
            
            public static IWebElement chkSimpleByLTByPrecentage
            { get { return dialog.FindElementAndWait(By.XPath(".//*[@id='ctl00_PageContent_WorkloadTypeDialog_C_WorkloadCntrl_chkSimpleByLTByPrecentage']")); } }
            
            public static IWebElement imgBtnSimpleByGroup
            { get { return dialog.FindElementAndWait(By.XPath(".//*[@id='ctl00_PageContent_WorkloadTypeDialog_C_WorkloadCntrl_imgBtnSimpleByGroup']")); } }
            
            public static IWebElement imgBtnComplexByLT
            { get { return dialog.FindElementAndWait(By.XPath(".//*[@id='ctl00_PageContent_WorkloadTypeDialog_C_WorkloadCntrl_imgBtnComplexByLT']")); } }

            public static IWebElement chkComplexByLTByNumber
            { get { return dialog.FindElementAndWait(By.XPath(".//*[@id='ctl00_PageContent_WorkloadTypeDialog_C_WorkloadCntrl_chkComplexByLTByNumber']")); } }

            public static IWebElement chkComplexByLTByPrecentage
            { get { return dialog.FindElementAndWait(By.XPath(".//*[@id='ctl00_PageContent_WorkloadTypeDialog_C_WorkloadCntrl_chkComplexByLTByPrecentage']")); } }
            public static IWebElement imgBtnComplexByGroup
            { get { return dialog.FindElementAndWait(By.XPath(".//*[@id='ctl00_PageContent_WorkloadTypeDialog_C_WorkloadCntrl_imgBtnComplexByGroup']")); } }
            
            #endregion

            #region Actions Pane
            
            public static IWebElement btnOK
            { get { return dialog.FindElementAndWait(By.XPath(".//*[@id='ctl00_PageContent_WorkloadTypeDialog_C_WorkloadCntrl_btnOk']")); } }

            public static IWebElement btnCancel
            { get { return dialog.FindElementAndWait(By.XPath(".//*[@id='ctl00_PageContent_WorkloadTypeDialog_C_WorkloadCntrl_btnCancel'] ")); } }
            
            public static IWebElement btnHelp
            { get { return dialog.FindElementAndWait(By.XPath(".//*[@id='ctl00_PageContent_WorkloadTypeDialog_C_WorkloadCntrl_btnHelp'] ")); } }

            #endregion  Actions Pane
        }

        public class Tabs
        {
            static string position = @"//frame[contains(@id,'tabs')]";
            static IWebDriverExt _tabs=Driver.Instance;

            static IWebDriverExt tabs
            {
                get{
                    if (_tabs.CurrentFrame != By.XPath(position))
                    {
                        _tabs.SwitchToDefaultContent();
                        _tabs.SwitchToFrame(By.XPath(@"//iframe[contains(@ng-src,'PreManageLoadTest.aspx')]"));
                        _tabs.SwitchToFrame(By.XPath(position));
                    }
                    return _tabs;
                }
            }
            
            #region Content
            
            public static IWebElement tabSummary
            {get {return tabs.FindElementAndWait(By.XPath(@"//span[contains(text(), 'Summary')]"));}}
            
            public static IWebElement tabGroupsAndWorkload
            { get { return tabs.FindElementAndWait(By.XPath(@"//span[contains(text(), 'Groups & Workload')]")); } }
            
            public static IWebElement tabMonitors
            { get { return tabs.FindElementAndWait(By.XPath(@"//span[contains(text(), 'Monitors')]")); } }
            
            public static IWebElement tabTopology
            { get { return tabs.FindElementAndWait(By.XPath(@"//span[contains(text(), 'Topology')]")); } }
            
            public static IWebElement tabDiagnostics
            { get { return tabs.FindElementAndWait(By.XPath(@"//span[contains(text(), 'Diagnostics')]")); } }

            public static IWebElement tabTestRunsTrend
            { get { return tabs.FindElementAndWait(By.XPath(@"//span[contains(text(), 'Test Runs Trend')]")); } }

            #endregion Content
        }

        public class SummaryGeneralDetails
        {
            private static IWebDriverExt _generalDetails
            {
                get {
                    Driver.Instance.SwitchToDefaultContent();
                    Driver.Instance.SwitchToFrame(By.XPath(@"//iframe[contains(@ng-src,'PreManageLoadTest.aspx')]"));
                    return Driver.Instance.SwitchToFrame(By.XPath(@"//frame[contains(@src,'GeneralContent.aspx')]"));
                }
            }

            public static IWebElement GeneralDetailsGrid
            { get { return _generalDetails.FindElementAndWait(By.Id("ctl00_PageContent_DLTGeneralDetailsGrid")); } }
            
            public static IWebElement GroupsGrid
            { get { return _generalDetails.FindElementAndWait(By.Id("ctl00_PageContent_DLTGroupsGrid")); } }
            
            public static IWebElement slaToolbarPanel
            { get { return _generalDetails.FindElementAndWait(By.Id("ctl00_PageContent_ctl00_PageContent_slaToolbarPanel")); } }

            #region SLA Toolbar Actions Pane

            public static IWebElement toolSLACreate
            { get { return slaToolbarPanel.FindElementAndWait(By.Id("toolSLACreate")); } }

            public static IWebElement toolSLAModify
            { get { return slaToolbarPanel.FindElementAndWait(By.Id("toolSLAModify")); } }

            public static IWebElement toolSLADelete
            { get { return slaToolbarPanel.FindElementAndWait(By.Id("toolSLADelete")); } }

            public static IWebElement toolSLADetails
            { get { return slaToolbarPanel.FindElementAndWait(By.Id("toolSLADetails")); } }

            public static IWebElement toolSLATrackingPeriod
            { get { return slaToolbarPanel.FindElementAndWait(By.Id("toolSLATrackingPeriod")); } }

            #endregion


        }

        public class GroupsAndWorkloadPane
        {
            private const string position =  @"//frame[contains(@src,'Workload.aspx')]";
            private static IWebDriverExt _panelWorkLoadAndController = Driver.Instance;
            
            private static IWebDriverExt panelWorkLoadAndController 
            {
                get {
                    if (_panelWorkLoadAndController.CurrentFrame == By.XPath(position))
                        return _panelWorkLoadAndController;
                    else
                    {
                        Tabs.tabGroupsAndWorkload.Click();
                        Driver.Instance.SwitchToDefaultContent();
                        Driver.Instance.SwitchToFrame(By.XPath(@"//iframe[contains(@ng-src,'PreManageLoadTest.aspx')]"));
                        return _panelWorkLoadAndController = Driver.Instance.SwitchToFrame(By.XPath(position));   
                    }                    
                }
            }
        }
        #endregion DLT Frames
    }
}
