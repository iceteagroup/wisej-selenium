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

namespace Qooxdoo.WebDriver.UI
{
    /// <summary>
    /// Scrollable interface
    /// </summary>
    /// <seealso cref="IWidget" />
    public interface IScrollable : IWidget
    {
        /// <summary>
        /// Scrolls the widget to a given position
        /// </summary>
        /// <param name="direction"> "x" or "y" for horizontal/vertical scrolling </param>
        /// <param name="position"> Position (in pixels) to scroll to </param>
        void ScrollTo(string direction, int? position);

        /// <summary>
        /// Scrolls the area in the given direction until the locator finds a child
        /// widget. The locator will be executed in the scroll area's context, so
        /// a relative locator should be used, e.g. <code>By.Qxh("*\/[@label=Foo]")</code>
        /// </summary>
        /// <param name="direction"> "x" or "y" for horizontal/vertical scrolling </param>
        /// <param name="locator"> Child widget locator </param>
        /// <returns>The matching child widget.</returns>
        IWidget ScrollToChild(string direction, OpenQA.Selenium.By locator);

        /// <summary>
        /// Returns the maximum scroll position of the widget
        /// </summary>
        /// <param name="direction"> "x" or "y" for horizontal/vertical maximum </param>
        /// <returns>The maximum scroll position in pixels.</returns>
        long? GetMaximum(string direction);

        /// <summary>
        /// Returns the current scroll position of the widget
        /// </summary>
        /// <param name="direction"> "x" or "y" for horizontal/vertical position </param>
        /// <returns>The scroll position in pixels.</returns>
        long? GetScrollPosition(string direction);
    }
}