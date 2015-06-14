using OpenQA.Selenium;


namespace WEBPages.BasePageObject
{

    public abstract class FramePageBase : DriverContainer, IFrame
    {
        //Frame Url
        public string Url { get; protected set; }

        //Name of Perspective view 
        public abstract string ViewLocator { get; }

        //The locator of a frame contains HTML content of the view
        public abstract By FrameLocator { get; }

        // Returns true if an expected view is opened, otherwise returns false
        public bool ViewOpened
        { get { return driver.CurrentView == ViewLocator; } }

        /// <summary>
        ///  Checks the driver is focused on the expected view
        /// </summary>
        /// <returns>true if driver has focus on the expected view, otherwise returns false</returns>
        protected bool IsDriverOnTheFrame()
        {
            return (driver.CurrentView == ViewLocator && driver.CurrentFrame == FrameLocator);
        }
    }

}
