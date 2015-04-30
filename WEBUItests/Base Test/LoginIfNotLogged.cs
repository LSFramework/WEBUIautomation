using NUnit.Framework;
using System;
using WEBPages.Pages;
using WEBUIautomation.Utils;
using WEBUItests.TestVariables;

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

        MainHead mainHead=new MainHead();
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
                DoLogin();
            }

            if ( ! mainHead.PageCanGetFocus())
            {                
                DriverCleanup();
                DriverSetUp();
                DoLogin();
            }
        }

        private void DoLogin()
        {
            mainHead = new ALMainPage().GoToMyPC(Config.MyPCUrl).LoginToProject(Config.UserName, Config.UserPassword, Config.DomainName, Config.ProjectName);           
        }


        /// <summary>
        /// Target of the attribute
        /// </summary>
        public ActionTargets Targets
        {
            get { return ActionTargets.Suite; }
        }
        
        /// <summary>
        /// Inits WebDriver instance
        /// </summary>
        public void DriverSetUp()
        {
            
                Driver.Initialize(Variables.BROWSER);               
                Driver.BrowserMaximize();
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
