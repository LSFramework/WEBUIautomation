using OpenQA.Selenium;
using System;
using WEBPages.ContentLocators;
using WEBUIautomation.Utils;

namespace WEBPages.BasePageObject
{
    public class WorkloadContext 
    {
        /// <summary>
        /// The menu item to navigate to a selected View e.g. "Groups & Workload"
        /// </summary>
        public WorkloadMenu ViewName { get; private set; }

        /// <summary>
        /// The key determinant element should be found by this locator to be sure that an expected workload tab was opened 
        /// </summary>
        public By byKeyElement { get; private set; }

        /// <summary>
        /// Data defines navigation to tab 
        /// </summary>
        /// <param name="viewName">The menu item to navigate to a selected View e.g. "Groups & Workload".</param>
        /// <param name="keyElement">The key determinant element should be found by this locator to be sure that an expected view is really opened.</param>
        public WorkloadContext(WorkloadMenu viewName,  By keyElement)
        {
            this.ViewName = viewName;
            this.byKeyElement = keyElement;
        }
    }
}
