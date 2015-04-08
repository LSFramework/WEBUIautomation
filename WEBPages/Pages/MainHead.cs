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

namespace WEBPages.Pages
{ 
    public class MainHead: DriverContainer
    {
        #region The Page Locator

        const string position = "MastheadDiv";       

        private static IWebDriverExt mainPage
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

        public static bool PageCanGetFocus()
        {
            return driver.CurrentFrame == By.Id(position) || driver.CurrentFrame == By.Id("MainTab");                
        }

        #endregion Page Locator

        #region Elements Locators

        #region Main Head Title Elements

        private static WebElement lblUser
        { get { return mainPage.NewWebElement().ByXPath(@".//span[contains(@local-string, 'hello')]/.."); } }

        private static WebElement lblDomain
        { get { return mainPage.NewWebElement().ByXPath(@".//span[contains(@local-string, 'domain')]/.."); } }

        private static WebElement lblProject
        { get { return mainPage.NewWebElement().ByXPath(@".//span[contains(@local-string, 'project')]/.."); } }

        private static WebElement btnLogout
        { get { return mainPage.NewWebElement().ByXPath(@".//span[contains(@local-string, 'logout')]"); } }

        public static void ClickLogout()
        {
            btnLogout.Click();        
        }


        #endregion  Main Head Title Elements

        #region Main Head Tabs Elements Locators

        private static WebElement tabHome
        { get { return mainPage.NewWebElement().ByXPath(@".//span[contains(@class, 'IconContainer IconHome')]"); } }

        private static WebElement btnCloseDLT
        { get { return mainPage.NewWebElement().ByXPath(@".//div[contains(@class, 'xButtonWrapper')]"); } }

        #endregion  Main Head Tabs Elements Locators

        #region Main Head Links Elements Locators

        #region Links
        /// <summary>
        /// Start Link
        /// </summary>
        private static WebElement link_Start
          { get { return mainPage.NewWebElement().ByText("Start"); } }

        /// <summary>
        /// Test Management Links 
        /// </summary>
        private static WebElement link_TestMgmt
        { get { return mainPage.NewWebElement().ByText("Test Management"); } }

        private static WebElement linkTestPlan
        { get { return mainPage.NewWebElement().ByText("Test Plan"); } }

        private static WebElement linkTestLab
        { get { return mainPage.NewWebElement().ByText("Test Lab"); } }



        /// <summary>
        /// Runs & Analysis Links
        /// </summary>
        private static WebElement link_RunsAndAnalysis
        { get { return mainPage.NewWebElement().ByText("Runs & Analysis"); } }

        private static WebElement linkRuns
        { get { return mainPage.NewWebElement().ByText("Runs"); } }

        private static WebElement linkTrending
        { get { return mainPage.NewWebElement().ByText("Trending"); } }

        private static WebElement linkPAL
        { get { return mainPage.NewWebElement().ByText("PAL"); } }


        /// <summary>
        /// Resources Link
        /// </summary>
        private static WebElement link_Resources
        { get { return mainPage.NewWebElement().ByText("Resources"); } }

        private static WebElement link_TestResources
        { get { return mainPage.NewWebElement().ByText("Test Resources"); } }

        private static WebElement link_TestingHosts
        { get { return mainPage.NewWebElement().ByText("Testing Hosts"); } }

        private static WebElement link_Timeslots
        { get { return mainPage.NewWebElement().ByText("Timeslots"); } }

        private static WebElement link_Topologies
        { get { return mainPage.NewWebElement().ByText("Topologies"); } }

        private static WebElement link_MI_Listeners
        { get { return mainPage.NewWebElement().ByText("MI Listeners"); } }

        /// <summary>
        /// Reports Link
        /// </summary>
        private static WebElement link_Reports
        { get { return mainPage.NewWebElement().ByText("Reports"); } }

        /// <summary>
        /// Personalized Views Link
        /// </summary>
        private static WebElement link_Personal
        { get { return mainPage.NewWebElement().ByText("Personalized Views"); } }

        #endregion Links

        #region Refresh Section
        /// <summary>
        /// Refresh Button
        /// </summary>
        private static WebElement btnRefresh 
        { get { return mainPage.NewWebElement().ByXPath(@".//div[contains(@ng-click, 'Refresh()')]"); } }

        /// <summary>
        /// Auto refresh menu
        /// </summary>
        private static WebElement menuAutoRefresh
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
        private static WebElement menuItemAutoRefreshOn
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
        private static WebElement menuItemAutoRefreshOff
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

        public static string GetDomainName()
        {
           return lblDomain.Text;
        }

        public static string GetProjectName()
        {
            return lblProject.Text;
        }

        public static string GetUserLoggedIn()
        {
            return lblUser.Text;
        }

        #endregion Main Head Title

        #region Main Head Tabs Actions

        public static void CloseDLT_Tab()
        {
            btnCloseDLT.Click();
        }

        public static void ClickHomeTab()
        {
            tabHome.Click();
        }

        #endregion Main Head Tabs Actions

        #region Main Head Links Actions

        public static void ClickRefresh()
        {
            btnRefresh.Click();
        }


        ///To be DELETED
        //public static void ClickMenuItem(string textMenuItem)
        //{
        //    string xPathLocator = @".//*[contains(text(), '" + textMenuItem + "')]";
        //    IWebElement menuItem = mainPage.FindElementAndWait(By.XPath(xPathLocator));
        //    (mainPage as IJavaScriptExecutor).ExecuteScript(string.Format("window.scrollTo(0, {0});", menuItem.Location.Y));
        //    menuItem.Click();
        //}

        /// <summary>
        /// Action: Perform click on Test Management Link
        /// Expected: Test Plan and Test Plan links are shown 
        /// </summary>
        public static void MouseOverTestManagementLink()
        {
            link_TestMgmt.MouseOver();
        }
        

        /// <summary>
        /// Action: Perform click on Test Lab item
        /// Expected: Test Lab perspective opened
        /// </summary>
        public static void ClickTestLabLink()
        {
            linkTestLab.Click();
        }

        /// <summary>
        /// Actions: 
        /// 1. Mouse over Test Management link 
        /// 1. Perform click on Test Lab item
        /// Expected: Test Lab perspective opened
        /// </summary>
        public static void NavigateToTestLab()
        {
            MouseOverTestManagementLink();
            ClickTestLabLink();
        }

        /// <summary>
        /// Action: Perform click on Test Lab item
        /// Expected: Test Plan perspective opened
        /// </summary>
        public static void ClickTestPlanLink()
        {
            linkTestPlan.Click();
        }


        /// <summary>
        /// Actions: 
        /// 1. Mouse over Test Management link 
        /// 1. Perform click on Test Lab item
        /// Expected: Test Lab perspective opened
        /// </summary>
        public static void NavigateToTestPlan()
        {
            MouseOverTestManagementLink();
            ClickTestPlanLink();
        }

        #endregion Main Head Links Actions

        #endregion //Page Actions
    }   
}
