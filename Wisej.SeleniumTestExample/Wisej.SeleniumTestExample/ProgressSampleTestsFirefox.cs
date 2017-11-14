using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace Wisej.SeleniumTestExample
{
    [TestClass]
    public class ProgressSampleTestsFirefox : ProgressSampleBase
    {
        [ClassInitialize]
        public static void Setup(TestContext testContext)
        {
            TestDriver = new ProgressSampleWebDriver(Browser.Firefox);
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