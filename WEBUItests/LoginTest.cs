using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WEBUIautomation;

namespace WEBUItests
{
    [TestClass]
    public class LoginTest : WEBUItest
    {
        [TestMethod]
        public void Login_In_Webui()
        {
            LoginPage.GoTo(Properties.QCServer);
            LoginPage.EnterName(Properties.UserName);
            LoginPage.EnterPassword(Properties.UserPasswod);

            LoginPage.Authenticate();
            LoginPage.SelectDomain(Properties.Domain);
            LoginPage.SelectProject(Properties.ProjectName);
            LoginPage.Submit();

            Assert.IsTrue(AlmHeader.IsAt, "failed to login");
            Assert.IsTrue(AlmHeader.ValidateUsername(Properties.UserName), "wrong username");
            Assert.IsTrue(AlmHeader.ValidateLogin(Properties.Domain, Properties.ProjectName), "wrong domain/project");

        }
        
        [TestMethod]
        public void Change_ProjectDomain()
        {
            LoginPage.LoginFlow();
            AlmHeader.ChangeProjectDomain("vuds_1", "ALEXG");

            Assert.IsTrue(AlmHeader.IsAt, "failed to login");
            Assert.IsTrue(AlmHeader.ValidateUsername(Properties.UserName), "wrong username");
            Assert.IsTrue(AlmHeader.ValidateLogin("ALEXG", "vuds_1"), "wrong domain/project");
        }        
    }
}
