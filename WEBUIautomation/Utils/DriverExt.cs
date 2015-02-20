﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEBUIautomation.Utils
{
   
    //extended IWebDriver interface with FindElementAndWait method
    public interface IWebDriverExt : IWebDriver
    {
        By CurrentFrame { get; set; }
    }

    public static class RemoteWebDriverExt
    {
        private static IWebElement FindElementByLocator(this IWebDriverExt iWebDriverExt, By by)
        {
            WebDriverWait wait = new WebDriverWait(iWebDriverExt, TimeSpan.FromSeconds(20));
            IWebElement element = wait.Until(d =>
            {
                var elements = d.FindElements(by);
                if (elements.Count > 0)
                    return elements[0];
                else
                    return null;
            } );

            //Draw a border around found element
            Highlight(element);

            return element;// iWebDriverExt.FindElement(by); ;
        }

        //FindElement method with an element highlight
        public static IWebElement FindElement(this IWebDriverExt iWebDriverExt, By by, int ms=10)
        {
            var element = Driver.Instance.FindElement(by);
            
            //Draw a border around found element
            Highlight(element, ms);
            
            return element;
        }

        public static IWebElement FindElementAndWait(this IWebDriverExt iWebDriverExt, By by)
        {
            return  FindElementByLocator(iWebDriverExt,by);            
        }

        public static bool IsElementPresent(this IWebDriverExt iWebDriverExt, By by, int seconds)
        {
            DriverWait.Instance.Timeout = TimeSpan.FromSeconds(seconds);
            return FindElementByLocator(iWebDriverExt, by) != null;      
        }

        public static IWebElement FindElementAndWait(this IWebDriverExt iWebDriverExt, By by, int seconds)
        {
            DriverWait.Instance.Timeout = TimeSpan.FromSeconds(seconds);
            return FindElementByLocator(iWebDriverExt, by);
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

        //Highlight a found element
        public static void Highlight(this IWebElement element, int ms = 10)
        {
            try
            {
                var jsDriver = ((IJavaScriptExecutor)Driver.Instance);
                var originalElementBorder = (string)jsDriver.ExecuteScript("return arguments[0].style.border", element);
                jsDriver.ExecuteScript("arguments[0].style.border='3px solid red'; return;", element);
                Driver.Wait(ms/1000);
                jsDriver.ExecuteScript("arguments[0].style.border='" + originalElementBorder + "'; return;", element);
            }
            catch (Exception)
            { 
            }
        }

        //Wait until element is visible
        public static IWebElement WaitForVisible(this IWebDriverExt iWebDriverExt, By by, int timeout = 1)
        {
            var then = DateTime.Now.AddSeconds(timeout);
            for (var now = DateTime.Now; now < then; now = DateTime.Now)
            {
                var eles = iWebDriverExt.FindElements(by);
                if (eles.Count > 0 && eles[0].Displayed)
                    return eles[0];
            }
            throw new ElementNotVisibleException(string.Format("Element ({0}) was not visible after {1} seconds",
                by.ToString(), timeout));
        }

    }

    #region IWebDriverExt instances implementations for some browsers

    //extended FirefoxDriver class with FindElementAndWait method
    public class FirefoxDriverExt : FirefoxDriver, IWebDriverExt
    {
        public FirefoxDriverExt() : base() { }
        public FirefoxDriverExt(FirefoxProfile profile) : base(profile) { }
        public By CurrentFrame { get; set; }
    }

    //extended ChromeDriver class with FindElementAndWait method
    public class ChromeDriverExt : ChromeDriver, IWebDriverExt
    {
        //Constructor inherited from the base class
        public ChromeDriverExt(string path) : base(path) { }
        public By CurrentFrame { get; set; }
    }

    //extended InternetExplorerDriver class with FindElementAndWait method
    public class InternetExplorerDriverExt : InternetExplorerDriver, IWebDriverExt
    {
        //Constructor inherited from the base class
        public InternetExplorerDriverExt(string path) : base(path) { }
        public InternetExplorerDriverExt(string path, InternetExplorerOptions options) : base(path, options) { }
        public By CurrentFrame { get; set; }
    }

    //extended PhantomJSDriver class with FindElementAndWait method
    public class PhantomJSDriverExt : PhantomJSDriver, IWebDriverExt
    {
        //Constructor inherited from the base class
        public PhantomJSDriverExt(string path) : base(path) { }
        public By CurrentFrame { get; set; }
    }

    //extended EventFiringWebDriver class with FindElementAndWait method
    public class EventFiringWebDriverExt : EventFiringWebDriver, IWebDriverExt
    {
        //Constructor inherited from the base class
        public EventFiringWebDriverExt(IWebDriver parentDriver) : base(parentDriver) { }
        public By CurrentFrame { get; set; }
    }

    #endregion

}
