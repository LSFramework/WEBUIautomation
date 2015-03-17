using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBPages.Pages;
using WEBPages.Pages.ModalDialogues;
using WEBUIautomation.Utils;

namespace WEBUItests.Smoke_Tests.MyPC
{

    public static partial class Const
    {
        /// <summary>
        /// Name of Test Set Folder
        /// </summary>
        public const string TestSetFolderName = "TestSetFolder";
    }

    /// <summary>
    /// The fixture to test a possibility to create test lab folder
    /// </summary>
    [TestFixture]
    public class Create_Test_Lab_Folder : LoginInMyPC
    {

        static string testSetFolderName = Const.TestSetFolderName;
       

        /// <summary>
        /// Opens TestLab perspective and check is it opened
        /// </summary>
        [Test]
        public void Test_1_NavigateToTestLab()
        {
            Assert.IsTrue(TestLab.TestLabOpened);
        }


        /// <summary>
        /// Opens ManageTestSetsDialog
        /// </summary>
         [Test]
        public void Test_2_OpenManageTestSetDialog()
        {
            TestLab.ClickManageTestSets();
        }


        /// <summary>
        /// Opens CreateNewTestSetFolderDialog
        /// </summary>
         [Test]
        public void Test_3_OpenCreateNewTestSetFolderDialog()
        {
            ManageTestSetsDialog.CreateNewFolderClick();
            //expected CreateNewTestSetFolderDialog opened
        }
         

        /// <summary>
        /// Performs filling Folder Name to text input
        /// </summary>
        [Test]
         public void Test_4_TypeFolderName()
        {
            CreateNewTestSetFolderDialog.TypeFolderName(testSetFolderName);
            //expected: txt input is filled with testSetFolder string
        }


        /// <summary>
        /// Trying to create the folder
        /// </summary>
        [Test]
        public void Test_5_Confirm()
        {
            CreateNewTestSetFolderDialog.ClickOK();
            //Expected: Dialog closed. 
            //New folder is shown in tree under root folder
            //ManageTestSetsDialog is active           
        }
    }
}
