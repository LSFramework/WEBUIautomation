using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBPages.BasePageObject;
using WEBPages.ContentLocators;

namespace WEBPages.MyPCPages
{
    using Locators = ContentLocators.Locators.TestResources;

    public class TestResources : MainTabBasePage
    {
        protected override MainHead_Links MenuHeader { get {  return MainHead_Links.Resources; } }

        protected override Perspectives ViewName  { get { return Perspectives.TestResources; } }

        protected override By byKeyElement { get { return Locators.TestResourcesTitle; } }
    }
}
