using OpenQA.Selenium;
using WEBUIautomation.Utils;

namespace WEBPages.BasePageObject
{
    public abstract class DriverContainer
    {
        // Summary:
        //      Provides access to WebDriver instanse
        protected IWebDriverExt driver { get { return Driver.Instance; } }
    }

   

    
}
