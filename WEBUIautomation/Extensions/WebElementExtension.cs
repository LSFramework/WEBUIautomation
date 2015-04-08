using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEBUIautomation.Extensions
{
    using WebElement = WEBUIautomation.WebElement.WebElement;

    public static partial class Extensions
    {
         public static WebElement SelectItem(this WebElement iWebElement, string listItemText)
        {
            return new WebElement().ByTagName(Tags.TagNames.Li).ByText(listItemText);              
        }
    }
}
