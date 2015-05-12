using OpenQA.Selenium;
using WEBPages.BasePageObject;
using WEBUIautomation.WebElement;
using WEBUIautomation.Extensions;
using WEBPages.Extensions;

namespace WEBPages.MyPCPages
{
  

using Locators = ContentLocators.Locators.UploadScriptDialog;
    using System.Threading;

    public class UploadScriptDialog :   FirstLevelDialog
    {
        #region The dialog locators

        public override string  ViewLocator     { get { return Locators.ViewLocator; } }
        public override By      FrameLocator    { get { return Locators.FrameLocator; } }       
                    
        #endregion The dialog locators

        #region UI Web Elements

        protected override WebElement btnClose { get {return dialog.NewWebElement().ById(Locators.btnCloseId);} }
        WebElement btnSelect { get { return dialog.NewWebElement().ByXPath(Locators.btnSelectXpath); } }
        WebElement btnUpload { get { return dialog.NewWebElement().ById(Locators.btnUploadId); } }

        #endregion UI Web Elements

        #region Helpers
        

        #endregion Helpers

        #region Actions

        public UploadScriptDialog ClickSelectBtn()
        {
            btnSelect.Click();
            return this;
        }

        public UploadScriptDialog ClickUploadBtn()
        {
            btnUpload.Click();
            Thread.Sleep(1000);
            return this;
        }

        public TestPlanPage ClickCloseButton()
        { 
            btnClose.Click();
            return new TestPlanPage();
        }


        public UploadScriptDialog SelectScript(string pathToScript)
        {
            ClickSelectBtn()
            .SendPathToWindow(pathToScript);
            return this;
        }

        UploadScriptDialog SendPathToWindow(string path)
        {
            System.Windows.Forms.SendKeys.SendWait(path);
            System.Windows.Forms.SendKeys.SendWait("{ENTER}");
            return this;
        }

        #endregion Actions
    }
}
