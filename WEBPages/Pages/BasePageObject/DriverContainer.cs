using OpenQA.Selenium;
using WEBUIautomation.Utils;

namespace WEBPages.Pages
{
    public abstract class DriverContainer
    {
        /// <summary>
        /// Provides access to WebDriver instanse
        /// </summary>
        protected IWebDriverExt driver { get { return Driver.Instance; } }
    }

    interface IFrame
    {
        string Url { get; }
        string ViewLocator { get; }
        By FrameLocator { get; }
        bool Opened { get; }
    }

    public abstract class FramePageBase:DriverContainer, IFrame
    {
        //Frame Url
        public string Url { get; protected set; }
        
        //Name of Perspective view 
        public abstract string ViewLocator { get; }

        //The locator of a frame contains HTML content of the view
        public abstract By FrameLocator { get; }

        //returns true if an expected view is opened, otherwise returns false
        public bool Opened 
        { 
            get 
            { 
                return driver.CurrentView == ViewLocator; 
            } 
        }        

        /// <summary>
        ///  Checks the driver is focused on the expected view
        /// </summary>       
        /// <returns>true if driver has focus on the expected view, otherwise returns false</returns>
        protected bool IsDriverOnTheFrame()
        {
            return (driver.CurrentFrame == FrameLocator & driver.CurrentView == ViewLocator);
        }    
    }

}
