using OpenQA.Selenium;
using WEBUIautomation.Extensions;
using WEBUIautomation.WebElement;
using WEBPages.Extensions;
using WEBPages.BasePageObject;
using WEBPages.ContentLocators;

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
        { get { return mainPage.GetElement().ByTagName(WEBUIautomation.Tags.TagNames.Span).ByAttribute(WEBUIautomation.Tags.TagAttributes.LocalString, "operational"); } }
        //Runs
        //Last modified entities
        //Resources

        

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
