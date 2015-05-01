using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBUIautomation.Utils;
using WEBUIautomation.Extensions;

namespace WEBPages.Pages
{
    partial class DesignLoadTest
    {
        public partial class Workload
        {
            public class SummaryGeneralDetails
            {
                const string form = @".//form[contains(@src,'GeneralContent.aspx')]";

                static IWebElement generalDetailsTab
                { get { return WorkloadFrame.FindElementAndWait(By.XPath(form)); } }

                public static IWebElement GeneralDetailsGrid
                { get { return generalDetailsTab.FindElementAndWait(By.Id("ctl00_PageContent_DLTGeneralDetailsGrid")); } }

                public static IWebElement GroupsGrid
                { get { return generalDetailsTab.FindElementAndWait(By.Id("ctl00_PageContent_DLTGroupsGrid")); } }

                public static IWebElement slaToolbarPanel
                { get { return generalDetailsTab.FindElementAndWait(By.Id("ctl00_PageContent_ctl00_PageContent_slaToolbarPanel")); } }

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
        }
    }
}
