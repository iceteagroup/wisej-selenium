using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Opera;
using OpenQA.Selenium.Support.UI;
using Qooxdoo.WebDriver;

namespace SeleniumDemo.Tests
{
    [TestClass]
    public class OperaWisej
    {
        private const string OperaBinary = @"C:\Program Files (x86)\Opera\48.0.2685.52\opera.exe";

        public static QxWebDriver Driver;

        [ClassInitialize]
        public static void Setup(TestContext testContext)
        {
            var options = new OperaOptions();
            options.BinaryLocation = OperaBinary;
            Driver = new QxWebDriver(new OperaDriver(options));
            Driver.Manage().Window.Maximize();
            Cache.Clear();
            WisejTests.Driver = Driver;
#if !DEBUGJS
            Driver.Url = "http://localhost:7185/Default.html";
#else
            Driver.Url = "http://localhost:7185/Debug.html";
#endif
        }

        [ClassCleanup]
        public static void TearDown()
        {
            Driver.Quit();
            Driver.Dispose();
        }

        [TestMethod]
        [Priority(5050)]
        public void W01_AskQuitNo()
        {
            ExpectedConditions.TitleIs("Main Page");
            WisejTests.W01_AskQuitNo();
        }

        [TestMethod]
        [Priority(5060)]
        public void W02_MainPage_customerEditor_Click()
        {
            WisejTests.W02_MainPage_customerEditor_Click();
        }

        [TestMethod]
        [Priority(5070)]
        public void W03_ButtonsWindow_customerEditor_Click()
        {
            WisejTests.W03_ButtonsWindow_customerEditor_Click();
        }

        [TestMethod]
        [Priority(5080)]
        public void W04_CustomerEditor_customerEditor_LabelContents()
        {
            WisejTests.W04_CustomerEditor_customerEditor_LabelContents();
        }

        [TestMethod]
        [Priority(5090)]
        public void W05_CloseWindow()
        {
            WisejTests.W05_CloseWindow();
        }

        [TestMethod]
        [Priority(5100)]
        public void W06_MainPage_customerEditor_Click()
        {
            WisejTests.W06_MainPage_customerEditor_Click();
        }

        [TestMethod]
        [Priority(5110)]
        public void W07_ButtonsWindow_supplierEditor_Click()
        {
            WisejTests.W07_ButtonsWindow_supplierEditor_Click();
        }

        [TestMethod]
        [Priority(5120)]
        public void W08_CustomerEditor_customerEditor_LabelContents()
        {
            WisejTests.W08_CustomerEditor_customerEditor_LabelContents();
        }

        [TestMethod]
        [Priority(5130)]
        public void W09_CloseWindow()
        {
            WisejTests.W09_CloseWindow();
        }

        [TestMethod]
        [Priority(5140)]
        public void W10_AskQuitYes()
        {
            WisejTests.W10_AskQuitYes();
        }
    }
}