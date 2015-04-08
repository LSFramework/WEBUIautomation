using NUnit.Framework;
using System;
using WEBPages.Pages;

namespace WEBUItests
{
    //using Logger = WEBUIautomation.Utils.Logger;   

    
    /// <summary>
    /// Implements reusible methods to login MyPC
    /// All tests should be inherit this class in case if the tests check PC functionality
    /// </summary>
   // [TestFixture]
    //public abstract class LoginInMyPC : WEBUItest
    //{
    //    const string expMyPcOpened = "MastheadDiv";

    //    /// <summary>
    //    /// The method runs before all tests
    //    /// </summary>
    //    [TestFixtureSetUp]
    //    public void FixtureSetUp()
    //    {

    //        base.TestSetUp();
    //        GoToMyPC_URL();
    //        UserAuthenticate();
    //        LoginToSelectedProject();
    //        CheckIsUserLoggedToProject();


    //        // Logger.Log(e.Message, Logger.msgType.Error);
    //        // this.FixtureTearDown(); 

    //    }

    //    #region To login

    //    /// <summary>
    //    /// Opens MyPC Login Page from ALM server
    //    /// </summary>
    //    public void GoToMyPC_URL()
    //    {
    //        ALMainPage.GoToMyPC(Config.MyPCUrl);
    //    }

    //    /// <summary>
    //    ///  Authenticate User to ALM
    //    /// </summary>
    //    public void UserAuthenticate()
    //    {
    //        MyPCLoginPage.TypeUserName(Config.UserName);
    //        MyPCLoginPage.TypePassword(Config.UserPassword);
    //        MyPCLoginPage.ClickAuthenticate();
    //        // System.Threading.Thread.Sleep(2000);
    //    }

    //    /// <summary>
    //    /// Select Domain and Project and login to
    //    /// </summary>
    //    public void LoginToSelectedProject()
    //    {
    //        MyPCLoginPage.SelectDomain(Config.DomainName);
    //        MyPCLoginPage.SelectProject(Config.ProjectName);
    //        MyPCLoginPage.ClickLogin();
    //        MyPCLoginPage.SwitchToPopup();
    //    }

    //    /// <summary>
    //    /// Checks is user really logged in the project and domain were selected at LoginPage.
    //    /// </summary>
    //    public void CheckIsUserLoggedToProject()
    //    {
    //        // System.Threading.Thread.Sleep(500);
            
    //        Assert.True( // Check that userName, Domain and Project are shown on page as expected
    //            MainHead.GetDomainName().Contains(Config.DomainName)
    //        && MainHead.GetProjectName().Contains(Config.ProjectName)
    //        && MainHead.GetUserLoggedIn().Contains(Config.UserName));
    //    }

    //    #endregion /To Login

    //    /// <summary>
    //    /// After all tests in the fixture
    //    /// </summary>
    //    [TestFixtureTearDown]
    //    public void FixtureTearDown()
    //    {
    //        base.TearDown();
    //        base.DriverCleanup();
    //    }
    //}
}
