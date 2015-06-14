using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEBPages.ContentLocators
{
    public static partial class Locators
    {
        public static class Online
        {
            public static By FrameLocator = By.XPath("RunStart.aspx");
            public static string ViewLocator = "Online Screen Run";
            public static string PanelRunFinishedId = "ctl00_PageContent_PanelRunFinished";



        }

    }
}
