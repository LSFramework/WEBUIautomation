﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBUIautomation.Utils;
using WEBUIautomation.Extensions;

namespace WEBPages.Pages.TestPlan.ModalDialogues
{
    #region Upload Script dialog
    
    //public class UploadScriptDialog:DriverContainer
    //{
    //    const string viewLocator = "Upload Script Dialog";
    //    const string frameLocator = @".//iframe[contains(@ng-src,'UploadScripts.aspx')]";

    //    static IWebDriverExt Dialog
    //    {
    //        get 
    //        {
    //            if (! IsDriverOnTheView(By.XPath(frameLocator),viewLocator))
    //            {
    //                driver.SwitchTo().DefaultContent();
    //                driver.SwitchToFrame(By.XPath(frameLocator));
    //                driver.CurrentView = viewLocator;
    //            }

    //            return driver;
    //        }            
    //    }

        

    //    const string txtScriptPath = "ctl00_PageContent_RadUpload1TextBox1";

    //    const string btnUpload = "ctl00_PageContent_SubmitButton";

    //    const string btnSelect = @".//span[contains(@class,'ruFileWrap ruStyled')]";

    //    const string btnClose = "ctl00_PageContent_btnClose";


    //    static void SendPathToWindow(string path)
    //    {
    //        System.Windows.Forms.SendKeys.SendWait(path);
    //        System.Windows.Forms.SendKeys.SendWait("{ENTER}");
    //    }


    //    public static void UploadScript(string pathToScript)
    //    {
    //        Dialog.FindElementAndWait(By.XPath(btnSelect)).Click();
    //        SendPathToWindow(pathToScript);
    //        Dialog.FindElementAndWait(By.Id(btnUpload)).Click();
    //    }

    //    public static void CloseDialog()
    //    {
    //        Dialog.FindElementAndWait(By.Id(btnClose)).Click();
    //    }

    //}

    #endregion
}
