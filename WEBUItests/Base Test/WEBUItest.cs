﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBUIautomation;
using WEBUIautomation.Utils;

namespace WEBUItests
{
    public class WEBUItest
    {
        [TestInitialize]
        public void Initialize()
        {
            Driver.Initialize();
            Properties.Create();
            DriverWait.Initialize(2);
            Driver.BrowserMaximize();
        }


        [TestCleanup]
        public void Cleanup()
        {
            //Driver.Wait(5);
            Driver.Close();
        }
    }
}
