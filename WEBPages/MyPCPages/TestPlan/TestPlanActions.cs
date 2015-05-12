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
            OpenCreateNewTestDialog(folderName)
                .TypeTestName(testName);        
        
        }


        public void UploadScript(string folderName, string pathToScript) 
        {
            SelectTreeItem(folderName)
                .ClickUploadScriptBtn()
                .SelectScript(pathToScript)
                .ClickUploadBtn()
                .ClickCloseButton();         
        }

    }
}
