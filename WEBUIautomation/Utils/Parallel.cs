using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Threading;

namespace WEBUIautomation.Utils
{
    //public class LocalDriverFactory
    //{
    //    public static IWebDriver CreateInstance(String browserName)
    //    {
    //        IWebDriver driver = null;
    //        if (browserName.ToLower().Contains("firefox"))
    //        {
    //           // Driver.Initialize();
    //            driver = new FirefoxDriverExt();
    //            return Driver.Instance;
    //        }
    //        if (browserName.ToLower().Contains("internet"))
    //        {
    //            driver = new InternetExplorerDriverExt(@"C:\Utils");
    //            return driver;
    //        }
    //        if (browserName.ToLower().Contains("chrome"))
    //        {
    //            driver = new ChromeDriverExt(@"C:\Utils");
    //            return driver;
    //        }
    //        return driver;
    //    }
    //}

    public class LocalDriverManager
    {
        private static ThreadLocal<IWebDriver> webDriver = new ThreadLocal<IWebDriver>();

        public static IWebDriver GetDriver()
        {
            return webDriver.Value;
        }

        public static void SetWebDriver(IWebDriver driver)
        {
            webDriver.Value = driver;
        }
    }

//    public class WebDriverListener : ITestAction 
//    {
//        public ActionTargets Targets { get { return ActionTargets.Test | ActionTargets.Suite; } }

//        public void BeforeTest(TestDetails testDetails) 
//        {
//            if (testDetails.Method.IsPublic)
//            {
//                //String browserName = TestContext.CurrentContext.//testDetails.Method.GetParameters().GetHashCode().ToString();//method.getTestMethod().getXmlTest().getLocalParameters().get("browserName");
//                IWebDriver driver = LocalDriverFactory.CreateInstance("firefox");
//                LocalDriverManager.SetWebDriver(driver);
//            }
//        }


//        public void AfterTest(TestDetails testDetails)
//        {
//            if (testDetails.Method.IsPublic) {
//                IWebDriver driver = LocalDriverManager.GetDriver();
//                if (driver != null) {
//                    driver.Dispose();
//                }
//            }
//        }
//}
}
