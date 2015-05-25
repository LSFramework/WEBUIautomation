using OpenQA.Selenium;
using WEBUIautomation.Tags;
using WEBUIautomation.Utils;
using WEBUIautomation.Extensions;
using WEBUIautomation.WebElement;
using WEBPages.Extensions;
using System;
using WEBPages.BasePageObject;
using WEBPages.ContentLocators;

namespace WEBPages.MyPCPages
{
    using Locators=ContentLocators.Locators.TestLabPage;

    public class TestLabPage : MainTabBasePage
    {
        #region The MainTabFrame members

        protected override MainHead_Links MenuHeader { get { return MainHead_Links.TestManagement; } }
        protected override Perspectives ViewName { get { return Perspectives.TestLab; } }
        protected override By byKeyElement  { get { return Locators.byElement; } }

        #endregion The MainTabFrame members

        #region Elements Locators

        WebElement btnManageTestSets
        { get { return mainTab.GetElement().ByAttribute(TagAttributes.Title, Locators.btnManageTestSetsValue); } }

         WebElement btnAssignTest
        { get { return mainTab.GetElement().ByXPath(Locators.btnAssignTestXPath); } }

         WebElement btnRunTest
        { get { return mainTab.GetElement().ByXPath(Locators.btnRunTestXPath); } }

         WebElement filterByTestSetInput
         { get { return mainTab.GetElement().ById(Locators.filterByTestSetInputId); } }

         #endregion Elements Locators

         /// <summary>
        /// Action : Performs click Manage Test Sets button.
        /// Expected : A modal-dialog Manage Test Sets appears.
        /// </summary>
        public  ManageTestSetsDialog ClickManageTestSets()
        {
            btnManageTestSets.Click();
            return new ManageTestSetsDialog();
        }
        
        /// <summary>
        /// Select Test In Grid
        /// </summary>
        /// <param name="testName"></param>
        public  void SelectTestInGrid(string testName)
        {
            string xPath = @".//td[contains(text(), '" + testName + "')]";

            mainTab.GetElement().ByXPath(xPath).Click();
        }

        public string SelectedTestSet
        { get { return filterByTestSetInput.Text; } }

    }
}
