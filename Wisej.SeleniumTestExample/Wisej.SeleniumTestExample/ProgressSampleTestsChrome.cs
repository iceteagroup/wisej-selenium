using System.IO;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Wisej.SeleniumTestExample
{
    public class ProgressSampleTestsChrome : ProgressSampleBase
    {
        [OneTimeSetUp]
        public static void Setup()
        {
            var options = new ChromeOptions
            {
                PageLoadStrategy = PageLoadStrategy.Default
            };
            TestDriver = new ProgressSampleWebDriver(Browser.Chrome, options);

            SetupTestOutputFolder();

            Directory.SetCurrentDirectory(TestOutputFolder);
        }

        [OneTimeTearDown]
        public static void TearDown()
        {
            TearDownTestOutputFolder();

            TestDriver.TearDown();
            TestDriver = null;
        }
    }
}