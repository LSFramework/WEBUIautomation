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
            Properties.Read();
            Driver.Initialize();
            DriverWait.Initialize(10);
        }

        [TestCleanup]
        public void Close()
        {
            Driver.Wait(5);
            //Driver.Close();
        }
    }
}
