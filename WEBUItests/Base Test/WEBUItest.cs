//using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;
using WEBUIautomation;
using WEBUIautomation.Utils;
using System.IO;
using NUnit.Core;
using System.Collections;

namespace WEBUItests
{

    using Logger= WEBUIautomation.Utils.Logger;   


    /// <summary>
    /// Base test to use with WebDriver
    /// </summary>
    public abstract class WEBUItest
    {

        
        protected static Object locker = new object();
        /// <summary>
        /// Inits WebDriver instance
        /// </summary>
        public static void TestFixtureSetUp()
        {
            lock (locker)
            {
                Driver.Instance = null;
                Driver.Initialize(TestContextVariables.BROWSER);
                Logger.Log("Starting Test Set", Logger.msgType.Message);
                Properties.Create();
                Properties.Read();
                Driver.BrowserMaximize();
            }        
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
        //[TestFixtureTearDown]
        public void Cleanup()
        {
            Driver.Wait(1);
            Driver.Close();
        }
    }
}