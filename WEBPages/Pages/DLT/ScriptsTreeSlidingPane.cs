using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBUIautomation.Utils;


namespace WEBPages.Pages
{
    partial class DesignLoadTest
    {
        public partial class Workload
        {
            public class ScriptsTreeSlidingPane
            {
                #region Private content
                
                static IWebElement ScriptsTree
                { get { return WorkloadFrame.FindElementAndWait(By.Id("ctl00_PageContent_TreeSlidingPane")); } }

                static IWebElement btnCloseTree
                { get { return WorkloadFrame.FindElementAndWait(By.Id("SelectScripts")); } }
                public static void SelectScript(string scriptName, string scriptFolder)
                {
                    Actions action = new Actions(WorkloadFrame);
                    action.MoveToElement(ScriptsTree.SelectItem("Subject", "span")).DoubleClick().Build().Perform();
                    action.MoveToElement(ScriptsTree.SelectItem(scriptFolder, "span")).DoubleClick().Build().Perform();
                    action.MoveToElement(ScriptsTree.SelectItem(scriptName, "span")).DoubleClick().Build().Perform();
                }

                public static void CloseScriptsTree()
                {
                    btnCloseTree.Click();                
                }
                #endregion
            }
        }
    }
}
