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

        //public static WebElement FindTreeItemByName(this WebElement tree, string treeItemName)
        //{
        //    string xpath = string.Format(".//span[@class='rtIn'][text()='{0}']", treeItemName);

        //    return tree.FindRelative().ByXPath(xpath);
        //}

        public static WebElement GetParent(this WebElement webElement)
        {
            return webElement.FindRelative().ByXPath("..");        
        }
    }
}
