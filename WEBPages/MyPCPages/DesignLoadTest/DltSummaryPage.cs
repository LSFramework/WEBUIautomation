using OpenQA.Selenium;
using WEBPages.BasePageObject;
using WEBPages.Extensions;
using WEBUIautomation.WebElement;
using WEBUIautomation.Extensions;
using WEBUIautomation.Utils;
using System.Linq;

namespace WEBPages.MyPCPages.DesignLoadTest
{
    using Locators = ContentLocators.Locators.DltSummaryPage;
    using WEBUIautomation.Utils;
    using WEBPages.MyPCPages.SLA;
    
    public class DltSummaryPage : WorkLoadBasePage
    {
        protected override WorkloadMenu ViewName { get { return WorkloadMenu.Summary; } }

        protected override By byKeyElement { get { return Locators.byKeyElement; } }

        public DltSummaryPage(LoadTest loadTest)
            :base(loadTest)
        { }

        private WebElement toolSLACreate 
        { get { return workload.GetElement().ById(Locators.toolSLACreate); } }             
        
        public DltSummaryPage ClickAddNewSlaBtn()
        {
            toolSLACreate.Click();
            return this;
        }

        private ServiceLevelAgreementPage SwitchToSLAPopup()
        {
            var driver = Driver.Instance;
            string popup = driver.GetNewWindow();

            driver.SwitchTo().Window(popup);
           // driver.SwitchToDefaultContent();
            driver.WaitStaticDOM();

            return new ServiceLevelAgreementPage();
        }

        /// <summary>
        /// DEBUG
        /// </summary>
        public void SetSLA()
        {
           ClickAddNewSlaBtn().SwitchToSLAPopup().SetTotalHitsStatusPerRun(1000);
        }


    }

}
