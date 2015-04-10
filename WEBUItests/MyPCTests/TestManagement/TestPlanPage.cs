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

namespace WEBUItests.MyPCTests.Test_3_TestManagement_TestPlan
{
    public static partial class Const
    {
        /// <summary>
        /// test folder name
        /// </summary>
        public static string testFolderName = "testFolder" + Guid.NewGuid().ToString().Substring(0, 10);
    
    }

    /// <summary>
    /// Creates Test plan items
    /// </summary>
    [TestFixture][LoginIfNotLogged]
    public class TestPlanPage:WEBUItest
    {

        MainHead mainHead = new MainHead();

        /// <summary>
        /// Navigate to Test Plan perspective
        /// </summary>
        [Test]
        public void Step_1_NavigateToTestPlan()
        {
            mainHead.NavigateToTestPlan();          
        }


        /// <summary>
        /// Select Subject Folder on tree
        /// </summary>
        [Test]
        public void Step_2_SelectSubjectFolder()
        {
            TestPlan.SelectSubjectFolder();
           // Assert.True(TestPlan.IsFolderSelected("Subject"));
        }

        /// <summary>
        /// Open Ceate New Test Folder Dialog
        /// </summary>
        [Test]
        public void Step_3_OpenCreateFolderDailog()
        {
            TestPlan.OpenCreateNewFolderDialog("Subject");
            Assert.True(CreateNewTestFolderDialog.Opened);
        }

        /// <summary>
        /// Type Folder name
        /// </summary>
        [Test]
        public void Step_4_TypeNewFolderName()
        {
            CreateNewTestFolderDialog.TypeFolderName(Const.testFolderName);
        }
        /// <summary>
        /// Confirm Create Folder
        /// </summary>
        [Test]
        public void Step_5_Confirm()
        {
            CreateNewTestFolderDialog.ClickOkBtn();
            
        }

    }
}
