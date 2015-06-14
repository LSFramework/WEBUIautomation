using OpenQA.Selenium;
using WEBPages.ContentLocators;

namespace WEBPages.BasePageObject
{
    /// <summary>
    /// Implements required data to init a Main Tab view
    /// </summary>
    public class InitMainTabContext
    {
        /// <summary>
        /// The main tab menu item to select a child menu item e.g. "Test Management" 
        /// </summary>
        public MainHead_Links MenuHeader { get; private set; }

        /// <summary>
        /// The menu item to navigate to a selected View e.g. "Test Plan"
        /// </summary>
        public Perspectives ViewName { get; private set; }

        /// <summary>
        /// The key determinant element should be found by this locator to be sure that an expected view is really opened 
        /// </summary>
        public By byKeyElement { get; private set; }

        /// <summary>
        /// Data defines navigation to tab 
        /// </summary>
        /// <param name="menuHeader">The main tab menu item to select a child menu item e.g. "Test Management".</param>
        /// <param name="viewName">The menu item to navigate to a selected View e.g. "Test Plan".</param>
        /// <param name="keyElement">The key determinant element should be found by this locator to be sure that an expected view is really opened.</param>
        public InitMainTabContext(MainHead_Links menuHeader, Perspectives viewName, By keyElement)
        {
            this.MenuHeader = menuHeader;
            this.ViewName = viewName;
            this.byKeyElement = keyElement;
        }
    }
}
