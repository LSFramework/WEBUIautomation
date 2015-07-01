using OpenQA.Selenium;
using WEBPages.BasePageObject;
using WEBPages.Extensions;
using WEBUIautomation.WebElement;

namespace WEBPages.MyPCPages.TestRunDialog
{
    using System;
    using Locators = ContentLocators.Locators.StartRunDialog;

    public class StartRunDialog: FirstLevelDialog
    {
        public override string ViewLocator 
        { get { return Locators.ViewLocator; } }

        public override By FrameLocator 
        {  get { return Locators.FrameLocator; } }

        private WebElement btnRun 
        { get { return dialog.GetElement().ById(Locators.btnRunId); } }

        private WebElement lblAvailabilityResults 
        { get { return dialog.GetElement().ById(Locators.lblAvailabilityResults); } }

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
            else
            {
                throw new Exception("Unable to start test  " + lblAvailabilityResults.Text + lblMessage.Text);
            }
                        
        }
        
    }
}
