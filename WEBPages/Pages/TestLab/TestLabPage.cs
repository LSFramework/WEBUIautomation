using OpenQA.Selenium;
using WEBUIautomation.Utils;
using WEBUIautomation.Extensions;
using WEBUIautomation.WebElement;
using WEBUIautomation.Wait;

namespace WEBPages.Pages.TestLab
{
    using TagAttributes = WEBUIautomation.Tags.TagAttributes;
    using WEBPages.Pages.TestLab.ModalDialogues;
    using System;

    public class TestLabPage: DriverContainer, IPage
    {

        public string Url { get; private set; }

        public string ViewLocator { get { return "Test Lab"; } }

        public By FrameLocator { get { return By.Id( "MainTab"); } }

        IWebDriverExt mainTab
        {
            get
            {
                if (! IsDriverOnTheView(FrameLocator, ViewLocator))          
                {
                    try
                    {
                        driver.SwitchToFrame(FrameLocator);
                        driver.NewWebElement().ByAttribute(TagAttributes.Title,"Manage Test Sets");
                        driver.CurrentView = ViewLocator;
                    }
                    catch (Exception)
                    {
                        driver.SwitchTo().DefaultContent();
                        MainHead mainHead = new MainHead();
                        mainHead.NavigateToTestLab();
                        driver.SwitchToFrame(FrameLocator);
                        driver.CurrentView = ViewLocator;
                    }
                }
               
                return driver;
            }
        }
                
        public TestLabPage() 
        { 
           Url = mainTab.Url; 
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
        public  ManageTestSetsDialog ClickManageTestSets()
        {
            btnManageTestSets.Click();
            return new ManageTestSetsDialog();
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
