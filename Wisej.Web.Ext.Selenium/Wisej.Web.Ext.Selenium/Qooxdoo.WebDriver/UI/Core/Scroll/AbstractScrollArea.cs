/*************************************************************************

   qxwebdriver-java

   http://github.com/qooxdoo/qxwebdriver-java

   Copyright:
     2012-2013 1&1 Internet AG, Germany, http://www.1und1.de

   License:
     LGPL: http://www.gnu.org/licenses/lgpl.html
     EPL: http://www.eclipse.org/org/documents/epl-v10.php
     See the license.txt file in the project's top-level directory for details.

   Authors:
     * Daniel Wagner (danielwagner)

*************************************************************************/

using System;
using System.Drawing;
using OpenQA.Selenium;

namespace Qooxdoo.WebDriver.UI.Core.Scroll
{
    /// <summary>
    /// Represents a <a href="http://demo.qooxdoo.org/current/apiviewer/#qx.ui.core.Scroll.AbstractScrollArea">ScrollArea</a>
    /// widget
    /// </summary>
    public class AbstractScrollArea : WidgetImpl, IScrollable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AbstractScrollArea"/> class.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="webDriver">The web driver.</param>
        public AbstractScrollArea(IWebElement element, QxWebDriver webDriver) : base(element, webDriver)
        {
        }

        /// <summary>
        /// Gets the Scrollbar widget.
        /// </summary>
        /// <param name="direction">The scrollbar direction.</param>
        /// <returns>The scroll bar.</returns>
        protected internal virtual IWidget GetScrollbar(string direction)
        {
            string childControlId = "scrollbar-" + direction;
            try
            {
                IWidget scrollBar = WaitForChildControl(childControlId, 2);
                return scrollBar;
            }
            catch (TimeoutException)
            {
                return null;
            }
        }

        /// <summary>
        /// Scrolls the widget to a given position
        /// </summary>
        /// <param name="direction"> "x" or "y" for horizontal/vertical scrolling </param>
        /// <param name="position"> Position (in pixels) to scroll to </param>
        public virtual void ScrollTo(string direction, int? position)
        {
            IWidget scrollBar = GetScrollbar(direction);
            if (scrollBar == null)
            {
                return;
            }
            JsRunner.RunScript("scrollTo", scrollBar.ContentElement, position);
        }

        /// <summary>
        /// Returns the current scroll position of the widget
        /// </summary>
        /// <param name="direction"> "x" or "y" for horizontal/vertical position </param>
        /// <returns>The scroll position in pixels.</returns>
        public virtual long? GetScrollPosition(string direction)
        {
            IWidget scrollBar = GetScrollbar(direction);
            if (scrollBar == null)
            {
                return 0;
            }
            return GetScrollPosition(scrollBar);
        }

        /// <summary>
        /// Gets the scroll position.
        /// </summary>
        /// <param name="scrollBar">The scroll bar.</param>
        /// <returns>The scroll position in pixels.</returns>
        protected internal virtual long? GetScrollPosition(IWidget scrollBar)
        {
            try
            {
                string result = scrollBar.GetPropertyValueAsJson("position");
                return long.Parse(result);
            }
            //catch (com.opera.Core.systems.scope.exceptions.ScopeException)
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the scroll step.
        /// </summary>
        /// <param name="scrollBar">The scroll bar.</param>
        /// <returns>The scroll step in pixels.</returns>
        protected internal virtual long? GetScrollStep(IWidget scrollBar)
        {
            string result = scrollBar.GetPropertyValueAsJson("singleStep");
            return long.Parse(result);
        }

        /// <summary>
        /// Gets the scroll step.
        /// </summary>
        /// <param name="direction">The direction.</param>
        /// <returns>The scroll step in pixels.</returns>
        public virtual long? GetScrollStep(string direction)
        {
            IWidget scrollBar = GetScrollbar(direction);
            if (scrollBar == null)
            {
                return 0;
            }
            return GetScrollStep(scrollBar);
        }

        /// <summary>
        /// Returns the maximum scroll position of the widget
        /// </summary>
        /// <param name="direction"> "x" or "y" for horizontal/vertical maximum </param>
        /// <returns>The maximum scroll position in pixels.</returns>
        public virtual long? GetMaximum(string direction)
        {
            IWidget scrollBar = GetScrollbar(direction);
            if (scrollBar == null)
            {
                return 0;
            }
            return GetMaximum(scrollBar);
        }

        /// <summary>
        /// Returns the maximum scroll position of the widget
        /// </summary>
        /// <param name="scrollBar">The scroll bar.</param>
        /// <returns>The maximum scroll position in pixels.</returns>
        protected internal virtual long? GetMaximum(IWidget scrollBar)
        {
            string result = scrollBar.GetPropertyValueAsJson("maximum");
            return long.Parse(result);
        }

        /// <summary>
        /// Scrolls the area in the given direction until the locator finds a child
        /// widget. The locator will be executed in the scroll area's context, so
        /// a relative locator should be used, e.g. <code>By.Qxh("*\/[@label=Foo]")</code>
        /// </summary>
        /// <param name="direction"> "x" or "y" for horizontal/vertical scrolling </param>
        /// <param name="locator"> Child widget locator </param>
        /// <returns>The matching child widget.</returns>
        public virtual IWidget ScrollToChild(string direction, OpenQA.Selenium.By locator)
        {
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(100);
            IWebElement target = null;
            try
            {
                target = ContentElement.FindElement(locator);
            }
            catch (NoSuchElementException)
            {
            }
            if (target != null && IsChildInView(target).GetValueOrDefault(false))
            {
                return Driver.GetWidgetForElement(target);
            }

            long? singleStep = GetScrollStep(direction);
            long? maximum = GetMaximum(direction);
            long? scrollPosition = GetScrollPosition(direction);

            while (scrollPosition < maximum)
            {
                // Virtual list items are created on demand, so query the DOM again
                try
                {
                    target = ContentElement.FindElement(locator);
                }
                catch (NoSuchElementException)
                {
                }
                int to;
                if (target != null && IsChildInView(target).GetValueOrDefault(false))
                {
                    // Scroll one more stop after the target item is visible.
                    // Without this, clicking the target in IE9 and Firefox doesn't
                    // work sometimes.
                    to = (int) (scrollPosition + singleStep);
                    ScrollTo(direction, to);
                    Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(4);
                    return Driver.GetWidgetForElement(target);
                }

                to = (int) (scrollPosition + singleStep);
                ScrollTo(direction, to);
                scrollPosition = GetScrollPosition(direction);
            }

            //TODO: Find out the original timeout and re-Apply it
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(4);
            return null;
        }

        /// <summary>
        /// Determines whether the child is visible.
        /// </summary>
        /// <param name="child">The child.</param>
        /// <returns><value>true</value> if the child is visible; otherwise <value>false</value>.</returns>
        public virtual bool? IsChildInView(IWebElement child)
        {
            Point paneLocation = ContentElement.Location;
            int paneTop = paneLocation.Y;
            int paneLeft = paneLocation.X;
            Size paneSize = ContentElement.Size;
            int paneHeight = paneSize.Height;
            int paneBottom = paneTop + paneHeight;
            int paneWidth = paneSize.Width;
            int paneRight = paneLeft + paneWidth;

            Point childLocation = child.Location;
            int childTop = childLocation.Y;
            int childLeft = childLocation.X;

            if (childTop >= paneTop && childTop < paneBottom && childLeft >= paneLeft && childLeft < paneRight)
            {
                return true;
            }

            return false;
        }
    }
}