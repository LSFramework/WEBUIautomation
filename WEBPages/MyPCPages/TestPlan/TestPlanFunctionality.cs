using WEBPages.BasePageObject;
using WEBPages.MyPCPages.DesignLoadTest;

namespace WEBPages.MyPCPages
{
    public class TestPlanFunctionality:TestPlanPage
    {     
        public TestPlanPage CreateFolder(string folderName)
        {
          return SelectSubjectFolder()
                .ClickCreateNewFolderBtn()
                .TypeFolderName(folderName)
                .ClickOkBtn();
        }

        public DLT CreateTest(string folderName, string testName, string testSetFolderName, string testSetName)
        {
          OpenCreateNewTestDialog(folderName)
                .TypeTestName(testName)
                .SelectTargetTestSet(testSetFolderName, testSetName)
                .ClickbtnCreateNewOK();

          return new DLT(new LoadTest(testName));
        }

        public DLT CreateTest(string folderName, string testName)
        {
            OpenCreateNewTestDialog(folderName)
                  .TypeTestName(testName)
                  .ClickbtnCreateNewOK();

            return new DLT(new LoadTest(testName));
        }

        public DLT EditTest(string folderName, string testName)
        {
            LoadTest test = EditLoadTest(folderName, testName);

            return new DLT(test);
        }

        public TestPlanPage UploadScript(string folderName, string pathToScript) 
        {
           var testPlan= SelectTreeItem(folderName);

           var uploadDialog = testPlan.ClickUploadScriptBtn();
               uploadDialog.SelectScript(pathToScript);
               uploadDialog.ClickUploadBtn();

           return uploadDialog.ClickCloseButton();         
        }

    }
}
