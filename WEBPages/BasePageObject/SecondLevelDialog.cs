using WEBUIautomation;
using WEBUIautomation.Extensions;

namespace WEBPages.BasePageObject
{
    public abstract class SecondLevelDialog : Dialog
    {
        protected override IWebDriverExt dialog
        {
            get
            {
                return Navigate();
            }
        }

        private IWebDriverExt Navigate()
        {
            if (!IsDriverOnTheFrame())
            {
                driver.SwitchToFrame(FrameLocator);
                driver.CurrentView = ViewLocator;
            }

            return driver;
        } 
    }
}
