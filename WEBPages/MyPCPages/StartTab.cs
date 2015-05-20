using OpenQA.Selenium;
using WEBUIautomation.Extensions;

namespace WEBPages.MyPCPages
{

    using WEBPages.ContentLocators;
    using Locators = ContentLocators.Locators.StartTabPage;

    public class StartTab : MainHead
    {
        public override string ViewLocator
        { get { return Perspectives.Start.GetEnumDescription(); } }

        public StartTab() : base() 
        { base.ShowStart(); }

        #region UI Web Elements

        //Runs
        //Last modified entities
        //Resources
        #endregion UI Web Elements

        #region Helpers

        #endregion Helpers

        #region Actions
        #endregion Actions
    }
}
