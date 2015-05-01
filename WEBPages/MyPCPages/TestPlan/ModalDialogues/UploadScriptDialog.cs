using OpenQA.Selenium;
using WEBPages.BasePageObject;

namespace WEBPages.MyPCPages
{
  
    using Locators = ContentLocators.Locators.UploadScriptDialog;

    public class UploadScriptDialog :FirstLevelDialog
    {
        #region The dialog locators

        public override string ViewLocator { get { return Locators.ViewLocator; } }
        public override By FrameLocator { get { return Locators.FrameLocator; } }       
                    
        #endregion The dialog locators

        #region UI Web Elements
        

        #endregion UI Web Elements

        #region Helpers




        #endregion Helpers

        #region Actions




        #endregion Actions
    }
}
