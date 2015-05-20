using OpenQA.Selenium;
using WEBPages.BasePageObject;
using WEBUIautomation.WebElement;
using WEBUIautomation.Extensions;
using WEBPages.Extensions;
using AutoItX3Lib;

namespace WEBPages.MyPCPages
{
  

using Locators = ContentLocators.Locators.UploadScriptDialog;
    using System.Threading;
    using WEBUIautomation.Wait;
    using System;

    public class UploadScriptDialog :   FirstLevelDialog
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
            WaitHelper.MakeTry(
                () => GetNotificationMessage().Contains("uploaded")                
                );
            return this;
        }
         
        public TestPlanPage ClickCloseButton()
        { 
            btnClose.Click();
            return new TestPlanPage();
        }


        public UploadScriptDialog SelectScript(string pathToScript)
        {
            return ClickSelectBtn().SendPathToWindow(pathToScript); 
        }

        private UploadScriptDialog SendPathToWindow(string path)
        {
            System.Windows.Forms.SendKeys.SendWait(path);
            System.Windows.Forms.SendKeys.SendWait("{ENTER}");
            return this;
        }

        #endregion Actions
    }
}
