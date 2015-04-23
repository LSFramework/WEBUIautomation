using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WEBUIautomation.Utils;

namespace WEBPages.Pages
{
    public class ALMainPage:DriverContainer
    {
        const string MyPCLink = @"//a[text()='My Performance Center']";

        public MyPCLoginPage GoToMyPC(string MyPCUrl)
        {                    
            driver.Navigate().GoToUrl(MyPCUrl);
            return new MyPCLoginPage();
        }
    }
}
