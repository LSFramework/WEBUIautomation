using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBPages.Extensions;
using WEBUIautomation.Utils;

namespace WEBPages.BasePageObject
{
    using WEBUIautomation.Wait;
    using WEBUIautomation.WebElement;
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
                () => dialog.NewWebElement()
                    .ById(Locators.requiredFieldValidatorID)
                    .ByAttribute(WEBUIautomation.Tags.TagAttributes.Style, Locators.noMesaageStyleValue));
        }

        protected virtual WebElement btnOk
        { get { return dialog.NewWebElement().ById(Locators.btnOkID); } }

        protected virtual WebElement btnClose
        { get { return dialog.NewWebElement().ById(Locators.btnClose); } }

        protected virtual WebElement lblMessage
        { get { return dialog.NewWebElement().ByXPath(Locators.lblMessageXPath); } }
    
    }
}
