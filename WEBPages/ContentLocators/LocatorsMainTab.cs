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
            public const string txtUserNameID           = "ctl00_PageContent_txtUserName";
            public const string txtPasswordID           = "ctl00_PageContent_txtPassword";
            public const string btnAuthenticateID       = "ctl00_PageContent_btnAuthenticate";
            public const string ddlDomains_ArrowID      = "ctl00_PageContent_ddlDomains_Arrow";
            public const string ddlDomains_InputID      = "ctl00_PageContent_ddlDomains_Input";
            public const string ddlDomains_DropDownID   = "ctl00_PageContent_ddlDomains_DropDown";
            public const string ddlProjects_ArrowID     = "ctl00_PageContent_ddlProjects_Arrow";
            public const string ddlProjects_InputID     = "ctl00_PageContent_ddlProjects_Input";
            public const string ddlProjects_DropDownID  = "ctl00_PageContent_ddlProjects_DropDown";
            public const string btnLoginID              = "ctl00_PageContent_btnLogin";
        }

        public static class MainHeadPage
        {
            public const string ExceptionString = "WebDriver can't get access to the MainHead page.  A modal dialogue is still opened.";

            public const string ViewLocator     = "Main Head";
            public const string FrameLocatorID  = "MastheadDiv";
            public const string MainTabID       = "MainTab";       

            public static By FrameLocator =By.Id(FrameLocatorID);
            public static By MainTabFrame=By.Id(MainTabID);

            public const string lblUserXPath    = @".//span[contains(@local-string, 'hello')]/..";
            public const string lblDomainXPath  = @".//span[contains(@local-string, 'domain')]/..";
            public const string lblProjectXPath = @".//span[contains(@local-string, 'project')]/..";
            public const string btnLogoutXPath  = @".//span[contains(@local-string, 'logout')]";
            public const string tabHomeXPath    = @".//span[contains(@class, 'IconContainer IconHome')]";
            public const string btnCloseDLTXPath= @".//div[contains(@class, 'xButtonWrapper')]";

            public const string btnRefreshXPath             = @".//div[contains(@ng-click, 'Refresh()')]";
            public const string menuAutoRefreshClass        = "iconPadding iconPaddingDropdown";
            public const string menuItemAutoRefreshOnText   = "Auto Refresh On";
            public const string menuItemAutoRefreshOffText  = "Auto Refresh Off";
            public const string ModalOpened                 = "ng-scope ng-animate modal-open";
            public const string bodyXPath                   = "html/body";

        }

        public static class StartTabPage
        {
            public const string ViewLocator = "Start";
        }

        public static class TestLabPage
        {
            const string UniqueElementXPath = @".//*[contains(@title, 'Manage Test Sets')]";

            public static By byElement = By.XPath(UniqueElementXPath);

            public const string btnManageTestSetsValue  = "Manage Test Sets";
            public const string btnAssignTestXPath      = @".//a[contains(@title, 'Assign Test to TestSet')]";
            public const string btnRunTestXPath         = @".//img[contains(@alt, 'Run Test')]";
            public const string filterByTestSetInputId  = "ctl00_PageContent_Toolbar_toolbar2_i0_SelectTestSetTree_ComboTree_Input"; 
        }

        public static class TestPlanPage
        {
            public static By byElement= By.XPath(@".//*[contains(@title, 'Test Plan')]");

            public const string subjectFolderName   = "Subject";
            public const string txtFindNodeID1      = "ctl00_PageContent_WebPartManager";
            public const string txtFindNodeID2      = "TestPlanTreeControl_GenericTreeView1_RadTextBox1";
            public const string treePanelID         = "divTestPlanTree";

            public const string btnUploadScriptTitle    = "Upload Script";
            public const string btnCreateTestTitle      = "New Test" ;
            public const string btnDeleteTitle          = "Delete"; 
            public const string btnCopyTitle            = "Copy" ;
            public const string btnCutTitle             =  "Cut";
            public const string btnPasteTitle           = "Paste";
            
            public const string newFolderButtonClass = "newFolderButton";

            public const string selectedFolderXPath     = @"//img[contains(@src, 'selected_folder')]/following-sibling::span";
            public const string performanceTestXPath    = @"//img[contains(@src, 'test-performance.svg')]/following-sibling::span";
            public static string Menu;            
        }

        public static class TestRunsPage
        {
            public static By LeftLabel = By.XPath(@".//*[@id='LeftLabel']/span[@local-string='TestRuns']"); 
        }

        public static class TrendingPage
        {
            public static By LeftLabel = By.XPath(@".//*[@id='LeftLabel']/span[@local-string='PerformanceTrending']"); 
        }

        public static class PalPage
        {
            public static By PalTitle = By.XPath(@".//*[@id='ctl00_PageContent_iPC_A_Zone']//span[contains(@title, 'PAL Resources')]");
        }

        public static class TestResources
        {
            public static By TestResourcesTitle = By.XPath(@".//*[@id='ctl00_PageContent_iPC_A_Zone']//span[contains(@title, 'Test Resources')]");
        }

        public static class TestingHosts
        {
            public static By TestingHostsTitle = By.XPath(@".//*[@id='ctl00_PageContent_iPC_A_Zone']//span[contains(@title, 'Performance Center Hosts')]");
        }

        public static class Timeslots
        { 
            
        }

    }
}
