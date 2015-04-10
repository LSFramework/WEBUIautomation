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

namespace WEBPages.Pages
{
    public class MainHead: DriverContainer
    {
        #region The Page Locator

        const string position = "MastheadDiv";

        public static bool PageCanGetFocus()
        {
            return driver.CurrentFrame == By.Id(position) || driver.CurrentFrame == By.Id("MainTab");
        }
        
        IWebDriverExt mainPage
        {
            get 
            {
                if (driver.CurrentFrame != (By.Id(position)))
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
        private  WebElement link_Start
          { get { return mainPage.NewWebElement().ByText("Start"); } }

        /// <summary>
        /// Test Management Links 
        /// </summary>
        private  WebElement link_TestMgmt
        { get { return mainPage.NewWebElement().ByText("Test Management"); } }

        private  WebElement linkTestPlan
        { get { return mainPage.NewWebElement().ByText("Test Plan"); } }

        private  WebElement linkTestLab
        { get { return mainPage.NewWebElement().ByText("Test Lab"); } }



        /// <summary>
        /// Runs & Analysis Links
        /// </summary>
        private  WebElement link_RunsAndAnalysis
        { get { return mainPage.NewWebElement().ByText("Runs & Analysis"); } }

        private  WebElement linkRuns
        { get { return mainPage.NewWebElement().ByText("Runs"); } }

        private  WebElement linkTrending
        { get { return mainPage.NewWebElement().ByText("Trending"); } }

        private  WebElement linkPAL
        { get { return mainPage.NewWebElement().ByText("PAL"); } }


        /// <summary>
        /// Resources Link
        /// </summary>
        private  WebElement link_Resources
        { get { return mainPage.NewWebElement().ByText("Resources"); } }

        private  WebElement link_TestResources
        { get { return mainPage.NewWebElement().ByText("Test Resources"); } }

        private  WebElement link_TestingHosts
        { get { return mainPage.NewWebElement().ByText("Testing Hosts"); } }

        private  WebElement link_Timeslots
        { get { return mainPage.NewWebElement().ByText("Timeslots"); } }

        private  WebElement link_Topologies
        { get { return mainPage.NewWebElement().ByText("Topologies"); } }

        private  WebElement link_MI_Listeners
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

        public  void ClickRefresh()
        {
            btnRefresh.Click();
        }

        /// <summary>
        /// Action: Perform click on Test Management Link
        /// Expected: Test Plan and Test Plan links are shown 
        /// </summary>
        public  void MouseOverTestManagementLink()
        {
            link_TestMgmt.MouseOver();
        } 

        /// <summary>
        /// Action: Perform click on Test Lab item
        /// Expected: Test Lab perspective opened
        /// </summary>
        public  void ClickTestLabLink()
        {
            linkTestLab.Click();
        }

        /// <summary>
        /// Actions: 
        /// 1. Mouse over Test Management link 
        /// 1. Perform click on Test Lab item
        /// Expected: Test Lab perspective opened
        /// </summary>
        public void NavigateToTestLab()
        {
            MouseOverTestManagementLink();
            ClickTestLabLink();
            driver.SwitchToFrame(TestLabPage.FrameLocator);         
            driver.CurrentView = TestLabPage.ViewLocator;
        }

        /// <summary>
        /// Action: Perform click on Test Lab item
        /// Expected: Test Plan perspective opened
        /// </summary>
        public  void ClickTestPlanLink()
        {
            linkTestPlan.Click();
        }

        /// <summary>
        /// Actions: 
        /// 1. Mouse over Test Management link 
        /// 1. Perform click on Test Lab item
        /// Expected: Test Lab perspective opened
        /// </summary>
        public void NavigateToTestPlan()
        {
            MouseOverTestManagementLink();
            ClickTestPlanLink();
            driver.SwitchToFrame(TestLabPage.FrameLocator);
            driver.CurrentView = TestLabPage.ViewLocator;
        }

        #endregion Main Head Links Actions

        #endregion //Page Actions
    }   
}
