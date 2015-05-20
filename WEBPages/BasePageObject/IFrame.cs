using OpenQA.Selenium;

namespace WEBPages.BasePageObject
{

    interface IFrame
    {
        /// <summary>
        /// The frame Url
        /// </summary>
        string Url { get; }
        
        /// <summary>
        /// Alias of View containing by the frame
        /// </summary>
        string ViewLocator { get; }

        /// <summary>
        /// A mechanism by which to find the frame
        /// </summary>
        By FrameLocator { get; }

        /// <summary>
        /// Has the view been opened?
        /// </summary>
        bool ViewOpened { get; }
    }
}
