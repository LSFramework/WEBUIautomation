using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBUIautomation;

namespace WEBUItests
{
    public class WEBUItest
    {
        [TestInitialize]
        public void Initialize()
        {
            Driver.Initialize();
            DriverWait.Initialize(10);
        }


        [TestCleanup]
        public void Cleanup()
        {
            Driver.Wait(5);
            Driver.Close();
        }
    }
}
