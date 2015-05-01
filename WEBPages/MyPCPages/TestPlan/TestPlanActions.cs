namespace WEBPages.MyPCPages
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
