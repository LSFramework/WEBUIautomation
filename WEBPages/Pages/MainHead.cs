using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBUIautomation;
using WEBUIautomation.Utils;
using System.Drawing;
using WEBUIautomation.Extensions;
using WEBUIautomation.WebElement;
using WEBUIautomation.Wait;
using WEBPages.Pages.TestLab;
using WEBPages.Pages.TestPlan;

namespace WEBPages.Pages
{
    public class MainHead: DriverContainer
    {
        #region The Page Locator

        public string ViewLocator { get { return "Main Head"; } }

        public static By FrameLocator { get { return By.Id("MastheadDiv"); } }   
        

        public static bool PageCanGetFocus()
        {
            return driver.CurrentFrame == FrameLocator || driver.CurrentFrame == By.Id("MainTab");
        }
        
        IWebDriverExt mainPage
        {
            get 
            {
                if (driver.CurrentFrame != FrameLocator)
                {   
                    driver.SwitchToDefaultContent(); 
                }
                return driver;            
            }
        }

       

        #endregion Page Locator

        #region Elements Locators

        #region Main Head Title Elements

        private  WebElement lblUser
        { get { return mainPage.NewWebElement().ByXPath(@".//span[contains(@local-string, 'hello')]/.."); } }

        private  WebElement lblDomain
        { get { return mainPage.NewWebElement().ByXPath(@".//span[contains(@local-string, 'domain')]/.."); } }

        private  WebElement lblProject
        { get { return mainPage.NewWebElement().ByXPath(@".//span[contains(@local-string, 'project')]/.."); } }

        private  WebElement btnLogout
        { get { return mainPage.NewWebElement().ByXPath(@".//span[contains(@local-string, 'logout')]"); } }

        public  void ClickLogout()
        {
            btnLogout.Click();        
        }


        #endregion  Main Head Title Elements

        #region Main Head Tabs Elements Locators

        private  WebElement tabHome
        { get { return mainPage.NewWebElement().ByXPath(@".//span[contains(@class, 'IconContainer IconHome')]"); } }

        private  WebElement btnCloseDLT
        { get { return mainPage.NewWebElement().ByXPath(@".//div[contains(@class, 'xButtonWrapper')]"); } }

        #endregion  Main Head Tabs Elements Locators

        #region Main Head Links Elements Locators

        #region Links
        /// <summary>
        /// Start Link
        /// </summary>
        WebElement link_Start
        { get { return mainPage.NewWebElement().ByText("Start"); } }

        /// <summary>
        /// Test Management Links 
        /// </summary>
        WebElement link_TestMgmt
        { get { return mainPage.NewWebElement().ByText("Test Management"); } }

        WebElement linkTestPlan
        { get { return mainPage.NewWebElement().ByText("Test Plan"); } }

        WebElement linkTestLab
        { get { return mainPage.NewWebElement().ByText("Test Lab"); } }



        /// <summary>
        /// Runs & Analysis Links
        /// </summary>
        WebElement link_RunsAndAnalysis
        { get { return mainPage.NewWebElement().ByText("Runs & Analysis"); } }

        WebElement linkRuns
        { get { return mainPage.NewWebElement().ByText("Runs"); } }

        WebElement linkTrending
        { get { return mainPage.NewWebElement().ByText("Trending"); } }

        WebElement linkPAL
        { get { return mainPage.NewWebElement().ByText("PAL"); } }


        /// <summary>
        /// Resources Link
        /// </summary>
        WebElement link_Resources
        { get { return mainPage.NewWebElement().ByText("Resources"); } }

        WebElement link_TestResources
        { get { return mainPage.NewWebElement().ByText("Test Resources"); } }

        WebElement link_TestingHosts
        { get { return mainPage.NewWebElement().ByText("Testing Hosts"); } }

        WebElement link_Timeslots
        { get { return mainPage.NewWebElement().ByText("Timeslots"); } }

        WebElement link_Topologies
        { get { return mainPage.NewWebElement().ByText("Topologies"); } }

        WebElement link_MI_Listeners
        { get { return mainPage.NewWebElement().ByText("MI Listeners"); } }

        /// <summary>
        /// Reports Link
        /// </summary>
        private  WebElement link_Reports
        { get { return mainPage.NewWebElement().ByText("Reports"); } }

        /// <summary>
        /// Personalized Views Link
        /// </summary>
        private  WebElement link_Personal
        { get { return mainPage.NewWebElement().ByText("Personalized Views"); } }

        #endregion Links

        #region Refresh Section
        /// <summary>
        /// Refresh Button
        /// </summary>
        private  WebElement btnRefresh 
        { get { return mainPage.NewWebElement().ByXPath(@".//div[contains(@ng-click, 'Refresh()')]"); } }

        /// <summary>
        /// Auto refresh menu
        /// </summary>
        private  WebElement menuAutoRefresh
        {
            get
            {
                return mainPage.NewWebElement()
                    .ByTagName(WEBUIautomation.Tags.TagNames.Div)
                    .ByClass("iconPadding iconPaddingDropdown");
            }
        }

        /// <summary>
        /// Auto refresh On 
        /// </summary>
        private  WebElement menuItemAutoRefreshOn
        {
            get
            {
                return mainPage.NewWebElement()
                    .ByTagName(WEBUIautomation.Tags.TagNames.Span)
                    .ByText("Auto Refresh On");
            }
        }
        /// <summary>
        /// Auto refresh Off
        /// </summary>
        private  WebElement menuItemAutoRefreshOff
        {
            get
            {
                return mainPage.NewWebElement()
                    .ByTagName(WEBUIautomation.Tags.TagNames.Span)
                    .ByText("Auto Refresh Off");
            }
        }
       
        #endregion Refresh Section

        #endregion Main Head Links Elements Locators
        
        #endregion //Elements Locators

        #region Page Actions
        
        #region Main Head Title Actions

        public  string GetDomainName()
        {
           return lblDomain.Text;
        }

        public  string GetProjectName()
        {
            return lblProject.Text;
        }

        public  string GetUserLoggedIn()
        {
            return lblUser.Text;
        }

        #endregion Main Head Title

        #region Main Head Tabs Actions

        public  void CloseDLT_Tab()
        {
            btnCloseDLT.Click();
        }

        public  void ClickHomeTab()
        {
            tabHome.Click();
        }

        #endregion Main Head Tabs Actions

        #region Main Head Links Actions

        public MainHead ClickRefresh()
        {
            btnRefresh.Click();
            return this;
        }

        /// <summary>
        /// Action: Perform click on Test Management Link
        /// Expected: Test Plan and Test Plan links are shown 
        /// </summary>
        public MainHead MouseOverTestManagementLink()
        {
            link_TestMgmt.MouseOver();
            return this;
        } 

        /// <summary>
        /// Action: Perform click on Test Lab item
        /// Expected: Test Lab perspective opened
        /// </summary>
        public  TestLabPage ClickTestLabLink()
        {
            linkTestLab.Click();
            return new TestLabPage();
        }

        /// <summary>
        /// Actions: 
        /// 1. Mouse over Test Management link 
        /// 1. Perform click on Test Lab item
        /// Expected: Test Lab perspective opened
        /// </summary>
        public TestLabPage NavigateToTestLab()
        {
            return MouseOverTestManagementLink()
            .ClickTestLabLink();
        }

        /// <summary>
        /// Action: Perform click on Test Lab item
        /// Expected: Test Plan perspective opened
        /// </summary>
        public TestPlanPage ClickTestPlanLink()
        {
            linkTestPlan.Click();
            return new TestPlanPage();
        }

        /// <summary>
        /// Actions: 
        /// 1. Mouse over Test Management link 
        /// 1. Perform click on Test Lab item
        /// Expected: Test Lab perspective opened
        /// </summary>
        public TestPlanPage NavigateToTestPlan()
        {
            return MouseOverTestManagementLink()
            .ClickTestPlanLink();
        }

        #endregion Main Head Links Actions

        #endregion //Page Actions
    }   
}
