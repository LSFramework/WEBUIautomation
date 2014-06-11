using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
<<<<<<< HEAD
using System.Threading;
=======
using System.Linq;
using System.Text;
using System.Threading.Tasks;
>>>>>>> origin/master
using WEBUIautomation;

namespace WEBUItests
{
    public class WEBUItest
    {
        [TestInitialize]
        public void Initialize()
        {
            Properties.Read();
            Driver.Initialize();
        }

        [TestCleanup]
        public void Close()
        {
            Driver.Close();
        }
    }
}
