using Microsoft.VisualStudio.TestTools.UnitTesting;
using Qooxdoo.WebDriver.UI;
using Wisej.Web.Ext.Selenium.UI;

namespace Wisej.Web.Ext.Selenium.Tests
{
    public static class HelperAlertBox
    {
        #region private utility stuff

        private static string GetMessage(string baseMessage, bool ignoreIcon, MessageBoxIcon alertBoxIcon,
            string alertBoxMessage = "")
        {
            var result = string.Empty;
            if (!ignoreIcon)
            {
                result += string.Format("icon {0}", alertBoxIcon);
                if (!string.IsNullOrWhiteSpace(alertBoxMessage))
                    result += " and ";
            }
            if (!string.IsNullOrWhiteSpace(alertBoxMessage))
                result += string.Format("message {0}", alertBoxMessage);

            return string.Format(baseMessage, result);
        }

        #endregion

        #region private Core

        private static AlertBox AlertBoxGetCore(this WisejWebDriver driver, bool ignoreIcon,
            MessageBoxIcon alertBoxIcon, string alertBoxMessage = "", long timeoutInSeconds = 5)
        {
            AlertBox alertBox = driver.WaitForAlertBox(ignoreIcon, alertBoxIcon, alertBoxMessage, timeoutInSeconds);

            Assert.IsNotNull(alertBox,
                GetMessage("AlertBox with {0} not found.", ignoreIcon, alertBoxIcon, alertBoxMessage));
            return alertBox;
        }

        private static void AlertBoxAssertNotExistsCore(this WisejWebDriver driver, bool ignoreIcon,
            MessageBoxIcon alertBoxIcon, string alertBoxMessage = "", long timeoutInSeconds = 5)
        {
            AlertBox alertBox = driver.WaitForAlertBox(ignoreIcon, alertBoxIcon, alertBoxMessage, timeoutInSeconds);

            Assert.IsNull(alertBox,
                GetMessage("AlertBox with {0} should not exist.", ignoreIcon, alertBoxIcon, alertBoxMessage));
        }

        #endregion

        #region AlertBox Get

        public static AlertBox AlertBoxGet(this WisejWebDriver driver, MessageBoxIcon alertBoxIcon,
            string alertBoxMessage, long timeoutInSeconds = 5)
        {
            return driver.AlertBoxGetCore(false, alertBoxIcon, alertBoxMessage, timeoutInSeconds);
        }

        public static AlertBox AlertBoxGet(this WisejWebDriver driver, MessageBoxIcon alertBoxIcon,
            long timeoutInSeconds = 5)
        {
            return driver.AlertBoxGetCore(false, alertBoxIcon, string.Empty, timeoutInSeconds);
        }

        public static AlertBox AlertBoxGet(this WisejWebDriver driver, string alertBoxMessage = "",
            long timeoutInSeconds = 5)
        {
            return driver.AlertBoxGetCore(true, MessageBoxIcon.None, alertBoxMessage, timeoutInSeconds);
        }

        #endregion

        #region AlertBox Assert Not Exists

        public static void AlertBoxAssertNotExists(this WisejWebDriver driver, MessageBoxIcon alertBoxIcon,
            string alertBoxMessage, long timeoutInSeconds = 5)
        {
            driver.AlertBoxAssertNotExistsCore(false, alertBoxIcon, alertBoxMessage, timeoutInSeconds);
        }

        public static void AlertBoxAssertNotExists(this WisejWebDriver driver, MessageBoxIcon alertBoxIcon,
            long timeoutInSeconds = 5)
        {
            driver.AlertBoxAssertNotExistsCore(false, alertBoxIcon, string.Empty, timeoutInSeconds);
        }

        public static void AlertBoxAssertNotExists(this WisejWebDriver driver, string alertBoxMessage = "",
            long timeoutInSeconds = 5)
        {
            driver.AlertBoxAssertNotExistsCore(true, MessageBoxIcon.None, alertBoxMessage, timeoutInSeconds);
        }

        #endregion

        #region AlertBox close

        public static void AlertBoxClose(this WisejWebDriver driver, MessageBoxIcon alertBoxIcon,
            string alertBoxMessage, long timeoutInSeconds = 5)
        {
            driver.AlertBoxCloseCore(alertBoxIcon, false, alertBoxMessage, timeoutInSeconds);
        }

        public static void AlertBoxClose(this WisejWebDriver driver, MessageBoxIcon alertBoxIcon,
            long timeoutInSeconds = 5)
        {
            driver.AlertBoxCloseCore(alertBoxIcon, false, string.Empty, timeoutInSeconds);
        }

        public static void AlertBoxClose(this WisejWebDriver driver, string alertBoxMessage = "",
            long timeoutInSeconds = 5)
        {
            driver.AlertBoxCloseCore(MessageBoxIcon.None, true, alertBoxMessage, timeoutInSeconds);
        }

        private static void AlertBoxCloseCore(this WisejWebDriver driver, MessageBoxIcon alertBoxIcon, bool ignoreIcon,
            string alertBoxMessage = "", long timeoutInSeconds = 5)
        {
            AlertBox alertBox = driver.AlertBoxGetCore(ignoreIcon, alertBoxIcon, alertBoxMessage, timeoutInSeconds);
            Assert.IsNotNull(alertBox,
                GetMessage("AlertBox with {0} not found.", ignoreIcon, alertBoxIcon, alertBoxMessage));

            IWidget closeButton = alertBox.CloseButton;
            Assert.IsNotNull(closeButton,
                GetMessage("AlertBox close button with {0} not found.", ignoreIcon, alertBoxIcon, alertBoxMessage));
            Assert.IsTrue(closeButton.Enabled,
                GetMessage("AlertBox close button with {0} isn\'t enabled.", ignoreIcon, alertBoxIcon,
                    alertBoxMessage));
            closeButton.Click();
        }

        #endregion
    }
}