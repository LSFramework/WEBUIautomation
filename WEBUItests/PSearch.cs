using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBUIautomation;
using WEBUIautomation.Pages;
using WEBUIautomation.Utils;

namespace WEBUItests
{
    [TestFixture]
    public class PSearch : WEBUItest
    {
        [Test]
        public void SearchTest()
        {
            PLoginPage.Login();
            PLoginPage.Search("project");
            //PLoginPage.ProjectExists("Project Management");

            Assert.IsTrue(PLoginPage.IsPackExists("Project Management"));

            Assert.IsTrue(PLoginPage.IsAppExists("Projects"));

            Assert.IsTrue(PLoginPage.AppsExist(new string[] {"Projects", "Deliverables", "Design Approvals", "Inspiration"}));
        }
    }
}
