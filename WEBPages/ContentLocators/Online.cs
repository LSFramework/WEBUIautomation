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
            public static readonly By FrameLocator = By.XPath(@".//iframe[contains(@ng-src,'Loadtest/RuntimeOperations/RunStart.aspx')]");
            public static readonly string ViewLocator = "Online Screen Run";
            public static readonly string PanelRunFinishedId = "ctl00_PageContent_PanelRunFinished";
            public static readonly string InitRunFormXPath = @".//form[contains(@action,'InitializingRun.aspx')]";
            public static readonly string RunScreenFormXPath = @".//form[contains(@action, 'RunScreen.aspx')]";
            public static readonly string btnFinishedRunClose = "ctl00_PageContent_btnFinishedRunClose";
            public static readonly string hidRunFinished = "ctl00_PageContent_hidRunFinished";
            

        }

    }
}
