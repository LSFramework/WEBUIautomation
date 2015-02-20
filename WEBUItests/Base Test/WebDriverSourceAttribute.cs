using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBUIautomation.Utils;

namespace WEBUItests.Base_Test
{
    public class WebDriverSourceAttribute : TestCaseSourceAttribute
    {
        public WebDriverSourceAttribute() : base(typeof(WebDriverFactory), "Drivers")
        {
        }
    }
}
