using System.Drawing;
using System.IO;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace SeleniumDemo.Tests
{
    public class SeleniumDemoTestFirefox : SeleniumDemoBase
    {
        [OneTimeSetUp]
        public static void Setup()
        {
            var options = new FirefoxOptions
            {
                PageLoadStrategy = PageLoadStrategy.Default
            };
            CurrentBrowser = Browser.Firefox;
            TestDriver = new SeleniumDemoWebDriver(CurrentBrowser, options);
            TestDriver.Manage().Window.Size = new Size(1280, 768);
            TestDriver.Manage().Window.Position = new Point(0, 0);

            Waiter.BrowserUpdate = 2000;

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