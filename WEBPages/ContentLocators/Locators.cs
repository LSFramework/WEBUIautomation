using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEBPages.ContentLocators
{
    public static partial class Locators
    {
        public static class ALMMainPage
        {
            public const string MyPCLink = @"//a[text()='My Performance Center']";

        }

        public static class MyPCLoginPage
        {
            public const string txtUserNameID   = "ctl00_PageContent_txtUserName";
            public const string txtPasswordID   = "ctl00_PageContent_txtPassword";
            public const string btnAuthenticateID = "ctl00_PageContent_btnAuthenticate";
            public const string ddlDomains_ArrowID = "ctl00_PageContent_ddlDomains_Arrow";
            public const string ddlDomains_InputID = "ctl00_PageContent_ddlDomains_Input";
            public const string ddlDomains_DropDownID = "ctl00_PageContent_ddlDomains_DropDown";
            public const string ddlProjects_ArrowID = "ctl00_PageContent_ddlProjects_Arrow";
            public const string ddlProjects_InputID = "ctl00_PageContent_ddlProjects_Input";
            public const string ddlProjects_DropDownID = "ctl00_PageContent_ddlProjects_DropDown";
            public const string btnLoginID = "ctl00_PageContent_btnLogin";
        }

        public static class MainHeadPage
        {
            public const string ViewLocator = "Main Head";
            public const string FrameLocatorID = "MastheadDiv";
            public const string MainTabID = "MainTab";

            public static By FrameLocator =By.Id(FrameLocatorID);
            public static By MainTabFrame=By.Id(MainTabID);

            public const string lblUserXPath=@".//span[contains(@local-string, 'hello')]/..";
            public const string lblDomainXPath=@".//span[contains(@local-string, 'domain')]/..";
            public const string lblProjectXPath=@".//span[contains(@local-string, 'domain')]/..";
            public const string btnLogoutXPath=@".//span[contains(@local-string, 'logout')]";
            public const string tabHomeXPath=@".//span[contains(@class, 'IconContainer IconHome')]";
            public const string btnCloseDLTXPath=@".//div[contains(@class, 'xButtonWrapper')]";

            public const string btnRefreshXPath = @".//div[contains(@ng-click, 'Refresh()')]";
            public const string menuAutoRefreshClass = "iconPadding iconPaddingDropdown";
            public const string menuItemAutoRefreshOnText = "Auto Refresh On";
            public const string menuItemAutoRefreshOffText = "Auto Refresh Off";
        }

        public static class TestLabPage
        {
            public static By byElement= By.XPath(@".//*[contains(@title, 'Manage Test Sets')]");

            public const string btnManageTestSetsValue = "Manage Test Sets";
            public const string btnAssignTestXPath = @".//a[contains(@title, 'Assign Test to TestSet')]";
            public const string btnRunTestXPath = @".//img[contains(@alt, 'Run Test')]";
 
        
        
        }


        public static class TestPlanPage
        {
            public static By byElement= By.XPath(@".//*[contains(@title, 'Test Plan')]");

            public const string subjectFolderName = "Subject";
            public const string txtFindNodeID1 = "ctl00_PageContent_WebPartManager";
            public const string txtFindNodeID2 = "TestPlanTreeControl_GenericTreeView1_RadTextBox1";
            public const string treePanelID = "divTestPlanTree";

            public const string btnUploadScriptTitle = "Upload Script";
            public const string btnCreateTestTitle = "New Test" ;
            public const string btnDeleteTitle = "Delete"; 
            public const string btnCopyTitle = "Copy" ;
            public const string btnCutTitle =  "Cut";
            public const string btnPasteTitle = "Paste";
            
            public const string newFolderButtonClass = "newFolderButton";

            public const string selectedFolderXPath = @"//img[contains(@src, 'selected_folder')]/following-sibling::span";
            public const string performanceTestXPath = @"//img[contains(@src, 'test-performance.svg')]/following-sibling::span";
            public static string Menu;            
        }

        public static class CreateTestFolderDialog
        { 
            public static By FrameLocator =By.XPath(@".//iframe[contains(@ng-src,'CreateNewTestFolder.aspx')]");

            public const string ViewLocator = "Create New Test Folder";

            public const string dialogTitleID = "dialogTitle";
            public const string txtTestFolderNameID = "ctl00_ctl00_PageContent_DialogContent_TxtTestFolderName";
            public const string btnOkID = "ctl00_ctl00_PageContent_DialogActions_btnOK";
            public const string btnClose = "ctl00_ctl00_PageContent_btnClose";
            public const string lblMessageXPath = @".//*[@id='ctl00_ctl00_PageContent_DialogContent_RequiredFieldValidator1']//font";
            public const string panelID = "ctl00_ctl00_PageContent_DialogContent_PanelCreateNewTestFolder";
            public const string requiredFieldValidatorID = "ctl00_ctl00_PageContent_DialogContent_RequiredFieldValidator1";
            public const string noMesaageStyleValue = "color:Red;display:none;";
        }

        public static class UploadScriptDialog
        {
            public static By FrameLocator = By.XPath(@".//iframe[contains(@ng-src,'UploadScripts.aspx')]");
            public const string ViewLocator = "Upload Script Dialog";
        }

        public static class CreateTestDialog
        {
            public static By FrameLocator = By.XPath(@".//iframe[contains(@ng-src,'CreateNewTestDialog.aspx')]");
            public const string ViewLocator = "Create New Test Dialog";

            public const string txtNewTestNameID = "ctl00_ctl00_PageContent_DialogContent_txtNewTestName";
            public const string cmbTestSetTreeID = "ctl00_ctl00_PageContent_DialogContent_TestSetTree_ComboTree";
            public const string btnCreateNewOKID = "ctl00_ctl00_PageContent_DialogActions_btnCreateNewOK";
            public const string btnCloseID = "ctl00_ctl00_PageContent_btnClose";
            public const string btnHelpID = "ctl00_ctl00_PageContent_btnHelp";          
        }

        public static class NewTestSetDialog
        {
            public static By FrameLocator = By.Name("CreateNewTestSet");
            public const string ViewLocator = "Create New Performance Test Set";

        
        }

        public static class StartRunDialog
        {
            public static By FrameLocator = By.XPath(@".//iframe[contains(@ng-src,'StartRun.aspx')]");
            public const string ViewLocator = "Run Performance Test";

            public const string btnRunId = "ctl00_PageContent_btnRun";
        }

        public static class NewTestSetFolderDialog
        {
            public static By FrameLocator = By.Name("CreateNewTestSetFolder");
            public const string ViewLocator = "Create New Test Set Folder";
            public const string lblMessageXPath = @".//*[@id='ctl00_ctl00_PageContent_DialogContent_RequiredFieldValidator1']//font";
            public const string btnCloseId = "ctl00_ctl00_PageContent_btnClose";
            public const string btnOkId = "ctl00_ctl00_PageContent_DialogActions_btnOK";
            public const string txtFolderNameId = "ctl00_ctl00_PageContent_DialogContent_TxtTestSetFolderName";


        }
    }
}
