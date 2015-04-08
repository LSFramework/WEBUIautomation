using OpenQA.Selenium;
using WEBUIautomation.Utils;
using WEBUIautomation.Extensions;
using WEBUIautomation.WebElement;
using WEBUIautomation.Wait;

namespace WEBPages.Pages.TestLab
{
    using TagAttributes = WEBUIautomation.Tags.TagAttributes;

    public class TestLab: DriverContainer
    {

        const string viewLocator = "Test Lab perspective";
        const string frameLocator = "MainTab";   

        static IWebDriverExt mainTab
        {
            get
            {
                ///Is driver on the perspective we need ?
                if (! IsDriverOnTheView(By.Id(frameLocator), viewLocator))
                /// if it isn't
                {     
                    //Navigate to the perspective
                    driver.SwitchTo().DefaultContent();
                    MainHead.NavigateToTestLab();                    
                    //Set driver's focus on the frame contains the perspective UI
                    //and mark driver as it is on the perspective
                    driver.SwitchToFrame(By.Id(frameLocator));
                    driver.CurrentView = viewLocator;
                }
                // If yes 
                return driver;
            }
        }
        

        static WebElement btnManageTestSets
        { get { return mainTab.NewWebElement().ByAttribute(TagAttributes.Title,"Manage Test Sets"); } }

        static WebElement btnAssignTest
        { get { return mainTab.NewWebElement().ByXPath(@".//a[contains(@title, 'Assign Test to TestSet')]"); } }

        static WebElement btnRunTest
        { get { return mainTab.NewWebElement().ByXPath(@".//img[contains(@alt, 'Run Test')]"); } }
               
        public static bool TestLabOpened
        { get { return WaitHelper.Try(() => btnManageTestSets.Exists()); } }

        /// <summary>
        /// Action : Performs click Manage Test Sets button.
        /// Expected : A modal-dialog Manage Test Sets appears.
        /// </summary>
        public static void ClickManageTestSets()
        {
            btnManageTestSets.Click();
        }
        
        /// <summary>
        /// Select Test In Grid
        /// </summary>
        /// <param name="testName"></param>
        public static void SelectTestInGrid(string testName)
        {
            mainTab.NewWebElement().ByXPath(@".//td[contains(text(), '" + testName + "')]").Click();
        }
    }
}
