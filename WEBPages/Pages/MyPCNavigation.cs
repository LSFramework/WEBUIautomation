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
        const string xPathLogoutBtn = @".//*[@id='MastheadDiv']/div[1]/div[2]/div[7]";
        const string xPathTestMgmt = @"//div[contains(@ng-class, 'selectedLink_TestMgmt')]";
        

        #endregion

        public static IWebElement LogoutBtn
        { get {return Driver.Instance.FindElementAndWait(By.XPath(xPathLogoutBtn)); } }

        public static IWebElement TestManagement
        { get { return Driver.Instance.FindElementAndWait(By.XPath(xPathTestMgmt)); } }

        public static void SwitchToDefaultContent()
        {
            Driver.Instance.SwitchTo().DefaultContent();
            Driver.Wait(2);
        }

        public static void SwitchToMainTab()
        {
            Driver.Instance.SwitchTo().DefaultContent();
            Driver.Instance.SwitchTo().Frame("MainTab");
            Driver.Wait(2);
        }

        public static void SwitchToFrame(string frameLocator)
        {
            Driver.Instance.SwitchTo().Frame(Driver.Instance.FindElementAndWait(By.XPath(frameLocator)));
        }

        public static void SwitchToPopup()
        {
            int before = Driver.Instance.WindowHandles.ToList().Count;

            do
            {
               IList<string> afterPopup = Driver.Instance.WindowHandles.ToList();
            } while (Driver.Instance.WindowHandles.ToList().Count == before);

            Driver.Instance.SwitchTo().Window(Driver.Instance.WindowHandles.Last());
        }
    }
}
