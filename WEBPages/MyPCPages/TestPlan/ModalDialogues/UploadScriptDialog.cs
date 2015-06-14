using OpenQA.Selenium;
using WEBPages.BasePageObject;
using WEBUIautomation.WebElement;
using WEBPages.Extensions;
using WEBUIautomation.Wait;
using System;
using System.Windows.Forms;

namespace WEBPages.MyPCPages
{
    using Locators = ContentLocators.Locators.UploadScriptDialog;
   

    public class UploadScriptDialog : FirstLevelDialog
    {
        #region The dialog locators

        public override string  ViewLocator     { get { return Locators.ViewLocator; } }
        public override By      FrameLocator    { get { return Locators.FrameLocator; } }       
                    
        #endregion The dialog locators

        #region UI Web Elements

        protected override WebElement btnClose { get {return dialog.GetElement().ById(Locators.btnCloseId);} }
        
        private WebElement btnSelect { get { return dialog.GetElement().ByXPath(Locators.btnSelectXpath); } }

        private WebElement btnUpload { get { return dialog.GetElement().ById(Locators.btnUploadId); } }
       
        #endregion UI Web Elements

        public string GetNotificationMessage()
        {
            return dialog.GetElement().ByXPath(Locators.msgNotificationXPath).Text;
        }

        #region Helpers
        

        #endregion Helpers

        #region Actions


        /// <summary>
        /// Action: Click
        /// Response: A windows' diolog opens to upload a script
        /// </summary>
        /// <returns></returns>
        public UploadScriptDialog ClickSelectBtn()
        {
           
            btnSelect.ClickPerform();
            return this;
        }

        public UploadScriptDialog ClickUploadBtn()
        {
            btnUpload.Click();
            WaitHelper.WithTimeout(TimeSpan.FromSeconds(10), TimeSpan.FromMilliseconds(200))
                .WaitFor(
                () => GetNotificationMessage().Contains("uploaded")                
                );
            return this;
        }
         
        public TestPlanPage ClickCloseButton()
        { 
            btnClose.Click();
            return new TestPlanPage();
        }


        public void SelectScript(string pathToScript)
        {
             ClickSelectBtn();
             dialog.SendStringToWinDialog(pathToScript);
        }

       
        #endregion Actions
    }
}
