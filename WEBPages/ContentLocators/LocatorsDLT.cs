using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEBPages.ContentLocators
{
    public static partial class Locators
    {
        public static class DesignLoadTestFrame
        {
            public static string ViewLocator(string testName)
            {
                return string.Format("{0} {1}", "DLT main tab", testName);
            }

            public static By FrameLocator(string testName)
            {
                WEBPages.MyPCPages.MainHead mainHead = new WEBPages.MyPCPages.MainHead();

                string fullTitle= mainHead.GetDltTabFullTitleValue(testName);

                return By.XPath(MainHeadPage.dltIFrameXPath(fullTitle)); 
            }

            public static readonly By TabsFrameLocator = By.Id("tabs");
            public static readonly By WorkloadFrameLocator = By.Id("workload");
            public static readonly By ActionsFrameLocator = By.Id("actions");
            public static readonly string firstPartXPathLocator = @".//ul[@class='rtsUL']/li[";
            public static readonly string lastPartXPathLocator = "]";

            
        }

        public static class DltBasePage
        {
            public static readonly string actionMessageId = "ctl00_PageContent_lblStatus";
            public static readonly string btnSaveAndRunId = "ctl00_PageContent_btnSaveAndRun";
            public static readonly string btnSaveId = "ctl00_PageContent_btnSave";
            public static readonly string btnCloseId = "ctl00_PageContent_btnClose";
            public static readonly string btnOptionsId = "ctl00_PageContent_btnOptions";
            public static readonly string btnHelpId = "ctl00_PageContent_btnHelp";
        }

        public static class DltSummaryPage
        {
            public static readonly By byKeyElement = By.Id("ctl00_PageContent_lblTitleLoadTestDetails");
            public static readonly string toolSLACreate="toolSLACreate";
        }

        public static class DltGroupsAndWorkloadPage
        {
            public static readonly By byKeyElement = By.Id("ctl00_PageContent_updatePanelWorkLoadTypeLink");

            public static readonly string imgBtnComplexByLT = "ctl00_PageContent_WorkloadTypeDialog_C_WorkloadCntrl_imgBtnComplexByLT";
            public static readonly string WorkloadCntrl_btnOk= "ctl00_PageContent_WorkloadTypeDialog_C_WorkloadCntrl_btnOk";
            public static readonly string SelectScript = "SelectScripts";
            public static readonly string ScriptsTreePanel = "ctl00_PageContent__uiScriptsTreeSelectionControl_UpdatePanelEntityTree";
            public static readonly string toolApplySelection = "toolApplySelection";
            public static readonly string txtLoadGenerators = "ctl00_PageContent_WorkloadToolBar_groupsToolbar_i13_txtLoadGenerators";
            public static readonly string WorkloadTypeDialogWrapperId = "RadWindowWrapper_ctl00_PageContent_WorkloadTypeDialog";
            public static readonly string btnWorkloadType = "ctl00_PageContent_btnWorkloadType";
            public static readonly string StyleHiden="visibility: hidden";
            public static readonly string btnCollapseScriptsSlidingPane = "RAD_SPLITTER_SLIDING_PANE_COLLAPSE_ctl00_PageContent_TreeSlidingPane";
            public static readonly string TreeSlidingPane = "ctl00_PageContent_TreeSlidingPane";
            public static readonly string attrStyleVisibleLeft = "left:";
            public static readonly string attrStyleVisibleTop = "top:";

            #region Locators to Tree Slider Pane

            public static readonly string TreeSlidingZone_ClientStateXPath = @"//*[@id='RAD_SPLITTER_PANE_CONTENT_ctl00_PageContent_TreePane']/input";
            public static string DockedValue="\"dockedPaneId\":\"ctl00_PageContent_TreeSlidingPane\"";       
            public static string ExpandedValue="\"expandedPaneId\":\"ctl00_PageContent_TreeSlidingPane\"";  

            #endregion Locators to Tree Slider Pane

            public static readonly string rowDurationXPath = @".//*[@id='ctl00_PageContent_Scheduler_SchedulerGrid_RowId2']/td[1]";
            public static readonly string inputDuarationId = "ctl00_PageContent_Scheduler_SchedulerGrid_DayNTimeIntervalSecs";


        }
    }
}
