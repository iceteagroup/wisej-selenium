using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        /// Clicks a <see cref="Button"/>.
        /// </summary>
        /// <param name="driver">The <see cref="WisejWebDriver"/> to use.</param>
        /// <param name="path">The widget path.</param>
        /// <param name="timeoutInSeconds">The number of seconds to wait for the Button (default is 5).</param>
        public static void ButtonClick(this WisejWebDriver driver, string path, long timeoutInSeconds = 5)
        {
            Button button = driver.WidgetGet<Button>(path, timeoutInSeconds);
            Assert.IsTrue(button.Enabled, string.Format("Button {0} isn't enabled.", path));
            button.Click();
        }

        /// <summary>
        /// Clicks a <see cref="Button"/>.
        /// </summary>
        /// <param name="parent">The parent widget.</param>
        /// <param name="path">The widget path.</param>
        /// <param name="timeoutInSeconds">The number of seconds to wait for the Button (default is 5).</param>
        public static void ButtonClick(this IWidget parent, string path, long timeoutInSeconds = 5)
        {
            Button button = parent.WidgetGet<Button>(path, timeoutInSeconds);
            Assert.IsTrue(button.Enabled, string.Format("Button {0} isn't enabled.", path));
            button.Click();
        }
    }
}