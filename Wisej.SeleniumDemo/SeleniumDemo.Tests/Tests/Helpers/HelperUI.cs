using Microsoft.VisualStudio.TestTools.UnitTesting;
using By = Qooxdoo.WebDriver.By;

namespace Wisej.Web.Ext.Selenium.Tests
{
    public static class HelperUI
    {
        #region By

        public static OpenQA.Selenium.By QxhByString(string expression)
        {
            OpenQA.Selenium.By by = By.Qxh(expression);
            Assert.IsNotNull(by, string.Format("Could not cast {0} to OpenQA.Selenium.By.", expression));
            return by;
        }

        #endregion
    }
}