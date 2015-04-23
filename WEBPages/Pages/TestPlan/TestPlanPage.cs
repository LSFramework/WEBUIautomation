using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using WEBUIautomation.Utils;
using WEBUIautomation.Extensions;
using WEBUIautomation.WebElement;
using WEBUIautomation.Wait;
using WEBPages.ContentLocators;
using WEBPages.Extensions;

namespace WEBPages.Pages.TestPlan
{
    using TagAttributes = WEBUIautomation.Tags.TagAttributes;
    using WEBPages.Pages.TestPlan.ModalDialogues;  

    public partial class TestPlanPage:DriverContainer, IPage
    {
        #region The Page Locator

        public string Url { get; private set; }

        public string ViewLocator { get { return "Test Plan"; } }

        public By FrameLocator { get { return By.Id("MainTab"); } }                

        IWebDriverExt mainTab
        {
            get
            {               
                if (!IsDriverOnTheView(FrameLocator, ViewLocator))
                {
                    try
                    {
                        driver.SwitchToFrame(FrameLocator);
                        driver.NewWebElement().ByAttribute(TagAttributes.Title, "Test Plan");
                        driver.CurrentView = ViewLocator;
                    }
                    catch (Exception)
                    {                     
                        driver.SwitchTo().DefaultContent();
                        MainHead mainHead = new MainHead();
                        mainHead.NavigateToTestPlan();                       
                        driver.SwitchToFrame(FrameLocator);
                        driver.CurrentView = ViewLocator;
                    }
                }
                return driver;
            }
        }

        #endregion The Page Locator

        public TestPlanPage()
        {
            Url = mainTab.Url;
        }

        #region Elements Locators

        WebElement txtFindNode
        {
            get
            {
                return mainTab.NewWebElement()
                    .ById(Locators.TestPlanPage.txtFindNodeID, false)
                    .ById("TestPlanTreeControl_GenericTreeView1_RadTextBox1", false);
            }
        }

        #region Test Plan Tree toolbar buttons

        WebElement btnCreateNewFolder
        { get { return mainTab.NewWebElement().ByClass("newFolderButton", false); } }

        WebElement btnUploadScript
        { get { return mainTab.NewWebElement().ByAttribute(TagAttributes.Title, "Upload Script"); } }

        WebElement btnCreateTest
        { get { return  mainTab.NewWebElement().ByAttribute(TagAttributes.Title, "New Test"); } }
        
        WebElement btnDelete
        { get { return mainTab.NewWebElement().ByAttribute(TagAttributes.Title, "Delete"); } }
       
        WebElement btnCopy
        { get { return mainTab.NewWebElement().ByAttribute(TagAttributes.Title, "Copy"); } }

        WebElement btnCut
        { get { return mainTab.NewWebElement().ByAttribute(TagAttributes.Title, "Cut"); } }

        WebElement btnPaste
        { get { return mainTab.NewWebElement().ByAttribute(TagAttributes.Title, "Paste"); } }

        WebElement TreePanel
        { get { return mainTab.NewWebElement().ById("divTestPlanTree"); } }

        WebElement lblTitle
        { get { return mainTab.NewWebElement().ByAttribute(TagAttributes.Title, "Test Plan"); } }             
        
        #endregion

        #endregion  Elements Locators

        #region Opened

        public bool Opened
        { get { return WaitHelper.Try(() => lblTitle.IsEnabled()); } }   

        #endregion

        #region Helpers

        static List<string> FoldersList = new List<string>();
        static List<string> ScriptsList = new List<string>();
        static List<string> TestsList = new List<string>();

        public bool IsFolderSelected(string folderName)
        {
            const string selectedFolderLocator = @"//img[contains(@src, 'selected_folder')]/following-sibling::span";

            return folderName == mainTab.NewWebElement().ByXPath(selectedFolderLocator).Text;
        }

        public WebElement FindTest(string testName)
        { 
            string testLocator = @"//img[contains(@src, 'test-performance.svg')]/following-sibling::span";
            return mainTab.NewWebElement().ByXPath(testLocator).ByText(testName);
        }

        #endregion Helpers

        #region Single Actions

        public CreateNewTestFolderDialog ClickCreateNewFolderBtn()
        {
            btnCreateNewFolder.Click();
            return new CreateNewTestFolderDialog();
        }

        public TestPlanPage SelectSubjectFolder()
        {
            mainTab.FindTreeItemByText("Subject").Click();
            return this;
        }

        WebElement FindTreeFolder(string folderName)
        {
            return mainTab.FindTreeItemByText(folderName);
        }

        public void TryExpandTreeNode(string nodeName)
        {
             mainTab.TryExpandTreeFolder(nodeName);                     
        }

        public void ClickUploadScriptBtn()
        {
            btnUploadScript.Click();
        }

        public void ClickCreateTestBtn()
        {
            btnCreateTest.Click();
        }


        #endregion Single Actions

        #region TestPlanPage Actions

        /// <summary>
        /// Performs select folder in tree and click "Create New Folder" button
        /// Expected: CreateNewTestFolderDialog appears.
        /// </summary>
        /// <param name="parentFolderName"></param>
        public CreateNewTestFolderDialog OpenCreateNewFolderDialog(string parentFolderName)
        {
            mainTab.FindTreeItemByText(parentFolderName).Click();           
            return ClickCreateNewFolderBtn();
        }

        /// <summary>
        /// Performs select folder in tree and click "Upload Script" button
        /// Expected: Upload script dialog appears.
        /// </summary>
        /// <param name="parentFolderName"></param>
        public void OpenUploadScriptDialog(string parentFolderName)
        {
            mainTab.FindTreeItemByText(parentFolderName).Click();       
            ClickUploadScriptBtn();
        }

        /// <summary>
        /// Performs select folder in tree and click "Create New Test" button
        /// Expected: Create New Test dialog screen appears.
        /// </summary>
        /// <param name="parentFolderName"></param>
        /// <param name="testName"></param>
        public void OpenCreateNewTestDialog(string parentFolderName)
        {
            mainTab.FindTreeItemByText(parentFolderName).Click();       
            ClickCreateTestBtn();
        }       

        #endregion        

    
        
    }
}
