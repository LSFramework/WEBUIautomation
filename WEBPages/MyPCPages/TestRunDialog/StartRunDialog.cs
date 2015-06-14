using OpenQA.Selenium;
using WEBPages.BasePageObject;
using WEBPages.Extensions;

namespace WEBPages.MyPCPages.TestRunDialog
{

    using WEBUIautomation.WebElement;
    using Locators = ContentLocators.Locators.StartRunDialog;

    public class StartRunDialog: FirstLevelDialog
    {
        public override string ViewLocator { get { return Locators.ViewLocator; } }

        public override By FrameLocator {  get { return Locators.FrameLocator; } }

        private WebElement btnRun { get { return dialog.GetElement().ById(Locators.btnRunId); } }

        private WebElement lblAvailabilityResults { get { return dialog.GetElement().ById(Locators.lblAvailabilityResults); } }

        private bool IsRunAvailable
        { 
            get { return lblAvailabilityResults.Text == Locators.strAvailabe; } 
        }

        private void ClickRunButton()
        {
            btnRun.Click();
        }

        public void StartRunTestIfAvailable()
        {
            if (IsRunAvailable)
                ClickRunButton();
                        
        }
        
    }
}
