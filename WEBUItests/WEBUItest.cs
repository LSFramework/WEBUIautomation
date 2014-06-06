using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using WEBUIautomation;

namespace WEBUItests
{
    public class WEBUItest
    {
        [TestInitialize]
        public void Initialize()
        {
            Driver.Initialize();
        }


        [TestCleanup]
        public void Cleanup()
        {
            Driver.Cleanup();
        }
    }
}
