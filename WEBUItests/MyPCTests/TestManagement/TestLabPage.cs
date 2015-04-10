using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBPages.Pages;
using WEBPages.Pages.TestLab;
using WEBPages.Pages.TestLab.ModalDialogues;
using WEBUItests.Base_Test;

namespace WEBUItests.MyPCTests.Test_2_TestManagement_TestLab
{
    /// <summary>
    /// Const
    /// </summary>
    public static partial class Const
    {
        /// <summary>
        /// Name of Test Set Folder   
        /// </summary>     
        public static string testSetFolderName="TestSetFolder" + Guid.NewGuid().ToString().Substring(0,10);
        /// <summary>
        /// Name of Test Set
        /// </summary>
        public static string testSetName = "Tes Set" + Guid.NewGuid().ToString().Substring(0, 10);
    }

    /// <summary>
    /// Createsa new Test Set Folder and a new Test Set
    /// </summary>
    [TestFixture][LoginIfNotLogged]
    public class Test_1_TestLabCreateEntities:WEBUItest
    {

        MainHead mainHead = new MainHead();
        TestLabPage testLabPage = new TestLabPage();
        /// <summary>
        /// Navigate to Test Lab perspective
        /// </summary>
        [Test]
        public void Step_0_NavigateToTestLab()
        {
            mainHead.NavigateToTestLab();
        }

        /// <summary>
        /// Open Manage Test Sets Dialog
        /// </summary>
        [Test]
        public void Step_1_ClickManageTestSets()
        {
            testLabPage.ClickManageTestSets();
        }

        /// <summary>
        /// Create a new test set folder
        /// </summary>
        [Test]
        public void Step_2_CreateNewTestSetFolder()
        {
            ManageTestSetDialogActions actions=new ManageTestSetDialogActions();
            actions.CreateNewTestSetFolder(Const.testSetFolderName);            
        }

        /// <summary>
        /// Create a new test set
        /// </summary>
        [Test]
        public void Step_3_CreateNewTestSet()
        {
            ManageTestSetDialogActions actions = new ManageTestSetDialogActions();
            actions.CreateNewTestSet(Const.testSetFolderName, Const.testSetName);           
        }

        /// <summary>
        /// Select test set in tree and close the dialog
        /// </summary>
        [Test]
        public void Step_4_SelectTestSet()
        {
            ManageTestSetDialogActions actions = new ManageTestSetDialogActions();
            actions.SelectTestSet(Const.testSetFolderName, Const.testSetName);            
        }

    }
}
