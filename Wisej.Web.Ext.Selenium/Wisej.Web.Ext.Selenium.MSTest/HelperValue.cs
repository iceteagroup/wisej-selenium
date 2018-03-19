using Microsoft.VisualStudio.TestTools.UnitTesting;
using Qooxdoo.WebDriver.UI;

namespace Wisej.Web.Ext.Selenium.Tests
{
    /// <summary>
    /// Extension class with helper methods for handling <see cref="IHaveValue"/> widgets.
    /// </summary>
    public static class HelperValue
    {
        /// <summary>
        /// Checks the widget value matches the specified string.
        /// </summary>
        /// <param name="iHaveValue">The <see cref="IHaveValue"/> widget.</param>
        /// <param name="value">The value to check.</param>
        public static void CheckValueIs(this IHaveValue iHaveValue, string value)
        {
            CheckValueCore(iHaveValue, "", value);
        }

        /// <summary>
        /// Checks the widget value matches the specified string.
        /// </summary>
        /// <param name="driver">The <see cref="WisejWebDriver"/> to use.</param>
        /// <param name="path">The widget path.</param>
        /// <param name="value">The value to check.</param>
        /// <param name="timeoutInSeconds">The number of seconds to wait for the widget (default is 5).</param>
        public static void CheckValueIs(this WisejWebDriver driver, string path, string value,
            int timeoutInSeconds = 5)
        {
            IHaveValue iHaveValue = driver.WidgetGet<IHaveValue>(path, timeoutInSeconds);
            CheckValueCore(iHaveValue, path, value);
        }

        /// <summary>
        /// Checks the widget value matches the specified string.
        /// </summary>
        /// <param name="parent">The parent widget.</param>
        /// <param name="path">The widget path.</param>
        /// <param name="value">The value to check.</param>
        /// <param name="timeoutInSeconds">The number of seconds to wait for the widget (default is 5).</param>
        public static void CheckValueIs(this IWidget parent, string path, string value,
            int timeoutInSeconds = 5)
        {
            IHaveValue iHaveValue = parent.WidgetGet<IHaveValue>(path, timeoutInSeconds);
            CheckValueCore(iHaveValue, path, value);
        }

        private static void CheckValueCore(this IHaveValue iHaveValue, string path, string value)
        {
            Assert.IsNotNull(iHaveValue, string.Format("Could not cast {0} to IHaveValue.", path));

            string iHaveValueValue = iHaveValue.Value;
            //Assert.AreEqual(value, iHaveValueValue, string.Format("Expected {0} and actual is {1}.", value, iHaveValueValue));
            Assert.AreEqual(value, iHaveValueValue);
        }

        /// <summary>
        /// Gets the widget value.
        /// </summary>
        /// <param name="driver">The <see cref="WisejWebDriver"/> to use.</param>
        /// <param name="path">The widget path.</param>
        /// <param name="timeoutInSeconds">The number of seconds to wait for the widget (default is 5).</param>
        /// <returns>A <see cref="string"/> with the widget value.</returns>
        public static string GetValue(this WisejWebDriver driver, string path, int timeoutInSeconds = 5)
        {
            IHaveValue iHaveValue = driver.WidgetGet<IHaveValue>(path, timeoutInSeconds);
            return GetValueCore(iHaveValue, path);
        }

        /// <summary>
        /// Gets the widget value.
        /// </summary>
        /// <param name="parent">The parent widget.</param>
        /// <param name="path">The widget path.</param>
        /// <param name="timeoutInSeconds">The number of seconds to wait for the widget (default is 5).</param>
        /// <returns>A <see cref="string"/> with the widget value.</returns>
        public static string GetValue(this IWidget parent, string path, int timeoutInSeconds = 5)
        {
            IHaveValue iHaveValue = parent.WidgetGet<IHaveValue>(path, timeoutInSeconds);
            return GetValueCore(iHaveValue, path);
        }

        private static string GetValueCore(this IHaveValue iHaveValue, string path)
        {
            Assert.IsNotNull(iHaveValue, string.Format("Could not cast {0} to IHaveValue.", path));
            return iHaveValue.Value;
        }
    }
}