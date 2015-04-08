using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBUIautomation.Utils;

namespace WEBUIautomation.Extensions
{
    public static partial class Extensions
    {
        //Highlight a found element
        public static void Highlight(this IWebElement iWebElement, int ms = 20)
        {
            try
            {
                var jsDriver = ((IJavaScriptExecutor)Driver.Instance);
                var originalElementBorder = (string)jsDriver.ExecuteScript("return arguments[0].style.border", iWebElement);
                jsDriver.ExecuteScript("arguments[0].style.border='3px solid red'; return;", iWebElement);
                Driver.Wait(ms / 1000);
                jsDriver.ExecuteScript("arguments[0].style.border='" + originalElementBorder + "'; return;", iWebElement);
            }
            catch (Exception)
            {
            }
        }

        public static bool IsElementPresent(this IWebElement iWebElement, By by)
        {
            return Driver.Instance.IsElementPresent(by);
        }

        public static IWebElement FindElementAndWait(this IWebElement iWebElement, By by)
        {
            return Driver.Instance.FindElementAndWait(by);
        }

        public static IWebElement SelectItem(this IWebElement iWebElement, string itemLocator)
        {
            return Driver.Instance.FindElementAndWait(By.XPath("//li[contains(text(), '" + itemLocator + "')]"));
        }

        public static IWebElement SelectItem(this IWebElement iWebElement, string itemLocator, string tagName)
        {
            IWebElement item = Driver.Instance.FindElementAndWait(By.XPath(@"//" + tagName + "[contains(text(), '" + itemLocator + "')]"));
            (Driver.Instance as IJavaScriptExecutor).ExecuteScript(string.Format("window.scrollTo(0, {0});", item.Location.Y));
            return item;
        }

        public static IWebElement SelectItem(this IWebElement iWebElement, string itemLocator, string tagName, string propertyName)
        {
            return Driver.Instance.FindElementAndWait(By.XPath(@"//" + tagName + "[contains(@" + propertyName + ",'" + itemLocator + "')]"));
        }

        /// <summary>
        /// Performs click action on UI element that contains listItemText's text in the tag tagName
        /// </summary>
        /// <param name="iWebElement"></param>
        /// <param name="listItemText"></param>
        /// <param name="tagName"></param>
        public static void ClickItem(this IWebElement iWebElement, string itemLocator, string tagName)
        {
            Driver.Instance.FindElementAndWait(By.XPath(@"//" + tagName + "[contains(text(), '" + itemLocator + "')]")).Click();
        }

    }
}
