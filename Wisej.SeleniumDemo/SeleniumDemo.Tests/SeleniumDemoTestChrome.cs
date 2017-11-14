using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace SeleniumDemo.Tests
{
    [TestClass]
    public class SeleniumDemoTestChrome : SeleniumDemoBase
    {
        [ClassInitialize]
        public static void Setup(TestContext testContext)
        {
            CurrentBrowser = Browser.Chrome;
            TestDriver = new SeleniumDemoWebDriver(CurrentBrowser);
            TestDriver.Manage().Window.Maximize();
            Directory.SetCurrentDirectory(testContext.TestRunResultsDirectory);
            Waiter.BrowserUpdate = 350;
        }

        [ClassCleanup]
        public static void TearDown()
        {
            TestDriver.TearDown();
            TestDriver = null;
        }
    }
}