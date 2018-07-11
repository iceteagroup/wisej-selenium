using System;
using System.IO;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using Wisej.Web.Ext.Selenium;

namespace Wisej.SeleniumTestExample
{
    /// <summary>
    /// The base class for the ProgressSample tests.
    /// </summary>
    [TestFixture]
    [NonParallelizable]
    public abstract partial class ProgressSampleBase
    {
        protected static ProgressSampleWebDriver TestDriver;

        [Test, Order(1)]
        public void T1_StartStopBackgroundTask()
        {
            TestDriver.Window1.Restore();
            TestDriver.Window1.FindWidget("panel1.buttonStart").Click();
            TestDriver.Sleep(5000);

            Assert.IsTrue(TestDriver.LabelStep.Text.StartsWith("Executing Step "));

            TestDriver.Window1.FindWidget("panel1.buttonCancel").Click();
            TestDriver.SaveScreenshot("T1_StartStopBackgroundTask.jpg", ScreenshotImageFormat.Jpeg);

            TestDriver.Sleep(1000);
            Assert.AreEqual("", TestDriver.LabelStep.Text);
            Assert.AreEqual(true, TestDriver.Window1.FindWidget("panel1.buttonStart").Enabled);
        }

        [Test, Order(2)]
        public void T2_MinimizeWindow()
        {
            TestDriver.Window1.Minimize();
            TestDriver.SaveScreenshot("T2_MinimizeWindow.jpg", ScreenshotImageFormat.Jpeg);

            TestDriver.Sleep(1000);

            Assert.AreEqual(false, TestDriver.Window1.Displayed);
        }

        [Test, Order(3)]
        public void T3_RestoreWindow()
        {
            TestDriver.Window1.Restore();
            TestDriver.SaveScreenshot("T3_RestoreWindow.jpg", ScreenshotImageFormat.Jpeg);

            TestDriver.Sleep(1000);

            Assert.AreEqual(true, TestDriver.Window1.Displayed);
        }
    }
}