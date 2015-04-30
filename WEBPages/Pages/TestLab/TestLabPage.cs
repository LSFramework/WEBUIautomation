﻿using OpenQA.Selenium;
using WEBUIautomation.Tags;
using WEBUIautomation.Utils;
using WEBUIautomation.Extensions;
using WEBUIautomation.WebElement;
using WEBPages.Extensions;
using WEBPages.Pages.TestLab.ModalDialogues;
using System;
using WEBPages.Pages.BasePageObject;
using WEBPages.ContentLocators;

namespace WEBPages.Pages.TestLab
{
    using Locators=ContentLocators.Locators.TestLabPage;

    public class TestLabPage: MainTabFrame
    {
        #region The MainTabFrame members

        protected override MainHead_Links MenuHeader { get { return MainHead_Links.TestManagement; } }
        protected override Perspectives ViewName { get { return Perspectives.TestLab; } }
        protected override By byElement  { get { return Locators.byElement; } }

        #endregion The MainTabFrame members

        #region Elements Locators

        WebElement btnManageTestSets
        { get { return mainTab.NewWebElement().ByAttribute(TagAttributes.Title, Locators.btnManageTestSetsValue); } }

         WebElement btnAssignTest
        { get { return mainTab.NewWebElement().ByXPath(Locators.btnAssignTestXPath); } }

         WebElement btnRunTest
        { get { return mainTab.NewWebElement().ByXPath(Locators.btnRunTestXPath); } }

         WebElement filterByTestSetInput
         { get { return mainTab.NewWebElement().ById(Locators.filterByTestSetInputId); } }

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

            mainTab.NewWebElement().ByXPath(xPath).Click();
        }

        public string SelectedTestSet
        { get { return filterByTestSetInput.Text; } }

    }
}
