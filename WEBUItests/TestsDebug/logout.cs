using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBPages.MyPCPages;
using WEBUIautomation.Utils;
using WEBUItests.Base_Test;

namespace WEBUItests.TestsDebug
{
    /// <summary>
    /// Logout from project
    /// </summary>
    [TestFixture]
    public class Test_Last_Logout : WEBUItest
    {

        MainHead mainHead = new MainHead();

        /// <summary>
        /// Performs click on logout button
        /// </summary>
        [Test]
        public void Logout()
        {
            if (Driver.Instance != null)
                mainHead.ClickLogout();
        }

        /// <summary>
        /// Closes WebDriver
        /// </summary>
        [TestFixtureTearDown]
        public void FixtureTearDown()
        {
            base.DriverCleanup();
        }
    }
}
