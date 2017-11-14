using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace SeleniumDemo.Tests
{
    [TestClass]
    public class SeleniumDemoTestFirefox : SeleniumDemoBase
    {
        [ClassInitialize]
        public static void Setup(TestContext testContext)
        {
            CurrentBrowser = Browser.Firefox;
            TestDriver = new SeleniumDemoWebDriver(CurrentBrowser);
            Directory.SetCurrentDirectory(testContext.TestRunResultsDirectory);
            Waiter.BrowserUpdate = 1500;
        }

        [ClassCleanup]
        public static void TearDown()
        {
            TestDriver.TearDown();
            TestDriver = null;
        }
    }
}