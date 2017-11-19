using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Qooxdoo.WebDriver.UI;
using Wisej.Web.Ext.Selenium.UI;

namespace Wisej.Web.Ext.Selenium.Tests
{
    public static class HelperAlertBox
    {
        #region private utility stuff

        private static AlertBox _targetAlertBox;

        private static string GetMessage(string baseMessage, MessageBoxIcon alertBoxIcon,
            bool ignoreIcon, string alertBoxMessage = "")
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

        private static AlertBox AlertBoxGetCore(this WisejWebDriver driver, MessageBoxIcon alertBoxIcon,
            bool ignoreIcon, string alertBoxMessage = "", long timeoutInSeconds = 5)
        {
            AlertBox alertBox = WaitForAlertBox(driver, alertBoxIcon, ignoreIcon, alertBoxMessage, timeoutInSeconds);

            Assert.IsNotNull(alertBox,
                GetMessage("AlertBox with {0} not found.", alertBoxIcon, ignoreIcon, alertBoxMessage));
            return _targetAlertBox;
        }

        private static bool AlertBoxAssertNotExistsCore(this WisejWebDriver driver, MessageBoxIcon alertBoxIcon,
            bool ignoreIcon, string alertBoxMessage = "", long timeoutInSeconds = 5)
        {
            AlertBox alertBox = WaitForAlertBox(driver, alertBoxIcon, ignoreIcon, alertBoxMessage, timeoutInSeconds);

            Assert.IsNull(alertBox,
                GetMessage("AlertBox with {0} should not exist.", alertBoxIcon, ignoreIcon, alertBoxMessage));
            return _targetAlertBox == null;
        }

        private static AlertBox WaitForAlertBox(this WisejWebDriver driver, MessageBoxIcon alertBoxIcon,
            bool ignoreIcon,
            string alertBoxMessage, long timeoutInSeconds)
        {
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds))
                    .Until(AlertBoxExists(alertBoxIcon, ignoreIcon, alertBoxMessage));
            }
            catch (WebDriverTimeoutException)
            {
            }

            return _targetAlertBox;
        }

        public static Func<IWebDriver, bool> AlertBoxExists(MessageBoxIcon alertBoxIcon, bool ignoreIcon,
            string alertBoxMessage)
        {
            return driver =>
            {
                _targetAlertBox = null;
                AlertBox[] alertBoxes = ((WisejWebDriver) driver).AlertBoxes;
                if (alertBoxes != null)
                {
                    foreach (AlertBox alertBox in alertBoxes)
                    {
                        var matchIcon = false;
                        var matchMessage = false;

                        // check icon type
                        if (!ignoreIcon)
                        {
                            if (alertBoxIcon.ToString().ToUpper() == alertBox.Icon.ToUpper())
                            {
                                matchIcon = true;
                            }
                        }
                        else
                        {
                            matchIcon = true;
                        }

                        // check message box
                        if (!string.IsNullOrEmpty(alertBoxMessage))
                        {
                            if (alertBoxMessage == alertBox.Message)
                            {
                                matchMessage = true;
                            }
                        }
                        else
                        {
                            matchMessage = true;
                        }

                        if (matchIcon && matchMessage)
                        {
                            _targetAlertBox = alertBox;
                            return true;
                        }
                    }
                }

                return false;
            };
        }

        #endregion

        #region AlertBox Get

        public static AlertBox AlertBoxGet(this WisejWebDriver driver, MessageBoxIcon alertBoxIcon,
            string alertBoxMessage, long timeoutInSeconds = 5)
        {
            return AlertBoxGetCore(driver, alertBoxIcon, false, alertBoxMessage, timeoutInSeconds);
        }

        public static AlertBox AlertBoxGet(this WisejWebDriver driver, MessageBoxIcon alertBoxIcon,
            long timeoutInSeconds = 5)
        {
            return AlertBoxGetCore(driver, alertBoxIcon, false, string.Empty, timeoutInSeconds);
        }

        public static AlertBox AlertBoxGet(this WisejWebDriver driver, string alertBoxMessage = "",
            long timeoutInSeconds = 5)
        {
            return AlertBoxGetCore(driver, MessageBoxIcon.None, true, alertBoxMessage, timeoutInSeconds);
        }

        #endregion

        #region AlertBox Assert Not Exists

        public static bool AlertBoxAssertNotExists(this WisejWebDriver driver, MessageBoxIcon alertBoxIcon,
            string alertBoxMessage, long timeoutInSeconds = 5)
        {
            return AlertBoxAssertNotExistsCore(driver, alertBoxIcon, false, alertBoxMessage, timeoutInSeconds);
        }

        public static bool AlertBoxAssertNotExists(this WisejWebDriver driver, MessageBoxIcon alertBoxIcon,
            long timeoutInSeconds = 5)
        {
            return AlertBoxAssertNotExistsCore(driver, alertBoxIcon, false, string.Empty, timeoutInSeconds);
        }

        public static bool AlertBoxAssertNotExists(this WisejWebDriver driver, string alertBoxMessage = "",
            long timeoutInSeconds = 5)
        {
            return AlertBoxAssertNotExistsCore(driver, MessageBoxIcon.None, true, alertBoxMessage, timeoutInSeconds);
        }

        #endregion

        #region AlertBox close

        public static void AlertBoxClose(this WisejWebDriver driver, MessageBoxIcon alertBoxIcon,
            string alertBoxMessage, long timeoutInSeconds = 5)
        {
            AlertBoxCloseCore(driver, alertBoxIcon, false, alertBoxMessage, timeoutInSeconds);
        }

        public static void AlertBoxClose(this WisejWebDriver driver, MessageBoxIcon alertBoxIcon,
            long timeoutInSeconds = 5)
        {
            AlertBoxCloseCore(driver, alertBoxIcon, false, string.Empty, timeoutInSeconds);
        }

        public static void AlertBoxClose(this WisejWebDriver driver, string alertBoxMessage = "",
            long timeoutInSeconds = 5)
        {
            AlertBoxCloseCore(driver, MessageBoxIcon.None, true, alertBoxMessage, timeoutInSeconds);
        }

        private static void AlertBoxCloseCore(this WisejWebDriver driver, MessageBoxIcon alertBoxIcon, bool ignoreIcon,
            string alertBoxMessage = "", long timeoutInSeconds = 5)
        {
            var alertBox = AlertBoxGetCore(driver, alertBoxIcon, ignoreIcon, alertBoxMessage, timeoutInSeconds);
            Assert.IsNotNull(alertBox,
                GetMessage("AlertBox with {0} not found.", alertBoxIcon, ignoreIcon, alertBoxMessage));

            IWidget closeButton = alertBox.CloseButton;
            Assert.IsNotNull(closeButton,
                GetMessage("AlertBox close button with {0} not found.", alertBoxIcon, ignoreIcon, alertBoxMessage));
            Assert.IsTrue(closeButton.Enabled,
                GetMessage("AlertBox close button with {0} isn\'t enabled.", alertBoxIcon, ignoreIcon,
                    alertBoxMessage));
            closeButton.Click();
        }

        #endregion
    }
}