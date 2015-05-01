using OpenQA.Selenium;
using System;
using WEBUIautomation.Utils;
using WEBUIautomation.WebElement;
using WEBUIautomation.Extensions;
using WEBPages.Extensions;
using WEBPages.BasePageObject;

namespace WEBPages.MyPCPages
{

    using Locators = WEBPages.ContentLocators.Locators.CreateTestDialog;

    public class CreateTestDialog : FirstLevelDialog
    {
        #region The dialog locators
        
        public override string ViewLocator { get { return Locators.ViewLocator; } }

        public override By FrameLocator { get { return Locators.FrameLocator; } }


        #endregion The dialog locators

        #region UI Web Elements

        WebElement txtNewTestName
        { get { return dialog.NewWebElement().ById(Locators.txtNewTestNameID); } }

        WebElement cmbTestSetTree
        { get { return dialog.NewWebElement().ById(Locators.cmbTestSetTreeID); } }

        WebElement btnCreateNewOK
        { get { return dialog.NewWebElement().ById(Locators.btnCreateNewOKID); } }

        WebElement btnClose
        { get { return dialog.NewWebElement().ById(Locators.btnCloseID); } }

        WebElement btnHelp
        { get { return dialog.NewWebElement().ById(Locators.btnHelpID); } }

        #endregion UI Web Elements

        #region Helpers




        #endregion Helpers

        #region Actions




        #endregion Actions
    }
}
