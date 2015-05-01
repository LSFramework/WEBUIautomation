using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBPages.MyPCPages;
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
        MainHead mainHead = new MainHead();
        TestLabPage testLabPage;
        ManageTestSetsDialog dlgMngTestSets;
        NewTestSetFolderDialog dlgCreateTestFolder;
        NewTestSetDialog dlgCreateTesSet;

        string tsFolderName = Variables.TestLab.testSetFolderName;
        string tsName = Variables.TestLab.testSetName;

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Step_0_TestPlan()
        {
            TestPlanPage testPlan = new TestPlanPage();
            Assert.True(testPlan.ViewOpened);
        }

        /// <summary>
        /// Navigate to Test Lab perspective
        /// </summary>
        [Test]
        public void Step_01_NavigateToTestLab()
        {
            testLabPage = new TestLabPage();
            Assert.True(testLabPage.ViewOpened);
        }

        /// <summary>
        /// Open Manage Test Sets Dialog
        /// </summary>
        [Test]
        public void Step_02_ClickManageTestSets()
        {
            dlgMngTestSets=testLabPage.ClickManageTestSets();
            Assert.True(dlgMngTestSets.ViewOpened);
        }

        /// <summary>
        /// Select "Root" Folder
        /// </summary>
        [Test]
        public void Step_03_SelectRootFolder()
        {
            dlgMngTestSets=dlgMngTestSets.SelectRootFolder();
            Assert.AreEqual("Root", dlgMngTestSets.SelectedFolder);
        }

        /// <summary>
        /// Open a new test set folder dialog
        /// </summary>
        [Test]
        public void Step_04_OpenNewTestSetFolderDialog()
        {
            dlgCreateTestFolder = dlgMngTestSets.btnNewFolderClick();
            Assert.True(dlgCreateTestFolder.ViewOpened);
        }

        /// <summary>
        /// Type folder name to input field. Checks that input field was filled.
        /// </summary>
        [Test]
        public void Step_05_TypeFolderName()
        {
            dlgCreateTestFolder=dlgCreateTestFolder.TypeFolderName(tsFolderName);
            Assert.AreEqual(tsFolderName, dlgCreateTestFolder.FolderName);
        }

        /// <summary>
        /// Confirm creating of the folder. Checks that "Create test folder dialog" closed and the "Manage test sets dialog" has focus. 
        /// </summary>
        [Test]
        public void Step_06_ConfirmCreateTestFolder()
        {
            dlgMngTestSets=dlgCreateTestFolder.ClickOKExpectedSuccess();
            Assert.True(dlgMngTestSets.ViewOpened);
        }

        /// <summary>
        /// Select the created folder in tree
        /// </summary>
        [Test]
        public void Step_07_CheckHasFolderBeenCreated()
        {
            dlgMngTestSets.SelectFolder(tsFolderName);
            Assert.AreEqual(tsFolderName, dlgMngTestSets.SelectedFolder);
        }

        /// <summary>
        /// Open New Test Set Dialog
        /// </summary>
        [Test]
        public void Step_08_OpenNewTestSetDialog()
        {
            dlgCreateTesSet=dlgMngTestSets.btnNewTestSetClick();
            Assert.True(dlgCreateTesSet.ViewOpened);
        }

        /// <summary>
        /// Type test set name
        /// </summary>
        [Test]
        public void Step_09_TypeTestSetName()
        {
            dlgCreateTesSet.TypeTestSetName(tsName);
            Assert.AreEqual(tsName, dlgCreateTesSet.TestSetName);
        }

        /// <summary>
        /// Confirm creating of the test set. Checks that "Create test set dialog" closed and the "Manage test sets dialog" has focus. 
        /// </summary>
        [Test]
        public void Step_10_ConfirmCreateTestSet()
        {
            dlgMngTestSets = dlgCreateTesSet.ClickOkExpectingSucces();
            Assert.True(dlgMngTestSets.ViewOpened);
        }


        /// <summary>
        /// Select test set in tree and close the "Manage test sets dialog"
        /// </summary>
        [Test]
        public void Step_11_SelectTestSet()
        {
            testLabPage=dlgMngTestSets.SelectTestSet(tsFolderName, tsName);
            Assert.True(testLabPage.ViewOpened);       
        }

        /// <summary>
        /// Check selected test set name
        /// </summary>
        [Test]
        public void Step_12_CheckTestSetSelected()
        {
            Assert.AreEqual(tsName, testLabPage.SelectedTestSet);
        }
    }
}
