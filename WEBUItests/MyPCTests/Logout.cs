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
    /// Logout from project
    /// </summary>
    [TestFixture]
    public class Test_Last_Logout : WEBUItest
    {
        /// <summary>
        /// Performs click on logout button
        /// </summary>
        [Test]
        public void Logout()
        {
            if (Driver.Instance != null)
            MainHead.ClickLogout();
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
