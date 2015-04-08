using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBPages.Pages.TestPlan.ModalDialogues;

namespace WEBPages.Pages.TestPlan
{
    public class TestPlanFlows
    {
        public static void CreateTestPlanFolder(string folderName, out string warning)
        {
            warning = string.Empty;

            TestPlan.SelectSubjectFolder();
            TestPlan.ClickCreateNewFolderBtn();
            CreateNewTestFolderDialog.TypeFolderName(folderName);
            CreateNewTestFolderDialog.ClickOkBtn();

            if (CreateNewTestFolderDialog.Opened)
            {
                warning = CreateNewTestFolderDialog.GetWarningMessage();
                if (warning != string.Empty)
                    CreateNewTestFolderDialog.ClickCloseBtn();
            }
        }

        public static void UploadScriptToFolder(string folderName, string scriptName) { }

    }
}
