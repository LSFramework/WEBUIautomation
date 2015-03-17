using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBUIautomation;
using WEBUIautomation.Utils;
using System.Drawing;

namespace WEBPages.Pages
{ 
    public class MyPCNavigation:PageBase
    {
        #region Page Locator

        static string position = "MastheadDiv";

       

        static IWebDriverExt mainPage
        {
            get 
            {
                if (driver.CurrentFrame != (By.Id(position)))
                {   
                    driver.SwitchToDefaultContent(); 
                }

                return driver;            
            }
        }

        #endregion Page Locator

        #region Elements Locators



        const string lblUser = @".//*[@id='MastheadDiv']/div[1]/div[2]/div[6]";

        const string lblDomain = @".//*[@id='MastheadDiv']/div[1]/div[2]/div[1]/span[1]";

        const string lblProject = @".//*[@id='MastheadDiv']/div[1]/div[2]/div[1]/span[2]";

        const string LogoutBtn = @".//*[@id='MastheadDiv']/div[1]/div[2]/div[7]";

        const string btnRefresh = @".//div[contains(@ng-click, 'Refresh()')]";

        const string Home = @".//span[contains(@class, 'IconContainer IconHome')]";

        const string TestManagement = @".//div[contains(@ng-class, 'selectedLink_TestMgmt')]";

        const string xPathCloseDLT = @".//div[contains(@class, 'xButtonWrapper')]";

        #endregion //Elements Locators

 //       static IList<IWebElement> projectProperties = mainPage.FindElements(By.XPath(@".//span[@class='ng-binding']")).ToList<IWebElement>();



        #region Page Actions

        public static void SwitchToPopup()
        {
            string popup = driver.NewWindow();
            driver.SwitchTo().Window(popup);
        }



        public static void CloseDLT_Tab()
        {
            mainPage.FindElementAndWait(By.XPath(xPathCloseDLT)).Click();
        }

        public static string GetDomainName()
        {
           return mainPage.FindElementAndWait(By.XPath(lblDomain)).Text;
        }

        public static string GetProjectName()
        {
            return mainPage.FindElementAndWait(By.XPath(lblProject)).Text;
        }

        public static string GetUserLoggedIn()
        {
            return mainPage.FindElementAndWait(By.XPath(lblUser)).Text;
        }

        public static void ClickRefresh()
        {
            mainPage.FindElementAndWait(By.XPath(btnRefresh)).Click();
        }

        public static void ClickMenuItem(string textMenuItem)
        {
            string xPathLocator = @".//*[contains(text(), '" + textMenuItem + "')]";
            IWebElement menuItem = mainPage.FindElementAndWait(By.XPath(xPathLocator));
            (mainPage as IJavaScriptExecutor).ExecuteScript(string.Format("window.scrollTo(0, {0});", menuItem.Location.Y));
            menuItem.Click();
        }
        #endregion //Page Actions
    }   
}
