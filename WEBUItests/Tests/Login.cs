using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBPages.Pages;
using WEBUIautomation.Utils;
using WEBUItests.Base_Test;

namespace WEBUItests.MyPCTests.Test_0_Login
{
    /// <summary>
    /// Login to project
    /// </summary>
    [TestFixture][LoginIfNotLogged]
    public class Test_0_Login : WEBUItest
    {

        MainHead mainHead = new MainHead();

        /// <summary>
        /// Checks is user really logged in the project and domain were selected at LoginPage.
        /// </summary>
        [Test]
        public void CheckIsUserLoggedToProject()
        {
            Assert.True(
                // Check that userName, Domain and Project are shown on page as expected
                mainHead.GetDomainName().Contains(Config.DomainName)
            && mainHead.GetProjectName().Contains(Config.ProjectName)
            && mainHead.GetUserLoggedIn().Contains(Config.UserName));
        }
    }
}
