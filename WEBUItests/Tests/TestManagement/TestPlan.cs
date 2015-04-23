using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBPages.Pages;
using WEBPages.Pages.TestPlan;
using WEBPages.Pages.TestPlan.ModalDialogues;
using WEBUItests.Base_Test;
using WEBUItests.TestVariables;

namespace WEBUItests.MyPCTests.Test_3_TestManagement_TestPlan
{
  
    /// <summary>
    /// Creates Test plan items
    /// </summary>
    [TestFixture][LoginIfNotLogged]
    public class TestPlan:WEBUItest
    {

        MainHead mainHead = new MainHead();
        TestPlanPage testPlan;
        CreateNewTestFolderDialog createNewTestFolderDialog;

        string tFolderName = Variables.TestPlan.testFolderName;
        string tName = Variables.TestPlan.testName;
        string subject = Variables.TestPlan.subjectFolder;



        /// <summary>
        /// Navigate to Test Plan perspective
        /// </summary>
        [Test]
        public void Step_1_NavigateToTestPlan()
        {
           testPlan= mainHead.NavigateToTestPlan();          
        }


        /// <summary>
        /// Select Subject Folder on tree
        /// </summary>
        [Test]
        public void Step_2_SelectSubjectFolder()
        {
            testPlan.SelectSubjectFolder();
           // Assert.True(TestPlan.IsFolderSelected("Subject"));
        }

        /// <summary>
        /// Open Ceate New Test Folder Dialog
        /// </summary>
        [Test]
        public void Step_3_OpenCreateFolderDailog()
        {
            createNewTestFolderDialog = testPlan.OpenCreateNewFolderDialog(subject);
            Assert.True(createNewTestFolderDialog.Opened);
        }

        /// <summary>
        /// Type Folder name
        /// </summary>
        [Test]
        public void Step_4_TypeNewFolderName()
        {
            createNewTestFolderDialog.TypeFolderName(tFolderName);
        }
        /// <summary>
        /// Confirm Create Folder
        /// </summary>
        [Test]
        public void Step_5_Confirm()
        {
            createNewTestFolderDialog.ClickOkBtn();
        }

    }
}
