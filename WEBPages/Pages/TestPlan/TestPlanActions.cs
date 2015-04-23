using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBPages.Pages.TestPlan.ModalDialogues;

namespace WEBPages.Pages.TestPlan
{
    public class TestPlanActions:TestPlanPage
    {
        public TestPlanPage CreateTestPlanFolder(string folderName)
        {
          return SelectSubjectFolder()
                .ClickCreateNewFolderBtn()
                .TypeFolderName(folderName)
                .ClickOkBtn();
        }

        public void UploadScriptToFolder(string folderName, string scriptName) { }

    }
}
