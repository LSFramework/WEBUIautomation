using WEBUIautomation.Tags;
using WEBUIautomation.Extensions;
using WEBUIautomation.WebElement;
using WEBPages.BasePageObject; 
using WEBPages.Extensions;
using WEBPages.ContentLocators;
using OpenQA.Selenium;

namespace WEBPages.MyPCPages
{
    using Locators= WEBPages.ContentLocators.Locators.TestPlanPage;
    
    public partial class TestPlanPage: MainTabFrame
    {
        #region The MainTabFrame members

        protected override MainHead_Links MenuHeader { get { return MainHead_Links.TestManagement; } }
        protected override Perspectives ViewName { get { return Perspectives.TestPlan; } }
        protected override By byKeyElement { get { return Locators.byElement; } }

        #endregion The MainTabFrame members

        #region Static Elements

        #region Test Plan Tree toolbar buttons

        WebElement btnCreateNewFolder
        { get { return mainTab.NewWebElement().ByClass(Locators.newFolderButtonClass, false); } }

        WebElement btnUploadScript
        { get { return mainTab.NewWebElement().ByAttribute(TagAttributes.Title, Locators.btnUploadScriptTitle); } }

        WebElement btnCreateTest
        { get { return mainTab.NewWebElement().ByAttribute(TagAttributes.Title, Locators.btnCreateTestTitle); } }

        WebElement btnDelete
        { get { return mainTab.NewWebElement().ByAttribute(TagAttributes.Title, Locators.btnDeleteTitle); } }

        WebElement btnCopy
        { get { return mainTab.NewWebElement().ByAttribute(TagAttributes.Title, Locators.btnCopyTitle); } }

        WebElement btnCut
        { get { return mainTab.NewWebElement().ByAttribute(TagAttributes.Title, Locators.btnCutTitle); } }

        WebElement btnPaste
        { get { return mainTab.NewWebElement().ByAttribute(TagAttributes.Title, Locators.btnPasteTitle); } }

        WebElement TreePanel
        { get { return mainTab.NewWebElement().ById(Locators.treePanelID); } }

        WebElement lblWindowTitle
        { get { return mainTab.NewWebElement().ByAttribute(TagAttributes.Title, ViewName.GetEnumDescription()); } }

        #endregion Test Plan Tree toolbar buttons

        WebElement txtFindNode
        {
            get
            {
                return mainTab.NewWebElement()
                    .ById( Locators.txtFindNodeID1, false )
                    .ById( Locators.txtFindNodeID2, false );
            }
        }

        #endregion Static Elements

        #region Dynamic Elements

        public WebElement FindTest(string testName)
        {
            return mainTab.NewWebElement().ByXPath(Locators.performanceTestXPath).ByText(testName);
        }

        public WebElement FindTreeFolder(string folderName)
        {
            return mainTab.FindTreeItemByText(folderName);
        }

        //public WebElement FindScript(string pathToScript)
        //{ 
        
        //}


        #endregion Dynamic Elements

        #region Helpers

        public bool IsFolderSelected(string folderName)
        {
            return folderName == mainTab.FindSelectedFolder();
        }
        
        #endregion Helpers

        #region Single Actions

        public CreateTestFolderDialog ClickCreateNewFolderBtn()
        {
            btnCreateNewFolder.Click();
            return new CreateTestFolderDialog();
        }

        public TestPlanPage SelectSubjectFolder()
        {
            return SelectTreeItem(Locators.subjectFolderName);
        }

        public TestPlanPage SelectTreeItem(string treeItemName)
        {
            mainTab.FindTreeItemByText(treeItemName).Click();
            return this;
        }

        public TestPlanPage TryExpandTreeNode(string nodeName)
        {
             mainTab.TryExpandTreeFolder(nodeName);
             return this;      
        }

        public UploadScriptDialog ClickUploadScriptBtn()
        {
            btnUploadScript.Click();
            return new UploadScriptDialog();
        }

        public CreateTestDialog ClickCreateTestBtn()
        {
            btnCreateTest.Click();
            return new CreateTestDialog();
        }

        #endregion Single Actions

        #region TestPlanPage Actions

        /// <summary>
        /// Performs select folder in tree and click "Create New Folder" button
        /// Expected: CreateTestFolderDialog appears.
        /// </summary>
        /// <param name="parentFolderName"></param>
        public CreateTestFolderDialog OpenCreateNewFolderDialog(string parentFolderName)
        {
            mainTab.FindTreeItemByText(parentFolderName).Click();           
            return ClickCreateNewFolderBtn();
        }

        /// <summary>
        /// Performs select folder in tree and click "Upload Script" button
        /// Expected: Upload script dialog appears.
        /// </summary>
        /// <param name="parentFolderName"></param>
        public UploadScriptDialog OpenUploadScriptDialog(string parentFolderName)
        {
            mainTab.FindTreeItemByText(parentFolderName).Click();       
            return ClickUploadScriptBtn();
        }

        /// <summary>
        /// Performs select folder in tree and click "Create New Test" button. 
        /// Expected: Create New Test dialog screen appears.
        /// </summary>
        /// <param name="parentFolderName"></param>
        /// <param name="testName"></param>
        public CreateTestDialog OpenCreateNewTestDialog(string parentFolderName)
        {
            mainTab.FindTreeItemByText(parentFolderName).Click();       
            return ClickCreateTestBtn();
        }       

        #endregion            
    }
}
