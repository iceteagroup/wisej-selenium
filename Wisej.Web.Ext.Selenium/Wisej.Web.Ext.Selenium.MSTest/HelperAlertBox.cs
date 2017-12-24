using Microsoft.VisualStudio.TestTools.UnitTesting;
using Qooxdoo.WebDriver.UI;
using Wisej.Web.Ext.Selenium.UI;

namespace Wisej.Web.Ext.Selenium.Tests
{
    /// <summary>
    /// Extension class with helper methods for handling <see cref="AlertBox"/>.
    /// </summary>
    public static class HelperAlertBox
    {
        #region private utility stuff

        private static string GetMessage(string baseMessage, bool ignoreIcon, MessageBoxIcon icon, string message = "")
        {
            var result = string.Empty;
            if (!ignoreIcon)
            {
                result += string.Format("icon {0}", icon);
                if (!string.IsNullOrWhiteSpace(message))
                    result += " and ";
            }
            if (!string.IsNullOrWhiteSpace(message))
                result += string.Format("message {0}", message);

            return string.Format(baseMessage, result);
        }

        #endregion

        #region private Core

        private static AlertBox AlertBoxGetCore(this WisejWebDriver driver, bool ignoreIcon, MessageBoxIcon icon,
            string message, long timeoutInSeconds)
        {
            AlertBox alertBox = driver.WaitForAlertBox(ignoreIcon, icon, message, timeoutInSeconds);

            Assert.IsNotNull(alertBox, GetMessage("AlertBox with {0} not found.", ignoreIcon, icon, message));
            return alertBox;
        }

        private static void AlertBoxAssertNotExistsCore(this WisejWebDriver driver, bool ignoreIcon,
            MessageBoxIcon icon, string message, long timeoutInSeconds)
        {
            AlertBox alertBox = driver.WaitForAlertBox(ignoreIcon, icon, message, timeoutInSeconds);

            Assert.IsNull(alertBox, GetMessage("AlertBox with {0} should not exist.", ignoreIcon, icon, message));
        }

        #endregion

        #region AlertBox Get

        /// <summary>
        /// Returns a <see cref="AlertBox"/> matching the specified icon and message.
        /// </summary>
        /// <param name="driver">The <see cref="WisejWebDriver"/> to use.</param>
        /// <param name="icon">The AlertBox icon to look for.</param>
        /// <param name="message">The AlertBox message to search for.</param>
        /// <param name="timeoutInSeconds">The number of seconds to wait for the AlertBox (default is 5).</param>
        /// <returns>The first matching AlertBox.</returns>
        public static AlertBox AlertBoxGet(this WisejWebDriver driver, MessageBoxIcon icon, string message,
            long timeoutInSeconds = 5)
        {
            return driver.AlertBoxGetCore(false, icon, message, timeoutInSeconds);
        }

        /// <summary>
        /// Returns a <see cref="AlertBox"/> matching the specified icon.
        /// </summary>
        /// <param name="driver">The <see cref="WisejWebDriver"/> to use.</param>
        /// <param name="icon">The AlertBox icon to look for.</param>
        /// <param name="timeoutInSeconds">The number of seconds to wait for the AlertBox (default is 5).</param>
        /// <returns>The first matching AlertBox.</returns>
        public static AlertBox AlertBoxGet(this WisejWebDriver driver, MessageBoxIcon icon, long timeoutInSeconds = 5)
        {
            return driver.AlertBoxGetCore(false, icon, string.Empty, timeoutInSeconds);
        }

        /// <summary>
        /// Returns a <see cref="AlertBox"/> matching the specified message.
        /// </summary>
        /// <param name="driver">The <see cref="WisejWebDriver"/> to use.</param>
        /// <param name="message">The AlertBox message to search for (default is an empty string).</param>
        /// <param name="timeoutInSeconds">The number of seconds to wait for the AlertBox (default is 5).</param>
        /// <returns>The first matching AlertBox.</returns>
        public static AlertBox AlertBoxGet(this WisejWebDriver driver, string message = "", long timeoutInSeconds = 5)
        {
            return driver.AlertBoxGetCore(true, MessageBoxIcon.None, message, timeoutInSeconds);
        }

        #endregion

        #region AlertBox Assert Not Exists

        /// <summary>
        /// Asserts an <see cref="AlertBox"/> matching the icon and message does not exist.
        /// </summary>
        /// <param name="driver">The <see cref="WisejWebDriver"/> to use.</param>
        /// <param name="icon">The AlertBox icon to look for.</param>
        /// <param name="message">The AlertBox message to search for.</param>
        /// <param name="timeoutInSeconds">The number of seconds to wait for the AlertBox (default is 0).</param>
        public static void AlertBoxAssertNotExists(this WisejWebDriver driver, MessageBoxIcon icon, string message,
            long timeoutInSeconds = 0)
        {
            driver.AlertBoxAssertNotExistsCore(false, icon, message, timeoutInSeconds);
        }

        /// <summary>
        /// Asserts an <see cref="AlertBox"/> matching the specified icon does not exist.
        /// </summary>
        /// <param name="driver">The <see cref="WisejWebDriver"/> to use.</param>
        /// <param name="icon">The AlertBox icon to look for.</param>
        /// <param name="timeoutInSeconds">The number of seconds to wait for the AlertBox (default is 0).</param>
        public static void AlertBoxAssertNotExists(this WisejWebDriver driver, MessageBoxIcon icon,
            long timeoutInSeconds = 0)
        {
            driver.AlertBoxAssertNotExistsCore(false, icon, string.Empty, timeoutInSeconds);
        }

        /// <summary>
        /// Asserts an <see cref="AlertBox"/> matching the specified message does not exist.
        /// </summary>
        /// <param name="driver">The <see cref="WisejWebDriver"/> to use.</param>
        /// <param name="message">The AlertBox message to search for (default is an empty string).</param>
        /// <param name="timeoutInSeconds">The number of seconds to wait for the AlertBox (default is 0).</param>
        public static void AlertBoxAssertNotExists(this WisejWebDriver driver, string message = "",
            long timeoutInSeconds = 0)
        {
            driver.AlertBoxAssertNotExistsCore(true, MessageBoxIcon.None, message, timeoutInSeconds);
        }

        #endregion

        #region AlertBox close

        /// <summary>
        /// Closed an <see cref="AlertBox"/> matching the specified icon and message.
        /// </summary>
        /// <param name="driver">The <see cref="WisejWebDriver"/> to use.</param>
        /// <param name="icon">The AlertBox icon to look for.</param>
        /// <param name="message">The AlertBox message to search for.</param>
        /// <param name="timeoutInSeconds">The number of seconds to wait for the AlertBox (default is 5).</param>
        public static void AlertBoxClose(this WisejWebDriver driver, MessageBoxIcon icon, string message,
            long timeoutInSeconds = 5)
        {
            driver.AlertBoxCloseCore(icon, false, message, timeoutInSeconds);
        }

        /// <summary>
        /// Closed an <see cref="AlertBox"/> matching the specified icon.
        /// </summary>
        /// <param name="driver">The <see cref="WisejWebDriver"/> to use.</param>
        /// <param name="icon">The AlertBox icon to look for.</param>
        /// <param name="timeoutInSeconds">The number of seconds to wait for the AlertBox (default is 5).</param>
        public static void AlertBoxClose(this WisejWebDriver driver, MessageBoxIcon icon, long timeoutInSeconds = 5)
        {
            driver.AlertBoxCloseCore(icon, false, string.Empty, timeoutInSeconds);
        }

        /// <summary>
        /// Closed an <see cref="AlertBox"/> matching the specified message.
        /// </summary>
        /// <param name="driver">The <see cref="WisejWebDriver"/> to use.</param>
        /// <param name="message">The AlertBox message to search for (default is an empty string).</param>
        /// <param name="timeoutInSeconds">The number of seconds to wait for the AlertBox (default is 5).</param>
        public static void AlertBoxClose(this WisejWebDriver driver, string message = "", long timeoutInSeconds = 5)
        {
            driver.AlertBoxCloseCore(MessageBoxIcon.None, true, message, timeoutInSeconds);
        }

        private static void AlertBoxCloseCore(this WisejWebDriver driver, MessageBoxIcon icon, bool ignoreIcon,
            string message, long timeoutInSeconds)
        {
            AlertBox alertBox = driver.AlertBoxGetCore(ignoreIcon, icon, message, timeoutInSeconds);
            Assert.IsNotNull(alertBox, GetMessage("AlertBox with {0} not found.", ignoreIcon, icon, message));

            IWidget closeButton = alertBox.CloseButton;
            Assert.IsNotNull(closeButton,
                GetMessage("AlertBox close button with {0} not found.", ignoreIcon, icon, message));
            Assert.IsTrue(closeButton.Enabled,
                GetMessage("AlertBox close button with {0} isn\'t enabled.", ignoreIcon, icon, message));
            closeButton.Click();
        }

        #endregion
    }
}