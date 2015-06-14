using WEBPages.Extensions;
using WEBUIautomation.Utils;
using WEBUIautomation.Wait;
using WEBUIautomation.WebElement;

namespace WEBPages.BasePageObject
{
   
    using Locators = ContentLocators.Locators.BaseDialog;

    public abstract class Dialog : FramePageBase
    {
        protected Dialog()
        {
            Url = dialog.Url; 
        }

        protected abstract IWebDriverExt dialog { get; }

        public bool IsMessageDisplayed()
        {
            return ! WaitHelper.Try(
                () => dialog.GetElement()
                    .ById(Locators.requiredFieldValidatorID)
                    .ByAttribute(WEBUIautomation.Tags.TagAttributes.Style, Locators.noMesageStyleValue));
        }

        protected virtual WebElement btnOk
        { get { return dialog.GetElement().ById(Locators.btnOkID); } }

        protected virtual WebElement btnClose
        { get { return dialog.GetElement().ById(Locators.btnClose); } }

        protected virtual WebElement lblMessage
        { get { return dialog.GetElement().ByXPath(Locators.lblMessageXPath); } }
    
    }
}
