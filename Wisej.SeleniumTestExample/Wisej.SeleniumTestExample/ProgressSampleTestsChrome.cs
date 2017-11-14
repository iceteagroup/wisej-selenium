using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace Wisej.SeleniumTestExample
{
    [TestClass]
    public class ProgressSampleTestsChrome : ProgressSampleBase
    {
        [ClassInitialize]
        public static void Setup(TestContext testContext)
        {
            TestDriver = new ProgressSampleWebDriver(Browser.Chrome);
            //TestDriver.Manage().Window.Maximize();
            Directory.SetCurrentDirectory(testContext.TestRunResultsDirectory);
        }

        [ClassCleanup]
        public static void TearDown()
        {
            TestDriver.TearDown();
            TestDriver = null;
        }
    }
}