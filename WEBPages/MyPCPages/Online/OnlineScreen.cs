using WEBPages.BasePageObject;
using WEBUIautomation.WebElement;
using WEBPages.Extensions;
using WEBUIautomation.Wait;
using System;
using WEBUIautomation;
using OpenQA.Selenium;
using WEBUIautomation.Extensions;

namespace WEBPages.MyPCPages.Online
{
    using Locators = ContentLocators.Locators.Online;
 
    public class OnlineScreen : FramePageBase
    {
        public LoadTest LoadTest { get; private set; }

        private string runName { get { return LoadTest[TestAttributes.TestName]; } }

        public override string ViewLocator
        { get { return Locators.ViewLocator; } }

        public override By FrameLocator 
        { get { return frameLocator(); } }

        private By _frameLocator;

        private By frameLocator()
        {
            if (_frameLocator == null)
            {
                MainHead mainHead = new MainHead();

                string fullTitle = mainHead.GetExecutionTabFullTitleValue(runName);

                if (fullTitle != string.Empty)
                {
                    string strLocator = string.Format(@".//iframe[@name = '{0}']", fullTitle);
                    _frameLocator = By.XPath(strLocator);
                }
                else
                {
                    string strLocator = string.Format(@".//iframe[contains(@name, '{0}'][contains(@ng-src,'RunStart.aspx')]", runName);
                    _frameLocator = By.XPath(strLocator);
                }
            }

            return _frameLocator;
        }

        public OnlineScreen(LoadTest loadTest)
        {
            this.LoadTest = loadTest;
            this.Url = onlineTab.Url;
        }

        private IWebDriverExt onlineTab 
        {
            get
            {
                if (!IsDriverOnTheFrame())
                {
                    driver.WaitReadyState();

                    MainHead mainHead = new MainHead();

                    if (mainHead.IsExecutionTabShown(runName))
                    {
                        driver.SwitchToFrame(FrameLocator);
                        driver.CurrentView = ViewLocator;
                    }
                    else
                    {
                        mainHead.ClickExecutionTab(runName);
                        driver.SwitchToFrame(FrameLocator);
                        driver.CurrentView = ViewLocator;
                    }
                }

                return driver;
            }
        }

        private WebElement CloseBtn { get { return onlineTab.GetElement().ById(Locators.btnFinishedRunClose); } }

        private WebElement testFinishedPopup { get { return onlineTab.GetElement().ById(Locators.PanelRunFinishedId); } }

        private string isFinishedTabIndexValue 
        { 
            get 
            {
                string value = onlineTab.GetElement().ById(Locators.hidRunFinished).GetAttribute(WEBUIautomation.Tags.TagAttributes.TabIndex);
                return value;
            } 
        }

        private bool _TestFinished()
        {
            try
            {
                return isFinishedTabIndexValue == "-1";
            }
            catch
            {
                return false;
            }
        }

        public bool WaitForTestFinished()
        {
            return WaitHelper.SpinWait(()=> _TestFinished(), TimeSpan.FromMinutes(10), TimeSpan.FromSeconds(1));
        }

        public void CloseButtonClick()
        {
            CloseBtn.Click();
        }
    }
}
