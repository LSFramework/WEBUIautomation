using NUnit.Framework;
using WEBUIautomation.Utils;
using WEBPages.Pages;

namespace WEBUItests.Smoke_Tests
{
    [TestFixture]
    public class LoginInMypc : WEBUItest
    {
        [Test]
        public void Login_In_MyPC()
        {
            ALMainPage.GoToMyPC(Properties.QCServer, Properties.ServerPort);            
            MyPCLoginPage.EnterName(Properties.UserName);        
            MyPCLoginPage.EnterPassword(Properties.UserPassword);
            MyPCLoginPage.Authenticate();
            MyPCLoginPage.SelectDomain(Properties.DomainName);
            MyPCLoginPage.SelectProject(Properties.ProjectName);            
            MyPCLoginPage.Submit();
            MyPCNavigation.Logout();
        }
    }
}
