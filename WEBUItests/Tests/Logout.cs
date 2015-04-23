using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBPages.Pages;
using WEBUIautomation.Utils;
using WEBUItests.Base_Test;

namespace WEBUItests.MyPCTests.Test_Last_Logout
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
