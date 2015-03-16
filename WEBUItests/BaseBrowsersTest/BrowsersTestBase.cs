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
        /// <summary>
        /// Constant marker of a browser to be used in an instance of inherited class
        /// </summary>
        public Browser defaultBrowser{get;set;}

        /// <summary>
        ///  Gets info from WEBUItests.config file
        /// </summary>
        /// <returns>Returns set of brosers to testing</returns>
        public static List<string> BrowserProvider() { return Config.BrowsersSet; }
        

        /// <summary>
        /// The method will be called from BrowserTestFixture class 
        /// to create instances of a class that inherites this class
        /// with parameter <browser> from <BrowserProvider>
        /// </summary>
        /// <param name="browser"></param>
        [TestFixtureSetUp]
        protected void FixtureSetUp(string browser)
        {
            defaultBrowser = WebDriverBrowser.getBrowserFromString(browser);
            Logger.Log("Starting Test Set on " + defaultBrowser, Logger.msgType.Message);
            Driver.Initialize(defaultBrowser);
            Driver.BrowserMaximize();
            Properties.Create();
            Properties.Read();
        }

        //[TestFixtureSetUp]
        //protected void thisFixtureSetUp()        
        //{
        //    Logger.Log("Starting Test Set on " + defaultBrowser, Logger.msgType.Message);            
        //    Driver.Initialize(defaultBrowser);
        //    Driver.BrowserMaximize();
        //    Properties.Create();
        //    Properties.Read();
        //}


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
