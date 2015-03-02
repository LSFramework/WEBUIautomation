using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBUIautomation;
using WEBUIautomation.Utils;

namespace WEBPages.Pages
{
    public class MyPCNavigation
    {
        #region xPath constatnts

        const string xPathHome = @".//span[contains(@class, 'IconContainer IconHome')]";
        const string xPathLogoutBtn = @".//*[@id='MastheadDiv']/div[1]/div[2]/div[7]";
        const string xPathTestMgmt = @".//*[@id='MastheadDiv']/div[3]/div/div[2]/span[1]";
        const string xPathCloseDLT = @".//div[contains(@class, 'xButtonWrapper')]";

        #endregion

        static string position = "MastheadDiv";

        static IWebDriverExt driver = Driver.Instance;

        static IWebDriverExt mainPage
        {
            get {
                if (driver.CurrentFrame != (By.Id(position)))
                { 
                    driver.SwitchToDefaultContent(); 
                }
                return driver;            
            }
        }

        public static IWebElement LogoutBtn
        { get { return mainPage.FindElementAndWait(By.XPath(xPathLogoutBtn)); } }

        public static IWebElement btnRefresh
        { get { return mainPage.FindElementAndWait(By.XPath(".//div[contains(@ng-click, 'Refresh()')]")); } }

        public static IWebElement Home
        { get { return mainPage.FindElementAndWait(By.XPath(xPathHome)); } }

        public static IWebElement TestManagement
        { get { return mainPage.FindElementAndWait(By.XPath(xPathTestMgmt)); } }

        

        public static void SwitchToPopup()
        {
            int before = driver.WindowHandles.ToList().Count;

            do { IList<string> afterPopup = driver.WindowHandles.ToList(); }
            while (driver.WindowHandles.ToList().Count == before);

            driver.SwitchTo().Window(Driver.Instance.WindowHandles.Last());
        }

        public static void CloseDLT_Tab()
        {
            mainPage.FindElementAndWait(By.XPath(xPathCloseDLT)).Click();
        }
    }
    
}
