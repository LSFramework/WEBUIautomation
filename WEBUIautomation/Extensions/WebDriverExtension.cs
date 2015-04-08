using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;
using WEBUIautomation.Utils;
using WEBUIautomation.Wait;


namespace WEBUIautomation.Extensions
{
    using WebElement = WEBUIautomation.WebElement.WebElement;

    public static partial class Extensions
    {
        public static object ExecuteJavaScript(this IWebDriverExt iWebDriverExt, string javaScript, params object[] args)
        {
            var javaScriptExecutor = (IJavaScriptExecutor)iWebDriverExt;

            return javaScriptExecutor.ExecuteScript(javaScript, args);
        }

        public static void WaitReadyState(this IWebDriverExt iWebDriverExt)
        {

            var ready = new Func<bool>(() => (bool)ExecuteJavaScript(iWebDriverExt, "return document.readyState == 'complete'"));

            WaitHelper.SpinWait(ready, TimeSpan.FromSeconds(60), TimeSpan.FromMilliseconds(100));
        }

        public static void WaitScript(this IWebDriverExt iWebDriverExt)
        {
            var ready = new Func<bool>(() => (bool)ExecuteJavaScript(iWebDriverExt, "return (typeof($) === 'undefined') ? true : !$.active;"));

            WaitHelper.SpinWait(ready, TimeSpan.FromSeconds(60), TimeSpan.FromMilliseconds(100));
        }
        
        public static string NewWindow(this IWebDriverExt driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            string window = wait.Until<string>
             (d =>
                {
                    Thread.Sleep(wait.PollingInterval);

                    if ( driver.WindowHandles.Count > 1)
                        return driver.WindowHandles[1];
                    else return null;
                }
             );

            return window;
        }

        public static IWebDriverExt SwitchToDefaultContent(this IWebDriverExt iWebDriverExt)
        {
            iWebDriverExt.SwitchTo().DefaultContent();
            iWebDriverExt.CurrentFrame = By.Id("MastheadDiv");
            return iWebDriverExt;
        }

        public static IWebDriverExt SwitchToFrame(this IWebDriverExt iWebDriverExt, By by)
        {
            iWebDriverExt.WaitScript();
            iWebDriverExt.WaitReadyState();

            IWebElement frame = iWebDriverExt.NewWebElement().ByCriteria(by).Element();

            iWebDriverExt.SwitchTo().Frame(frame);
            iWebDriverExt.CurrentFrame = by;

            return iWebDriverExt;
        }

        public static void SwitchToFrame(this IWebDriverExt iWebDriverExt, IWebElement inlineFrame)
        {
            iWebDriverExt.SwitchTo().Frame(inlineFrame);
        }

        public static void GoToFrame(this IWebDriverExt iWebDriverExt, string tag, string attribute, string frameLocator)
        {
            IList<IWebElement> frames = iWebDriverExt.FindElements(By.TagName(tag));
            foreach (IWebElement frame in frames)
                if (frame.GetAttribute(attribute).Contains(frameLocator))
                {
                    iWebDriverExt.SwitchTo().Frame(frame);
                    break;
                }
        }
        
        private static IWebElement FindElementByLocator(this IWebDriverExt iWebDriverExt, By by, int seconds = 10)
        {
            DefaultWait<IWebDriverExt> wait = new DefaultWait<IWebDriverExt>(iWebDriverExt);
            wait.Timeout = TimeSpan.FromSeconds(seconds);
            wait.PollingInterval = TimeSpan.FromMilliseconds(100);
            wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException), typeof(NoSuchElementException));

            iWebDriverExt.WaitReadyState();
            iWebDriverExt.WaitScript();

            var element = wait.Until<IWebElement>
                (driver =>
                {
                    Thread.Sleep(wait.PollingInterval);

                        var elements = iWebDriverExt.FindElements(by);

                        if (elements.Count > 0)
                            return elements[0];
                        else return null;
                   
                }
                );

            ////Draw a border around found element
            iWebDriverExt.Highlight(element);

            return element;
        }

        //Highlight a found element
        public static void Highlight(this IWebDriverExt driver, IWebElement iWebElement, int ms = 20)
        {
            try
            {
                var jsDriver = ((IJavaScriptExecutor)driver);
                var originalElementBorder = (string)jsDriver.ExecuteScript("return arguments[0].style.border", iWebElement);
                jsDriver.ExecuteScript("arguments[0].style.border='3px solid red'; return;", iWebElement);
                Driver.Wait(ms / 1000);
                jsDriver.ExecuteScript("arguments[0].style.border='" + originalElementBorder + "'; return;", iWebElement);
            }
            catch (Exception) { }
        }

        public static IWebElement FindElementAndWait(this IWebDriverExt iWebDriverExt, By by)
        {
                return FindElementByLocator(iWebDriverExt, by);
        }

        public static bool IsElementPresent(this IWebDriverExt iWebDriverExt, By by)
        {
            iWebDriverExt.WaitScript();
            iWebDriverExt.WaitReadyState();

            try
            {
                var elements = iWebDriverExt.FindElements(by);

                if (elements.Count > 0)
                    return true;

                return false;
            }
            catch (Exception)
            {
                return false;
            }            
        }

        public static IWebElement FindElementAndWait(this IWebDriverExt iWebDriverExt, By by, int seconds)
        {
            return FindElementByLocator(iWebDriverExt, by, seconds);
        }
        
        public static IWebElement SelectListItem(this IWebDriverExt iWebDriverExt, string itemLocator)
        {
            return iWebDriverExt.FindElementAndWait(By.XPath("//li[contains(text(), '" + itemLocator + "')]"));
        }

        public static void  DragAndDrop(this IWebDriverExt iWebDriverExt, IWebElement source, IWebElement destination)
        {
            (new Actions(iWebDriverExt))
                .DragAndDrop(source, destination)
                .Build()
                .Perform();
        }
              
        public static WebElement NewWebElement(this IWebDriverExt iWebDriverExt)
        {
            return new WebElement();
        }

        public static void ScrollToElement(this IWebDriverExt iWebDriverExt, IWebElement element)
        {
            (iWebDriverExt as IJavaScriptExecutor).ExecuteScript(string.Format("window.scrollTo(0, {0});", element.Location.Y));
        }

        public static WebElement FindFolder(this IWebDriverExt iWebDriverExt, string folderName)
        {
            return iWebDriverExt.NewWebElement()
                .ByXPath(@".//img[contains(@src, 'folder')]/following-sibling::span[contains(text(), '" + folderName + "')]");
            
        }

        public static WebElement FindTestSet(this IWebDriverExt iWebDriverExt, string testSetName)
        {
            return iWebDriverExt.NewWebElement()
                .ByXPath(@".//img[contains(@src, 'test-set')]/following-sibling::span[contains(text(), '" + testSetName + "')]");
         
        }

        public static bool TryExpandTreeFolder(this IWebDriverExt iWebDriverExt, string folderName)
        {
            By expanded = By.XPath(@".//img[contains(@src, 'folder')]/following-sibling::span[contains(text(), '"
                + folderName + "')]/../span[@class='rtMinus']");

            By collapsed = By.XPath(@".//img[contains(@src, 'folder')]/following-sibling::span[contains(text(), '"
                + folderName + "')]/../span[@class='rtPlus']");


            if (iWebDriverExt.IsElementPresent(expanded)) return true;           
           
            return WaitHelper.Try( 
                () => iWebDriverExt.NewWebElement().ByCriteria(collapsed).Click()
              );
        }
         
        /// <summary>
        /// Tries find elements by locator without any additional wait.
        /// </summary>
        /// <param name="driver">WebDriver instance</param>
        /// <param name="by">A mechanism by which to find elements</param>
        /// <param name="collection">Out collection of found elements</param>
        /// <param name="e">exception container</param>
        /// <returns>True if an element was found, otherwise false</returns>
        public static bool TryFindElements(this IWebDriverExt iWebDriverExt, By by, out IEnumerable<IWebElement> collection, out Exception exception)
        {
            exception = null;
            collection = new List<IWebElement>() as IEnumerable<IWebElement>;

            iWebDriverExt.WaitScript();
            iWebDriverExt.WaitReadyState();

            try
            {
               var elements = iWebDriverExt.FindElements(by);

               if (elements.Count > 0)
               {
                   collection = elements as IEnumerable<IWebElement>;
                   return true;
               }
               return false;
            }
            catch(Exception e)
            {
                exception = e;
                Console.WriteLine(e);
                return false;
            }
        }
        
    }
}
