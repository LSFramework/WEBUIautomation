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
            public static readonly string MyPCLink = @"//a[text()='My Performance Center']";
        }

        public static class MyPCLoginPage
        {
            public static readonly string txtUserNameID = "ctl00_PageContent_txtUserName";
            public static readonly string txtPasswordID = "ctl00_PageContent_txtPassword";
            public static readonly string btnAuthenticateID = "ctl00_PageContent_btnAuthenticate";
            public static readonly string ddlDomains_ArrowID = "ctl00_PageContent_ddlDomains_Arrow";
            public static readonly string ddlDomains_InputID = "ctl00_PageContent_ddlDomains_Input";
            public static readonly string ddlDomains_DropDownID = "ctl00_PageContent_ddlDomains_DropDown";
            public static readonly string ddlProjects_ArrowID = "ctl00_PageContent_ddlProjects_Arrow";
            public static readonly string ddlProjects_InputID = "ctl00_PageContent_ddlProjects_Input";
            public static readonly string ddlProjects_DropDownID = "ctl00_PageContent_ddlProjects_DropDown";
            public static readonly string btnLoginID = "ctl00_PageContent_btnLogin";
        }

        public static class MainHeadPage
        {
            public static readonly string strModalOpenedException = "WebDriver can't get access to the MainHead page.  A modal dialogue is still opened.";

            public static readonly string ViewLocator = "Main Head";
            public static readonly string FrameLocatorID = "MastheadDiv";
            public static readonly string MainTabID = "MainTab";       

            public static By FrameLocator               = By.Id(FrameLocatorID);
            public static By MainTabFrame               = By.Id(MainTabID);

            public static readonly string lblUserXPath = @".//span[contains(@local-string, 'hello')]/..";
            public static readonly string lblDomainXPath = @".//span[contains(@local-string, 'domain')]/..";
            public static readonly string lblProjectXPath = @".//span[contains(@local-string, 'project')]/..";
            public static readonly string btnLogoutXPath = @".//span[contains(@local-string, 'logout')]";
            public static readonly string tabHomeXPath = @".//span[contains(@class, 'IconContainer IconHome')]";
            public static readonly string tabDLTXPath = @".//span[contains(@class, 'IconContainer IconTest-Performance')]";
            public static readonly string btnCloseDLTXPath = @".//div[contains(@class, 'xButtonWrapper')]";

            public static readonly string btnRefreshXPath = @".//div[contains(@ng-click, 'Refresh()')]";
            public static readonly string menuAutoRefreshClass = "iconPadding iconPaddingDropdown";
            public static readonly string menuItemAutoRefreshOnText = "Auto Refresh On";
            public static readonly string menuItemAutoRefreshOffText = "Auto Refresh Off";
            public static readonly string ModalOpened = "ng-scope ng-animate modal-open";
            public static readonly string bodyXPath = "html/body";

            public static readonly string tabItemXPath = @".//div[@class='TabsItem']";

            public static readonly string hidenDltFrameClassValue = "DefaultPage ng-scope hide";
            public static readonly string shownDltFrameClassValue = "DefaultPage ng-scope show";

            /// <summary>
            /// Returns XPath string to locate main DLT iframe
            /// The string of the Xpath depends from test name and test ID 
            /// which are available from mainHead dltTab Title value
            /// </summary>
            internal static string dltIFrameXPath(string fullTitleValue)
            { 
                return string.Format(@".//iframe[@name = '{0}']", fullTitleValue); 
            }
        }

        public static class StartTabPage
        {
            public static readonly string ViewLocator = "Start";

            public static readonly string operationalHostsAmountXPath = "";
        }

        public static class TestLabPage
        {
            static readonly string UniqueElementXPath = @".//*[contains(@title, 'Manage Test Sets')]";

            public static By byElement = By.XPath(UniqueElementXPath);

            public static readonly string btnManageTestSetsValue = "Manage Test Sets";
            public static readonly string btnAssignTestXPath = @".//a[contains(@title, 'Assign Test to TestSet')]";
            public static readonly string btnRunTestXPath = @".//img[contains(@alt, 'Run Test')]";
            public static readonly string filterByTestSetInputId = "ctl00_PageContent_Toolbar_toolbar2_i0_SelectTestSetTree_ComboTree_Input"; 
                                                                    
        }

        public static class TestPlanPage
        {
            public static By byElement= By.XPath(@".//*[contains(@title, 'Test Plan')]");

            public static readonly string subjectFolderName = "Subject";
            public static readonly string txtFindNodeID1 = "ctl00_PageContent_WebPartManager";
            public static readonly string txtFindNodeID2 = "TestPlanTreeControl_GenericTreeView1_RadTextBox1";
            public static readonly string treePanelID = "divTestPlanTree";

            public static readonly string btnUploadScriptTitle = "Upload Script";
            public static readonly string btnCreateTestTitle = "New Test";
            public static readonly string btnDeleteTitle = "Delete";
            public static readonly string btnCopyTitle = "Copy";
            public static readonly string btnCutTitle = "Cut";
            public static readonly string btnPasteTitle = "Paste";
            public static readonly string btnEditTest = "Edit Test";

            public static readonly string newFolderButtonClass = "newFolderButton";

            public static readonly string selectedItemAttributeValue = "rtSelected";

            public static readonly string selectedFolderXPath = @"//img[contains(@src, 'selected_folder')]/following-sibling::span";
            public static readonly string performanceTestXPath = @"//img[contains(@src, 'test-performance.svg')]/following-sibling::span";
            public static readonly string scriptXPath = @"//img[contains(@src, 'default_view-script.svg')]/following-sibling::span";
            

            public static string TreeItemXPathByName(string treeItemName)
            { 
                return string.Format(".//span[@class='rtIn'][text()='{0}']", treeItemName); 
            }
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
