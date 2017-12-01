using Microsoft.VisualStudio.TestTools.UnitTesting;
using Qooxdoo.WebDriver.UI;
using Wisej.Web.Ext.Selenium.UI;

namespace Wisej.Web.Ext.Selenium.Tests
{
    public static class HelperMessageBox
    {
        #region private utility stuff

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
            MessageBox messageBox = driver.WaitForMessageBox(title, message, timeoutInSeconds);

            Assert.IsNotNull(messageBox, GetMessage("MessageBox {0} not found.", title, message));
            return messageBox;
        }

        private static void MessageBoxAssertNotExistCore(this WisejWebDriver driver, string title, string message,
            long timeoutInSeconds = 5)
        {
            MessageBox messageBox = driver.WaitForMessageBox(title, message, timeoutInSeconds);

            Assert.IsNull(messageBox, GetMessage("MessageBox {0} should not exist.", title, message));
        }

        #endregion

        #region WithTitle

        public static MessageBox GetMessageBoxWithTitle(this WisejWebDriver driver, string title,
            bool assertIsEnabled = true, long timeoutInSeconds = 5)
        {
            MessageBox messageBox = driver.GetMessageBoxCore(title, string.Empty, timeoutInSeconds);

            if (assertIsEnabled)
                Assert.IsTrue(messageBox.Enabled, GetMessage("MessageBox {0} isn't enabled.", title, string.Empty));

            return messageBox;
        }

        public static void MessageBoxWithTitleAssertNotExists(this WisejWebDriver driver, string title,
            long timeoutInSeconds = 5)
        {
            driver.MessageBoxAssertNotExistCore(title, string.Empty, timeoutInSeconds);
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
            MessageBox messageBox = driver.GetMessageBoxCore(string.Empty, message, timeoutInSeconds);

            if (assertIsEnabled)
                Assert.IsTrue(messageBox.Enabled, GetMessage("MessageBox {0} isn't enabled.", string.Empty, message));

            return messageBox;
        }

        public static void MessageBoxWithMessageAssertNotExists(this WisejWebDriver driver, string message,
            long timeoutInSeconds = 5)
        {
            driver.MessageBoxAssertNotExistCore(string.Empty, message, timeoutInSeconds);
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