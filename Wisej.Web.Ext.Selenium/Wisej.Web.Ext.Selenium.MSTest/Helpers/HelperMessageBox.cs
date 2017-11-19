using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Qooxdoo.WebDriver.UI;
using Wisej.Web.Ext.Selenium.UI;

namespace Wisej.Web.Ext.Selenium.Tests
{
    public static class HelperMessageBox
    {
        #region private utility stuff

        private static MessageBox _targetMessageBox;

        private static string GetMessage(string baseMessage, string title, string message)
        {
            var result = string.Empty;
            if (!string.IsNullOrWhiteSpace(title))
                result += string.Format("with title {0}", title);

            if (!string.IsNullOrWhiteSpace(message))
                result += string.Format("with message {0}", message);

            return string.Format(baseMessage, result);
        }

        #endregion

        #region private Core

        private static MessageBox GetMessageBoxCore(this WisejWebDriver driver, string title, string message,
            long timeoutInSeconds = 5)
        {
            MessageBox messageBox = WaitForMessageBox(driver, title, message, timeoutInSeconds);

            Assert.IsNotNull(messageBox, GetMessage("MessageBox {0} not found.", title, message));
            return _targetMessageBox;
        }

        private static bool MessageBoxAssertNotExistCore(this WisejWebDriver driver, string title, string message,
            long timeoutInSeconds = 5)
        {
            MessageBox messageBox = WaitForMessageBox(driver, title, message, timeoutInSeconds);

            Assert.IsNull(messageBox, GetMessage("MessageBox {0} should not exist.", title, message));
            return _targetMessageBox == null;
        }

        private static MessageBox WaitForMessageBox(this WisejWebDriver driver, string title, string message,
            long timeoutInSeconds)
        {
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds))
                    .Until(MessageBoxExists(title, message));
            }
            catch (WebDriverTimeoutException)
            {
            }

            return _targetMessageBox;
        }

        public static Func<IWebDriver, bool> MessageBoxExists(string title, string message)
        {
            return driver =>
            {
                _targetMessageBox = null;
                MessageBox[] messagesBoxes = ((WisejWebDriver) driver).MessageBoxes;
                if (messagesBoxes != null)
                {
                    foreach (MessageBox messageBox in messagesBoxes)
                    {
                        // check title
                        if (!string.IsNullOrEmpty(title))
                        {
                            if (title == messageBox.Title)
                            {
                                _targetMessageBox = messageBox;
                                return true;
                            }

                            continue;
                        }

                        // check message
                        if (!string.IsNullOrEmpty(message))
                        {
                            if (message == messageBox.Message)
                            {
                                _targetMessageBox = messageBox;
                                return true;
                            }
                        }
                    }
                }

                return false;
            };
        }

        #endregion

        #region WithTitle

        public static MessageBox GetMessageBoxWithTitle(this WisejWebDriver driver, string title,
            bool assertIsEnabled = true, long timeoutInSeconds = 5)
        {
            MessageBox messageBox = GetMessageBoxCore(driver, title, string.Empty, timeoutInSeconds);

            if (assertIsEnabled)
                Assert.IsTrue(messageBox.Enabled, GetMessage("MessageBox {0} isn't enabled.", title, string.Empty));

            return messageBox;
        }

        public static bool MessageBoxWithTitleAssertNotExists(this WisejWebDriver driver, string title,
            long timeoutInSeconds = 5)
        {
            return MessageBoxAssertNotExistCore(driver, title, string.Empty, timeoutInSeconds);
        }

        public static void MessageBoxWithTitleButtonClick(this WisejWebDriver driver, string title, DialogResult result,
            long timeoutInSeconds = 5)
        {
            MessageBox messageBox = driver.GetMessageBoxWithTitle(title, true, timeoutInSeconds);

            messageBox.ButtonClick(result);
        }

        #endregion

        #region WithMessage

        public static MessageBox GetMessageBoxWithMessage(this WisejWebDriver driver, string message,
            bool assertIsEnabled = true, long timeoutInSeconds = 5)
        {
            MessageBox messageBox = GetMessageBoxCore(driver, string.Empty, message, timeoutInSeconds);

            if (assertIsEnabled)
                Assert.IsTrue(messageBox.Enabled, GetMessage("MessageBox {0} isn't enabled.", string.Empty, message));

            return messageBox;
        }

        public static bool MessageBoxWithMessageAssertNotExists(this WisejWebDriver driver, string message,
            long timeoutInSeconds = 5)
        {
            return MessageBoxAssertNotExistCore(driver, string.Empty, message, timeoutInSeconds);
        }

        public static void MessageBoxWithMessageButtonClick(this WisejWebDriver driver, string message,
            DialogResult result, long timeoutInSeconds = 5)
        {
            MessageBox messageBox = driver.GetMessageBoxWithMessage(message, true, timeoutInSeconds);

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