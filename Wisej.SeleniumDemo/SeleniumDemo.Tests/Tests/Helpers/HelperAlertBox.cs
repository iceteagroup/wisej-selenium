using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Qooxdoo.WebDriver.UI;

namespace Wisej.Web.Ext.Selenium.Tests
{
    public static class HelperAlertBox
    {
        #region AlertBox Get

        public static IWidget AlertBoxGet(this WisejWebDriver driver, MessageBoxIcon alertBoxIcon,
            string alertBoxMessage = "", long timeoutInSeconds = 5)
        {
            return AlertBoxGetCore(driver, alertBoxIcon, false, alertBoxMessage, timeoutInSeconds);
        }

        public static IWidget AlertBoxGet(this WisejWebDriver driver, string alertBoxMessage = "",
            long timeoutInSeconds = 5)
        {
            return AlertBoxGetCore(driver, MessageBoxIcon.None, true, alertBoxMessage, timeoutInSeconds);
        }

        private static IWidget AlertBoxGetCore(this WisejWebDriver driver, MessageBoxIcon alertBoxIcon, bool ignoreIcon,
            string alertBoxMessage = "", long timeoutInSeconds = 5)
        {
            var alertBoxManagerBy = HelperUI.QxhByString("qx.ui.container.Composite");
            IWidget alertBoxManager = driver.WaitForWidget(alertBoxManagerBy, timeoutInSeconds);
            Assert.IsNotNull(alertBoxManager, "AlertBox manager not found.");

            return WaitForAlertBox(driver, alertBoxManager, alertBoxIcon, ignoreIcon, alertBoxMessage,
                timeoutInSeconds);
        }

        private static IWidget WaitForAlertBox(this WisejWebDriver driver, IWidget alertBoxManager,
            MessageBoxIcon alertBoxIcon, bool ignoreIcon, string alertBoxMessage, long timeoutInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            IWidget widget;
            try
            {
                widget = wait.Until(AlertBoxExists(alertBoxManager, alertBoxIcon, ignoreIcon, alertBoxMessage));
            }
            catch (WebDriverTimeoutException e)
            {
                throw new NoSuchElementException("Unable to find element for locator.", e);
            }

            Assert.IsNotNull(widget, "AlertBox not found.");
            return widget;
        }

        public static Func<IWebDriver, IWidget> AlertBoxExists(IWidget alertBoxManager, MessageBoxIcon alertBoxIcon,
            bool ignoreIcon, string alertBoxMessage)
        {
            return driver =>
            {
                foreach (var alertBox in alertBoxManager.Children)
                {
                    var matchIcon = false;
                    var matchMessage = false;

                    // check icon type
                    if (!ignoreIcon)
                    {
                        object icon = null;
                        try
                        {
                            icon = alertBox.GetPropertyValue("icon");
                        }
                        catch (Exception)
                        {
                        }
                        Assert.IsNotNull(icon, "AlertBox icon not found.");

                        if (alertBoxIcon.ToString().ToUpper() == icon.ToString().ToUpper())
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
                        string message = null;
                        try
                        {
                            message = (string) alertBox.GetPropertyValue("message");
                        }
                        catch (Exception)
                        {
                        }
                        Assert.IsNotNull(message, "AlertBox message not found.");

                        if (alertBoxMessage == message)
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
                        return alertBox;
                    }
                }


                return null;
            };
        }

        #endregion

        #region AlertBox close

        public static void AlertBoxClose(this WisejWebDriver driver, MessageBoxIcon alertBoxIcon,
            string alertBoxMessage = "", long timeoutInSeconds = 5)
        {
            AlertBoxCloseCore(driver, alertBoxIcon, false, alertBoxMessage, timeoutInSeconds);
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
            IWidget closeButton = null;
            try
            {
                closeButton = alertBox.GetChildControl("close");
            }
            catch (Exception)
            {
            }
            Assert.IsNotNull(closeButton, "AlertBox close button not found.");
            Assert.IsTrue(closeButton.Enabled, "AlertBox close button isn\'t enabled.");
            closeButton.Click();
        }

        #endregion

        // TODO: MessageBoxGetCaption
        // TODO: MessageBoxGetMessage
    }
}