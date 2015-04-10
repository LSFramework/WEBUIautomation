using OpenQA.Selenium;
using WEBUIautomation.Utils;
using WEBUIautomation.Extensions;
using WEBUIautomation.WebElement;
using WEBUIautomation.Wait;

namespace WEBPages.Pages.TestLab
{
    using TagAttributes = WEBUIautomation.Tags.TagAttributes;

    public class TestLabPage: DriverContainer
    {
        public const string ViewLocator = "Test Lab";
        public static By FrameLocator =By.Id( "MainTab");   

        IWebDriverExt mainTab
        {
            get
            {
                ///Is driver on the perspective we need ?
                if (! IsDriverOnTheView(FrameLocator, ViewLocator))
                /// if it isn't
                {     
                    //Navigate to the perspective
                    driver.SwitchTo().DefaultContent();
                    MainHead mainHead = new MainHead();
                    mainHead.NavigateToTestLab();                    
                    //Set driver's focus on the frame contains the perspective UI
                    //and mark driver as it is on the perspective
                    driver.SwitchToFrame(FrameLocator);
                    driver.CurrentView = ViewLocator;
                }
                // If yes 
                return driver;
            }
        }
        

         WebElement btnManageTestSets
        { get { return mainTab.NewWebElement().ByAttribute(TagAttributes.Title,"Manage Test Sets"); } }

         WebElement btnAssignTest
        { get { return mainTab.NewWebElement().ByXPath(@".//a[contains(@title, 'Assign Test to TestSet')]"); } }

         WebElement btnRunTest
        { get { return mainTab.NewWebElement().ByXPath(@".//img[contains(@alt, 'Run Test')]"); } }
               
        public bool Opened
        { get { return WaitHelper.Try(() => btnManageTestSets.Exists(1)); } }

        /// <summary>
        /// Action : Performs click Manage Test Sets button.
        /// Expected : A modal-dialog Manage Test Sets appears.
        /// </summary>
        public  void ClickManageTestSets()
        {
            btnManageTestSets.Click();
        }
        
        /// <summary>
        /// Select Test In Grid
        /// </summary>
        /// <param name="testName"></param>
        public  void SelectTestInGrid(string testName)
        {
            mainTab.NewWebElement().ByXPath(@".//td[contains(text(), '" + testName + "')]").Click();
        }
    }
}
