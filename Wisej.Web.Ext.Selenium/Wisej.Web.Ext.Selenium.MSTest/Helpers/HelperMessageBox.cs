using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Qooxdoo.WebDriver.UI;
using Wisej.Web.Ext.Selenium.UI;

namespace Wisej.Web.Ext.Selenium.Tests
{
    public static class HelperMessageBox
    {
        #region WithTitle

        public static MessageBox GetMessageBoxWithTitle(this WisejWebDriver driver, string title,
            bool assertExists = true, bool assertIsEnabled = true, long timeoutInSeconds = 5)
        {
            MessageBox messageBox = GetMessageBoxWithTitleCore(driver, title, timeoutInSeconds);

            if (assertExists)
                Assert.IsNotNull(messageBox, string.Format("MessageBox with title {0} not found.", title));
            if (assertIsEnabled)
                Assert.IsTrue(messageBox.Enabled, string.Format("MessageBox with title {0} isn't enabled.", title));

            return messageBox;
        }

        private static MessageBox GetMessageBoxWithTitleCore(this WisejWebDriver driver, string title,
            long timeoutInSeconds = 5)
        {
            MessageBox[] messageBoxes;
            try
            {
                messageBoxes = driver.GetMessageBoxes(timeoutInSeconds);
            }
            catch (WebDriverTimeoutException)
            {
                return null;
            }

            if (messageBoxes != null)
            {
                foreach (MessageBox messageBox in driver.GetMessageBoxes(timeoutInSeconds))
                {
                    if (messageBox.Title == title)
                    {
                        return messageBox;
                    }
                }
            }

            return null;
        }

        public static void MessageBoxWithTitleButtonClick(this WisejWebDriver driver, string title,
            DialogResult result, long timeoutInSeconds = 5)
        {
            MessageBox messageBox = driver.GetMessageBoxWithTitle(title, true, true, timeoutInSeconds);

            messageBox.ButtonClick(result);
        }

        #endregion

        #region WithMessage

        public static MessageBox GetMessageBoxWithMessage(this WisejWebDriver driver, string message,
            bool assertExists = true, bool assertIsEnabled = true, long timeoutInSeconds = 5)
        {
            MessageBox messageBox = GetMessageBoxWithMessageCore(driver, message, timeoutInSeconds);

            if (assertExists)
                Assert.IsNotNull(messageBox, string.Format("MessageBox with message {0} not found.", message));
            if (assertIsEnabled)
                Assert.IsTrue(messageBox.Enabled, string.Format("MessageBox with message {0} isn't enabled.", message));

            return messageBox;
        }

        private static MessageBox GetMessageBoxWithMessageCore(this WisejWebDriver driver, string message,
            long timeoutInSeconds = 5)
        {
            MessageBox[] messageBoxes;
            try
            {
                messageBoxes = driver.GetMessageBoxes(timeoutInSeconds);
            }
            catch (WebDriverTimeoutException)
            {
                return null;
            }

            if (messageBoxes != null)
            {
                foreach (MessageBox messageBox in messageBoxes)
                {
                    if (messageBox.Message == message)
                    {
                        return messageBox;
                    }
                }
            }

            return null;
        }

        public static void MessageBoxWithMessageButtonClick(this WisejWebDriver driver, string message,
            DialogResult result, long timeoutInSeconds = 5)
        {
            MessageBox messageBox = driver.GetMessageBoxWithMessage(message, true, true, timeoutInSeconds);

            messageBox.ButtonClick(result);
        }

        #endregion

        #region ButtonClick

        public static void ButtonClick(this MessageBox messageBox, DialogResult result)
        {
            IWidget button = messageBox.GetButton(result.ToString());

            Assert.IsNotNull(button, string.Format("MessageBox Button {0} not found.", result.ToString()));
            Assert.IsTrue(button.Enabled, string.Format("MessageBox Button {0} isn't enabled.", result.ToString()));

            button.Click();
        }

        #endregion
    }
}