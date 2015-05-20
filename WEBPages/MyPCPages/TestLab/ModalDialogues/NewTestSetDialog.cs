using OpenQA.Selenium;
using WEBUIautomation.WebElement;
using WEBUIautomation.Wait;
using WEBPages.Extensions;
using WEBPages.BasePageObject;

namespace WEBPages.MyPCPages
{
    using Locators = ContentLocators.Locators.NewTestSetDialog;
    

    public class NewTestSetDialog : SecondLevelDialog
    {
        #region The dialog locators

        public override string ViewLocator { get { return Locators.ViewLocator; } }

        public override By FrameLocator { get { return Locators.FrameLocator; } }        
        
        #endregion The dialog locators

        #region UI Web Elements

         WebElement txtTestSetName
        { get { return dialog.GetElement().ById("ctl00_ctl00_PageContent_DialogContent_TxtTestSetName"); } }

        #endregion UI Web Elements

        #region Properties

         public string TestSetName
         { get { return txtTestSetName.Text; } }

        #endregion Properties

    #region Actions

        #region Single Actions

        public NewTestSetDialog TypeTestSetName(string testSetName)
        {
            txtTestSetName.Text = testSetName;
            return this;            
        }        

        public ManageTestSetsDialog ClickOkExpectingSucces()
        {
             btnOk.Click();
             return new ManageTestSetsDialog();
        }

        public ManageTestSetsDialog ClickClose()
        {
            btnClose.Click();
            return new ManageTestSetsDialog();
        }

        public string GetWarningMessage()
        {
            if (IsMessageDisplayed())
                return lblMessage.Text;
            return string.Empty;
        }

        #endregion Single Actions


        #region Complex Action
                
        #endregion Complex Action

    #endregion Actions

    }
}
