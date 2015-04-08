using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBPages.Pages;
using WEBUIautomation.Utils;
using WEBUItests.Base_Test;

namespace WEBUItests.MyPCTests
{
    /// <summary>
    /// Login to project
    /// </summary>
    [TestFixture][LoginIfNotLogged]
    public class Test_0_Login : WEBUItest
    {
        /// <summary>
        /// Checks is user really logged in the project and domain were selected at LoginPage.
        /// </summary>
        [Test]
        public void CheckIsUserLoggedToProject()
        {
            Assert.True(
                // Check that userName, Domain and Project are shown on page as expected
                MainHead.GetDomainName().Contains(Config.DomainName)
            && MainHead.GetProjectName().Contains(Config.ProjectName)
            && MainHead.GetUserLoggedIn().Contains(Config.UserName));
        }
    }
}
