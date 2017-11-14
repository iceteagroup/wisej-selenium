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

using System.Collections.Generic;
using OpenQA.Selenium;
using Qooxdoo.WebDriver.UI.Core.Scroll;

namespace Qooxdoo.WebDriver.UI.Table.Pane
{
    /// <summary>
    /// Scroller widget
    /// </summary>
    /// <seealso cref="AbstractScrollArea" />
    public class Scroller : Core.Scroll.AbstractScrollArea
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Scroller"/> class.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="webDriver">The web driver.</param>
        public Scroller(IWebElement element, QxWebDriver webDriver) : base(element, webDriver)
        {
        }

        /// <summary>
        /// Scrolls the widget to a given position
        /// </summary>
        /// <param name="direction"> "x" or "y" for horizontal/vertical scrolling </param>
        /// <param name="position"> Position (in pixels) to scroll to </param>
        public override void ScrollTo(string direction, int? position)
        {
            string propertyName = "scroll" + direction.ToUpper();
            JsRunner.RunScript("setPropertyValue", ContentElement, propertyName, position);
        }

        /// <summary>
        /// Returns the maximum scroll position of the widget
        /// </summary>
        /// <param name="direction"> "x" or "y" for horizontal/vertical maximum </param>
        /// <returns>The maximum scroll position in pixels.</returns>
        public override long? GetMaximum(string direction)
        {
            if (ReferenceEquals(direction, "y"))
            {
                return (long?) JsRunner.RunScript("getTableScrollerMaximum", ContentElement);
            }

            // TODO
            return 0;
        }

        /// <summary>
        /// Returns the current scroll position of the widget
        /// </summary>
        /// <param name="direction"> "x" or "y" for horizontal/vertical position </param>
        /// <returns>scroll position in pixels.</returns>
        public override long? GetScrollPosition(string direction)
        {
            string propertyName = "scroll" + direction.ToUpper();
            return (long?) JsRunner.RunScript("getPropertyValue", ContentElement, propertyName);
        }

        /// <summary>
        /// Gets the scroll step.
        /// </summary>
        /// <param name="direction">The direction.</param>
        /// <returns>The scroll step.</returns>
        public override long? GetScrollStep(string direction)
        {
            if (ReferenceEquals(direction, "y"))
            {
                return (long?) JsRunner.RunScript("getTableRowHeight", ContentElement);
            }

            // TODO
            return 0;
        }

        /// <summary>
        /// Gets the visible row.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>The target row.</returns>
        public virtual IWebElement GetVisibleRow(int? index)
        {
            IWidget pane = GetChildControl("pane");
            IList<IWebElement> rows = pane.ContentElement.FindElements(OpenQA.Selenium.By.XPath("div/div"));
            if (index <= rows.Count)
            {
                return rows[index.Value];
            }
            return null;
        }

        /// <summary>
        /// Scrolls to row.
        /// </summary>
        /// <param name="rowIndex">Index of the row.</param>
        /// <returns>The target row.</returns>
        public virtual IWebElement ScrollToRow(int? rowIndex)
        {
            long? firstVisibleRow = FirstVisibleRow;
            long? visibleRowCount = VisibleRowCount;
            long? lastVisibleRow = firstVisibleRow + visibleRowCount - 1;

            if (rowIndex.Value >= firstVisibleRow && rowIndex.Value <= lastVisibleRow)
            {
                int? visibleIndex = (int) (rowIndex.Value - firstVisibleRow);
                return GetVisibleRow(visibleIndex);
            }

            string direction = "y";
            long? singleStep = GetScrollStep(direction);
            long? scrollPosition = GetScrollPosition(direction);
            long? maximum = GetMaximum(direction);

            if (rowIndex.Value > firstVisibleRow && scrollPosition < maximum)
            {
                int to = (int) (scrollPosition + singleStep);
                ScrollTo(direction, to);
                return ScrollToRow(rowIndex);
            }

            if (rowIndex.Value < lastVisibleRow && scrollPosition > 0)
            {
                int to = (int) (scrollPosition - singleStep);
                ScrollTo(direction, to);
                return ScrollToRow(rowIndex);
            }

            return null;
        }

        /// <summary>
        /// Gets the first visible row.
        /// </summary>
        /// <value>
        /// The first visible row.
        /// </value>
        public virtual long? FirstVisibleRow
        {
            get { return (long?) JsRunner.RunScript("getFirstVisibleTableRow", ContentElement); }
        }

        /// <summary>
        /// Gets the visible row count.
        /// </summary>
        /// <value>
        /// The visible row count.
        /// </value>
        public virtual long? VisibleRowCount
        {
            get { return (long?) JsRunner.RunScript("getVisibleTableRowCount", ContentElement); }
        }
    }
}