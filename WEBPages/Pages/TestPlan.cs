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
using OpenQA.Selenium.Interactions;

namespace WEBPages.Pages
{
    public class TestPlan
    {
        const string position="MainTab";
        static IWebDriverExt _mainTab = Driver.Instance;

        static IWebDriverExt mainTab
        {
            get
            {
                if (_mainTab.CurrentFrame != By.Id(position))
                {
                    _mainTab.SwitchTo().DefaultContent();
                    MyPCNavigation.TestManagement.Click();
                    MyPCNavigation.TestManagement.SelectItem("Test Plan").Click();
                    _mainTab = Driver.Instance.SwitchToFrame(By.Id(position));
                }
                return _mainTab;
            }
        }
        
        #region The containers of UI elements

        public static IWebElement Tree
        { get { return mainTab.FindElementAndWait(By.Id("divTestPlanTree"));} }
        
        #endregion

        public static IWebElement txtFindNode
        { get {return Tree.FindElementAndWait(By.Id("ctl00_PageContent_WebPartManager1_wp2108003362_5646e8c3_cc63_4bc6_9810_7580ae3300e4_TestPlanTreeControl_GenericTreeView1_RadTextBox1")); } }

        #region Test Plan Tree toolbar buttons

        public static IWebElement CreateNewFolderBtn
        { get { return Tree.SelectItem("New Folder", "a", "title"); } }

        public static IWebElement UploadScriptBtn
        { get { return Tree.SelectItem("Upload Script", "img", "alt"); } }

        public static IWebElement CreateTestBtn
        { get { return Tree.SelectItem("New Test", "img", "alt"); } }
        
        public static IWebElement DeleteBtn
        { get { return Tree.SelectItem("Delete", "img", "alt"); } }
       
        public static IWebElement CopyBtn
        { get { return Tree.SelectItem("Copy", "img", "alt"); } }

        public static IWebElement CutBtn
        { get { return Tree.SelectItem("Cut", "img", "alt"); } }

        public static IWebElement PasteBtn
        { get { return Tree.SelectItem("Paste", "img", "alt"); } }

        public static IWebElement RefreshBtn
        { get { return Tree.SelectItem("Refresh All", "img", "alt"); } }
        
        #endregion

        #region Popup dialogs

        #region Create New Test Folder Dialog

        public static class CreateNewTestFolderDialog
        {
            public static IWebElement FolderNameTxtBox
            { get { return Driver.Instance.FindElementAndWait(By.Id("ctl00_ctl00_PageContent_DialogContent_TxtTestFolderName")); } }

            public static IWebElement BtnOk
            { get { return Driver.Instance.FindElementAndWait(By.Id("ctl00_ctl00_PageContent_DialogActions_btnOK")); } }

            public static IWebElement BtnClose
            { get { return Driver.Instance.FindElementAndWait(By.Id("ctl00_ctl00_PageContent_btnClose")); } }            
        }

        #endregion

        #region Create New Test Dialog

        public static class CreateNewTestDialog
        {
            public static IWebElement txtNewTestName
            { get { return Driver.Instance.FindElementAndWait(By.Id("ctl00_ctl00_PageContent_DialogContent_txtNewTestName")); } }

            public static IWebElement TestSetTree_ComboTree
            { get { return Driver.Instance.FindElementAndWait(By.Id("ctl00_ctl00_PageContent_DialogContent_TestSetTree_ComboTree")); } }
                        
            public static IWebElement btnCreateNewOK
            { get { return Driver.Instance.FindElementAndWait(By.Id("ctl00_ctl00_PageContent_DialogActions_btnCreateNewOK")); } }
           
            public static IWebElement btnClose
            { get { return Driver.Instance.FindElementAndWait(By.Id("ctl00_ctl00_PageContent_btnClose")); } }
            
            public static IWebElement btnHelp
            { get { return Driver.Instance.FindElementAndWait(By.Id("ctl00_ctl00_PageContent_btnHelp")); } }
                                                                     
        }

        #endregion

        #region Upload Script Dialog

        public static class UploadScriptDialog
        {

            public static IWebElement ScriptPathTextBox
            { get { return Driver.Instance.FindElementAndWait(By.Id("ctl00_PageContent_RadUpload1TextBox1")); } }

            public static IWebElement UploadBtn
            { get { return Driver.Instance.FindElementAndWait(By.Id("ctl00_PageContent_SubmitButton")); } }

            public static IWebElement SelectBtn
            { get { return Driver.Instance.FindElementAndWait(By.XPath(@".//span[contains(@class,'ruFileWrap ruStyled')]")); } }

            public static IWebElement CloseBtn
            { get { return Driver.Instance.FindElementAndWait(By.Id("ctl00_PageContent_btnClose")); } }


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
            Tree.SelectItem("Subject", "span").Click();
            CreateNewFolderBtn.Click();
            Driver.Instance.SwitchToDefaultContent();
            Driver.Instance.SwitchToFrame(By.XPath(@".//iframe[contains(@ng-src,'CreateNewTestFolder.aspx')]"));
            CreateNewTestFolderDialog.FolderNameTxtBox.SendKeys(folderName);
            CreateNewTestFolderDialog.BtnOk.Click();
            Driver.Wait(2);
        }

        public static void CreateNewTest(string testName, string testFolder)
        {
            Tree.SelectItem("Subject", "span").Click();
            Tree.SelectItem(testFolder, "span").Click();
            CreateTestBtn.Click();
            Driver.Instance.SwitchToDefaultContent();
            Driver.Instance.SwitchToFrame(By.XPath(@".//iframe[contains(@ng-src,'CreateNewTest.aspx')]"));
            CreateNewTestDialog.txtNewTestName.SendKeys(testName);
            CreateNewTestDialog.btnCreateNewOK.Click();            
        }

        public static void UploadScript(string pathToScript, string scriptFolder)
        {
            Tree.SelectItem("Subject", "span").Click();
            Tree.SelectItem(scriptFolder, "span").Click();
            UploadScriptBtn.Click();
            Driver.Instance.SwitchToDefaultContent();
            Driver.Instance.SwitchToFrame(By.XPath(@".//iframe[contains(@ng-src,'UploadScripts.aspx')]"));           
            UploadScriptDialog.SelectBtn.Click();
            Thread.Sleep(1000);
            UploadScriptDialog.SendPathToWindow(pathToScript);
            UploadScriptDialog.UploadBtn.Click();
            Driver.Wait(3);
            UploadScriptDialog.CloseBtn.Click();          
        }

        public static void DeleteNode(string node)
        {
            txtFindNode.SendKeys(node);
            RefreshBtn.Click();
            Tree.SelectItem(node,"span").Click();
            DeleteBtn.Click();
            System.Windows.Forms.SendKeys.SendWait("{ENTER}");
            Driver.Wait(2);        
        }

        #endregion        
       
    }
}
