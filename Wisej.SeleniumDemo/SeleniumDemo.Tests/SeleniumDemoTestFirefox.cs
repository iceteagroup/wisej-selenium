using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace SeleniumDemo.Tests
{
    [TestClass]
    public class SeleniumDemoTestFirefox : SeleniumDemoBase
    {
        [ClassInitialize]
        public static void Setup(TestContext testContext)
        {
            var options = new FirefoxOptions
            {
                PageLoadStrategy = PageLoadStrategy.Eager
            };
            CurrentBrowser = Browser.Firefox;
            TestDriver = new SeleniumDemoWebDriver(CurrentBrowser, options);
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