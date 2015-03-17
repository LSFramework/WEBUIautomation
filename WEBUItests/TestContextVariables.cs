using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBUIautomation;

namespace WEBUItests
{
    /// <summary>
    /// To use same variables between fixtures
    /// </summary>
    public static class TestContextVariables
    {
        /// A browser to be used under test       
        public const Browser BROWSER = Browser.IE;
    }
}
