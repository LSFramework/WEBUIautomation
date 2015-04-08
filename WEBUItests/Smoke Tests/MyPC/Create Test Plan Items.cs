using NUnit.Framework;
using OpenQA.Selenium;
using System;
using WEBPages.Pages;


namespace WEBUItests
{
    /// <summary>
    /// The fixture to test a possibility to create test plan entities
    /// Such as folders, performance test, upload script.
    /// </summary>
    //[TestFixture]
    //public class Test_3_Create_Test_Plan_Items : WEBUItest
    //{
    //    const string expTestSaved = @".//*[@id='ctl00_PageContent_lblStatus'][contains(text(),'Test saved')]";
    //    const string pathToScript = @"C:\ins\CloudSanityScript.zip";

    //    static string scriptFolder = "scripts_" + Guid.NewGuid().ToString();
    //    static string testFolder = "tests_" + Guid.NewGuid().ToString();
    //    static string testName = "test_" + Guid.NewGuid().ToString();

    //    #region To Create Test Plan

    //    /// <summary>
    //    /// Navigate to Test Plan perspective
    //    /// </summary>
    //    [Test]
    //    public void Step_1_NaviagateToTestPlan()
    //    {
    //        Assert.IsInstanceOf<IWebElement>(TestPlan.TreePanel);
    //    }

    //    /// <summary>
    //    /// Creates folders in Test Plan Tree
    //    /// </summary>
    //    [Test]
    //    public void Step_2_CreateTheFolders()
    //    {
    //        TestPlan.CreateNewFolder(testFolder);
    //        TestPlan.CreateNewFolder(scriptFolder);
    //    }
    //    /// <summary>
    //    ///  Upload a script
    //    /// </summary>
    //    [Test]
    //    public void Step_3_UploadScript()
    //    {
    //        TestPlan.UploadScript(pathToScript, scriptFolder);
    //    }

    //    /// <summary>
    //    /// Create a performance test
    //    /// </summary>
    //    [Test]
    //    public void Step_4_CreatePerformanceTest()
    //    {
    //        TestPlan.CreateNewTest(testName, testFolder);
    //    }

    //    /// <summary>
    //    /// Check is DLT page opened after a performance test was created
    //    /// </summary>
    //    [Test]
    //    public void Step_5_CheckTheDLTScreenWithWorkloadTypeDialogIsOpened()
    //    {
    //        IWebElement element = DesignLoadTest.Workload.WorkloadTypeDialog.btnOK;
    //        element.Click();
    //        MainHead.CloseDLT_Tab();
    //    }

    //    #endregion
    //}
}
