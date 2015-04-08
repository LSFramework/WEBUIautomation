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

namespace WEBUItests.MyPCTests.TestManagement
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
        /// <summary>
        /// Navigate to Test Lab perspective
        /// </summary>
        [Test]
        public void Step_0_NavigateToTestLab()
        {
            MainHead.NavigateToTestLab();
        }

        /// <summary>
        /// Open Manage Test Sets Dialog
        /// </summary>
        [Test]
        public void Step_1_ClickManageTestSets()
        {
            TestLab.ClickManageTestSets();
        }

        /// <summary>
        /// Create a new test set folder
        /// </summary>
        [Test]
        public void Step_2_CreateNewTestSetFolder()
        {
            string warning=string.Empty;
            ManageTestSetDialogActions.CreateNewTestSetFolder(Const.testSetFolderName, out warning);            
        }

        /// <summary>
        /// Create a new test set
        /// </summary>
        [Test]
        public void Step_3_CreateNewTestSet()
        {
            string warning = string.Empty;
            ManageTestSetDialogActions.CreateNewTestSet(Const.testSetFolderName, Const.testSetName, out warning);           
        }

        /// <summary>
        /// Select test set in tree and close the dialog
        /// </summary>
        [Test]
        public void Step_4_SelectTestSet()
        {
            ManageTestSetDialogActions.SelectTestSet(Const.testSetFolderName,Const.testSetName);            
        }

    }
}
