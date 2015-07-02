using OpenQA.Selenium;
using WEBUIautomation;

namespace WEBPages.BasePageObject
{
    /// <summary>
    /// Provides single WebDriver instanse to all inheritors. 
    /// </summary>
    public abstract class DriverContainer
    {
        /// <summary>
        /// Provides access to WebDriver instanse
        /// </summary>
        protected IWebDriverExt driver { get { return Driver.Instance; } }
    }
}
