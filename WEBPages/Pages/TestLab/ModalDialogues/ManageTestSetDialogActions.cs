﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEBPages.Pages.TestLab.ModalDialogues
{
   
    // Complex Actions
    public partial class ManageTestSetsDialog
    {
        /// <summary>
        /// Makes try to create test set folder with folderName string
        /// returns nothing if folder has been created or a warning if it has not.
        /// </summary>
        /// <param name="folderName"></param>
        /// <param name="warning"></param>
        public ManageTestSetsDialog CreateNewTestSetFolder(string folderName)
        {
            return this.SelectRootFolder()
                .btnNewFolderClick()
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
                .btnNewTestSetClick()
                .TypeTestSetName(testSetName)
                .ClickOkExpectingSucces();            
        }

        public TestLabPage SelectTestSet(string parentFolder, string testSetName)
        {
            return this.SelectRootFolder()
                .SelectFolder(parentFolder)
                .TryExpandFolder(parentFolder)
                .SelectTestSet(testSetName)
                .ClickOkBtnExpectedSuccess();
        }
    }
}
