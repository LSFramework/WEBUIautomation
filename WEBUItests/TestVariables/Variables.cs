using System;

namespace WEBUItests.TestVariables
{
    public static class Variables
    {
        public static class TestLab
        {
            public const string rootFolder = "Root";
            public static string testSetFolderName = string.Format("TestSetFolder_{0}", Guid.NewGuid().ToString().Substring(0, 9));            
            public static string testSetName = string.Format("TestSet_{0}", Guid.NewGuid().ToString().Substring(0, 10));
        }

        public static class TestPlan
        {
            public const string subjectFolder = "Subject";
            public static string testFolderName = string.Format("TestFolder_{0}", Guid.NewGuid().ToString().Substring(0, 8));
            public static string testName = string.Format("Test_{0}", Guid.NewGuid().ToString().Substring(0, 10));
        }


    }
}
