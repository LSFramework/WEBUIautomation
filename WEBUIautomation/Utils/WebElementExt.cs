using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEBUIautomation.Utils
{
    /// <summary>
    /// Extends functionality of IWebElement
    /// </summary>
    public static class WebElementExt
    {
        //Highlight a found element
        public static void Highlight(this IWebElement element, int ms = 20)
        {
            try
            {
                var jsDriver = ((IJavaScriptExecutor)Driver.Instance);
                var originalElementBorder = (string)jsDriver.ExecuteScript("return arguments[0].style.border", element);
                jsDriver.ExecuteScript("arguments[0].style.border='3px solid red'; return;", element);
                Driver.Wait(ms / 1000);
                jsDriver.ExecuteScript("arguments[0].style.border='" + originalElementBorder + "'; return;", element);
            }
            catch (Exception)
            {
            }
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
            return Driver.Instance.FindElementAndWait(By.XPath(@"//" + tagName + "[contains(text(), '" + itemLocator + "')]"));
        }

        public static IWebElement SelectItem(this IWebElement iWebElement, string itemLocator, string tagName, string propertyName)
        {
            return Driver.Instance.FindElementAndWait(By.XPath(@"//" + tagName + "[contains(@" + propertyName + ",'" + itemLocator + "')]"));
        }
    }
}
