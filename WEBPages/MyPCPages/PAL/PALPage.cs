using OpenQA.Selenium;
using WEBPages.BasePageObject;

namespace WEBPages.MyPCPages
{
    using Locators = ContentLocators.Locators.PalPage;

    public class PalPage : MainTabBasePage
    {
        protected override MainHead_Links MenuHeader
        { get { return MainHead_Links.RunAnalysis; } }

        protected override Perspectives ViewName
        { get { return Perspectives.PAL; } }

        protected override By byKeyElement
        { get { return Locators.PalTitle; } }
    }
}
