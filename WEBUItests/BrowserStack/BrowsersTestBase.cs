using NUnit.Framework;
using System.Collections.Generic;
using WEBUIautomation;
using WEBUIautomation.Utils;
using WEBUIautomation.Extensions;
using WEBUItests.BrowserStack;
using WEBUItests.TestVariables;
using System.Diagnostics;
using WEBPages.MyPCPages;
using WEBUItests.Base_Test;


namespace WEBUItests
{

    /// <summary>
    /// The fixture to generate another fixtures
    /// </summary>
    [BrowserStackFixture("BrowserProvider")]
    [LoginIfNotLogged]
    public abstract class BrowsersTestBase
    {
        /// <summary>
        /// Constant marker of a browser to be used in an instance of inherited class
        /// </summary>
        public Browsers defaultBrowser {get; set;}

        MainHead mainHead = new MainHead();

        /// <summary>
        ///  Gets info from WEBUItests.dll.config file
        /// </summary>
        /// <returns>Returns set of brosers to testing</returns>
        public static List<string> BrowserProvider() { return Config.BrowsersSet; }

        /// <summary>
        /// The method will be called from BrowserTestFixture class 
        /// to create instances of a class that inherites this class
        /// with parameter "browser" from "BrowserProvider"
        /// </summary>
        /// <param name="browser"></param>
        [TestFixtureSetUp]
        protected void FixtureSetUp(string browser)
        {
            
            defaultBrowser = Extensions.GetEnumFromString<Browsers>(browser);
            //StaticVariables.BROWSER = defaultBrowser;

            Logger.Log("Starting Test Set on " + defaultBrowser.GetEnumDescription(), Logger.msgType.Message);

            if (Driver.Instance == null)
            {
                DriverSetUp(defaultBrowser);
                DoLogin();
            }

            if (mainHead.ModalOpened)
            {
                DriverCleanup();
                DriverSetUp(defaultBrowser);
                DoLogin();
            }
        }


        private void DoLogin()
        {
            mainHead = new ALMainPage()
                .GoToMyPC(Config.MyPCUrl)
                .LoginToProject(Config.UserName, Config.UserPassword, Config.DomainName, Config.ProjectName);

        }
        /// <summary>
        /// Inits WebDriver instance
        /// </summary>
        public void DriverSetUp(Browsers browser)
        {
            Driver.Initialize(browser);
            Driver.Instance.BrowserMaximize();
        }

        /// <summary>
        /// Shutdown WebDriver
        /// </summary>
        public void DriverCleanup()
        {
          Driver.Instance =  Driver.Instance.Shutdown();
        }

        /// <summary>
        /// Starts fixture before all tests
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            Logger.Log("Starting Test: " + NUnit.Framework.TestContext.CurrentContext.Test.Name, Logger.msgType.Message);
        }


        /// <summary>
        /// After all tests
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
        /// Cleanup WebDriver after all tests
        /// </summary>
        [TestFixtureTearDown]
        public void Cleanup()
        {
            Driver.Instance= Driver.Instance.Shutdown();
        }
    }
}
