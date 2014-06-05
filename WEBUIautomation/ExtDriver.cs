using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace WEBUIautomation
{
    public interface IExtWebDriver : IWebDriver
    {
        IWebElement FindElementAndWait(By by, Int32 seconds);
     }
/*
    public class ExtDriver : IExtWebDriver
    {
        
        public IWebElement FindElementAndWait(By m, Int32 seconds)
        {
            WebDriverWait wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(10));
            var element = wait.Until<IWebElement>(d =>
            {
                var elements = Driver.Instance.FindElements(m);
                if (elements.Count > 0)
                    return elements[0];
                else
                    return null;
            });
            return element;
        }
         
    }
*/
}
