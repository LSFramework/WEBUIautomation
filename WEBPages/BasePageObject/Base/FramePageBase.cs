using OpenQA.Selenium;


namespace WEBPages.BasePageObject
{
    public abstract class FramePageBase : DriverContainer, IFrame
    {
        /// <summary>
        /// Frame Url
        /// </summary>
        public string Url { get; protected set; }

        /// <summary>
        /// Name of Perspective view 
        /// </summary>
        public abstract string ViewLocator { get; }

        /// <summary>
        /// The locator of a frame contains HTML content of the view
        /// </summary>
        public abstract By FrameLocator { get; }

        /// <summary>
        /// Returns true if an expected view is opened, otherwise returns false
        /// </summary>
        public bool ViewOpened { get { return driver.CurrentView == ViewLocator; } }

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
