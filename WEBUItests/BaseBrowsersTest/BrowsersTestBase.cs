using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBUIautomation;
using WEBUIautomation.Utils;
using WEBUItests.BaseBrowsersTest;
using WEBUItests.BrowserStack;

namespace WEBUItests
{
    
    [BrowserStackFixture("BrowserProvider")]
    public abstract class BrowsersTestBase
    {
        protected Browser defaultBrowser;   

        protected void FixtureSetUp(string browser)
        {
            Logger.Log("Starting Test Set on " + browser, Logger.msgType.Message);
            defaultBrowser = WebDriverBrowser.getBrowserFromString(browser);            
        }

        [TestFixtureSetUp]
        protected void TestFixtureSetUp()
        {
            Properties.Create();
            Properties.Read();
            Driver.Initialize(defaultBrowser);
        }

        /// <summary>
        ///  Gets info from WEBUItests.config file
        /// </summary>
        /// <returns>Returns set of brosers to testing</returns>
        public static List<string> BrowserProvider()
        {
            return Config.BrowsersSet;
        }

        [SetUp]
        public void SetUp()
        {
            if(Driver.Instance==null)
            {
                Driver.Initialize(Browser.Firefox);
                Driver.BrowserMaximize();
            }    
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
