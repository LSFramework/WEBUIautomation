using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace WEBUIautomation.Utils
{
    public static class WebDriverExt
    {
        public static string NewWindow(this IWebDriverExt iWebDriverExt)
        {
            System.Threading.Thread.Sleep(200);

            WebDriverWait wait=new WebDriverWait(iWebDriverExt, TimeSpan.FromSeconds(10));
            string window=wait.Until<string>
                (driver =>
                    {
                        var sessions=iWebDriverExt.WindowHandles;
                        if (sessions.Count > 1)
                            return sessions[1];
                        else return null;
                    }
                 );

            return window;
        }

        private static IWebElement FindElementByLocator(this IWebDriverExt iWebDriverExt, By by, int seconds=10)
        {
            System.Threading.Thread.Sleep(200);

            //DefaultWait<IWebDriverExt> waitUntillPageLoaded = new DefaultWait<IWebDriverExt>(iWebDriverExt);
            //waitUntillPageLoaded.Timeout=TimeSpan.FromSeconds(seconds);
            //waitUntillPageLoaded.PollingInterval = TimeSpan.FromMilliseconds(100);
            //waitUntillPageLoaded.

            DefaultWait<IWebDriverExt> wait = new DefaultWait<IWebDriverExt>(iWebDriverExt);
            wait.Timeout = TimeSpan.FromSeconds(seconds);
            wait.PollingInterval = TimeSpan.FromMilliseconds(100);
            wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException), typeof(NoSuchElementException));
            wait.Until(driver => ((IJavaScriptExecutor)iWebDriverExt).ExecuteScript("return document.readyState").Equals("complete"));
            var element = wait.Until<IWebElement>
                (driver =>
                    {
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
            return  FindElementByLocator(iWebDriverExt, by);
        }

        public static bool IsElementPresent(this IWebDriverExt iWebDriverExt, By by, int seconds)
        {            
            try
            {
                IWebElement element = iWebDriverExt.FindElement(by);
                return true;
            }
            catch (NoSuchElementException) 
            { 
                return false; 
            }
        }

        public static IWebElement FindElementAndWait(this IWebDriverExt iWebDriverExt, By by, int seconds)
        {
            return FindElementByLocator(iWebDriverExt, by, seconds);
        }

        public static IWebDriverExt SwitchToFrame(this IWebDriverExt iWebDriverExt, By by)
        {
            //Driver.Wait(1);
            IWebElement frame = iWebDriverExt.FindElementAndWait(by);
            iWebDriverExt.SwitchTo().Frame(frame);
            iWebDriverExt.CurrentFrame = by;             
            return iWebDriverExt;
        }

        public static IWebDriverExt SwitchToDefaultContent(this IWebDriverExt iWebDriverExt)
        {
            iWebDriverExt.SwitchTo().DefaultContent();
            iWebDriverExt.CurrentFrame = By.Id("MastheadDiv");
            return iWebDriverExt;
        }

        public static void GoToFrame(this IWebDriverExt iWebDriverExt,string tag, string attribute, string frameLocator)
        {
            IList<IWebElement> frames = iWebDriverExt.FindElements(By.TagName(tag));
            foreach (IWebElement frame in frames)
                if (frame.GetAttribute(attribute).Contains(frameLocator))
                {
                    iWebDriverExt.SwitchTo().Frame(frame);
                    break;
                }           
        }

        public static IWebElement SelectListItem(this IWebDriverExt iWebDriverExt, string itemLocator)
        {
            return iWebDriverExt.FindElementAndWait(By.XPath("//li[contains(text(), '" + itemLocator + "')]"));
        }
    }

}
