using OpenQA.Selenium;

namespace WEBPages.BasePageObject
{
    interface IFrame
    {
        string Url { get; }
        string ViewLocator { get; }
        By FrameLocator { get; }
        bool ViewOpened { get; }
    }
}
