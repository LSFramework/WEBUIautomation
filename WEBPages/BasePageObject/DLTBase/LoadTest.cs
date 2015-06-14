using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEBPages.BasePageObject
{
    public class LoadTest : Dictionary<TestAttributes, string>
    {
        public LoadTest(string testName): base()
        {
            this.Add(TestAttributes.TestName, testName);
        }
    }
}
