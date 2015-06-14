using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEBPages.ContentLocators
{
    public static partial class Locators
    {
        public static class BaseDialog
        {
            public static readonly string noMesageStyleValue = "color:Red;display:none;";
            public static readonly string lblMessageXPath = @".//*[@id='ctl00_ctl00_PageContent_DialogContent_RequiredFieldValidator1']//font";
            public static readonly string requiredFieldValidatorID = "ctl00_ctl00_PageContent_DialogContent_RequiredFieldValidator1";
            public static readonly string btnOkID = "ctl00_ctl00_PageContent_DialogActions_btnOK";
            public static readonly string btnClose = "ctl00_ctl00_PageContent_btnClose";
        }

        public static class StartRunDialog
        {
            public static By FrameLocator = By.XPath(@".//iframe[contains(@ng-src,'StartRun.aspx')]");
        
            public static readonly string ViewLocator = "Run Performance Test";

            public static readonly string btnRunId = "ctl00_PageContent_btnRun";
            public static readonly string lblAvailabilityResults = "ctl00_PageContent_lblAvailabilityResults";

            public static string strAvailabe = "Timeslot can be reserved.";
            public static string strNotAvailable = "Timeslot cannot be reserved.";
            public static string strUnknown = "Unknown";

        }

        public static class ManageTestSetsDialog
        {
            public static By FrameLocator                   = By.XPath(@".//iframe[contains(@ng-src,'CrudTestSet.aspx')]");

            public static readonly string ViewLocator = "Manage Test Sets Dialog";

            public static readonly string btnNewFolderClassName = "newFolderButton";
            public static readonly string btnNewTestSetClassName = "newItemButton";
            public static readonly string btnDeleteItemClassName = "deleteButton";
            public static readonly string treeViewID = "ctl00_ctl00_PageContent_DialogContent_TestSetTreeControl_GenericTreeView1_RadTreeView1";
            public static readonly string TestLabRoot = "Root";
        }

        public static class CreateTestFolderDialog
        {
            public static By FrameLocator          = By.XPath(@".//iframe[contains(@ng-src,'CreateNewTestFolder.aspx')]");

            public static readonly string ViewLocator = "Create New Test Folder";

            public static readonly string txtTestFolderNameID = "ctl00_ctl00_PageContent_DialogContent_TxtTestFolderName";
            public static readonly string panelID = "ctl00_ctl00_PageContent_DialogContent_PanelCreateNewTestFolder";
 
        }

        public static class UploadScriptDialog
        {
            public static By FrameLocator                   = By.XPath(@".//iframe[contains(@ng-src,'UploadScripts.aspx')]");

            public static readonly string ViewLocator = "Upload Script Dialog";

            public static readonly string btnSelectXpath = @".//input[@type='button'][@value='Select']";
            public static readonly string btnUploadId = "ctl00_PageContent_SubmitButton";
            public static readonly string btnCloseId = "ctl00_PageContent_btnClose";
            public static readonly string msgNotificationXPath = @".//*[@id='AsyncScriptUploadControlrow0']/i";
        }

        public static class CreateTestDialog
        {
            public static By FrameLocator = By.XPath(@".//iframe[contains(@ng-src,'CreateNewTest.aspx')]");
            public static readonly string ViewLocator = "Create New Test Dialog";

            public static readonly string txtNewTestNameID = "ctl00_ctl00_PageContent_DialogContent_txtNewTestName";
            public static readonly string cmbTestSetTreeID = "ctl00_ctl00_PageContent_DialogContent_TestSetTree_ComboTree";
            public static readonly string btnCreateNewOKID = "ctl00_ctl00_PageContent_DialogActions_btnCreateNewOK";
            public static readonly string btnHelpID = "ctl00_ctl00_PageContent_btnHelp";


            public static readonly string arrTestSetTree = "ctl00_ctl00_PageContent_DialogContent_TestSetTree_ComboTree_Arrow";
        }

        public static class NewTestSetDialog
        {
            public static By FrameLocator                   = By.Name("CreateNewTestSet");
            public static readonly string ViewLocator = "Create New Performance Test Set";
        }

       
        public static class NewTestSetFolderDialog
        {
            public static By FrameLocator                   = By.Name("CreateNewTestSetFolder");
            public static readonly string ViewLocator = "Create New Test Set Folder";

            public static readonly string txtFolderNameId = "ctl00_ctl00_PageContent_DialogContent_TxtTestSetFolderName";
        }
    }
}
