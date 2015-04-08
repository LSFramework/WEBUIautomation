using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBPages.Pages;


namespace WEBUItests
{

    /// <summary>
    /// Global const
    /// </summary>
    public static partial class Const
    {
        /// <summary>
        /// Name of Test Set
        /// </summary>
        public const string TestSetName = "Performance Test Set";
    }

    /// <summary>
    /// Creates Test Set
    /// </summary>
//    [TestFixture]
//    public class Test_2_Create_Test_Set_from_Test_Lab : WEBUItest
//    {

//        string testSetName = Const.TestSetName;
//        /// <summary>
//        /// Opens TestLab perspective and check is it opened
//        /// </summary>
//        [Test]
//        public void Step_1_NavigateToTestLab()
//        {
//            Assert.IsTrue(TestLab.TestLabOpened);
//        }

//        /// <summary>
//        /// Opens ManageTestSetsDialog
//        /// </summary>
//        [Test]
//        public void Step_2_OpenManageTestSetDialog()
//        {
//            TestLab.ClickManageTestSets();
//        }
//        /// <summary>
//        /// Select Root Folder
//        /// </summary>
//        [Test]
//        public void Step_3_SelectRootFolder()
//        {
//            ManageTestSetsDialog.SelectFolderInTree("Root");
//        }
//        /// <summary>
//        /// Select a folder under Root
//        /// </summary>
//        [Test]
//        public void Step_4_SelectFolderUnderRoot()
//        {
//            ManageTestSetsDialog.SelectFolderInTree(Const.TestSetFolderName);
//        }


//        /// <summary>
//        /// Opens CreateNewTestSetDialog
//        /// </summary>
//        [Test]
//        public void Step_5_OpenCreateNewTestSetDialog()
//        {
//            ManageTestSetsDialog.CreateNewTestSetClick();
//            //expected CreateNewTestSetDialog opened
//        }

//        /// <summary>
//        /// Types TS name
//        /// </summary>
//        [Test]
//        public void Step_6_TypeTestSetName()
//        {
//            CreateNewTestSetDialog.TypeTestSetName(testSetName);
//        }

//        /// <summary>
//        /// Confirms test set creating
//        /// </summary>
//        [Test]
//        public void Step_7_Confirm()
//        {
//            CreateNewTestSetDialog.ClickOK();
//        }
//    }
}
