using System.IO;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace Wisej.SeleniumTestExample
{
    public class ProgressSampleTestsEdge : ProgressSampleBase
    {
        [OneTimeSetUp]
        public static void Setup()
        {
            var options = new EdgeOptions
            {
                PageLoadStrategy = PageLoadStrategy.Default
            };
            TestDriver = new ProgressSampleWebDriver(Browser.Edge, options);

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