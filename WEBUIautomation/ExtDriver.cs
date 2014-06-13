using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEBUIautomation
{
    public class ExtDriver
    {
        public interface IWebDriverExt : IWebDriver
        {
            public IWebElement findElementAndWait(By by, int seconds)
            { 
            
            }
        }
    }
}
