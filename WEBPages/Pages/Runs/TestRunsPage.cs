using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBPages.ContentLocators;
using WEBPages.Pages.BasePageObject;

namespace WEBPages.Pages.Runs
{
    using Locators = ContentLocators.Locators.TestRunsPage;
    public class TestRunsPage: MainTabFrame
    {

        protected override MainHead_Links MenuHeader
        { get { return MainHead_Links.RunAnalysis; } }

        protected override Perspectives ViewName
        { get { return Perspectives.Runs; } }

        protected override By byElement
        {
            get { return Locators.LeftLabel; }
        }
    }
}
