using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Support.UI;
using Qooxdoo.WebDriver;

namespace SeleniumDemo.Tests
{
    [TestClass]
    public class InternetExplorerWisej
    {
        public static QxWebDriver Driver;

        [ClassInitialize]
        public static void Setup(TestContext testContext)
        {
            Driver = new QxWebDriver(Browser.IE);
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
        [Priority(4050)]
        public void W01_AskQuitNo()
        {
            ExpectedConditions.TitleIs("Main Page");
            WisejTests.W01_AskQuitNo();
        }

        [TestMethod]
        [Priority(4060)]
        public void W02_MainPage_customerEditor_Click()
        {
            WisejTests.W02_MainPage_customerEditor_Click();
        }

        [TestMethod]
        [Priority(4070)]
        public void W03_ButtonsWindow_customerEditor_Click()
        {
            WisejTests.W03_ButtonsWindow_customerEditor_Click();
        }

        [TestMethod]
        [Priority(4080)]
        public void W04_CustomerEditor_customerEditor_LabelContents()
        {
            WisejTests.W04_CustomerEditor_customerEditor_LabelContents();
        }

        [TestMethod]
        [Priority(4090)]
        public void W05_CloseWindow()
        {
            WisejTests.W05_CloseWindow();
        }

        [TestMethod]
        [Priority(4100)]
        public void W06_MainPage_customerEditor_Click()
        {
            WisejTests.W06_MainPage_customerEditor_Click();
        }

        [TestMethod]
        [Priority(4110)]
        public void W07_ButtonsWindow_supplierEditor_Click()
        {
            WisejTests.W07_ButtonsWindow_supplierEditor_Click();
        }

        [TestMethod]
        [Priority(4120)]
        public void W08_CustomerEditor_customerEditor_LabelContents()
        {
            WisejTests.W08_CustomerEditor_customerEditor_LabelContents();
        }

        [TestMethod]
        [Priority(4130)]
        public void W09_CloseWindow()
        {
            WisejTests.W09_CloseWindow();
        }

        [TestMethod]
        [Priority(4140)]
        public void W10_AskQuitYes()
        {
            WisejTests.W10_AskQuitYes();
        }
    }
}