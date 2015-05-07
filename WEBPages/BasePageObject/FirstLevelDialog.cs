using WEBUIautomation.Utils;
using WEBUIautomation.Extensions;
using WEBPages.Extensions;

namespace WEBPages.BasePageObject
{
    public abstract class FirstLevelDialog : Dialog
    {
        protected override IWebDriverExt dialog
        {
            get
            {
                if (!IsDriverOnTheFrame())
                {
                    driver.SwitchToDefaultContent();
                    driver.SwitchToFrame(FrameLocator);
                    driver.CurrentView = ViewLocator;
                }

                return driver;
            }
        }             
    }
}
