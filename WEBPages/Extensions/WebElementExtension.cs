using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBUIautomation;
using WEBUIautomation;
using WEBUIautomation.Tags;
using WEBUIautomation.WebElement;

namespace WEBPages.Extensions
{
    public static class WebElementExtension
    {
        public static WebElement SelectItem(this WebElement webElement, string listItemText)
        {
            return new WebElement().ByTagName(TagNames.Li).ByText(listItemText);
        }
    }
}
