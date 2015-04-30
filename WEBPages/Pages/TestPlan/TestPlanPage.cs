using WEBUIautomation.Tags;
using WEBUIautomation.Extensions;
using WEBUIautomation.WebElement;
using WEBPages.Pages.TestPlan.ModalDialogues;
using WEBPages.Pages.BasePageObject; 
using WEBPages.Extensions;
using WEBPages.ContentLocators;
using OpenQA.Selenium;

namespace WEBPages.Pages.TestPlan
{
    using Locators= WEBPages.ContentLocators.Locators.TestPlanPage;
    
    public partial class TestPlanPage: MainTabFrame
    {
        #region The MainTabFrame members

        protected override MainHead_Links MenuHeader { get { return MainHead_Links.TestManagement; } }
        protected override Perspectives ViewName { get { return Perspectives.TestPlan; } }
        protected override By byElement { get { return Locators.byElement; } }

        #endregion The MainTabFrame members

        #region Elements Locators

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

        #endregion  Elements Locators

        #region Helpers

        public bool IsFolderSelected(string folderName)
        {
            return folderName == mainTab.FindSelectedFolder();
        }

        public WebElement FindTest(string testName)
        { 
            return mainTab.NewWebElement().ByXPath(Locators.performanceTestXPath).ByText(testName);
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
            mainTab.FindTreeItemByText(Locators.subjectFolderName).Click();
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
            ClickUploadScriptBtn();
            return new UploadScriptDialog();
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
