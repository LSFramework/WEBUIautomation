using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBPages.Pages;
using WEBUIautomation.Utils;

namespace WEBUItests.Base_Test
{
    /// <summary>
    /// Performs Login if not logged yet
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class |
                AttributeTargets.Interface | AttributeTargets.Assembly,
                AllowMultiple = true)]
    public class LoginIfNotLoggedAttribute:Attribute, ITestAction
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public LoginIfNotLoggedAttribute() { }
        
        /// <summary>
        /// Agter all tests
        /// </summary>
        /// <param name="testDetails"></param>
        public void AfterTest(TestDetails testDetails){ }


        /// <summary>
        /// Before all tests in a fixture
        /// </summary>
        /// <param name="testDetails"></param>
        public void BeforeTest(TestDetails testDetails)
        { 
            if (Driver.Instance == null)
            {
                DriverSetUp();

                ALMainPage almMainPage = new ALMainPage();
                almMainPage.GoToMyPC(Config.MyPCUrl);
                MyPCLoginPage loginPage = new MyPCLoginPage();
                loginPage.LoginToProject(Config.UserName, Config.UserPassword, Config.DomainName, Config.ProjectName);
            }

            if (!MainHead.PageCanGetFocus())
            {                
                DriverCleanup();
                DriverSetUp();

                ALMainPage almMainPage = new ALMainPage();
                almMainPage.GoToMyPC(Config.MyPCUrl);

                MyPCLoginPage loginPage = new MyPCLoginPage();
                loginPage.LoginToProject(Config.UserName, Config.UserPassword, Config.DomainName, Config.ProjectName);
            }
        }


        /// <summary>
        /// Target of the attribute
        /// </summary>
        public ActionTargets Targets
        {
            get { return ActionTargets.Suite; }
        }


        /// <summary>
        /// Locker to create a new WebDriver instance
        /// </summary>
        protected static Object locker = new object();
        /// <summary>
        /// Inits WebDriver instance
        /// </summary>
        public void DriverSetUp()
        {
            lock (locker)
            {
                Driver.Instance = null;
                Driver.Initialize(Const.BROWSER);               
                Driver.BrowserMaximize();
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
