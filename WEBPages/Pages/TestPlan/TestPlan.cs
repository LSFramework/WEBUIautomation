using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using WEBUIautomation.Utils;
using WEBUIautomation.Extensions;
using WEBUIautomation.WebElement;
using WEBUIautomation.Wait;

namespace WEBPages.Pages.TestPlan
{
    using TagAttributes = WEBUIautomation.Tags.TagAttributes;
    using WEBPages.Pages.TestPlan.ModalDialogues;

    public partial class TestPlan:DriverContainer
    {
        #region The Page Locator

        public const string ViewLocator = "Test Plan";
        public static By FrameLocator=By.Id("MainTab");
        

        static IWebDriverExt mainTab
        {
            get
            {
                ///Is driver on the perspective we need ?
                if (!IsDriverOnTheView(FrameLocator, ViewLocator))
                /// if it isn't
                {
                    //Navigate to the perspective
                    driver.SwitchTo().DefaultContent();
                    MainHead mainHead = new MainHead();
                    mainHead.NavigateToTestPlan();
                    //Set driver's focus on the frame contains the perspective UI
                    //and mark driver as it is on the perspective
                    driver.SwitchToFrame(FrameLocator);
                    driver.CurrentView = ViewLocator;
                }
                // If yes 
                return driver;
            }
        }

        #endregion The Page Locator

        #region Elements Locators

        static WebElement txtFindNode
        {
            get
            {
                return mainTab.NewWebElement()
                    .ById("ctl00_PageContent_WebPartManager", false)
                    .ById("TestPlanTreeControl_GenericTreeView1_RadTextBox1", false);
            }
        }

        #region Test Plan Tree toolbar buttons

        static WebElement btnCreateNewFolder
        { get { return mainTab.NewWebElement().ByClass("newFolderButton", false); } }

        static WebElement btnUploadScript
        { get { return mainTab.NewWebElement().ByAttribute(TagAttributes.Title, "Upload Script"); } }

        static WebElement btnCreateTest
        { get { return  mainTab.NewWebElement().ByAttribute(TagAttributes.Title, "New Test"); } }
        
        static WebElement btnDelete
        { get { return mainTab.NewWebElement().ByAttribute(TagAttributes.Title, "Delete"); } }
       
        static WebElement btnCopy
        { get { return mainTab.NewWebElement().ByAttribute(TagAttributes.Title, "Copy"); } }

        static WebElement btnCut
        { get { return mainTab.NewWebElement().ByAttribute(TagAttributes.Title, "Cut"); } }

        static WebElement btnPaste
        { get { return mainTab.NewWebElement().ByAttribute(TagAttributes.Title, "Paste"); } }

        public static WebElement TreePanel
        { get { return mainTab.NewWebElement().ById("divTestPlanTree"); } }

        static WebElement lblTitle
        { get { return mainTab.NewWebElement().ByAttribute(TagAttributes.Title, "Test Plan").ByText("Test Plan"); } }             
        
        #endregion

        #endregion  Elements Locators

        #region Opened

        public static bool Opened
        { get { return WaitHelper.Try(() => lblTitle.IsEnabled()); } }   

        #endregion

        #region Helpers

        static List<string> FoldersList = new List<string>();
        static List<string> ScriptsList = new List<string>();
        static List<string> TestsList = new List<string>();

        public static bool IsFolderSelected(string folderName)
        {
            const string selectedFolderLocator = @"//img[contains(@src, 'selected_folder')]/following-sibling::span";

            return folderName == mainTab.NewWebElement().ByXPath(selectedFolderLocator).Text;
        }

        public static WebElement FindTest(string testName)
        { 
            string testLocator = @"//img[contains(@src, 'test-performance.svg')]/following-sibling::span";
            return mainTab.NewWebElement().ByXPath(testLocator).ByText(testName);
        }

        #endregion Helpers

        #region Single Actions

        public static void ClickCreateNewFolderBtn()
        {
            btnCreateNewFolder.Click();
        }

        public static void SelectSubjectFolder()
        {
            mainTab.FindFolder("Subject").Click(); 
        }

        static WebElement FindTreeFolder(string folderName)
        {
            return mainTab.FindFolder(folderName);
        }

        public static bool TryExpandTreeNode(string nodeName)
        {
            return mainTab.TryExpandTreeFolder(nodeName);                     
        }

        public static void ClickUploadScriptBtn()
        {
            btnUploadScript.Click();
        }

        public static void ClickCreateTestBtn()
        {
            btnCreateTest.Click();
        }
        #endregion Single Actions

        #region TestPlan Actions

        /// <summary>
        /// Performs select folder in tree and click "Create New Folder" button
        /// Expected: CreateNewTestFolderDialog appears.
        /// </summary>
        /// <param name="parentFolderName"></param>
        public static void OpenCreateNewFolderDialog(string parentFolderName)
        {
            mainTab.FindFolder(parentFolderName).Click();           
            ClickCreateNewFolderBtn();
        }

        /// <summary>
        /// Performs select folder in tree and click "Upload Script" button
        /// Expected: Upload script dialog appears.
        /// </summary>
        /// <param name="parentFolderName"></param>
        public static void OpenUploadScriptDialog(string parentFolderName)
        {
            mainTab.FindFolder(parentFolderName).Click();       
            ClickUploadScriptBtn();
        }

        /// <summary>
        /// Performs select folder in tree and click "Create New Test" button
        /// Expected: Create New Test dialog screen appears.
        /// </summary>
        /// <param name="parentFolderName"></param>
        /// <param name="testName"></param>
        public static void OpenCreateNewTestDialog(string parentFolderName)
        {
            mainTab.FindFolder(parentFolderName).Click();       
            ClickCreateTestBtn();
        }       

        #endregion        

    }
}
