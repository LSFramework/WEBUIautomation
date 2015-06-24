using OpenQA.Selenium;
using WEBPages.BasePageObject;

namespace WEBPages.MyPCPages
{
    using Locators = ContentLocators.Locators.TestResources;

    public class TestResources : MainTabBasePage
    {
        protected override MainHead_Links MenuHeader 
        { get {  return MainHead_Links.Resources; } }

        protected override Perspectives ViewName  
        { get { return Perspectives.TestResources; } }

        protected override By byKeyElement 
        { get { return Locators.TestResourcesTitle; } }
    }
}
