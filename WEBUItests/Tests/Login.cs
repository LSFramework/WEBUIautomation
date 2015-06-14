using NUnit.Framework;
using WEBPages.MyPCPages;
using WEBUItests.Base_Test;
using WEBUItests.TestVariables;

namespace WEBUItests.MyPCTests.Test_0_Login
{
    /// <summary>
    /// Checks is user really logged in the project and domain were selected at LoginPage.
    /// </summary>
    [TestFixture]
    public class Test_0_Login : WEBUItest
    {

        MainHead mainHead = new MainHead();

        /// <summary>
        /// Check domain
        /// </summary>
        [Test]
        public void CheckDomain()
        {
            string Expected = string.Format("Domain: {0},", Config.DomainName);
            Assert.AreEqual(Expected, mainHead.GetDomainName());  
        }

        /// <summary>
        /// Check project
        /// </summary>
        [Test]
        public void CheckProject()
        {
            string Expected = string.Format("Project: {0}", Config.ProjectName);
            Assert.AreEqual(Expected, mainHead.GetProjectName());
        }

        /// <summary>
        /// Check user name
        /// </summary>
        [Test]
        public void CheckUserName()
        {
            string Expected = string.Format("Hello {0}", Config.UserName);
            Assert.AreEqual(Expected, mainHead.GetUserLoggedIn());
        }
    }
}
