///////////////////////////////////////////////////////////////////////////////
//
// (C) 2017 ICE TEA GROUP LLC - ALL RIGHTS RESERVED
//
// 
//
// ALL INFORMATION CONTAINED HEREIN IS, AND REMAINS
// THE PROPERTY OF ICE TEA GROUP LLC AND ITS SUPPLIERS, IF ANY.
// THE INTELLECTUAL PROPERTY AND TECHNICAL CONCEPTS CONTAINED
// HEREIN ARE PROPRIETARY TO ICE TEA GROUP LLC AND ITS SUPPLIERS
// AND MAY BE COVERED BY U.S. AND FOREIGN PATENTS, PATENT IN PROCESS, AND
// ARE PROTECTED BY TRADE SECRET OR COPYRIGHT LAW.
//
// DISSEMINATION OF THIS INFORMATION OR REPRODUCTION OF THIS MATERIAL
// IS STRICTLY FORBIDDEN UNLESS PRIOR WRITTEN PERMISSION IS OBTAINED
// FROM ICE TEA GROUP LLC.
//
///////////////////////////////////////////////////////////////////////////////

using Qooxdoo.WebDriver.UI;

namespace Wisej.Web.Ext.Selenium
{
    /// <summary>
    /// Adds method to <see cref="IWidget"/>.
    /// </summary>
    public static class WidgetExtensions
    {
        /// <summary>
        /// Returns the child widget identified by the specified <para>path</para>.
        /// </summary>
        /// <param name="parent">The parent widget.</param>
        /// <param name="path">The path string.</param>
        /// <param name="timeoutInSeconds">The time to wait for the widget (seconds).</param>
        /// <returns>The <see cref="IWidget"/> that matches the <para>path</para>.</returns>
        public static IWidget FindWidget(this IWidget parent, string path, long timeoutInSeconds = 5)
        {
            var driver = (WisejWebDriver) parent.Driver;
            return driver.FindChildWidget(parent, path, timeoutInSeconds);
        }

        /// <summary>
        /// Gets a newly fecthed child <see cref="IWidget"/> from the browser.
        /// </summary>
        /// <param name="parent">The parent widget.</param>
        /// <param name="path">The path string.</param>
        /// <param name="timeoutInSeconds">The time to wait for the widget (seconds).</param>
        /// <returns>The child <see cref="IWidget"/> that matches the <para>path</para>.</returns>
        public static IWidget RefreshWidget(this IWidget parent, string path, long timeoutInSeconds = 5)
        {
            var driver = (WisejWebDriver) parent.Driver;
            return driver.RefreshChildWidget(parent, path, timeoutInSeconds);
        }
    }
}