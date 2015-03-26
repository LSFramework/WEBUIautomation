using NUnit.Framework;
using WEBUIautomation.Utils;
using WEBPages.Pages;

namespace WEBUItests.Smoke_Tests
{
    /// <summary>
    /// Implements reusible methods to login MyPC
    /// </summary>
    [TestFixture]
    public abstract class LoginInMyPC : WEBUItest
    {
        const string expMyPcOpened = "MastheadDiv";

        /// <summary>
        /// The method runs before all tests
        /// </summary>
        [TestFixtureSetUp]
        public void FixtureSetUp()
        {
            
            WEBUItest.TestFixtureSetUp();
            GoToMyPC_URL();
            UserAuthenticate();
            LoginToSelectedProject();
            CheckIsUserLoggedToProject();
        }

        #region To login

        /// <summary>
        /// Opens MyPC Login Page from ALM server
        /// </summary>
        public void GoToMyPC_URL()
        {
            ALMainPage.GoToMyPC(Properties.QCServer, Properties.ServerPort);            
        }

        /// <summary>
        ///  Authenticate User to ALM
        /// </summary>
        public void UserAuthenticate()
        {
            MyPCLoginPage.TypeUserName(Properties.UserName);
            MyPCLoginPage.TypePassword(Properties.UserPassword);
            MyPCLoginPage.ClickAuthenticate();           
        }

        /// <summary>
        /// Select Domain and Project and login to
        /// </summary>
        public void LoginToSelectedProject()
        { 
            MyPCLoginPage.SelectDomain(Properties.DomainName);
            MyPCLoginPage.SelectProject(Properties.ProjectName);
            MyPCLoginPage.ClickLogin();
        }       

        /// <summary>
        /// Checks is user really logged in the project and domain were selected at LoginPage.
        /// </summary>
        public void CheckIsUserLoggedToProject()
        {
            System.Threading.Thread.Sleep(500);
            MyPCNavigation.SwitchToPopup();
            Assert.True( // Check that userName, Domain and Project are shown on page as expected
                MyPCNavigation.GetDomainName().Contains(Properties.DomainName)
            &&  MyPCNavigation.GetProjectName().Contains(Properties.ProjectName)
            &&  MyPCNavigation.GetUserLoggedIn().Contains(Properties.UserName));
        }
       
        #endregion /To Login      
        [TestFixtureTearDown]
        public void FixtureTearDown()
        {
            base.Cleanup();
        }
    }
}
