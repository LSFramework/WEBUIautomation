//using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;
using WEBUIautomation;
using WEBUIautomation.Utils;
using System.IO;
using NUnit.Core;
using System.Collections;

namespace WEBUItests.Base_Test
{
    

    /// <summary>
    /// Base test to use with WebDriver
    /// </summary>
    public abstract class WEBUItest
    {
        /// <summary>
        /// Logs test start
        /// </summary>
        public void TestSetUp()
        {
            Logger.Log("Starting Test Set", Logger.msgType.Message);  
        }

        /// <summary>
        /// Before each tests
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            Logger.Log("Starting Test: " + NUnit.Framework.TestContext.CurrentContext.Test.Name, Logger.msgType.Message);
        }

        /// <summary>
        /// After each tests
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            if (NUnit.Framework.TestContext.CurrentContext.Result.Status == TestStatus.Failed)
            {
                Logger.Log("The step: " + NUnit.Framework.TestContext.CurrentContext.Test.Name + " failed!", Logger.msgType.Error);
                Logger.Log("Snapshot is: " + Snapshot.Take(), Logger.msgType.Error);
            }
            else
            {
                Logger.Log("Test Finished! ", Logger.msgType.Passed);
            }
        }

        /// <summary>
        /// Close WebDriver
        /// </summary>
        public void DriverCleanup()
        {
            Driver.Wait(1);
            Driver.Close();
        }
    }
}
