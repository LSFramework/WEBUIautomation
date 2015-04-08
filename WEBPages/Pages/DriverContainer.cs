using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBUIautomation.Utils;

namespace WEBPages.Pages
{
    public class DriverContainer 
    {
        /// <summary>
        /// Provides access to WebDriver instanse
        /// </summary>
        protected static IWebDriverExt driver  { get { return Driver.Instance; } }

        /// <summary>
        ///  Checks the driver is focused on the expected view
        /// </summary>
        /// <param name="frameLocator">Defines locator for a frame that contains expected view</param>
        /// <param name="viewLocator">Name of the expected view</param>
        /// <returns>true if driver has focus on the expected view, otherwise returns false</returns>
        protected static bool IsDriverOnTheView(By frameLocator, string viewLocator)
        {
            return (driver.CurrentFrame == frameLocator && driver.CurrentView == viewLocator);
        }
    }
}
