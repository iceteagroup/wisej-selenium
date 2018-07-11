using System.IO;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace Wisej.SeleniumTestExample
{
    public class ProgressSampleTestsFirefox : ProgressSampleBase
    {
        [OneTimeSetUp]
        public static void Setup()
        {
            var options = new FirefoxOptions
            {
                PageLoadStrategy = PageLoadStrategy.Default
            };
            TestDriver = new ProgressSampleWebDriver(Browser.Firefox, options);

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