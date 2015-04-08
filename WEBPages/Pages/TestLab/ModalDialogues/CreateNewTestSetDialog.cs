using OpenQA.Selenium;
using WEBUIautomation.Utils;
using WEBUIautomation.Extensions;
using WEBUIautomation.WebElement;
using WEBUIautomation.Wait;

namespace WEBPages.Pages.TestLab.ModalDialogues
{
    public class CreateNewTestSetDialog: DriverContainer
    {

        #region The dialog locators

        const string viewLocator = "Create New Performance Test Set";
        const string frameLocator = "CreateNewTestSet";
       

        static IWebDriverExt dialog
        {
            get
            {
                if (!IsDriverOnTheView(By.Name(frameLocator), viewLocator))
                {
                    driver.SwitchToFrame(By.Name(frameLocator));
                    driver.CurrentView = viewLocator;
                }
                return driver;
            }
        }
        
        #endregion The dialog locators

        #region UI Web Elements

        static WebElement txtTestSetName
        { get { return dialog.NewWebElement().ById("ctl00_ctl00_PageContent_DialogContent_TxtTestSetName"); } }

        static WebElement btnOK
        { get { return dialog.NewWebElement().ById("ctl00_ctl00_PageContent_DialogActions_btnOK"); } }

        static WebElement btnClose
        { get { return dialog.NewWebElement().ById("ctl00_ctl00_PageContent_btnClose"); } }

        static WebElement lblMessage
        { get { return dialog.NewWebElement().ByXPath(@".//*[@id='ctl00_ctl00_PageContent_DialogContent_RequiredFieldValidator1']//font"); } }

        #endregion UI Web Elements

        #region Properties

        public static bool Opened
        { get
            { return WaitHelper.Try(()=>dialog.NewWebElement()
                .ById("ctl00_ctl00_PageContent_DialogContent_PanelCreateNewTestSet"));         
            }       
        }

        #endregion Properties

        #region Helpers

        static bool IsMessageDisplayed()
        {
            return !WaitHelper.Try(
                () => dialog.NewWebElement()
                    .ById("ctl00_ctl00_PageContent_DialogContent_RequiredFieldValidator1")
                    .ByAttribute(WEBUIautomation.Tags.TagAttributes.Style, "color:Red;display:none;")
                    );
        }

        #endregion Helpers

        #region Actions

        public static void TypeTestSetName(string testSetName)
        {
            txtTestSetName.Text = testSetName;
        }

        public static void ClickOK()
        {
            btnOK.Click();
        }

        public static void ClickClose()
        {
            btnClose.Click();
        }

        public static string GetWarningMessage()
        {
            if (IsMessageDisplayed())
                return lblMessage.Text;
            return string.Empty;
        }

        #endregion Actions

    }
}
