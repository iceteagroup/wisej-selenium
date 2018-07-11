using Qooxdoo.WebDriver.UI;
using Wisej.Web.Ext.Selenium.UI;

namespace Wisej.Web.Ext.Selenium.Tests
{
    /// <summary>
    /// Extension class with helper methods for handling <see cref="Button"/>.
    /// </summary>
    public static class HelperButton
    {
        /// <summary>
        /// Clicks a <see cref="Button"/>, if it's Enabled.
        /// </summary>
        /// <param name="driver">The <see cref="WisejWebDriver"/> to use.</param>
        /// <param name="path">The widget path.</param>
        /// <param name="timeoutInSeconds">The number of seconds to wait for the Button (default is 5).</param>
        public static void ButtonClick(this WisejWebDriver driver, string path, int timeoutInSeconds = 5)
        {
            Button button = driver.WidgetGet<Button>(path, timeoutInSeconds);
            button.Click();
        }

        /// <summary>
        /// Clicks a <see cref="Button"/>, if it's Enabled.
        /// </summary>
        /// <param name="parent">The parent widget.</param>
        /// <param name="path">The widget path.</param>
        /// <param name="timeoutInSeconds">The number of seconds to wait for the Button (default is 5).</param>
        public static void ButtonClick(this IWidget parent, string path, int timeoutInSeconds = 5)
        {
            Button button = parent.WidgetGet<Button>(path, timeoutInSeconds);
            button.Click();
        }

        /// <summary>
        /// Clicks a <see cref="Button"/>, even if not Enabled.
        /// </summary>
        /// <param name="driver">The <see cref="WisejWebDriver"/> to use.</param>
        /// <param name="path">The widget path.</param>
        /// <param name="timeoutInSeconds">The number of seconds to wait for the Button (default is 5).</param>
        public static void ButtonForceClick(this WisejWebDriver driver, string path, int timeoutInSeconds = 5)
        {
            Button button = driver.WidgetGet<Button>(path, timeoutInSeconds);
            button.ForceClick();
        }

        /// <summary>
        /// Clicks a <see cref="Button"/>, even if not Enabled.
        /// </summary>
        /// <param name="parent">The parent widget.</param>
        /// <param name="path">The widget path.</param>
        /// <param name="timeoutInSeconds">The number of seconds to wait for the Button (default is 5).</param>
        public static void ButtonForceClick(this IWidget parent, string path, int timeoutInSeconds = 5)
        {
            Button button = parent.WidgetGet<Button>(path, timeoutInSeconds);
            button.ForceClick();
        }
    }
}