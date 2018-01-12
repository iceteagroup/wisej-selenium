using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumDemo.Tests
{
    [TestClass]
    public class SeleniumDemoTestChrome : SeleniumDemoBase
    {
        [ClassInitialize]
        public static void Setup(TestContext testContext)
        {
            var options = new ChromeOptions
            {
                PageLoadStrategy = PageLoadStrategy.Default
            };
            CurrentBrowser = Browser.Chrome;
            TestDriver = new SeleniumDemoWebDriver(CurrentBrowser, options);
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