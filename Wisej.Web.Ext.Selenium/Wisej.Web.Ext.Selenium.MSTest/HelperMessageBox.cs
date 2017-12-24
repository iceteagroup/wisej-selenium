using Microsoft.VisualStudio.TestTools.UnitTesting;
using Qooxdoo.WebDriver.UI;
using Wisej.Web.Ext.Selenium.UI;

namespace Wisej.Web.Ext.Selenium.Tests
{
    /// <summary>
    /// Extension class with helper methods for handling <see cref="MessageBox"/>.
    /// </summary>
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

        private static MessageBox GetMessageBoxCore(this WisejWebDriver driver, string title, bool ignoreIcon,
            MessageBoxIcon icon, string message, long timeoutInSeconds)
        {
            MessageBox messageBox = driver.WaitForMessageBox(title, ignoreIcon, icon, message, timeoutInSeconds);

            Assert.IsNotNull(messageBox, GetMessage("MessageBox {0} not found.", title, message));
            return messageBox;
        }

        private static void MessageBoxAssertNotExistCore(this WisejWebDriver driver, string title, bool ignoreIcon,
            MessageBoxIcon icon, string message, long timeoutInSeconds)
        {
            MessageBox messageBox = driver.WaitForMessageBox(title, ignoreIcon, icon, message, timeoutInSeconds);

            Assert.IsNull(messageBox, GetMessage("MessageBox {0} should not exist.", title, message));
        }

        #endregion

        #region MessageBox (no parameters)

        /// <summary>
        /// Returns the first <see cref="MessageBox"/>.
        /// </summary>
        /// <param name="driver">The <see cref="WisejWebDriver"/> to use.</param>
        /// <param name="assertIsEnabled">If set to <c>true</c>, asserts the MessageBox is enabled (default is <c>true</c>).</param>
        /// <param name="timeoutInSeconds">The number of seconds to wait for the MessageBox (default is 5).</param>
        /// <returns>The first MessageBox.</returns>
        public static MessageBox GetMessageBox(this WisejWebDriver driver, bool assertIsEnabled = true,
            long timeoutInSeconds = 5)
        {
            MessageBox messageBox =
                driver.GetMessageBoxCore(string.Empty, true, MessageBoxIcon.None, string.Empty, timeoutInSeconds);

            if (assertIsEnabled)
                Assert.IsTrue(messageBox.Enabled,
                    GetMessage("MessageBox {0} isn't enabled.", string.Empty, string.Empty));

            return messageBox;
        }

        /// <summary>
        /// Asserts no <see cref="MessageBox"/> exists.
        /// </summary>
        /// <param name="driver">The <see cref="WisejWebDriver"/> to use.</param>
        /// <param name="timeoutInSeconds">The number of seconds to wait for the MessageBox (default is 0).</param>
        public static void MessageBoxAssertNotExists(this WisejWebDriver driver, long timeoutInSeconds = 0)
        {
            driver.MessageBoxAssertNotExistCore(string.Empty, true, MessageBoxIcon.None, string.Empty,
                timeoutInSeconds);
        }

        /// <summary>
        /// Clicks the specified button on the <see cref="MessageBox"/>.
        /// </summary>
        /// <param name="driver">The <see cref="WisejWebDriver"/> to use.</param>
        /// <param name="resultButton">The result button to click.</param>
        /// <param name="timeoutInSeconds">The number of seconds to wait for the MessageBox (default is 5).</param>
        public static void MessageBoxButtonClick(this WisejWebDriver driver, DialogResult resultButton,
            long timeoutInSeconds = 5)
        {
            MessageBox messageBox = driver.GetMessageBox(true, timeoutInSeconds);

            messageBox.ButtonClick(resultButton);
        }

        #endregion

        #region MessageBox with Title

        /// <summary>
        /// Returns a <see cref="MessageBox"/> with the specified title.
        /// </summary>
        /// <param name="driver">The <see cref="WisejWebDriver"/> to use.</param>
        /// <param name="title">The MessageBox title to search for.</param>
        /// <param name="assertIsEnabled">If set to <c>true</c>, asserts the MessageBox is enabled (default is <c>true</c>).</param>
        /// <param name="timeoutInSeconds">The number of seconds to wait for the MessageBox (default is 5).</param>
        /// <returns>The first matching MessageBox.</returns>
        public static MessageBox GetMessageBoxWithTitle(this WisejWebDriver driver, string title,
            bool assertIsEnabled = true, long timeoutInSeconds = 5)
        {
            MessageBox messageBox =
                driver.GetMessageBoxCore(title, true, MessageBoxIcon.None, string.Empty, timeoutInSeconds);

            if (assertIsEnabled)
                Assert.IsTrue(messageBox.Enabled, GetMessage("MessageBox {0} isn't enabled.", title, string.Empty));

            return messageBox;
        }

        /// <summary>
        /// Asserts a <see cref="MessageBox"/> with the specified title does not exist.
        /// </summary>
        /// <param name="driver">The <see cref="WisejWebDriver"/> to use.</param>
        /// <param name="title">The MessageBox title to search for.</param>
        /// <param name="timeoutInSeconds">The number of seconds to wait for the MessageBox (default is 0).</param>
        public static void MessageBoxWithTitleAssertNotExists(this WisejWebDriver driver, string title,
            long timeoutInSeconds = 0)
        {
            driver.MessageBoxAssertNotExistCore(title, true, MessageBoxIcon.None, string.Empty, timeoutInSeconds);
        }

        /// <summary>
        /// Clicks the specified button on the <see cref="MessageBox"/> with the specified title.
        /// </summary>
        /// <param name="driver">The <see cref="WisejWebDriver"/> to use.</param>
        /// <param name="title">The MessageBox title to search for.</param>
        /// <param name="resultButton">The result button to click.</param>
        /// <param name="timeoutInSeconds">The number of seconds to wait for the MessageBox (default is 5).</param>
        public static void MessageBoxWithTitleButtonClick(this WisejWebDriver driver, string title,
            DialogResult resultButton, long timeoutInSeconds = 5)
        {
            MessageBox messageBox = driver.GetMessageBoxWithTitle(title, true, timeoutInSeconds);

            messageBox.ButtonClick(resultButton);
        }

        #endregion

        #region MessageBox with message

        /// <summary>
        /// Returns a <see cref="MessageBox"/> with the specified message.
        /// </summary>
        /// <param name="driver">The <see cref="WisejWebDriver"/> to use.</param>
        /// <param name="message">The MessageBox message to search for.</param>
        /// <param name="assertIsEnabled">If set to <c>true</c>, asserts the MessageBox is enabled (default is <c>true</c>).</param>
        /// <param name="timeoutInSeconds">The number of seconds to wait for the MessageBox (default is 5).</param>
        /// <returns>The first matching MessageBox.</returns>
        public static MessageBox GetMessageBoxWithMessage(this WisejWebDriver driver, string message,
            bool assertIsEnabled = true, long timeoutInSeconds = 5)
        {
            MessageBox messageBox =
                driver.GetMessageBoxCore(string.Empty, true, MessageBoxIcon.None, message, timeoutInSeconds);

            if (assertIsEnabled)
                Assert.IsTrue(messageBox.Enabled, GetMessage("MessageBox {0} isn't enabled.", string.Empty, message));

            return messageBox;
        }

        /// <summary>
        /// Asserts a <see cref="MessageBox"/> with the specified message does not exist.
        /// </summary>
        /// <param name="driver">The <see cref="WisejWebDriver"/> to use.</param>
        /// <param name="message">The MessageBox message to search for.</param>
        /// <param name="timeoutInSeconds">The number of seconds to wait for the MessageBox (default is 0).</param>
        public static void MessageBoxWithMessageAssertNotExists(this WisejWebDriver driver, string message,
            long timeoutInSeconds = 0)
        {
            driver.MessageBoxAssertNotExistCore(string.Empty, true, MessageBoxIcon.None, message, timeoutInSeconds);
        }

        /// <summary>
        /// Clicks the specified button on the <see cref="MessageBox"/> with the specified message.
        /// </summary>
        /// <param name="driver">The <see cref="WisejWebDriver"/> to use.</param>
        /// <param name="message">The MessageBox message to search for.</param>
        /// <param name="resultButton">The result button to click.</param>
        /// <param name="timeoutInSeconds">The number of seconds to wait for the MessageBox (default is 5).</param>
        public static void MessageBoxWithMessageButtonClick(this WisejWebDriver driver, string message,
            DialogResult resultButton, long timeoutInSeconds = 5)
        {
            MessageBox messageBox = driver.GetMessageBoxWithMessage(message, true, timeoutInSeconds);

            messageBox.ButtonClick(resultButton);
        }

        #endregion

        #region MessageBox with icon

        /// <summary>
        /// Returns a <see cref="MessageBox"/> with the specified icon.
        /// </summary>
        /// <param name="driver">The <see cref="WisejWebDriver"/> to use.</param>
        /// <param name="icon">The MessageBoxIcon to look for.</param>
        /// <param name="assertIsEnabled">If set to <c>true</c>, asserts the MessageBox is enabled (default is <c>true</c>).</param>
        /// <param name="timeoutInSeconds">The number of seconds to wait for the MessageBox (default is 5).</param>
        /// <returns>The first matching MessageBox.</returns>
        public static MessageBox GetMessageBoxWithIcon(this WisejWebDriver driver, MessageBoxIcon icon,
            bool assertIsEnabled = true, long timeoutInSeconds = 5)
        {
            MessageBox messageBox = driver.GetMessageBoxCore(string.Empty, false, icon, string.Empty, timeoutInSeconds);

            if (assertIsEnabled)
                Assert.IsTrue(messageBox.Enabled,
                    GetMessage("MessageBox {0} isn't enabled.", string.Empty, string.Empty));

            return messageBox;
        }

        /// <summary>
        /// Asserts a <see cref="MessageBox"/> with the specified icon does not exist.
        /// </summary>
        /// <param name="driver">The <see cref="WisejWebDriver"/> to use.</param>
        /// <param name="icon">The MessageBoxIcon to look for.</param>
        /// <param name="timeoutInSeconds">The number of seconds to wait for the MessageBox (default is 0).</param>
        public static void MessageBoxWithIconAssertNotExists(this WisejWebDriver driver, MessageBoxIcon icon,
            long timeoutInSeconds = 0)
        {
            driver.MessageBoxAssertNotExistCore(string.Empty, false, icon, string.Empty, timeoutInSeconds);
        }

        /// <summary>
        /// Clicks the specified button on the <see cref="MessageBox"/> with the specified icon.
        /// </summary>
        /// <param name="driver">The <see cref="WisejWebDriver"/> to use.</param>
        /// <param name="icon">The MessageBoxIcon to look for.</param>
        /// <param name="resultButton">The result button to click.</param>
        /// <param name="timeoutInSeconds">The number of seconds to wait for the MessageBox (default is 5).</param>
        public static void MessageBoxWithIconButtonClick(this WisejWebDriver driver, MessageBoxIcon icon,
            DialogResult resultButton, long timeoutInSeconds = 5)
        {
            MessageBox messageBox = driver.GetMessageBoxWithIcon(icon, true, timeoutInSeconds);

            messageBox.ButtonClick(resultButton);
        }

        #endregion

        #region MessageBox with all parameters

        /// <summary>
        /// Returns a <see cref="MessageBox"/> with the specified parameters.
        /// </summary>
        /// <param name="driver">The <see cref="WisejWebDriver"/> to use.</param>
        /// <param name="title">The title of message box to search for.</param>
        /// <param name="ignoreIcon">If set to <c>true</c> ignores the MessageBox icon parameter.</param>
        /// <param name="icon">The MessageBox icon to look for.</param>
        /// <param name="message">The message to search for.</param>
        /// <param name="assertIsEnabled">If set to <c>true</c>, asserts the MessageBox is enabled (default is <c>true</c>).</param>
        /// <param name="timeoutInSeconds">The number of seconds to wait for the MessageBox (default is 5).</param>
        /// <returns>The first matching MessageBox.</returns>
        public static MessageBox GetMessageBox(this WisejWebDriver driver, string title, bool ignoreIcon,
            MessageBoxIcon icon, string message, bool assertIsEnabled = true, long timeoutInSeconds = 5)
        {
            MessageBox messageBox = driver.GetMessageBoxCore(title, ignoreIcon, icon, message, timeoutInSeconds);

            if (assertIsEnabled)
                Assert.IsTrue(messageBox.Enabled, GetMessage("MessageBox {0} isn't enabled.", title, message));

            return messageBox;
        }

        /// <summary>
        /// Asserts a <see cref="MessageBox"/> with the specified parameters does not exist.
        /// </summary>
        /// <param name="driver">The <see cref="WisejWebDriver"/> to use.</param>
        /// <param name="title">The title of message box to search for.</param>
        /// <param name="ignoreIcon">If set to <c>true</c> ignores the MessageBox icon parameter.</param>
        /// <param name="icon">The MessageBox icon to look for.</param>
        /// <param name="message">The message to search for.</param>
        /// <param name="timeoutInSeconds">The number of seconds to wait for the MessageBox (default is 0).</param>
        public static void MessageBoxAssertNotExists(this WisejWebDriver driver, string title, bool ignoreIcon,
            MessageBoxIcon icon, string message, long timeoutInSeconds = 0)
        {
            driver.MessageBoxAssertNotExistCore(title, ignoreIcon, icon, message, timeoutInSeconds);
        }

        /// <summary>
        /// Clicks the specified button on the <see cref="MessageBox"/> with the specified parameters.
        /// </summary>
        /// <param name="driver">The <see cref="WisejWebDriver"/> to use.</param>
        /// <param name="title">The title of message box to search for.</param>
        /// <param name="ignoreIcon">If set to <c>true</c> ignores the MessageBox icon parameter.</param>
        /// <param name="icon">The MessageBox icon to look for.</param>
        /// <param name="message">The message to search for.</param>
        /// <param name="resultButton">The result button to click.</param>
        /// <param name="timeoutInSeconds">The number of seconds to wait for the MessageBox (default is 5).</param>
        public static void MessageBoxButtonClick(this WisejWebDriver driver, string title, bool ignoreIcon,
            MessageBoxIcon icon, string message, DialogResult resultButton, long timeoutInSeconds = 5)
        {
            MessageBox messageBox = driver.GetMessageBox(title, ignoreIcon, icon, message, true, timeoutInSeconds);

            messageBox.ButtonClick(resultButton);
        }

        #endregion

        #region ButtonClick

        /// <summary>
        /// Clicks the specified button on the <see cref="MessageBox"/>.
        /// </summary>
        /// <param name="messageBox">The message box.</param>
        /// <param name="resultButton">The result button to click.</param>
        public static void ButtonClick(this MessageBox messageBox, DialogResult resultButton)
        {
            IWidget button = messageBox.GetButton(resultButton.ToString());

            Assert.IsNotNull(button, string.Format("MessageBox Button {0} not found.", resultButton.ToString()));
            Assert.IsTrue(button.Enabled,
                string.Format("MessageBox Button {0} isn't enabled.", resultButton.ToString()));

            button.Click();
        }

        #endregion
    }
}