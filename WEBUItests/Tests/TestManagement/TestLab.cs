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
using WEBUItests.TestVariables;

namespace WEBUItests.MyPCTests.Test_2_TestManagement_TestLab
{
 
    /// <summary>
    /// Creates a new Test Set Folder and a new Test Set
    /// </summary>
    [TestFixture][LoginIfNotLogged]
    public class Test_1_TestLabCreateEntities:WEBUItest
    {
        TestLabPage testLabPage;
        ManageTestSetsDialog dialog;

        string tsFolderName = Variables.TestLab.testSetFolderName;
        string tsName = Variables.TestLab.testSetName;


        /// <summary>
        /// Navigate to Test Lab perspective
        /// </summary>
        [Test]
        public void Step_0_NavigateToTestLab()
        {
            testLabPage = new TestLabPage();
        }

        /// <summary>
        /// Open Manage Test Sets Dialog
        /// </summary>
        [Test]
        public void Step_1_ClickManageTestSets()
        {
            dialog=testLabPage.ClickManageTestSets();
        }

        /// <summary>
        /// Create a new test set folder
        /// </summary>
        [Test]
        public void Step_2_CreateNewTestSetFolder()
        {
            Assert.True(dialog.CreateNewTestSetFolder(tsFolderName).Opened);            
        }

        /// <summary>
        /// Create a new test set
        /// </summary>
        [Test]
        public void Step_3_CreateNewTestSet()
        {
            Assert.True(dialog.CreateNewTestSet(tsFolderName, tsName).Opened);           
        }

        /// <summary>
        /// Select test set in tree and close the dialog
        /// </summary>
        [Test]
        public void Step_4_SelectTestSet()
        {
            Assert.True(dialog.SelectTestSet(tsFolderName, tsName).Opened);            
        }

    }
}
