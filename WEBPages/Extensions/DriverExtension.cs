using OpenQA.Selenium;
using WEBUIautomation.Utils;
using WEBUIautomation.WebElement;
using WEBPages.ContentLocators;
using WEBUIautomation.Wait;
using WEBUIautomation.Extensions;
using System;
using TestStack.White;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems;



namespace WEBPages.Extensions
{
    public static class DriverExtension
    {               

        public static WebElement FindTreeItemByName(this IWebDriverExt driver, string text)
        {
            string xPathItemLocator = string.Format(".//li/div/span[@class='rtIn'][text()='{0}']", text);

            return driver.GetElement().ByXPath(xPathItemLocator).ReturnFound();               
        }

        public static WebElement GetElement(this IWebDriverExt driver)
        {
            return new WebElement();
        }

        public static bool isAlertPresent(this IWebDriverExt driver)
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }   
            catch (NoAlertPresentException)
            {
                return false;
            }  
        }

        public static void TryExpandTreeFolder(this IWebDriverExt driver, string folderName)
        {
            string collapsed = @".//span[@class='rtPlus']";

            WebElement currentFolder = driver.FindTreeItemByName(folderName);

            WebElement parentElement = currentFolder.GetParent();

            WaitHelper.Try(() => parentElement.FindRelative().ByXPath(collapsed).Click());
        }

       

        public static IWebDriverExt SwitchToDefaultContent(this IWebDriverExt driver)
        {
            driver.WaitReadyState();

            driver.SwitchTo().DefaultContent();
            driver.CurrentFrame = By.Id(Locators.MainHeadPage.FrameLocatorID);

            driver.WaitReadyState();
            
            return driver;
        }

        /// <summary>
        /// Returns name of a selected folder within tree
        /// </summary>
        /// <param name="driver"></param>
        /// <returns></returns>
        public static string FindSelectedFolder(this IWebDriverExt driver)
        {
            try
            {
                //return new WebElement().ByXPath(Locators.TestPlanPage.selectedFolderXPath).NodeName;
                return new WebElement().ByClass(Locators.TestPlanPage.selectedItemAttributeValue, false).FindRelative().ByTagName(WEBUIautomation.Tags.TagNames.Span).ByClass("rtIn").Text;
            }
            catch
            {
                return string.Empty;
            }
        }


        private static Object locker = new Object();
        public static void SendStringToWinDialog(this IWebDriverExt driver, string stringToSend)
        {
            if (Object.ReferenceEquals(driver.GetType(), typeof(FirefoxDriverExt)))
            {
                SendStringToOpenFileDialogUsingWhite(driver ,stringToSend);
                return;
            }

            lock (locker)
            {
                WaitHelper.Wait(driver.WaitProfile.PollingInterval.Milliseconds*2);
                System.Windows.Forms.SendKeys.SendWait(stringToSend);
                System.Windows.Forms.SendKeys.SendWait("~");
            }
        }

        private static void SendStringToOpenFileDialogUsingWhite(IWebDriverExt driver, string stringToSend)
        {
            try
            {

                var app = TestStack.White.Application.Attach((driver as FirefoxDriverExt).PID);
                var windows = app.GetWindows();

                var openFileDialog = windows[1];

                TextBox fileNameField = openFileDialog.Get<TextBox>(SearchCriteria.ByAutomationId("1148"));
                fileNameField.Text = stringToSend;

                Button openButton = openFileDialog.Get<Button>(SearchCriteria.ByAutomationId("1"));
                openButton.Click();
            }
            catch { }
        }

    }
}
