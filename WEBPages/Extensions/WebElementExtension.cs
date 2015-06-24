using WEBUIautomation.Tags;
using WEBUIautomation.WebElement;

namespace WEBPages.Extensions
{
    public static class WebElementExtension
    {
        public static WebElement SelectListItem(this WebElement webElement, string listItemText)
        {
            return webElement.FindRelative().ByTagName(TagNames.Li).ByText(listItemText);
        }
        
        public static WebElement GetParent(this WebElement webElement)
        {
            return webElement.FindRelative().ByXPath("..");        
        }
    }
}
