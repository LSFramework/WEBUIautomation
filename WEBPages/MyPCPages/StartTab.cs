using WEBUIautomation.Extensions;
using WEBUIautomation.WebElement;
using WEBPages.Extensions;
using WEBPages.BasePageObject;
using WEBPages.MyPCPages.DesignLoadTest;

namespace WEBPages.MyPCPages
{
    using Locators = ContentLocators.Locators.StartTabPage;   
  
    public class StartTab : MainHead
    {
        public override string ViewLocator
        { get { return Perspectives.Start.GetEnumDescription(); } }

        public StartTab() : base() 
        { base.ShowStart(); }

        #region UI Web Elements

        private WebElement operationalHostsAmount
        {
            get
            {
                return mainPage.GetElement()
                    .ByTagName(WEBUIautomation.Tags.TagNames.Span)
                    .ByAttribute(WEBUIautomation.Tags.TagAttributes.LocalString, "operational");
            }
        }
        //Runs
        //Last modified entities
        //Resources

        private WebElement TestLinkFinishedTest(string testName, int testRunId)
        {
           //Find link to Id
           WebElement linkToId = mainPage.GetElement()
               .ByAttribute(WEBUIautomation.Tags.TagAttributes.NgClick, Locators.runIdLinkNgClassValue)
               .ByText(testRunId.ToString());

           WebElement parent = linkToId.GetParent(); //Return to parent

           
           WebElement linkToFinishedTest = parent.FindRelative()  //Down to the test link
               .ByAttribute(WEBUIautomation.Tags.TagAttributes.Class, Locators.testLinkClassValue)
               .ByText(testName);

           return linkToFinishedTest;            
        }

        public DLT ClickTestLinkFinishedTest(string testName, int runId)
        {
            TestLinkFinishedTest(testName, runId).Click();

            DLT dlt = new DLT(new LoadTest(testName));
            
            return dlt;
        }

        public DLT ClickLastModifiedTest(string testName)
        {
            LastModifiedTest(testName).Click();
            DLT dlt = new DLT(new LoadTest(testName));
            return dlt;
        }

        private WebElement LastModifiedTest(string testName)
        {
            return mainPage.GetElement()
                .ByTagName(WEBUIautomation.Tags.TagNames.Link)
                .ByAttribute(WEBUIautomation.Tags.TagAttributes.NgClick, Locators.lastModifiedTestNgClickValue)
                .ByAttribute(WEBUIautomation.Tags.TagAttributes.Title, testName);
        }

        #endregion UI Web Elements

        #region Helpers

        #endregion Helpers

        #region Actions

        public string GetHostsAmount()
        {
            return operationalHostsAmount.Text;
        }

        #endregion Actions
    }
}
