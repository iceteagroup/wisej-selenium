using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Qooxdoo.WebDriver.UI;

namespace Wisej.Web.Ext.Selenium.Tests
{
    public static class HelperWidget
    {
        #region WidgetGet

        public static IWidget WidgetGet(this WisejWebDriver driver, string path, string widgetType,
            long timeoutInSeconds = 5)
        {
            IWidget widget = driver.FindWidget(path);
            Assert.IsNotNull(widget, string.Format("{0} {1} not found.", widgetType, path));
            return widget;
        }

        public static IWidget WidgetGet(this IWidget parent, string path, string widgetType,
            long timeoutInSeconds = 5)
        {
            IWidget widget = parent.FindWidget(path);
            Assert.IsNotNull(widget, string.Format("{0} {1} not found.", widgetType, path));
            return widget;
        }

        public static T WidgetGet<T>(this WisejWebDriver driver, string path, long timeoutInSeconds = 5)
        {
            T widget = (T) driver.FindWidget(path);
            Assert.IsNotNull(widget, string.Format("{0} {1} not found.", typeof(T).Name, path));
            return widget;
        }

        public static T WidgetGet<T>(this IWidget parent, string path, long timeoutInSeconds = 5)
        {
            T widget = (T) parent.FindWidget(path);
            Assert.IsNotNull(widget, string.Format("{0} {1} not found.", typeof(T).Name, path));
            return widget;
        }

        #endregion

        #region WidgetRefresh

        public static IWidget WidgetRefresh(this WisejWebDriver driver, string path, string widgetType,
            long timeoutInSeconds = 5)
        {
            IWidget widget = driver.Refresh(path);
            Assert.IsNotNull(widget, string.Format("{0} {1} not found.", widgetType, path));
            return widget;
        }

        public static IWidget WidgetRefresh(this IWidget parent, string path, string widgetType,
            long timeoutInSeconds = 5)
        {
            IWidget widget = parent.RefreshWidget(path);
            Assert.IsNotNull(widget, string.Format("{0} {1} not found.", widgetType, path));
            return widget;
        }

        public static T WidgetRefresh<T>(this WisejWebDriver driver, string path, long timeoutInSeconds = 5)
        {
            T widget = (T) driver.Refresh(path);
            Assert.IsNotNull(widget, string.Format("{0} {1} not found.", typeof(T).Name, path));
            return widget;
        }

        public static T WidgetRefresh<T>(this IWidget parent, string path, long timeoutInSeconds = 5)
        {
            T widget = (T) parent.RefreshWidget(path);
            Assert.IsNotNull(widget, string.Format("{0} {1} not found.", typeof(T).Name, path));
            return widget;
        }

        #endregion

        #region Text

        public static void AssertText(this IWidget widget, string text)
        {
            WidgetAssertTextCore(widget, text);
        }

        public static void WidgetAssertText(this WisejWebDriver driver, string path, string text, string widgetType,
            long timeoutInSeconds = 5)
        {
            var widget = driver.WidgetGet(path, widgetType, timeoutInSeconds);
            WidgetAssertTextCore(widget, text);
        }

        public static void WidgetAssertText(this IWidget parent, string path, string text, string widgetType,
            long timeoutInSeconds = 5)
        {
            var widget = parent.WidgetGet(path, widgetType, timeoutInSeconds);
            WidgetAssertTextCore(widget, text);
        }

        private static void WidgetAssertTextCore(this IWidget widget, string text)
        {
            var widgetText = widget.Text;
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

        public static void AssertIsEnabled(this IWidget widget, string name = "")
        {
            var message = GetMessage("is not Enabled.", widget.GetType().Name, name);
            Assert.IsTrue(widget.Enabled, message);
        }

        public static void AssertIsNotEnabled(this IWidget widget, string name = "")
        {
            var message = GetMessage("is Enabled.", widget.GetType().Name, name);
            Assert.IsFalse(widget.Enabled, message);
        }

        #endregion

        #region Selected

        public static void AssertIsSelected(this IWidget widget, string name = "")
        {
            var message = GetMessage("is not Selected.", widget.GetType().Name, name);
            Assert.IsTrue(widget.Selected, message);
        }

        public static void AssertIsNotSelected(this IWidget widget, string name = "")
        {
            var message = GetMessage("is Selected.", widget.GetType().Name, name);
            Assert.IsFalse(widget.Selected, message);
        }

        #endregion

        #region Displayed

        public static void AssertIsDisplayed(this IWidget widget, string name = "")
        {
            var message = GetMessage("is not Displayed.", widget.GetType().Name, name);
            Assert.IsTrue(widget.Displayed, message);
        }

        public static void AssertIsNotDisplayed(this IWidget widget, string name = "")
        {
            var message = GetMessage("is Displayed.", widget.GetType().Name, name);
            Assert.IsFalse(widget.Displayed, message);
        }

        #endregion

        #region Disposed

        public static void AssertIsDisposed(this IWidget widget, string name = "")
        {
            var message = GetMessage("is not Disposed.", widget.GetType().Name, name);
            Assert.IsTrue(widget.IsDisposed, message);
        }

        public static void AssertIsNotDisposed(this IWidget widget, string name = "")
        {
            var message = GetMessage("is Disposed.", widget.GetType().Name, name);
            Assert.IsFalse(widget.IsDisposed, message);
        }

        #endregion

        #region Classname

        public static void AssertClassname(this IWidget widget, string classname)
        {
            Assert.AreEqual(widget.Classname, classname,
                string.Format("{0}: expected {1} and actual is {2}.", widget.GetType().Name, classname,
                    widget.Classname));
        }

        #endregion

        #region Location

        public static void AssertLocation(this IWidget widget, Point location)
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

        public static void AssertSize(this IWidget widget, Size size)
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