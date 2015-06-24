using OpenQA.Selenium;
using WEBPages.BasePageObject;

namespace WEBPages.MyPCPages
{
    using Locators = ContentLocators.Locators.TestRunsPage;

    public class TestRunsPage : MainTabBasePage
    {
        protected override MainHead_Links MenuHeader
        { get { return MainHead_Links.RunAnalysis; } }

        protected override Perspectives ViewName
        { get { return Perspectives.Runs; } }

        protected override By byKeyElement
        { get { return Locators.LeftLabel; } }
    }
}
