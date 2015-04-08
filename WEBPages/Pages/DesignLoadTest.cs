using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBUIautomation;
using WEBUIautomation.Utils;
using WEBUIautomation.Extensions;

namespace WEBPages.Pages
{
    public partial class DesignLoadTest
    {
        #region to manage DLT Frames

        //Here is main DLT Frame that contains tree of frames to work 

        const string position = @".//iframe[contains(@ng-src,'PreManageLoadTest.aspx')]";
        
        static IWebDriverExt driver = Driver.Instance;

        static IWebDriverExt MainDLTFrame
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

        static IWebDriverExt NavigateToDLTFrame(By frameBy)
        {
            if (driver.CurrentFrame != frameBy)
            {
                MainDLTFrame.SwitchToFrame(frameBy);
            }
            return driver;
        }

        #endregion

        #region DLT Frames
        public class Tabs
        {
            const string position = "tabs";          
            
            static IWebDriverExt TabsFrame {get { return NavigateToDLTFrame(By.Id(position)); } }
            
            #region Content
            
            public static IWebElement tabSummary
            {get {return TabsFrame.FindElementAndWait(By.XPath(@"//span[contains(text(), 'Summary')]"));}}
            
            public static IWebElement tabGroupsAndWorkload
            { get { return TabsFrame.FindElementAndWait(By.XPath(@"//span[contains(text(), 'Groups & Workload')]")); } }
            
            public static IWebElement tabMonitors
            { get { return TabsFrame.FindElementAndWait(By.XPath(@"//span[contains(text(), 'Monitors')]")); } }
            
            public static IWebElement tabTopology
            { get { return TabsFrame.FindElementAndWait(By.XPath(@"//span[contains(text(), 'Topology')]")); } }
            
            public static IWebElement tabDiagnostics
            { get { return TabsFrame.FindElementAndWait(By.XPath(@"//span[contains(text(), 'Diagnostics')]")); } }

            public static IWebElement tabTestRunsTrend
            { get { return TabsFrame.FindElementAndWait(By.XPath(@"//span[contains(text(), 'Test Runs Trend')]")); } }

            #endregion Content
        }

        public partial class Workload 
        {

            const string strMonitors = @"//form[contains(@action,'Monitors.aspx')]";
            const string strTopology = @"//form[contains(@action,'Topology.aspx')]";
            const string strDiagnostics = @"//form[contains(@action,'Diagnostics.aspx')]";
            const string strRunsTrend = @"//form[contains(@action,'RunsTrend.aspx')]";

            const string position = "workload";
            static IWebDriverExt WorkloadFrame { get { return NavigateToDLTFrame(By.Id(position)); } }
        }

        public class ActionsFrame
        {
            static string position = "actions";
            static IWebDriverExt actionsFrame { get { return NavigateToDLTFrame(By.Id(position)); } }

            public static IWebElement btnSaveAndRun
            { get { return actionsFrame.FindElementAndWait(By.Id("ctl00_PageContent_btnSaveAndRun")); } }

            public static IWebElement btnSave
            { get { return actionsFrame.FindElementAndWait(By.Id("ctl00_PageContent_btnSave")); } }

            public static IWebElement btnClose
            { get { return actionsFrame.FindElementAndWait(By.Id("ctl00_PageContent_btnClose")); } }

            public static IWebElement btnOptions
            { get { return actionsFrame.FindElementAndWait(By.Id("ctl00_PageContent_btnOptions")); } }

            public static IWebElement btnHelp
            { get { return actionsFrame.FindElementAndWait(By.Id("ctl00_PageContent_btnHelp")); } }

        }
               
        #endregion DLT Frames
    }
}
