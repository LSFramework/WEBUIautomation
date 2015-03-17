using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBUIautomation.Utils;

namespace WEBPages.Pages
{
    public interface IPageBase
    {
        IWebDriverExt driver { get; }
    }

    public class PageBase //
    {
        public static IWebDriverExt driver
        {
            get { return Driver.Instance; }
        }
    }
}
