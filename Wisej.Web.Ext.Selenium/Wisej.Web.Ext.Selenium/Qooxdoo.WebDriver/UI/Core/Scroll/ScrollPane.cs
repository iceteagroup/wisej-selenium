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

using OpenQA.Selenium;

namespace Qooxdoo.WebDriver.UI.Core.Scroll
{
    /// <summary>
    /// ScrollPane widget
    /// </summary>
    /// <seealso cref="AbstractScrollArea" />
    public class ScrollPane : AbstractScrollArea
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ScrollPane"/> class.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="webDriver">The web driver.</param>
        public ScrollPane(IWebElement element, QxWebDriver webDriver) : base(element, webDriver)
        {
        }

        /// <summary>
        /// Scrolls the widget to a given position
        /// </summary>
        /// <param name="direction"> "x" or "y" for horizontal/vertical scrolling </param>
        /// <param name="position"> Position (in pixels) to scroll to </param>
        public override void ScrollTo(string direction, int? position)
        {
            JsRunner.RunScript("scrollTo", ContentElement, position, direction);
        }

        /// <summary>
        /// Returns the maximum scroll position of the widget
        /// </summary>
        /// <param name="direction"> "x" or "y" for horizontal/vertical maximum </param>
        /// <returns>The maximum scroll position in pixels.</returns>
        public override long? GetMaximum(string direction)
        {
            return (long?) JsRunner.RunScript("getScrollMax", ContentElement, direction);
        }

        /// <summary>
        /// Returns the current scroll position of the widget
        /// </summary>
        /// <param name="direction"> "x" or "y" for horizontal/vertical position </param>
        /// <returns>The scroll position in pixels.</returns>
        public override long? GetScrollPosition(string direction)
        {
            string propertyName = "scroll" + direction.ToUpper();
            return (long?) GetPropertyValue(propertyName);
        }

        /// <summary>
        /// Gets the scroll step.
        /// </summary>
        /// <param name="direction">The direction.</param>
        /// <returns>The scroll step in pixels.</returns>
        public override long? GetScrollStep(string direction)
        {
            return 10;
        }
    }
}