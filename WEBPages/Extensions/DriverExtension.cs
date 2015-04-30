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
            string collapsed = @"span[@class='rtPlus']";

            WebElement currentFolder = driver.FindTreeItemByText(folderName);

            WebElement parentElement = currentFolder.FindRelative().ByXPath("..");

            WaitHelper.Try(() => parentElement.FindRelative().ByXPath(collapsed).Click());
        }

        public static IWebDriverExt SwitchToDefaultContent(this IWebDriverExt driver)
        {
            driver.SwitchTo().DefaultContent();
            driver.CurrentFrame = By.Id(Locators.MainHeadPage.FrameLocatorID);
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
                return new WebElement().ByXPath(Locators.TestPlanPage.selectedFolderXPath).Text;
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}
