using System.Drawing;
using System.IO;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Opera;

namespace SeleniumDemo.Tests
{
    public class SeleniumDemoTestOpera : SeleniumDemoBase
    {
        private const string OperaBinary = @"C:\Program Files (x86)\Opera\launcher.exe";

        [OneTimeSetUp]
        public static void Setup()
        {
            var options = new OperaOptions
            {
                PageLoadStrategy = PageLoadStrategy.Default,
                BinaryLocation = OperaBinary
            };
            CurrentBrowser = Browser.Opera;
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