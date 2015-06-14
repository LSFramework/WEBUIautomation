using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBPages.BasePageObject;
using WEBPages.MyPCPages;
using WEBPages.MyPCPages.DesignLoadTest;
using WEBPages.MyPCPages.Online;
using WEBPages.MyPCPages.TestRunDialog;
using WEBUItests.Base_Test;

namespace WEBUItests.TestsDebug
{

#pragma warning disable 1591
    [TestFixture]
    public class WaitForTestRun :WEBUItest //BrowsersTestBase
    {
         string testName = "Performance Test_d077c20a-b";
         StartTab startTab;
         DLT dlt;

       
        /// Start tab
        ///// </summary>
        //[Test]
        //public void Step_01_NavigateToStart()
        //{
        //    startTab = new StartTab();
        //    Assert.True(startTab.ViewOpened);
        //}
        //  [Test]
        //public void Step_02_NavigateDLT()
        //{
        //    dlt=startTab.ClickTestLinkFinishedTest(testName);
        //}
        //  [Test]
        //public void Step_03_StartTest()
        //{
        //    dlt.Workload.Run();        
        //}
        //  [Test]
        //public void Step_04_Run()
        //{
        //    StartRunDialog start = new StartRunDialog();
        //    start.StartRunTestIfAvailable();
        //    OnlineScreen online = new OnlineScreen(new LoadTest(testName));
        //    online.WaitForTestFinished();
        //    online.CloseButtonClick();
        //}

        [Test]
          public void Complex([Range(0,9)] int Itearation)
          {
              startTab = new StartTab();
              dlt = startTab.ClickLastModifiedTest(testName);

              dlt.Workload.Run();
              StartRunDialog start = new StartRunDialog();
              start.StartRunTestIfAvailable();
              OnlineScreen online = new OnlineScreen(new LoadTest(testName));
              online.WaitForTestFinished();
              online.CloseButtonClick();
        }

    }
#pragma warning disable 1591
}
