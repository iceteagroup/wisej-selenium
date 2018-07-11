using System.Drawing;
using System.IO;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace SeleniumDemo.Tests
{
    public class SeleniumDemoTestEdge : SeleniumDemoBase
    {
        [OneTimeSetUp]
        public static void Setup()
        {
            var options = new EdgeOptions
            {
                PageLoadStrategy = PageLoadStrategy.Default
            };
            CurrentBrowser = Browser.Edge;
            TestDriver = new SeleniumDemoWebDriver(CurrentBrowser, options);
            TestDriver.Manage().Window.Size = new Size(1280, 768);
            TestDriver.Manage().Window.Position = new Point(0, 0);

            Waiter.BrowserUpdate = 1250;

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