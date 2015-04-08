using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEBUIautomation.WebElement
{
    public class WebElementNotFoundException : Exception
    {
        public WebElementNotFoundException(string message)
            : base(message)
        {
        }
    }
}
