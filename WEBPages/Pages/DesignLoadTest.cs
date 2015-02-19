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
        #region DLT Frames

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
            const string position =  @"//frame[contains(@src,'Workload.aspx')]";
            static IWebDriverExt _panel = Driver.Instance;
            
            static IWebDriverExt panel 
            {
                get {
                    if (_panel.CurrentFrame != By.XPath(position))                    
                    {
                        Tabs.tabGroupsAndWorkload.Click();
                        Driver.Instance.SwitchToDefaultContent();
                        Driver.Instance.SwitchToFrame(By.XPath(@"//iframe[contains(@ng-src,'PreManageLoadTest.aspx')]"));
                        _panel = Driver.Instance.SwitchToFrame(By.XPath(position));   
                    }                    
                     return _panel;
                }
            }
        }
       
        #endregion DLT Frames
    }
}
