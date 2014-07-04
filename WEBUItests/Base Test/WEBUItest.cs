﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
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
        [TestFixtureSetUp]
        public void Initialize()
        {
            Logger.Log("Starting Test Set", Logger.msgType.Message);
            Driver.Initialize();
            Properties.Create();
            Properties.Read();
            DriverWait.Initialize(2);
            Driver.BrowserMaximize();
            //LocalDriverManager.GetDriver();
        }

        [SetUp]
        public void SetUp()
        {
            Logger.Log("Starting Test: " + NUnit.Framework.TestContext.CurrentContext.Test.Name, Logger.msgType.Message);
        }

        [TearDown]
        public void TearDown()
        {
            if (NUnit.Framework.TestContext.CurrentContext.Result.Status == TestStatus.Failed)
            {
                Logger.Log("The step: " + NUnit.Framework.TestContext.CurrentContext.Test.Name + " failed!",  Logger.msgType.Error);
                Logger.Log("Snapshot is: " + Snapshot.Take(), Logger.msgType.Error);
            }
            Logger.Log("Test Finished! ", Logger.msgType.Message);
        }

        [TestFixtureTearDown]
        public void Cleanup()
        {
            Driver.Close();
        }
    }
}
