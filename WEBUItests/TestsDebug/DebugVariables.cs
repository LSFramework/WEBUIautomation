using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEBUItests.TestsDebug
{
    #pragma warning disable 1591

    public class Variables
    {
        
        public static class TestLab
        {
            public const string rootFolder = "Root";

            public static string testSetFolderName = "testSetFolder";
            public static string testSetName = "testSet";
        }
     
        public static class TestPlan
        {
            public const string subjectFolder = "Subject";

            public static string testFolderName = "testFolder";
            public static string testName="test";
            public static string scriptFolderName="scriptFolder";
            public static string scriptName = "CloudSanityScript.zip";
            public static string pathToScript = "C:\\ins\\";
            public static string script = "CloudSanityScript";
        }

    }

    #pragma warning restore 1591
}
