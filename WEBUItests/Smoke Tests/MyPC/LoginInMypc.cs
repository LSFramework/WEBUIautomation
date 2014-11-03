using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBUIautomation;
using WEBUIautomation.Utils;

namespace WEBUItests.Smoke_Tests
{
    [TestFixture]
    public class LoginInMypc : WEBUItest
    {
        [Test]
        public void Login_In_MyPC()
        {
            LoginPage.GoTo(Properties.QCServer, Properties.ServerPort);
            LoginPage.EnterName(Properties.UserName);
            //Snapshot.Take("snapshot1");
            LoginPage.EnterPassword(Properties.UserPassword);
            LoginPage.Authenticate();
            LoginPage.SelectDomain(Properties.DomainName);
            LoginPage.SelectProject(Properties.ProjectName);
            //Snapshot.Take();
            LoginPage.Submit();

            //Assert.AreEqual();
        }
    }
}
