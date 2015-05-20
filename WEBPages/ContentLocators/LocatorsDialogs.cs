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
            public const string noMesaageStyleValue         = "color:Red;display:none;";
            public const string lblMessageXPath             = @".//*[@id='ctl00_ctl00_PageContent_DialogContent_RequiredFieldValidator1']//font";
            public const string requiredFieldValidatorID    = "ctl00_ctl00_PageContent_DialogContent_RequiredFieldValidator1";
            public const string btnOkID                     = "ctl00_ctl00_PageContent_DialogActions_btnOK";
            public const string btnClose                    = "ctl00_ctl00_PageContent_btnClose";
        }


        public static class ManageTestSetsDialog
        {
            public static By FrameLocator                   = By.XPath(@".//iframe[contains(@ng-src,'CrudTestSet.aspx')]");
            public const string ViewLocator                 = "Manage Test Sets Dialog";

            public const string btnNewFolderClassName       = "newFolderButton";
            public const string btnNewTestSetClassName      = "newItemButton";
            public const string btnDeleteItemClassName      = "deleteButton";
            public const string treeViewID                  = "ctl00_ctl00_PageContent_DialogContent_TestSetTreeControl_GenericTreeView1_RadTreeView1";            
            public const string TestLabRoot                 = "Root";
        }

        public static class CreateTestFolderDialog
        {
            public static By FrameLocator                   = By.XPath(@".//iframe[contains(@ng-src,'CreateNewTestFolder.aspx')]");
            public const string ViewLocator                 = "Create New Test Folder";

            public const string txtTestFolderNameID         = "ctl00_ctl00_PageContent_DialogContent_TxtTestFolderName";  
            public const string panelID                     = "ctl00_ctl00_PageContent_DialogContent_PanelCreateNewTestFolder";
 
        }

        public static class UploadScriptDialog
        {
            public static By FrameLocator                   = By.XPath(@".//iframe[contains(@ng-src,'UploadScripts.aspx')]");
            public const string ViewLocator                 = "Upload Script Dialog";

            
            public const string btnSelectXpath              = @".//input[@value='Select'][@type='button']";
            public const string btnUploadId                 = "ctl00_PageContent_SubmitButton";
            public const string btnCloseId                  = "ctl00_PageContent_btnClose";
            public const string msgNotificationXPath        = @".//*[@id='AsyncScriptUploadControlrow0']/i";
        }

        public static class CreateTestDialog
        {
            public static By FrameLocator                   = By.XPath(@".//iframe[contains(@ng-src,'CreateNewTestDialog.aspx')]");
            public const string ViewLocator                 = "Create New Test Dialog";

            public const string txtNewTestNameID            = "ctl00_ctl00_PageContent_DialogContent_txtNewTestName";
            public const string cmbTestSetTreeID            = "ctl00_ctl00_PageContent_DialogContent_TestSetTree_ComboTree";
            public const string btnCreateNewOKID            = "ctl00_ctl00_PageContent_DialogActions_btnCreateNewOK";
            public const string btnHelpID                   = "ctl00_ctl00_PageContent_btnHelp";
     
        }

        public static class NewTestSetDialog
        {
            public static By FrameLocator                   = By.Name("CreateNewTestSet");
            public const string ViewLocator                 = "Create New Performance Test Set";
        }

        public static class StartRunDialog
        {
            public static By FrameLocator                   = By.XPath(@".//iframe[contains(@ng-src,'StartRun.aspx')]");
            public const string ViewLocator                 = "Run Performance Test";

            public const string btnRunId                    = "ctl00_PageContent_btnRun";
        }

        public static class NewTestSetFolderDialog
        {
            public static By FrameLocator                   = By.Name("CreateNewTestSetFolder");
            public const string ViewLocator                 = "Create New Test Set Folder";

            public const string txtFolderNameId             = "ctl00_ctl00_PageContent_DialogContent_TxtTestSetFolderName";
        }
    }
}
