using OpenQA.Selenium;
using WEBPages.ContentLocators;
using WEBPages.Pages.BasePageObject;

namespace WEBPages.Pages.Trending
{
    
    using Locators = ContentLocators.Locators.TrendingPage;
    public class TrendingPage : MainTabFrame
    {

        protected override MainHead_Links MenuHeader
        { get { return MainHead_Links.RunAnalysis; } }

        protected override Perspectives ViewName
        { get { return Perspectives.Trending; } }

        protected override By byElement
        {
            get { return Locators.LeftLabel; }
        }
    }
}
