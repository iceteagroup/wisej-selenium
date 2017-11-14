using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace Wisej.SeleniumTestExample
{
    [TestClass]
    public class ProgressSampleTestsEdge : ProgressSampleBase
    {
        [ClassInitialize]
        public static void Setup(TestContext testContext)
        {
            TestDriver = new ProgressSampleWebDriver(Browser.Edge);
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