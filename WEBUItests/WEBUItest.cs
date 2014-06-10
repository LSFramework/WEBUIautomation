using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading;
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
        public void Cleanup()
        {
            //Driver.Cleanup();
        }
    }
}
