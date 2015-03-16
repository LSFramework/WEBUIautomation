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
using WEBPages.Pages.TestPlan_Pages;

namespace WEBPages.Pages
{
    public class TestPlan
    {
        const string position="MainTab";

        static List<string> FoldersList = new List<string>();
        static List<string> ScriptsList = new List<string>();
        static List<string> TestsList = new List<string>();

        static IWebDriverExt _mainTab = Driver.Instance;

        static IWebDriverExt mainTab
        {
            get
            {
                if (_mainTab.CurrentFrame != By.Id(position))
                {
                    _mainTab.SwitchTo().DefaultContent();
                    MyPCNavigation.ClickMenuItem(MainHeadLinks.TestManagement);
                    MyPCNavigation.ClickMenuItem(MainHeadLinks.TestPlan);
                    _mainTab.SwitchToFrame(By.Id(position));
                }
                return _mainTab;
            }
        }
        
        #region The containers of UI elements

        public static IWebElement TreePane
        { get { return mainTab.FindElementAndWait(By.Id("divTestPlanTree"));} }

        protected static IWebElement TreeContainer
        { get { return TreePane.FindElementAndWait(By.XPath(@"//")); } }
        //span class="rtPlus"

        #endregion

        public static IWebElement txtFindNode
        { get {return TreePane.FindElementAndWait(By.Id("ctl00_PageContent_WebPartManager1_wp2108003362_5646e8c3_cc63_4bc6_9810_7580ae3300e4_TestPlanTreeControl_GenericTreeView1_RadTextBox1")); } }

        #region Test Plan Tree toolbar buttons

        public static IWebElement CreateNewFolderBtn
        { get { return TreePane.SelectItem("New Folder", "a", "title"); } }

        public static IWebElement UploadScriptBtn
        { get { return TreePane.SelectItem("Upload Script", "img", "alt"); } }

        public static IWebElement CreateTestBtn
        { get { return TreePane.SelectItem("New Test", "img", "alt"); } }
        
        public static IWebElement DeleteBtn
        { get { return TreePane.SelectItem("Delete", "img", "alt"); } }
       
        public static IWebElement CopyBtn
        { get { return TreePane.SelectItem("Copy", "img", "alt"); } }

        public static IWebElement CutBtn
        { get { return TreePane.SelectItem("Cut", "img", "alt"); } }

        public static IWebElement PasteBtn
        { get { return TreePane.SelectItem("Paste", "img", "alt"); } }

        public static IWebElement RefreshBtn
        { get { return TreePane.SelectItem("Refresh All", "img", "alt"); } }
        
        #endregion

        #region TestPlan Actions/Flows

        public static void CreateNewFolder(string folderName)
        {
            
            TreePane.SelectItem("Subject", "span").Click();
            CreateNewFolderBtn.Click();

            CreateNewTestFolderDialog.TypeFolderName(folderName);
            CreateNewTestFolderDialog.ClickOk();
            
            Driver.Wait(2);
        }

        public static void CreateNewTest(string testName, string testFolder)
        {
            TreePane.SelectItem("Subject", "span").Click();
            TreePane.SelectItem(testFolder, "span").Click();
            CreateTestBtn.Click();
            Driver.Instance.SwitchToDefaultContent();
            Driver.Instance.SwitchToFrame(By.XPath(@".//iframe[contains(@ng-src,'CreateNewTest.aspx')]"));
            CreateNewTestDialog.txtNewTestName.SendKeys(testName);
            CreateNewTestDialog.btnCreateNewOK.Click();            
        }

        public static void UploadScript(string pathToScript, string scriptFolder)
        {
            TreePane.SelectItem("Subject", "span").Click();
            TreePane.SelectItem(scriptFolder, "span").Click();
            UploadScriptBtn.Click();
            UploadScriptDialog.UploadScript(pathToScript);            
            try
            {
                if (Driver.Instance.SwitchTo().Alert() != null)
                {
                    IAlert alertDialog = Driver.Instance.SwitchTo().Alert();
                    string stringToLog = string.Format("Modal window {0} appears ", alertDialog.Text);
                    Logger.Log(stringToLog, Logger.msgType.Message);
                    alertDialog.Accept();
                    Driver.Instance.SwitchTo().DefaultContent();
                }
            }
            catch (Exception)
            {
                // Do nothing
            }
            Driver.Wait(3);
            UploadScriptDialog.CloseDialog();          
        }

        public static void CleanTestPlanTree()
        {
            DeleteItemsFromTree(ScriptsList);         
            DeleteItemsFromTree(TestsList);        
            DeleteItemsFromTree(FoldersList);
        }

        
        public static void ExpandTreeAndFillItemsLists()
        {
            #region Find Folders
            ExpandTree();
            FindFolders();
            #endregion /Find Folders

            #region Find Scripts
            {
                const string scriptLocator = @"//img[contains(@src, 'default_view-script.svg')]/following-sibling::span";

                //Get all scripts by locator
                IEnumerable<IWebElement> scripts = TreePane.FindElements(By.XPath(scriptLocator));

                //Adding scripts' names to List
                foreach (IWebElement foundElement in scripts)
                    ScriptsList.Add(foundElement.Text);

                //ScriptsList is filled
            }
            #endregion /Find Scripts

            #region Find Tests
            {
                const string testLocator = @"//img[contains(@src, 'default_test-performance.svg')]/following-sibling::span";
                
                //Get all tests by locator
                IEnumerable<IWebElement> tests = TreePane.FindElements(By.XPath(testLocator));

                //Adding tests' names to List
                foreach (IWebElement foundElement in tests)
                    if (foundElement.Text != "Unattached")
                        TestsList.Add(foundElement.Text);

                //TestsList is filled
            }
            #endregion /Find Tests
        }


        private static void DeleteItemsFromTree(List<string> listOfNodesToBeDeleted)
        {
            foreach (string nodeName in listOfNodesToBeDeleted)
            {
                txtFindNode.Clear();
                txtFindNode.SendKeys(nodeName);
                TreePane.SelectItem(nodeName, "span").Click();
                DeleteBtn.Click();
                Driver.Wait(1);                
                    try
                    {
                        if (Driver.Instance.SwitchTo().Alert() != null)
                        {
                            IAlert alertDialog = Driver.Instance.SwitchTo().Alert();
                            string stringToLog = string.Format("Modal window {0} appears ", alertDialog.Text);
                            Logger.Log(stringToLog, Logger.msgType.Message);
                            alertDialog.Accept();                            
                            Driver.Instance.SwitchTo().DefaultContent();
                        }
                    }
                    catch (Exception)
                    {

                        // Do nothing
                    }

                MyPCNavigation.ClickRefresh();
            }
            listOfNodesToBeDeleted.Clear();
        }       

        private static void ExpandTree()
        {
            const string collapsedElementLocator = @"//span[@class='rtPlus']";

            //As long as a collapsed item could be found
            while (TreePane.IsElementPresent(By.XPath(collapsedElementLocator)))
            {
                //Get List of elements to expand a folder
                IEnumerable<IWebElement> folderExpanders = TreePane.FindElements(By.XPath(collapsedElementLocator));

                //Expand each folder was found
                foreach (IWebElement expander in folderExpanders)
                {
                    expander.Click();
                    //renewing the list
                    folderExpanders = TreePane.FindElements(By.XPath(collapsedElementLocator));
                }
            }
            //All folders of tree should be expanded here            
        }

        private static void FindFolders()
        {
            const string folderLocator = @"//img[contains(@src, 'default_folder')]/following-sibling::span";

            //Get List of elements are with name of test folder 
            IEnumerable<IWebElement> folders = TreePane.FindElements(By.XPath(folderLocator));

            //Add folders names to FoldersList
            foreach (IWebElement folder in folders)
                if (folder.Text != "Subject")
                    FoldersList.Add(folder.Text);

            //FoldersList is filled
        }

        #endregion        
       
    }
}
