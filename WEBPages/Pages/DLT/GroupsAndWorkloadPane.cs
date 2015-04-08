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
            public class GroupsAndWorkloadPane
            {                
                static IWebElement _GroupsAndWorkloadPane
                { get { return WorkloadFrame.FindElementAndWait(By.Id("ctl00_PageContent_WorkLoadPane")); } }
                
                public static IWebElement inputNumberOfLGs
                {get{return _GroupsAndWorkloadPane.FindElementAndWait(By.Id("ctl00_PageContent_WorkloadToolBar_groupsToolbar_i14_txtLoadGenerators"));}}

                public static IWebElement row0GroupsGrid
                { get { return _GroupsAndWorkloadPane.FindElementAndWait(By.Id("ctl00_PageContent_Groups_GroupsGrid_ctl00__0")); } }
            }
        }
    }
}
