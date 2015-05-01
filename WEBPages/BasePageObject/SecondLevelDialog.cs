using WEBUIautomation.Utils;
using WEBUIautomation.Extensions;

namespace WEBPages.BasePageObject
{
    public abstract class SecondLevelDialog : FramePageBase
    {
        protected SecondLevelDialog() { Url = dialog.Url; } 

        protected IWebDriverExt dialog
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
