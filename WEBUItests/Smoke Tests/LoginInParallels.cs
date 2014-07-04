using NUnit.Framework;
using WEBUIautomation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEBUItests.Smoke_Tests
{
    [TestFixture]
    public class LoginInParallels : WEBUItest
    {
        [Test]
        public void Login1()
        {
            LoginPage.LoginFlow();
        }

        [Test]
        public void Login2()
        {
            LoginPage.LoginFlow();
        }
    }
}
