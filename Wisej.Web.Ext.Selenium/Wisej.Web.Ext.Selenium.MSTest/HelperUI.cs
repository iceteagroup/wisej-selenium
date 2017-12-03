using Microsoft.VisualStudio.TestTools.UnitTesting;
using By = Qooxdoo.WebDriver.By;

namespace Wisej.Web.Ext.Selenium.Tests
{
    /// <summary>
    /// Extension class with helper methods for handling qooxdoo application's widget hierarchy expresions.
    /// </summary>
    public static class HelperUI
    {
        /// <summary>
        /// Casts a qooxdoo application's widget hierarchy expresion to <see cref="OpenQA.Selenium.By"/> mechanism.
        /// </summary>
        /// <param name="expression">The qooxdoo application's widget hierarchy expresion.</param>
        /// <returns>Returns a <see cref="OpenQA.Selenium.By"/> mechanism.</returns>
        public static OpenQA.Selenium.By QxhByString(string expression)
        {
            OpenQA.Selenium.By by = By.Qxh(expression);
            Assert.IsNotNull(by, string.Format("Could not cast {0} to OpenQA.Selenium.By.", expression));
            return by;
        }
    }
}