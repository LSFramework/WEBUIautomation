using OpenQA.Selenium;
using WEBUIautomation.Utils;

namespace WEBPages.BasePageObject
{
    /// <summary>
    /// Provides single WebDriver instanse to all inheritors. 
    /// </summary>
    public abstract class DriverContainer
    {
        // Summary:
        //      Provides access to WebDriver instanse
        protected IWebDriverExt driver { get { return Driver.Instance; } }
    }
}
