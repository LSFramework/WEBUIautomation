using OpenQA.Selenium;
using WEBPages.ContentLocators;
using WEBPages.BasePageObject;

namespace WEBPages.MyPCPages
{
    using Locators = ContentLocators.Locators.TrendingPage;

    public class TrendingPage : MainTabBasePage
    {
        protected override MainHead_Links MenuHeader { get { return MainHead_Links.RunAnalysis; } }

        protected override Perspectives ViewName { get { return Perspectives.Trending; } }

        protected override By byKeyElement { get { return Locators.LeftLabel; } }

    }
}
