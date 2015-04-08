using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEBPages.Pages.TestLab.ModalDialogues
{
    public class ManageTestSetDialogActions
    {

        /// <summary>
        /// Makes try to create test set folder with folderName string
        /// returns nothing if folder has been created or a warning if it has not.
        /// </summary>
        /// <param name="folderName"></param>
        /// <param name="warning"></param>
        public static void CreateNewTestSetFolder(string folderName, out string warning)
        {
            warning = string.Empty;   
            ManageTestSetsDialog.SelectRootFolder();
            ManageTestSetsDialog.CreateNewFolderClick();
            CreateNewTestSetFolderDialog.TypeFolderName(folderName);
            CreateNewTestSetFolderDialog.ClickOK();

            if (CreateNewTestSetFolderDialog.Opened)
            {
                warning = CreateNewTestSetFolderDialog.GetWarningMessage();
                if(warning!=string.Empty)
                CreateNewTestSetFolderDialog.ClickClose();          
            }
                     
        }


        /// <summary>
        /// Makes try to create test set with name testSetName under parentFolder
        /// returns nothing if test set has been created or a warning if it has not.
        /// </summary>
        /// <param name="parentFolder"></param>
        /// <param name="testSetName"></param>
        /// <param name="warning"></param>
        public static void CreateNewTestSet(string parentFolder, string testSetName, out string warning)
        {
            warning = string.Empty;
            ManageTestSetsDialog.SelectRootFolder();
            ManageTestSetsDialog.SelectFolder(parentFolder);
            ManageTestSetsDialog.CreateNewTestSetClick();
            CreateNewTestSetDialog.TypeTestSetName(testSetName);
            CreateNewTestSetDialog.ClickOK();

            if (CreateNewTestSetDialog.Opened)
            {
                warning = CreateNewTestSetDialog.GetWarningMessage();
                if(warning!=string.Empty)
                CreateNewTestSetDialog.ClickClose();
            }
        }


        public static void SelectTestSet(string parentFolder, string testSetName)
        {
            ManageTestSetsDialog.TryExpandFolder("Root");
            ManageTestSetsDialog.TryExpandFolder(parentFolder);
            ManageTestSetsDialog.SelectTestSet(testSetName);
            ManageTestSetsDialog.ClickOkBtn();
        }
    }
}
