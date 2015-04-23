using OpenQA.Selenium;
using WEBUIautomation.Utils;
using WEBUIautomation.WebElement;
using WEBPages.ContentLocators;
using WEBUIautomation.Wait;

namespace WEBPages.Extensions
{
    public static class DriverExtension
    {
        public static WebElement FindTreeItemByText(this IWebDriverExt driver, string text)
        {
            string xPathItemLocator = string.Format(".//span[@class='rtIn'][text()='{0}']", text);
            return driver.NewWebElement().ByXPath(xPathItemLocator);
        }

        public static WebElement NewWebElement(this IWebDriverExt driver)
        {
            return new WebElement();
        }      

        public static void TryExpandTreeFolder(this IWebDriverExt driver, string folderName)
        {
            WebElement currentFolder = driver.FindTreeItemByText(folderName);    

            string collapsed = @"../span[@class='rtPlus']";

            WaitHelper.Try(()=>currentFolder.FindRelative().ByXPath(collapsed).Click());
        }

        public static IWebDriverExt SwitchToDefaultContent(this IWebDriverExt driver)
        {
            driver.SwitchTo().DefaultContent();
            driver.CurrentFrame = By.Id(Locators.MainHeadPage.FrameLocatorID);
            return driver;
        }


    }
}
