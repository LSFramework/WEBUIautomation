using WEBPages.BasePageObject;
using WEBUIautomation.WebElement;
using WEBPages.Extensions;
using WEBUIautomation.Wait;
using System;

namespace WEBPages.MyPCPages.Online
{
  
using Locators = ContentLocators.Locators.Online;

    public class OnlineScreen : FramePageBase
    {
        //  RunStart /RunStart.aspx
        public override string ViewLocator
        {
            get { return Locators.ViewLocator; }
        }

        public override OpenQA.Selenium.By FrameLocator
        {
            get { return Locators.FrameLocator; }
        }

        private WebElement CloseBtn { get { return driver.GetElement().ById("ctl00_PageContent_btnFinishedRunClose"); } }

        private WebElement testFinishedPopup { get { return driver.GetElement().ById(Locators.PanelRunFinishedId); } }

        private string isFinishedTabIndexValue { get { return driver.GetElement().ById("ctl00_PageContent_hidRunFinished").GetAttribute(WEBUIautomation.Tags.TagAttributes.TabIndex); } }

        private bool _TestFinished()
        {
            return isFinishedTabIndexValue == "-1";
        }

        public bool WaitForTestFinished()
        {
            try
            {
                WaitHelper.WithTimeout(TimeSpan.FromMinutes(10), TimeSpan.FromSeconds(5))
                   .WaitFor(() => _TestFinished());
            }
            catch
            {
                throw;
            }

            return true;
        }

        public void CloseButtonClick()
        {
            CloseBtn.Click();
        }
    }
}
