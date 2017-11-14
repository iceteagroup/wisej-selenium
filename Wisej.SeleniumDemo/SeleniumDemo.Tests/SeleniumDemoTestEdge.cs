using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace SeleniumDemo.Tests
{
    [TestClass]
    public class SeleniumDemoTestEdge : SeleniumDemoBase
    {
        [ClassInitialize]
        public static void Setup(TestContext testContext)
        {
            CurrentBrowser = Browser.Edge;
            TestDriver = new SeleniumDemoWebDriver(CurrentBrowser);
            TestDriver.Manage().Window.Maximize();
            Directory.SetCurrentDirectory(testContext.TestRunResultsDirectory);
            Waiter.BrowserUpdate = 2500;
        }

        [ClassCleanup]
        public static void TearDown()
        {
            TestDriver.TearDown();
            TestDriver = null;
        }
    }
}