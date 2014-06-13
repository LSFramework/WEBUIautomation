using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEBUIautomation
{
    public class RequirementsPage
    {
        [FindsBy(How = How.XPath, Using = "//*")]
        private IWebElement userName;

        public static void GoTo()
        {
            PageFactory.InitElements(Driver.Instance, (new RequirementsPage()));
        }
    }
}
