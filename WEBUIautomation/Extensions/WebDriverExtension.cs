using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using WEBUIautomation.Utils;
using WEBUIautomation.Wait;


namespace WEBUIautomation.Extensions
{

    public static partial class Extensions
    {
        public static object ExecuteJavaScript(this IWebDriverExt driver, string javaScript, params object[] args)
        {
            var javaScriptExecutor = (IJavaScriptExecutor)driver;

            return javaScriptExecutor.ExecuteScript(javaScript, args);
        }

        public static void WaitReadyState(this IWebDriverExt driver)
        {
            Func<bool> ready = () => driver.ExecuteJavaScript("return document.readyState").Equals("complete");

            try
            {
                WaitHelper.SpinWait(ready, TimeSpan.FromSeconds(10), driver.WaitProfile.PollingInterval);
            }
            catch { }
        }
               
        
        public static string GetNewWindow(this IWebDriverExt driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            string window = wait.Until<string>
             (d =>
                {   
                    if (driver.WindowHandles.Count < 2)
                         return null;
                    return driver.WindowHandles[1];                    
                }
             );

            return window;
        }

        public static IWebDriverExt SwitchToFrame(this IWebDriverExt driver, By by)
        {
            driver.WaitReadyState();

            if (driver.TryFindElement(by))
            {
                IWebElement frame = driver.FindElement(by); 
                driver.SwitchTo().Frame(frame);
                driver.CurrentFrame = by;
            }
            return driver;
        }

        public static void SwitchToFrame(this IWebDriverExt driver, IWebElement inlineFrame)
        {
            driver.SwitchTo().Frame(inlineFrame);
        }                  
        
        public static void Highlight(this IWebDriverExt driver, IWebElement iWebElement, int ms = 20)
        {
            try
            {
                var originalElementBorder = (string)driver.ExecuteJavaScript("return arguments[0].style.border", iWebElement);
                driver.ExecuteJavaScript("arguments[0].style.border='3px solid red'; return;", iWebElement);
                Thread.Sleep(ms);
                driver.ExecuteJavaScript("arguments[0].style.border='" + originalElementBorder + "'; return;", iWebElement);
            }
            catch (Exception) { }
        }            
        
        public static void DragAndDrop(this IWebDriverExt driver, IWebElement source, IWebElement destination)
        {
            (new Actions(driver))
                .DragAndDrop(source, destination)
                .Build()
                .Perform();
        }

        public static bool TryFindElements(this IWebDriverExt driver, By by, out IEnumerable<IWebElement> collection)
        {
            driver.WaitReadyState();

            return (driver as ISearchContext).TryFindElements(by, out collection, driver.WaitProfile.Timeout, driver.WaitProfile.PollingInterval);            
        }


        //Maximize Browsers window
        public static void BrowserMaximize(this IWebDriverExt driver)
        {
            driver.Manage().Window.Maximize();
        }

        //Set Browsers resolution
        public static void SetBrowserResolution(this IWebDriverExt driver, int width, int height)
        {
            driver.Manage().Window.Position = new Point(0, 0);
            driver.Manage().Window.Size = new Size(width, height);
        }

        //Shutdown Driver
        public static void Shutdown(this IWebDriverExt driver)
        {
            if (driver == null) return;

            Thread.Sleep(1000);
            driver.Quit();
            driver.Dispose();
            driver = null;
        }
    }
}
