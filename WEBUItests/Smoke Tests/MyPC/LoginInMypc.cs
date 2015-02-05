using NUnit.Framework;
using WEBUIautomation.Utils;
using WEBPages.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace WEBUItests.Smoke_Tests
{
    [TestFixture]
    public class LoginInMypc : WEBUItest
    {
        [Test]
        public void Login_In_MyPC()
        {
            ALMainPage.GoToMyPC(Properties.QCServer, Properties.ServerPort);
            MyPCLoginPage.UserNameField.Clear();
            MyPCLoginPage.UserNameField.SendKeys(Properties.UserName);
            MyPCLoginPage.PasswordField.Clear();
            MyPCLoginPage.PasswordField.SendKeys(Properties.UserPassword);
            MyPCLoginPage.AuthenticateBtn.Click();
            MyPCLoginPage.SelectDomain(Properties.DomainName);
            MyPCLoginPage.SelectProject(Properties.ProjectName);
            MyPCLoginPage.LoginBtn.Click();
            MyPCNavigation.SwitchToPopup();
            MyPCNavigation.LogoutBtn.Click();
        }
    }
}
