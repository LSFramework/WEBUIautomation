using OpenQA.Selenium;
using WEBUIautomation.WebElement;
using WEBPages.Extensions;
using WEBPages.BasePageObject;

namespace WEBPages.MyPCPages
{
    using Locators = ContentLocators.Locators.StartRunDialog;

    public class StartRunDialog : FirstLevelDialog
    {
        public override By FrameLocator { get { return Locators.FrameLocator; } }        

        public override string ViewLocator { get { return Locators.ViewLocator; } }
        
        
        WebElement btnRun
        { get { return dialog.NewWebElement().ById(Locators.btnRunId); } }

        public StartRunDialog ClickRunBtn()
        {
            btnRun.Click();
            return this;
        }
    }
}
