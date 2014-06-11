using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEBUIautomation
{
    public class DriverWait
    {
        public static WebDriverWait Instance { get; private set; }

        public static void Initialize(int seconds)
        {
            Instance = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(seconds));
        }
    }
}
