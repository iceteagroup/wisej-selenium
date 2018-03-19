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

        private static string GetMessage(string format, MessageBoxIcon icon, string message = "")
        {
            var result = string.Empty;
            if (icon != MessageBoxIcon.None)
            {
                result += string.Format("icon {0}", icon);
                if (!string.IsNullOrWhiteSpace(message))
                    result += " and ";
            }

            if (!string.IsNullOrWhiteSpace(message))
                result += string.Format("message {0}", message);

            return string.Format(format, result);
        }

        #endregion

        #region private Core

        private static AlertBox AlertBoxGetCore(this WisejWebDriver driver, MessageBoxIcon icon, string message,
            int timeoutInSeconds)
        {
            AlertBox alertBox = driver.WaitForAlertBox(message, icon: icon, timeoutInSeconds: timeoutInSeconds);

            Assert.IsNotNull(alertBox, GetMessage("AlertBox with {0} not found.", icon, message));
            return alertBox;
        }

        private static void AlertBoxCheckNotExistsCore(this WisejWebDriver driver, MessageBoxIcon icon, string message,
            int timeoutInSeconds)
        {
            AlertBox alertBox = driver.WaitForAlertBox(message, icon: icon, timeoutInSeconds: timeoutInSeconds);

            Assert.IsNull(alertBox, GetMessage("AlertBox with {0} should not exist.", icon, message));
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
            int timeoutInSeconds = 5)
        {
            return driver.AlertBoxGetCore(icon, message, timeoutInSeconds);
        }

        /// <summary>
        /// Returns a <see cref="AlertBox"/> matching the specified icon.
        /// </summary>
        /// <param name="driver">The <see cref="WisejWebDriver"/> to use.</param>
        /// <param name="icon">The AlertBox icon to look for.</param>
        /// <param name="timeoutInSeconds">The number of seconds to wait for the AlertBox (default is 5).</param>
        /// <returns>The first matching AlertBox.</returns>
        public static AlertBox AlertBoxGet(this WisejWebDriver driver, MessageBoxIcon icon, int timeoutInSeconds = 5)
        {
            return driver.AlertBoxGetCore(icon, null, timeoutInSeconds);
        }

        /// <summary>
        /// Returns a <see cref="AlertBox"/> matching the specified message.
        /// </summary>
        /// <param name="driver">The <see cref="WisejWebDriver"/> to use.</param>
        /// <param name="message">The AlertBox message to search for (default is an empty string).</param>
        /// <param name="timeoutInSeconds">The number of seconds to wait for the AlertBox (default is 5).</param>
        /// <returns>The first matching AlertBox.</returns>
        public static AlertBox AlertBoxGet(this WisejWebDriver driver, string message = "", int timeoutInSeconds = 5)
        {
            return driver.AlertBoxGetCore(MessageBoxIcon.None, message, timeoutInSeconds);
        }

        #endregion

        #region AlertBox Check Not Exists

        /// <summary>
        /// Checks an <see cref="AlertBox"/> matching the icon and message does not exist.
        /// </summary>
        /// <param name="driver">The <see cref="WisejWebDriver"/> to use.</param>
        /// <param name="icon">The AlertBox icon to look for.</param>
        /// <param name="message">The AlertBox message to search for.</param>
        /// <param name="timeoutInSeconds">The number of seconds to wait for the AlertBox (default is 0).</param>
        public static void AlertBoxCheckNotExists(this WisejWebDriver driver, MessageBoxIcon icon, string message,
            int timeoutInSeconds = 0)
        {
            driver.AlertBoxCheckNotExistsCore(icon, message, timeoutInSeconds);
        }

        /// <summary>
        /// Checks an <see cref="AlertBox"/> matching the specified icon does not exist.
        /// </summary>
        /// <param name="driver">The <see cref="WisejWebDriver"/> to use.</param>
        /// <param name="icon">The AlertBox icon to look for.</param>
        /// <param name="timeoutInSeconds">The number of seconds to wait for the AlertBox (default is 0).</param>
        public static void AlertBoxCheckNotExists(this WisejWebDriver driver, MessageBoxIcon icon,
            int timeoutInSeconds = 0)
        {
            driver.AlertBoxCheckNotExistsCore(icon, null, timeoutInSeconds);
        }

        /// <summary>
        /// Checks an <see cref="AlertBox"/> matching the specified message does not exist.
        /// </summary>
        /// <param name="driver">The <see cref="WisejWebDriver"/> to use.</param>
        /// <param name="message">The AlertBox message to search for (default is an empty string).</param>
        /// <param name="timeoutInSeconds">The number of seconds to wait for the AlertBox (default is 0).</param>
        public static void AlertBoxCheckNotExists(this WisejWebDriver driver, string message = "",
            int timeoutInSeconds = 0)
        {
            driver.AlertBoxCheckNotExistsCore(MessageBoxIcon.None, message, timeoutInSeconds);
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
            int timeoutInSeconds = 5)
        {
            driver.AlertBoxCloseCore(icon, message, timeoutInSeconds);
        }

        /// <summary>
        /// Closed an <see cref="AlertBox"/> matching the specified icon.
        /// </summary>
        /// <param name="driver">The <see cref="WisejWebDriver"/> to use.</param>
        /// <param name="icon">The AlertBox icon to look for.</param>
        /// <param name="timeoutInSeconds">The number of seconds to wait for the AlertBox (default is 5).</param>
        public static void AlertBoxClose(this WisejWebDriver driver, MessageBoxIcon icon, int timeoutInSeconds = 5)
        {
            driver.AlertBoxCloseCore(icon, null, timeoutInSeconds);
        }

        /// <summary>
        /// Closed an <see cref="AlertBox"/> matching the specified message.
        /// </summary>
        /// <param name="driver">The <see cref="WisejWebDriver"/> to use.</param>
        /// <param name="message">The AlertBox message to search for (default is an empty string).</param>
        /// <param name="timeoutInSeconds">The number of seconds to wait for the AlertBox (default is 5).</param>
        public static void AlertBoxClose(this WisejWebDriver driver, string message = "", int timeoutInSeconds = 5)
        {
            driver.AlertBoxCloseCore(MessageBoxIcon.None, message, timeoutInSeconds);
        }

        private static void AlertBoxCloseCore(this WisejWebDriver driver, MessageBoxIcon icon, string message,
            int timeoutInSeconds)
        {
            AlertBox alertBox = driver.AlertBoxGetCore(icon, message, timeoutInSeconds);
            Assert.IsNotNull(alertBox, GetMessage("AlertBox with {0} not found.", icon, message));

            IWidget closeButton = alertBox.CloseButton;
            Assert.IsNotNull(closeButton,
                GetMessage("AlertBox close button with {0} not found.", icon, message));
            Assert.IsTrue(closeButton.Enabled,
                GetMessage("AlertBox close button with {0} isn\'t enabled.", icon, message));
            closeButton.Click();
        }

        #endregion
    }
}