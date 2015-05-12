using System;
using WEBUIautomation;
using System.Linq;

namespace WEBUItests.TestVariables
{
    /// <summary>
    /// To use the same test variables between fixtures
    /// </summary>
    public class Variables
    {
        /// <summary>
        ///  A browser to be used under test  
        /// </summary>
        public static Browsers BROWSER
        { get { return WebDriverBrowser.getBrowserFromString(Config.BrowsersSet.First()); } }


        /// <summary>
        /// to use for Test Lab tests
        /// </summary>
        public static class TestLab
        {
            /// <summary>
            /// Name of test lab tree root node
            /// </summary>
            public const string rootFolder = "Root";

            /// <summary>
            /// Name of folder to store test sets
            /// </summary>
            public static string testSetFolderName = string.Format("TestSet Folder_{0}", Guid.NewGuid().ToString().Substring(0, 9)); 

            /// <summary>
            /// Test set name
            /// </summary>
            public static string testSetName = string.Format("Test Set_{0}", Guid.NewGuid().ToString().Substring(0, 10));
        }

        /// <summary>
        /// to use for Test Plan tests
        /// </summary>
        public static class TestPlan
        {
            /// <summary>
            /// name of test plan tree root node
            /// </summary>
            public const string subjectFolder = "Subject";
            
            /// <summary>
            /// Name of folder to store tests
            /// </summary>
            public static string testFolderName = string.Format("Tests Folder_{0}", Guid.NewGuid().ToString().Substring(0, 8));
            /// <summary>
            /// Name of performance test
            /// </summary>
            public static string testName = string.Format("Performance Test_{0}", Guid.NewGuid().ToString().Substring(0, 10));
            /// <summary>
            /// Name of a folder to store scripts
            /// </summary>
            public static string scriptFolderName =string.Format("Scripts Folder_{0}", Guid.NewGuid().ToString().Substring(0, 8));
            /// <summary>
            /// script Name
            /// </summary>
            public static string scriptName = "CloudSanityScript.zip";
            /// <summary>
            /// Path to script .zip
            /// </summary>
            public static string pathToScript = @"C:\ins\";

        }


    }
}
