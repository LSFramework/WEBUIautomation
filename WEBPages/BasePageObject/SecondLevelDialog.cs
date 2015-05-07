using WEBUIautomation.Utils;
using WEBUIautomation.Extensions;

namespace WEBPages.BasePageObject
{
    public abstract class SecondLevelDialog : Dialog
    {
        protected override IWebDriverExt dialog
        {
            get
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
}
