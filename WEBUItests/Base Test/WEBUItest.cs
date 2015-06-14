using NUnit.Framework;
using System;
using WEBUIautomation;
using WEBUIautomation.Utils;
using WEBUIautomation.Extensions;
using System.IO;
using System.Collections;
using System.Diagnostics;

namespace WEBUItests.Base_Test
{
    using Logger = WEBUIautomation.Utils.Logger;

    /// <summary>
    /// Base test to use with WebDriver
    /// </summary>
    [LoginIfNotLogged]
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
                StackTrace stackTrace = new StackTrace();
                string methodName = stackTrace.GetFrame(1).GetMethod().Name;

                Logger.Log("The step: " + NUnit.Framework.TestContext.CurrentContext.Test.Name + " failed!", Logger.msgType.Error);
                Logger.Log("Snapshot is: " + Snapshot.Take(methodName), Logger.msgType.Error);
            }
            else
            {
                Logger.Log("Test Finished! ", Logger.msgType.Passed);
            }
        }

        /// <summary>
        /// Shutdown WebDriver
        /// </summary>
        public void DriverCleanup()
        {
           Driver.Instance= Driver.Instance.Shutdown();
        }
    }
}
