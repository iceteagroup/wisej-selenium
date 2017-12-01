using Microsoft.VisualStudio.TestTools.UnitTesting;
using Qooxdoo.WebDriver.UI;

namespace Wisej.Web.Ext.Selenium.Tests
{
    public static class HelperValue
    {
        public static void AssertValue(this IHaveValue iHaveValue, string value)
        {
            AssertValueCore(iHaveValue, "", value);
        }

        public static void AssertValue(this WisejWebDriver driver, string path, string value,
            long timeoutInSeconds = 5)
        {
            var iHaveValue = driver.WidgetGet<IHaveValue>(path, timeoutInSeconds);
            AssertValueCore(iHaveValue, path, value);
        }

        public static void AssertValue(this IWidget parent, string path, string value,
            long timeoutInSeconds = 5)
        {
            var iHaveValue = parent.WidgetGet<IHaveValue>(path, timeoutInSeconds);
            AssertValueCore(iHaveValue, path, value);
        }

        private static void AssertValueCore(this IHaveValue iHaveValue, string path, string value)
        {
            Assert.IsNotNull(iHaveValue, string.Format("Could not cast {0} to IHaveValue.", path));

            var iHaveValueValue = iHaveValue.Value;
            //Assert.AreEqual(value, iHaveValueValue, string.Format("Expected {0} and actual is {1}.", value, iHaveValueValue));
            Assert.AreEqual(value, iHaveValueValue);
        }

        public static string GetValue(this WisejWebDriver driver, string path, long timeoutInSeconds = 5)
        {
            var iHaveValue = driver.WidgetGet<IHaveValue>(path, timeoutInSeconds);
            return GetValueCore(iHaveValue, path);
        }

        public static string GetValue(this IWidget parent, string path, long timeoutInSeconds = 5)
        {
            var iHaveValue = parent.WidgetGet<IHaveValue>(path, timeoutInSeconds);
            return GetValueCore(iHaveValue, path);
        }

        private static string GetValueCore(this IHaveValue iHaveValue, string path)
        {
            Assert.IsNotNull(iHaveValue, string.Format("Could not cast {0} to IHaveValue.", path));
            return iHaveValue.Value;
        }
    }
}