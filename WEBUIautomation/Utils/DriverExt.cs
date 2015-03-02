using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace WEBUIautomation.Utils
{
    public static class WebDriverExt
    {
       
        private static IWebElement FindElementByLocator(this IWebDriverExt iWebDriverExt, By by, int seconds=20)
        {
            Func<IWebDriver, bool> predicate = (x) =>
            {
                try
                {
                    IWebElement elementThatOnlyAppearsOnPostback = iWebDriverExt.FindElement(by);
                    return true;
                }
                catch (NoSuchElementException){return false;}
            };

            WebDriverWait wait = new WebDriverWait(iWebDriverExt, TimeSpan.FromSeconds(seconds));
            wait.Until(driver => ((IJavaScriptExecutor)iWebDriverExt).ExecuteScript("return document.readyState").Equals("complete"));
            wait.Until(predicate);
            wait.Until(ExpectedConditions.ElementIsVisible(by));
            IWebElement element = iWebDriverExt.FindElement(by);
          
            //Draw a border around found element
            element.Highlight();

            return element;
        }


        public static IWebElement FindElementAndWait(this IWebDriverExt iWebDriverExt, By by)
        {
            return  FindElementByLocator(iWebDriverExt, by);            
        }

        public static bool IsElementPresent(this IWebDriverExt iWebDriverExt, By by, int seconds)
        {
            return FindElementByLocator(iWebDriverExt, by, seconds) != null;      
        }

        public static IWebElement FindElementAndWait(this IWebDriverExt iWebDriverExt, By by, int seconds)
        {
            return FindElementByLocator(iWebDriverExt, by, seconds);
        }

        public static IWebDriverExt SwitchToFrame(this IWebDriverExt iWebDriverExt, By by)
        {
            Driver.Wait(1);
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

        


    }

}
