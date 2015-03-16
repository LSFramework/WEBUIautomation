//using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBUIautomation;
using WEBUIautomation.Utils;


namespace WEBUItests
{
    public static class Const
    {
        public const Browser BROWSER = Browser.IE;
    }

    public abstract class WEBUItest
    {
        [TestFixtureSetUp]
        public void Initialize()
        {
            Driver.Initialize(Const.BROWSER);
            Logger.Log("Starting Test Set", Logger.msgType.Message);            
            Properties.Create();
            Properties.Read();            
            Driver.BrowserMaximize();          
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
                Logger.Log("The step: " + NUnit.Framework.TestContext.CurrentContext.Test.Name + " failed!", Logger.msgType.Error);
                Logger.Log("Snapshot is: " + Snapshot.Take(), Logger.msgType.Error);
            }
            else
            {
                Logger.Log("Test Finished! ", Logger.msgType.Passed);
            }
        }

        [TestFixtureTearDown]
        public void Cleanup()
        {
            Driver.Wait(3);
            Driver.Close();
        }
    }
}
