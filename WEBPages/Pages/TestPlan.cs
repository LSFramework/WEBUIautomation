using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBUIautomation;
using WEBUIautomation.Utils;
using System.Windows.Forms;
using System.Threading;

namespace WEBPages.Pages
{
    public class TestPlan
    {

        #region The containers of UI elements

        public static IWebElement Tree
        { get { return Driver.Instance.FindElementAndWait(By.XPath(@".//*[@id='divTestPlanTree']")); } }

        public static IWebElement TreeToolBar
        { get { return Driver.Instance.FindElementAndWait(By.XPath(@".//*[contains(@id,'TestPlanTreeControl_GenericTreeView1_toolbar')]")); } }
        
        #endregion

        #region Test Plan Tree toolbar buttons

        public static IWebElement CreateNewFolderBtn
        { get { return TreeToolBar.SelectItem("New Folder", "a", "title"); } }

        public static IWebElement UploadScriptBtn
        { get { return TreeToolBar.SelectItem("Upload Script", "img", "alt"); } }

        public static IWebElement CreateTestBtn
        { get { return TreeToolBar.SelectItem("New Test", "img", "alt"); } }
        
        public static IWebElement DeleteBtn
        { get { return TreeToolBar.SelectItem("Delete", "img", "alt"); } }
       
        public static IWebElement CopyBtn
        { get { return TreeToolBar.SelectItem("Copy", "img", "alt"); } }

        public static IWebElement CutBtn
        { get { return TreeToolBar.SelectItem("Cut", "img", "alt"); } }

        public static IWebElement PasteBtn
        { get { return TreeToolBar.SelectItem("Paste", "img", "alt"); } }

        public static IWebElement RefreshBtn
        { get { return TreeToolBar.SelectItem("Refresh All", "img", "alt"); } }
        
        #endregion

        #region Popup dialogs

        #region Create New Test Folder Dialog

        public static class CreateNewTestFolderDialog
        {
            public static IWebElement FolderNameTxtBox
            { get { return Driver.Instance.FindElementAndWait(By.XPath(".//*[@id='ctl00_ctl00_PageContent_DialogContent_TxtTestFolderName']")); } }

            public static IWebElement BtnOk
            { get { return Driver.Instance.FindElementAndWait(By.XPath(".//*[@id='ctl00_ctl00_PageContent_DialogActions_btnOK']")); } }

            public static IWebElement BtnClose
            { get { return Driver.Instance.FindElementAndWait(By.XPath(".//*[@id='ctl00_ctl00_PageContent_btnClose']']")); } }            
        }

        #endregion

        #region Create New Test Dialog

        public static class CreateNewTestDialog
        {
            public static IWebElement FolderNameTxtBox
            { get { return Driver.Instance.FindElementAndWait(By.XPath(".//*[@id='ctl00_ctl00_PageContent_DialogContent_txtNewTestName']")); } }

            public static IWebElement BtnOk
            { get { return Driver.Instance.FindElementAndWait(By.XPath(".//*[@id='ctl00_ctl00_PageContent_DialogActions_btnCreateNewOK']")); } }
            
        }

        #endregion

        #region Upload Script Dialog

        public static class UploadScriptDialog
        {

            public static IWebElement ScriptPathTextBox
            { get { return Driver.Instance.FindElementAndWait(By.XPath(@".//*[@id='ctl00_PageContent_RadUpload1TextBox1']")); } }

            public static IWebElement UploadBtn
            { get { return Driver.Instance.FindElementAndWait(By.XPath(@"//*[@id='ctl00_PageContent_SubmitButton']")); } }

            public static IWebElement SelectBtn
            { get { return Driver.Instance.FindElementAndWait(By.XPath(@".//span[contains(@class,'ruFileWrap ruStyled')]")); } }

            public static IWebElement CloseBtn
            { get { return Driver.Instance.FindElementAndWait(By.XPath(@".//*[@id='ctl00_PageContent_btnClose']")); } }


            public static void SendPathToWindow(string path)
            {
                System.Windows.Forms.SendKeys.SendWait(path);
                System.Windows.Forms.SendKeys.SendWait("{ENTER}");
            }
        }

        #endregion

        #endregion

        #region TestPlan Actions/Flows

        public static void CreateNewFolder(string folderName)
        {
            MyPCNavigation.SwitchToDefaultContent();
            MyPCNavigation.TestManagement.Click();
            MyPCNavigation.TestManagement.SelectItem("Test Plan").Click();
            MyPCNavigation.SwitchToMainTab();
            Tree.SelectItem("Subject", "span").Click();
            CreateNewFolderBtn.Click();
            MyPCNavigation.SwitchToDefaultContent();
            MyPCNavigation.SwitchToFrame(@"//iframe[contains(@ng-src,'CreateNewTestFolder.aspx')]");
            CreateNewTestFolderDialog.FolderNameTxtBox.SendKeys(folderName);
            CreateNewTestFolderDialog.BtnOk.Click();
            MyPCNavigation.SwitchToMainTab();
            MyPCNavigation.SwitchToDefaultContent();
        }

        public static void CreateNewTest(string testName)
        {
            MyPCNavigation.SwitchToDefaultContent();
            MyPCNavigation.TestManagement.Click();
            MyPCNavigation.TestManagement.SelectItem("Test Plan").Click();
            MyPCNavigation.SwitchToMainTab();
            Tree.SelectItem("Subject", "span").Click();
            Tree.SelectItem("Tests", "span").Click();
            CreateTestBtn.Click();
            MyPCNavigation.SwitchToDefaultContent();
            MyPCNavigation.SwitchToFrame(@"//iframe[contains(@ng-src,'CreateNewTest.aspx')]");
            CreateNewTestDialog.FolderNameTxtBox.SendKeys(testName);
            CreateNewTestDialog.BtnOk.Click();
            MyPCNavigation.SwitchToMainTab();
            MyPCNavigation.SwitchToDefaultContent();
        }

        public static void UploadScript(string pathToScript)
        {
            MyPCNavigation.SwitchToDefaultContent();
            MyPCNavigation.TestManagement.Click();
            MyPCNavigation.TestManagement.SelectItem("Test Plan").Click();
            MyPCNavigation.SwitchToMainTab();
            Tree.SelectItem("Subject", "span").Click();
            Tree.SelectItem("Tests", "span").Click();
            UploadScriptBtn.Click();
            MyPCNavigation.SwitchToDefaultContent();
            MyPCNavigation.SwitchToFrame(@"//iframe[contains(@ng-src,'UploadScripts.aspx')]");           
            UploadScriptDialog.SelectBtn.Click();
            Thread.Sleep(1000);
            UploadScriptDialog.SendPathToWindow(pathToScript);
            UploadScriptDialog.UploadBtn.Click();
            System.Threading.Thread.Sleep(3000);
            UploadScriptDialog.CloseBtn.Click();
            MyPCNavigation.SwitchToMainTab();
            MyPCNavigation.SwitchToDefaultContent();
        }

        #endregion        
       
    }
}
