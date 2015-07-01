using System.Linq;
using WEBPages.Extensions;
using WEBPages.BasePageObject;
using WEBUIautomation.Wait;
using WEBUIautomation.WebElement;

namespace WEBPages.MyPCPages.SLA
{

    using Locators = ContentLocators.Locators.ServiceLevelAgreementPage;

    class ServiceLevelAgreementPage:DriverContainer
    {
        #region Action Buttons

        private WebElement btnPrevious 
        { get { return driver.GetElement().ById(Locators.btnPrevious); } }

        private WebElement btnNext 
        { get { return driver.GetElement().ById(Locators.btnNext); } }

        private WebElement btnCancel 
        { get { return driver.GetElement().ById(Locators.btnCancel); } }

        private WebElement btnHelp 
        { get { return driver.GetElement().ById(Locators.btnHelp); } }

        #endregion Actions Buttons

        #region Measurments

         private WebElement radioTransactionResponseTime 
         { get { return driver.GetElement().ById(Locators.radioTransactionResponseTime); } }

         private WebElement ddlComplexLoad 
         { get { return driver.GetElement().ById(Locators.ddlComplexLoad); } }

         private WebElement radioErrorsPerSecond 
         { get { return driver.GetElement().ById(Locators.radioErrorsPerSecond); } }

         private WebElement radioTotalHitsStatusPerRun 
         { get { return driver.GetElement().ById(Locators.radioTotalHitsStatusPerRun); } }

         private WebElement radioAverageHitsPerSecond 
         { get { return driver.GetElement().ById(Locators.radioAverageHitsPerSecond); } }

         private WebElement txtThreshold 
         { get { return driver.GetElement().ById(Locators.txtThreshold); } }

        #endregion Measurments

         public void SetTotalHitsStatusPerRun(int totalHits)
         {
             btnNext.Click();
             radioTotalHitsStatusPerRun.Click();
             btnNext.Click();
             txtThreshold.ClickPerform();
             txtThreshold.SendKeys(totalHits.ToString());
                 //.TextInt = totalHits;
             btnNext.Click();
             WaitHelper.Wait(1000);
             btnNext.Click();
             ReturnDriverToMainPCPage();             
         }

         private void ReturnDriverToMainPCPage()
         {
             driver.SwitchTo().Window(driver.WindowHandles.First());
         }
           
    }
}
