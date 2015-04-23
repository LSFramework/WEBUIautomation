using OpenQA.Selenium;
using WEBUIautomation.Utils;

namespace WEBPages.Pages
{
    public class DriverContainer
    {
        /// <summary>
        /// Provides access to WebDriver instanse
        /// </summary>
        protected IWebDriverExt driver  { get { return Driver.Instance; } }

        /// <summary>
        ///  Checks the driver is focused on the expected view
        /// </summary>
        /// <param name="FrameLocator">Defines locator for a frame that contains expected view</param>
        /// <param name="ViewLocator">Name of the expected view</param>
        /// <returns>true if driver has focus on the expected view, otherwise returns false</returns>
        protected bool IsDriverOnTheView(By frameLocator, string viewLocator)
        {
            return (driver.CurrentFrame == frameLocator & driver.CurrentView == viewLocator);
        }    
    }
}
