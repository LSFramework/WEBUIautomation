using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEBPages.Pages.TestLab.ModalDialogues
{
    public class ManageTestSetDialogActions: ManageTestSetsDialog
    {
        /// <summary>
        /// Makes try to create test set folder with folderName string
        /// returns nothing if folder has been created or a warning if it has not.
        /// </summary>
        /// <param name="folderName"></param>
        /// <param name="warning"></param>
        public ManageTestSetsDialog CreateNewTestSetFolder(string folderName)
        {
            this.SelectRootFolder();    

            return this.NewFolderBtnClickExpectedSuccess()
                .TypeFolderName(folderName)
                .ClickOKExpectedSuccess();
        }


        /// <summary>
        /// Makes try to create test set with name testSetName under parentFolder
        /// returns nothing if test set has been created or a warning if it has not.
        /// </summary>
        /// <param name="parentFolder"></param>
        /// <param name="testSetName"></param>
        /// <param name="warning"></param>
        public ManageTestSetsDialog CreateNewTestSet(string parentFolder, string testSetName)
        { 
            return this.SelectRootFolder()
            .SelectFolder(parentFolder)
            .CreateNewTestSetClick()
            .TypeTestSetName(testSetName)
            .ClickOkExpectingSucces();            
        }


        public TestLabPage SelectTestSet(string parentFolder, string testSetName)
        {
            return this.TryExpandFolder("Root")
                .TryExpandFolder(parentFolder)
                .SelectTestSet(testSetName)
                .ClickOkBtnExpectedSuccess();
        }
    }
}
