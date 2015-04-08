using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBUIautomation;

namespace WEBUItests
{
    /// <summary>
    /// To use the same test variables between fixtures
    /// </summary>
    public static partial class Const
    {
        /// <summary>
        ///  A browser to be used under test  
        /// </summary>
        public static Browsers BROWSER
        { get { return WebDriverBrowser.getBrowserFromString(Config.BrowsersSet[0]); } }
    }
}
