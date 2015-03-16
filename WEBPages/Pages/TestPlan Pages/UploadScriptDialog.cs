using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBUIautomation.Utils;

namespace WEBPages.Pages.TestPlan_Pages
{
    #region Upload Script Dialog
    
    public static class UploadScriptDialog
    {
        const string position = @".//iframe[contains(@ng-src,'UploadScripts.aspx')]";

        static IWebDriverExt dialog=Driver.Instance;

        static IWebDriverExt Dialog
        {
            get 
            {
                if (dialog.CurrentFrame != By.XPath(position))
                {
                    dialog.SwitchTo().DefaultContent();
                    dialog.SwitchToFrame(By.XPath(position));
                }

                return dialog;
            }            
        }

        const string txtScriptPath = "ctl00_PageContent_RadUpload1TextBox1";

        const string btnUpload = "ctl00_PageContent_SubmitButton";

        const string btnSelect = @".//span[contains(@class,'ruFileWrap ruStyled')]";

        const string btnClose = "ctl00_PageContent_btnClose";


        static void SendPathToWindow(string path)
        {
            System.Windows.Forms.SendKeys.SendWait(path);
            System.Windows.Forms.SendKeys.SendWait("{ENTER}");
        }


        public static void UploadScript(string pathToScript)
        {
            Dialog.FindElementAndWait(By.XPath(btnSelect)).Click();
            SendPathToWindow(pathToScript);
            Dialog.FindElementAndWait(By.Id(btnUpload)).Click();
        }

        public static void CloseDialog()
        {
            Dialog.FindElementAndWait(By.Id(btnClose)).Click();
        }

    }

    #endregion
}
