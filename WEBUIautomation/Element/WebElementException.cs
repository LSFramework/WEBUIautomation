using System;

namespace WEBUIautomation.WebElement
{
    public class WebElementNotFoundException : Exception
    {
        public WebElementNotFoundException(string message)
            : base(message)
        {
        }
    }
}
