using WEBUIautomation.Utils;
using WEBUIautomation.Extensions;
using WEBPages.Extensions;

namespace WEBPages.BasePageObject
{

    /// <summary>
    /// Responds for navigation to first level dalogs
    /// </summary>
    public abstract class FirstLevelDialog : Dialog
    {
        protected override IWebDriverExt dialog
        {
            get
            {
                if (!IsDriverOnTheFrame())
                {
                    Navigate();
                }

                return driver;
            }
        }

        private void Navigate()
        {
            driver.SwitchToDefaultContent();
            driver.SwitchToFrame(FrameLocator);
            driver.CurrentView = ViewLocator;
        }             
    }
}
