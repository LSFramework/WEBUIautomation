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
   public class AssignTestDialog
    {
       static string position = @".//iframe[contains(@ng-src,'AssignTestToTestSet.aspx')]";
       static IWebDriverExt driver = Driver.Instance;

       static IWebDriverExt assignTestDialog
        {
            get
            {
                if (driver.CurrentFrame != By.XPath(position))
                {
                    driver.SwitchToDefaultContent();
                    driver.SwitchToFrame(By.XPath(position));
                }
                return driver;
            }
        }


       public static IWebElement btnOk
       { get { return assignTestDialog.FindElementAndWait(By.Id("ctl00_ctl00_PageContent_DialogActions_btnOK")); } }

       public static IWebElement ComboTreeInput
       { get { return assignTestDialog.FindElementAndWait(By.Id("ctl00_ctl00_PageContent_DialogContent_TestPlanTree_ComboTree_Input")); } }

       static IWebElement ScriptsTree
       { get { return assignTestDialog.FindElementAndWait(By.Id("ctl00_ctl00_PageContent_DialogContent_TestPlanTree_ComboTree_i0_TreeInCombo")); } }

       public static void SelectTest(string testName, string testFolder)
       {
           Actions action = new Actions(assignTestDialog);
           action.MoveToElement(ScriptsTree.SelectItem("Subject", "span")).DoubleClick().Build().Perform();
           action.MoveToElement(ScriptsTree.SelectItem(testFolder, "span")).DoubleClick().Build().Perform();
           action.MoveToElement(ScriptsTree.SelectItem(testName, "span")).DoubleClick().Build().Perform();
       }
    }
}
