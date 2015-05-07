namespace WEBPages.MyPCPages
{
    public class TestPlanActions:TestPlanPage
    {
        public TestPlanPage CreateFolder(string folderName)
        {
          return SelectSubjectFolder()
                .ClickCreateNewFolderBtn()
                .TypeFolderName(folderName)
                .ClickOkBtn();
        }

        public void CreateTest(string folderName, string testName)
        {
            OpenCreateNewTestDialog(folderName);         
        
        }


        public void UploadScript(string folderName, string scriptName) { }

    }
}
