using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEBUItests.TestVariables
{
    /// <summary>
    /// RunTimeVariables
    /// </summary>
    public class RunTimeVariables
    {
     
            /// <summary>
            /// Name of folder to store test sets
            /// </summary>
            public string testSetFolderName = string.Format("TestSet Folder_{0}", Guid.NewGuid().ToString().Substring(0, 9));

            /// <summary>
            /// Test set name
            /// </summary>
            public string testSetName = string.Format("Test Set_{0}", Guid.NewGuid().ToString().Substring(0, 10)); 

            /// <summary>
            /// Name of folder to store tests
            /// </summary>
            public string testFolderName = string.Format("Tests Folder_{0}", Guid.NewGuid().ToString().Substring(0, 8));
            /// <summary>
            /// Name of performance test
            /// </summary>
            public string testName = string.Format("Performance Test_{0}", Guid.NewGuid().ToString().Substring(0, 10));
            /// <summary>
            /// Name of a folder to store scripts
            /// </summary>
            public string scriptFolderName = string.Format("Scripts Folder_{0}", Guid.NewGuid().ToString().Substring(0, 8));
        

    }
}
