using Microsoft.VisualStudio.TestTools.UnitTesting;
using Qooxdoo.WebDriver.UI;
using Wisej.Web.Ext.Selenium.UI;

namespace Wisej.Web.Ext.Selenium.Tests
{
    public static class HelperButton
    {
        public static void ButtonClick(this WisejWebDriver driver, string path, long timeoutInSeconds = 5)
        {
            var button = driver.WidgetGet<Button>(path, timeoutInSeconds);
            Assert.IsTrue(button.Enabled, string.Format("Button {0} isn't enabled.", path));
            button.Click();
        }

        public static void ButtonClick(this IWidget parent, string path, long timeoutInSeconds = 5)
        {
            var button = parent.WidgetGet<Button>(path, timeoutInSeconds);
            Assert.IsTrue(button.Enabled, string.Format("Button {0} isn't enabled.", path));
            button.Click();
        }
    }
}