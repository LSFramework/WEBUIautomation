using WEBUIautomation.Tags;
using WEBUIautomation.Extensions;
using WEBUIautomation.WebElement;
using WEBPages.BasePageObject; 
using WEBPages.Extensions;
using OpenQA.Selenium;

namespace WEBPages.MyPCPages
{
    using Locators= WEBPages.ContentLocators.Locators.TestPlanPage;
    
    public class TestPlanPage: MainTabBasePage
    {
        #region The InitMainTabContext members

        protected override MainHead_Links   MenuHeader      { get { return MainHead_Links.TestManagement; } }
        protected override Perspectives     ViewName        { get { return Perspectives.TestPlan; } }
        protected override By               byKeyElement    { get { return Locators.byElement; } }

        #endregion //The InitMainTabContext members

        #region Static Elements

        #region Test Plan Tree toolbar buttons

        private WebElement btnCreateNewFolder
        { get { return mainTab.GetElement().ByClass(Locators.newFolderButtonClass, false); } }

        private WebElement btnUploadScript
        { get { return mainTab.GetElement().ByAttribute(TagAttributes.Title, Locators.btnUploadScriptTitle); } }

        private WebElement btnCreateTest
        { get { return mainTab.GetElement().ByAttribute(TagAttributes.Title, Locators.btnCreateTestTitle); } }

        private WebElement btnDelete
        { get { return mainTab.GetElement().ByAttribute(TagAttributes.Title, Locators.btnDeleteTitle); } }

        private WebElement btnCopy
        { get { return mainTab.GetElement().ByAttribute(TagAttributes.Title, Locators.btnCopyTitle); } }

        private WebElement btnCut
        { get { return mainTab.GetElement().ByAttribute(TagAttributes.Title, Locators.btnCutTitle); } }

        private WebElement btnPaste
        { get { return mainTab.GetElement().ByAttribute(TagAttributes.Title, Locators.btnPasteTitle); } }

        //private WebElement TreePanel
        //{ get { return mainTab.GetElement().ById(Locators.treePanelID); } }

        private WebElement lblWindowTitle
        { get { return mainTab.GetElement().ByAttribute(TagAttributes.Title, ViewName.GetEnumDescription()); } }

        private WebElement btnEditTest
        { get { return mainTab.GetElement().ByAttribute(TagAttributes.Title, Locators.btnEditTest); } }

        #endregion Test Plan Tree toolbar buttons

        private WebElement txtFindNode
        {
            get
            {
                return mainTab.GetElement()
                    .ById( Locators.txtFindNodeID1, false )
                    .ById( Locators.txtFindNodeID2, false );
            }
        }

        #endregion Static Elements

        #region Dynamic Elements

        public WebElement FindTest(string testName)
        {
            return mainTab.GetElement().ByXPath(Locators.performanceTestXPath).ByText(testName);
        }

        public WebElement FindTreeFolder(string folderName)
        {
            return mainTab.FindTreeItemByName(folderName);
        }

        public WebElement FindScript(string scriptName)
        {
            return mainTab.FindTreeItemByName(scriptName);
                //mainTab.GetElement().ByXPath(Locators.scriptXPath).ByText(scriptName);
        }

        

        #endregion Dynamic Elements

        #region Helpers

        
        
        #endregion Helpers

        #region Single Actions

        public CreateTestFolderDialog ClickCreateNewFolderBtn()
        {
            btnCreateNewFolder.Click();
            return new CreateTestFolderDialog();
        }

        public TestPlanPage SelectSubjectFolder()
        {
            // return SelectTreeItem(Locators.subjectFolderName);
           mainTab.FindTreeItemByName(Locators.subjectFolderName).Click();
            return this;
        }

        public TestPlanPage SelectTreeItem(string treeItemName)
        {
            mainTab.FindTreeItemByName(treeItemName).Click();
            return this;
        }

        public TestPlanPage SelectTreeItem(WebElement item)
        {
            item.Click();
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

        public LoadTest EditLoadTest(string testFolderName, string testName)
        {
            mainTab.FindTreeItemByName(testFolderName).Click();
            mainTab.TryExpandTreeFolder(testFolderName);
            mainTab.FindTreeItemByName(testName).Click();
            btnEditTest.Click();
            LoadTest loadTest = new LoadTest(testName);
            return loadTest;
        }


        #endregion Single Actions

        #region Complex Actions

        /// <summary>
        /// Performs select folder in tree and click "Create New Folder" button
        /// Expected: CreateTestFolderDialog appears.
        /// </summary>
        /// <param name="parentFolderName"></param>
        public CreateTestFolderDialog OpenCreateNewFolderDialog(string parentFolderName)
        {
            mainTab.FindTreeItemByName(parentFolderName).Click();           
            return ClickCreateNewFolderBtn();
        }

        /// <summary>
        /// Performs select folder in tree and click "Upload Script" button
        /// Expected: Upload script dialog appears.
        /// </summary>
        /// <param name="parentFolderName"></param>
        public UploadScriptDialog OpenUploadScriptDialog(string parentFolderName)
        {
            mainTab.FindTreeItemByName(parentFolderName).Click();       
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
            mainTab.FindTreeItemByName(parentFolderName).Click();       
            return ClickCreateTestBtn();
        }

        #endregion //Complex Actions

    }
}
