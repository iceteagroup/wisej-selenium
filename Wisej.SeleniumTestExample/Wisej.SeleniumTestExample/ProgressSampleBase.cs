using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Wisej.Web.Ext.Selenium;

namespace Wisej.SeleniumTestExample
{
    /// <summary>
    /// The base class for the ProgressSample tests.
    /// </summary>
    public abstract class ProgressSampleBase
    {
        protected static ProgressSampleWebDriver TestDriver;

        [TestMethod]
        public void A0_StartStopBackgroundTask()
        {
            TestDriver.Window1.Restore();
            TestDriver.Window1.FindWidget("panel1.buttonStart").Click();
            TestDriver.Sleep(5000);

            Assert.IsTrue(TestDriver.LabelStep.Text.StartsWith("Executing Step "));

            TestDriver.Window1.FindWidget("panel1.buttonCancel").Click();
            TestDriver.SaveScreenshot("A0_StartStopBackgroundTask.jpg", ScreenshotImageFormat.Jpeg);

            TestDriver.Sleep(1000);
            Assert.AreEqual("", TestDriver.LabelStep.Text);
            Assert.AreEqual(true, TestDriver.Window1.FindWidget("panel1.buttonStart").Enabled);
        }

        [TestMethod]
        public void A1_MinimizeWindow()
        {
            TestDriver.Window1.Minimize();
            TestDriver.SaveScreenshot("A1_MinimizeWindow.jpg", ScreenshotImageFormat.Jpeg);

            Assert.AreEqual(false, TestDriver.Window1.Displayed);
        }

        [TestMethod]
        public void A2_RestoreWindow()
        {
            TestDriver.Window1.Restore();
            TestDriver.SaveScreenshot("A2_RestoreWindow.jpg", ScreenshotImageFormat.Jpeg);

            Assert.AreEqual(true, TestDriver.Window1.Displayed);
        }
    }
}