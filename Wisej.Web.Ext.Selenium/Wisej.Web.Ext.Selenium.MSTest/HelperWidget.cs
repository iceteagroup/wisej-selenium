using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Qooxdoo.WebDriver.UI;

namespace Wisej.Web.Ext.Selenium.Tests
{
    /// <summary>
    /// Extension class with helper methods for handling <see cref="IWidget"/>.
    /// </summary>
    public static class HelperWidget
    {
        #region WidgetGet

        /// <summary>
        /// Returns an <see cref="IWidget"/> matching the specifyed parameters.
        /// </summary>
        /// <param name="driver">The <see cref="WisejWebDriver"/> to use.</param>
        /// <param name="path">The widget path.</param>
        /// <param name="widgetType">The widget type name.</param>
        /// <param name="timeoutInSeconds">The number of seconds to wait for the widget (default is 5).</param>
        /// <param name="assertIsDisplayed">If set to <c>true</c>, asserts the widget is displayed (default is <c>true</c>).</param>
        /// <returns>An <see cref="IWidget"/> that matches the specifyed search parameters.</returns>
        public static IWidget WidgetGet(this WisejWebDriver driver, string path, string widgetType,
            long timeoutInSeconds = 5, bool assertIsDisplayed = true)
        {
            IWidget widget = driver.FindWidget(path);
            Assert.IsNotNull(widget, string.Format("{0} {1} not found.", widgetType, path));
            if (assertIsDisplayed)
                widget.AssertIsDisplayed("ButtonsWindow");
            return widget;
        }

        /// <summary>
        /// Returns an <see cref="IWidget"/> matching the specifyed parameters.
        /// </summary>
        /// <param name="parent">The parent widget.</param>
        /// <param name="path">The widget path.</param>
        /// <param name="widgetType">The widget type name.</param>
        /// <param name="timeoutInSeconds">The number of seconds to wait for the widget (default is 5).</param>
        /// <param name="assertIsDisplayed">If set to <c>true</c>, asserts the widget is displayed (default is <c>true</c>).</param>
        /// <returns>An <see cref="IWidget"/> that matches the specifyed search parameters.</returns>
        public static IWidget WidgetGet(this IWidget parent, string path, string widgetType, long timeoutInSeconds = 5,
            bool assertIsDisplayed = true)
        {
            IWidget widget = parent.FindWidget(path);
            Assert.IsNotNull(widget, string.Format("{0} {1} not found.", widgetType, path));
            if (assertIsDisplayed)
                widget.AssertIsDisplayed("ButtonsWindow");
            return widget;
        }

        /// <summary>
        /// Returns a widget of type <typeparamref name="T"/> that matches the specifyed parameters.
        /// </summary>
        /// <typeparam name="T">The type of the widget to return.</typeparam>
        /// <param name="driver">The <see cref="WisejWebDriver"/> to use.</param>
        /// <param name="path">The widget path.</param>
        /// <param name="timeoutInSeconds">The number of seconds to wait for the widget (default is 5).</param>
        /// <param name="assertIsDisplayed">If set to <c>true</c>, asserts the widget is displayed (default is <c>true</c>).</param>
        /// <returns>A widget of type <typeparamref name="T"/> that matches the specifyed parameters.</returns>
        public static T WidgetGet<T>(this WisejWebDriver driver, string path, long timeoutInSeconds = 5,
            bool assertIsDisplayed = true)
        {
            T widget = (T) driver.FindWidget(path);
            Assert.IsNotNull(widget, string.Format("{0} {1} not found.", typeof(T).Name, path));
            if (assertIsDisplayed && widget is IWidget)
                ((IWidget) widget).AssertIsDisplayed("ButtonsWindow");
            return widget;
        }

        /// <summary>
        /// Returns a widget of type <typeparamref name="T"/> that matches the specifyed parameters.
        /// </summary>
        /// <typeparam name="T">The type of the widget to return.</typeparam>
        /// <param name="parent">The parent widget.</param>
        /// <param name="path">The widget path.</param>
        /// <param name="timeoutInSeconds">The number of seconds to wait for the widget (default is 5).</param>
        /// <param name="assertIsDisplayed">If set to <c>true</c>, asserts the widget is displayed (default is <c>true</c>).</param>
        /// <returns>A widget of type <typeparamref name="T"/> that matches the specifyed parameters.</returns>
        public static T WidgetGet<T>(this IWidget parent, string path, long timeoutInSeconds = 5,
            bool assertIsDisplayed = true)
        {
            T widget = (T) parent.FindWidget(path);
            Assert.IsNotNull(widget, string.Format("{0} {1} not found.", typeof(T).Name, path));
            if (assertIsDisplayed && widget is IWidget)
                ((IWidget) widget).AssertIsDisplayed("ButtonsWindow");
            return widget;
        }

        #endregion

        #region WidgetRefresh

        /// <summary>
        /// Returns an <see cref="IWidget"/> newly fetched from the browser.
        /// </summary>
        /// <param name="driver">The <see cref="WisejWebDriver"/> to use.</param>
        /// <param name="path">The widget path.</param>
        /// <param name="widgetType">The widget type name.</param>
        /// <param name="timeoutInSeconds">The number of seconds to wait for the widget (default is 5).</param>
        /// <returns>An widget newly fetched from the browser.</returns>
        /// <remarks>
        /// Removes an existing widget from the cache and fetches a fresh widget from the browser.
        /// </remarks>
        public static IWidget WidgetRefresh(this WisejWebDriver driver, string path, string widgetType,
            long timeoutInSeconds = 5)
        {
            IWidget widget = driver.Refresh(path);
            Assert.IsNotNull(widget, string.Format("{0} {1} not found.", widgetType, path));
            return widget;
        }

        /// <summary>
        /// Returns an <see cref="IWidget"/> newly fetched from the browser.
        /// </summary>
        /// <param name="parent">The parent widget.</param>
        /// <param name="path">The widget path.</param>
        /// <param name="widgetType">The widget type name.</param>
        /// <param name="timeoutInSeconds">The number of seconds to wait for the widget (default is 5).</param>
        /// <returns>An widget newly fetched from the browser.</returns>
        /// <remarks>
        /// Removes an existing widget from the cache and fetches a fresh widget from the browser.
        /// </remarks>
        public static IWidget WidgetRefresh(this IWidget parent, string path, string widgetType,
            long timeoutInSeconds = 5)
        {
            IWidget widget = parent.RefreshWidget(path);
            Assert.IsNotNull(widget, string.Format("{0} {1} not found.", widgetType, path));
            return widget;
        }

        /// <summary>
        /// Returns a widget of type <typeparamref name="T"/> newly fetched from the browser.
        /// </summary>
        /// <typeparam name="T">The type of the widget to return.</typeparam>
        /// <param name="driver">The <see cref="WisejWebDriver"/> to use.</param>
        /// <param name="path">The widget path.</param>
        /// <param name="timeoutInSeconds">The number of seconds to wait for the widget (default is 5).</param>
        /// <returns>An widget newly fetched from the browser.</returns>
        /// <remarks>
        /// Removes an existing widget from the cache and fetches a fresh widget from the browser.
        /// </remarks>
        public static T WidgetRefresh<T>(this WisejWebDriver driver, string path, long timeoutInSeconds = 5)
        {
            T widget = (T) driver.Refresh(path);
            Assert.IsNotNull(widget, string.Format("{0} {1} not found.", typeof(T).Name, path));
            return widget;
        }

        /// <summary>
        /// Returns a widget of type <typeparamref name="T"/> newly fetched from the browser.
        /// </summary>
        /// <typeparam name="T">The type of the widget to return.</typeparam>
        /// <param name="parent">The parent widget.</param>
        /// <param name="path">The widget path.</param>
        /// <param name="timeoutInSeconds">The number of seconds to wait for the widget (default is 5).</param>
        /// <returns>An widget newly fetched from the browser.</returns>
        /// <remarks>
        /// Removes an existing widget from the cache and fetches a fresh widget from the browser.
        /// </remarks>
        public static T WidgetRefresh<T>(this IWidget parent, string path, long timeoutInSeconds = 5)
        {
            T widget = (T) parent.RefreshWidget(path);
            Assert.IsNotNull(widget, string.Format("{0} {1} not found.", typeof(T).Name, path));
            return widget;
        }

        #endregion

        #region Text

        /// <summary>
        /// Asserts the widget text matches the specifyed string.
        /// </summary>
        /// <param name="widget">The target widget.</param>
        /// <param name="text">The text to match.</param>
        public static void AssertTextIs(this IWidget widget, string text)
        {
            WidgetAssertTextCore(widget, text);
        }

        /// <summary>
        /// Asserts the text of the widget with the given path, matches the specifyed string.
        /// </summary>
        /// <param name="driver">The <see cref="WisejWebDriver"/> to use.</param>
        /// <param name="path">The widget path.</param>
        /// <param name="text">The text to match.</param>
        /// <param name="widgetType">The widget type name.</param>
        /// <param name="timeoutInSeconds">The number of seconds to wait for the widget (default is 5).</param>
        public static void WidgetAssertTextIs(this WisejWebDriver driver, string path, string text, string widgetType,
            long timeoutInSeconds = 5)
        {
            IWidget widget = driver.WidgetGet(path, widgetType, timeoutInSeconds);
            WidgetAssertTextCore(widget, text);
        }

        /// <summary>
        /// Asserts the text of the widget with the given parent and path, matches the specifyed string.
        /// </summary>
        /// <param name="parent">The parent widget.</param>
        /// <param name="path">The widget path.</param>
        /// <param name="text">The text to match.</param>
        /// <param name="widgetType">The widget type name.</param>
        /// <param name="timeoutInSeconds">The number of seconds to wait for the widget (default is 5).</param>
        public static void WidgetAssertTextIs(this IWidget parent, string path, string text, string widgetType,
            long timeoutInSeconds = 5)
        {
            IWidget widget = parent.WidgetGet(path, widgetType, timeoutInSeconds);
            WidgetAssertTextCore(widget, text);
        }

        private static void WidgetAssertTextCore(this IWidget widget, string text)
        {
            string widgetText = widget.Text;
            //Assert.AreEqual(text, widgetText, string.Format("Expected {0} and actual is {1}.", text, widgetText));
            Assert.AreEqual(text, widgetText);
        }

        #endregion

        private static string GetMessage(string baseMessage, string widgetType, string name)
        {
            var message = string.Empty;
            if (!string.IsNullOrWhiteSpace(widgetType))
                message += widgetType + " ";
            if (!string.IsNullOrWhiteSpace(name))
                message += name + " ";
            if (string.IsNullOrWhiteSpace(message))
                message = "Widget ";
            message += baseMessage;

            return message;
        }

        #region Enabled

        /// <summary>
        /// Asserts the widget is enabled.
        /// </summary>
        /// <param name="widget">The target widget.</param>
        /// <param name="name">The widget name (default is an empty string).</param>
        public static void AssertIsEnabled(this IWidget widget, string name = "")
        {
            var message = GetMessage("is not Enabled.", widget.GetType().Name, name);
            Assert.IsTrue(widget.Enabled, message);
        }

        /// <summary>
        /// Asserts the widget is not enabled.
        /// </summary>
        /// <param name="widget">The target widget.</param>
        /// <param name="name">The widget name (default is an empty string).</param>
        public static void AssertIsNotEnabled(this IWidget widget, string name = "")
        {
            var message = GetMessage("is Enabled.", widget.GetType().Name, name);
            Assert.IsFalse(widget.Enabled, message);
        }

        #endregion

        #region Selected

        /// <summary>
        /// Asserts the widget is selected.
        /// </summary>
        /// <param name="widget">The target widget.</param>
        /// <param name="name">The widget name (default is an empty string).</param>
        public static void AssertIsSelected(this IWidget widget, string name = "")
        {
            var message = GetMessage("is not Selected.", widget.GetType().Name, name);
            Assert.IsTrue(widget.Selected, message);
        }

        /// <summary>
        /// Asserts the widget is not selected.
        /// </summary>
        /// <param name="widget">The target widget.</param>
        /// <param name="name">The widget name (default is an empty string).</param>
        public static void AssertIsNotSelected(this IWidget widget, string name = "")
        {
            var message = GetMessage("is Selected.", widget.GetType().Name, name);
            Assert.IsFalse(widget.Selected, message);
        }

        #endregion

        #region Displayed

        /// <summary>
        /// Asserts the widget is displayed.
        /// </summary>
        /// <param name="widget">The target widget.</param>
        /// <param name="name">The widget name (default is an empty string).</param>
        public static void AssertIsDisplayed(this IWidget widget, string name = "")
        {
            var message = GetMessage("is not Displayed.", widget.GetType().Name, name);
            Assert.IsTrue(widget.Displayed, message);
        }

        /// <summary>
        /// Asserts the widget is not displayed.
        /// </summary>
        /// <param name="widget">The target widget.</param>
        /// <param name="name">The widget name (default is an empty string).</param>
        public static void AssertIsNotDisplayed(this IWidget widget, string name = "")
        {
            var message = GetMessage("is Displayed.", widget.GetType().Name, name);
            Assert.IsFalse(widget.Displayed, message);
        }

        #endregion

        #region Disposed

        /// <summary>
        /// Asserts the widget is disposed.
        /// </summary>
        /// <param name="widget">The target widget.</param>
        /// <param name="name">The widget name (default is an empty string).</param>
        public static void AssertIsDisposed(this IWidget widget, string name = "")
        {
            var message = GetMessage("is not Disposed.", widget.GetType().Name, name);
            Assert.IsTrue(widget.IsDisposed, message);
        }

        /// <summary>
        /// Asserts the widget is not disposed.
        /// </summary>
        /// <param name="widget">The target widget.</param>
        /// <param name="name">The widget name (default is an empty string).</param>
        public static void AssertIsNotDisposed(this IWidget widget, string name = "")
        {
            var message = GetMessage("is Disposed.", widget.GetType().Name, name);
            Assert.IsFalse(widget.IsDisposed, message);
        }

        #endregion

        #region ClassName

        /// <summary>
        /// Asserts the widget class name matches the specifyed string.
        /// </summary>
        /// <param name="widget">The target widget.</param>
        /// <param name="className">The class name to match.</param>
        public static void AssertClassNameIs(this IWidget widget, string className)
        {
            /*Assert.AreEqual(widget.ClassName, className,
                string.Format("{0}: expected {1} and actual is {2}.", widget.GetType().Name, className, 
                    widget.ClassName));*/
            Assert.AreEqual(widget.ClassName, className);
        }

        #endregion

        #region Location

        /// <summary>
        /// Asserts the widget location matches the specifyed location.
        /// </summary>
        /// <param name="widget">The target widget.</param>
        /// <param name="location">The location to match.</param>
        public static void AssertLocationIs(this IWidget widget, Point location)
        {
            Assert.AreEqual(widget.Location.X, location.X,
                string.Format("{0}.X: expected {1} and actual is {2}.", widget.GetType().Name, location.X,
                    widget.Location.X));
            Assert.AreEqual(widget.Location.Y, location.Y,
                string.Format("{0}.Y: expected {1} and actual is {2}.", widget.GetType().Name, location.Y,
                    widget.Location.Y));
        }

        #endregion

        #region Size

        /// <summary>
        /// Asserts the widget size matches the specifyed size.
        /// </summary>
        /// <param name="widget">The target widget.</param>
        /// <param name="size">The size to match.</param>
        public static void AssertSizeIs(this IWidget widget, Size size)
        {
            Assert.AreEqual(widget.Size.Width, size.Width,
                string.Format("{0}.Width: expected {1} and actual is {2}.", widget.GetType().Name, size.Width,
                    widget.Size.Width));
            Assert.AreEqual(widget.Size.Height, size.Height,
                string.Format("{0}.Height: expected {1} and actual is {2}.", widget.GetType().Name, size.Height,
                    widget.Size.Height));
        }

        #endregion
    }
}