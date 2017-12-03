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
using System.Collections.Generic;
using OpenQA.Selenium;
using Qooxdoo.WebDriver.UI.Core.Scroll;

namespace Qooxdoo.WebDriver.UI.Menu
{
    /// <summary>
    /// Represents a <a href="http://demo.qooxdoo.org/current/apiviewer/#qx.ui.menu.Menu">Menu</a>
    /// widget
    /// </summary>
    public class Menu : Core.WidgetImpl, ISelectable, IScrollable
    {
        //TODO: Nested menus

        /// <summary>
        /// Initializes a new instance of the <see cref="Menu"/> class.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="webDriver">The web driver.</param>
        public Menu(IWebElement element, QxWebDriver webDriver) : base(element, webDriver)
        {
        }

        /// <summary>
        /// Finds a selectable child widget by index and selects it
        /// </summary>
        /// <param name="index">The index of the item.</param>
        public virtual void SelectItem(int index)
        {
            GetSelectableItem(index).Click();
        }

        /// <summary>
        /// Finds the first selectable child widget with a label matching the regular
        /// expression and selects it
        /// </summary>
        /// <param name="regex">The regular expression to match.</param>
        public void SelectItem(string regex)
        {
            GetSelectableItem(regex).Click();
        }

        /// <summary>
        /// Finds a selectable child widget by index and returns it
        /// </summary>
        /// <param name="index">The index of the item.</param>
        /// <returns>The found item.</returns>
        public IWidget GetSelectableItem(int index)
        {
            bool? hasSlideBar = HasChildControl("slidebar");
            if (hasSlideBar.Value)
            {
                Console.Error.WriteLine(
                    "Menu item selection by index is currently only supported for non-scrolling menus!");
                return null;
            }

            IList<IWidget> children = Children;
            return children[index];
        }

        /// <summary>
        /// Finds the first selectable child widget with a matching label and returns it
        /// </summary>
        /// <param name="label">The label to search for.</param>
        /// <returns>The matching item.</returns>
        public IWidget GetSelectableItem(string label)
        {
            By itemLocator = By.Qxh("*/[@label=" + label + "]");
            bool? hasSlideBar = HasChildControl("slidebar");
            if (hasSlideBar.Value)
            {
                ScrollTo("y", 0);
                return ScrollToChild("y", itemLocator);
            }

            return FindWidget(itemLocator);
        }

        /// <summary>
        /// Gets the scroll pane.
        /// </summary>
        /// <value>
        /// The scroll pane.
        /// </value>
        public virtual ScrollPane ScrollPane
        {
            get
            {
                IWidget slideBar = GetChildControl("slidebar");
                return (ScrollPane) slideBar.GetChildControl("scrollpane");
            }
        }

        /// <summary>
        /// Scrolls the widget to the specifyed position
        /// </summary>
        /// <param name="direction"> "x" or "y" for horizontal/vertical scrolling </param>
        /// <param name="position"> Position (in pixels) to scroll to </param>
        public void ScrollTo(string direction, int? position)
        {
            ScrollPane scrollPane = ScrollPane;
            scrollPane.ScrollTo(direction, position);
        }

        /// <summary>
        /// Scrolls the area in the specifyed direction until the locator finds a child
        /// widget. The locator will be executed in the scroll area's context, so
        /// a relative locator should be used, e.g. <code>By.Qxh("*\/[@label=Foo]")</code>
        /// </summary>
        /// <param name="direction"> "x" or "y" for horizontal/vertical scrolling </param>
        /// <param name="locator"> Child widget locator </param>
        /// <returns>The matching child widget.</returns>
        public IWidget ScrollToChild(string direction, OpenQA.Selenium.By locator)
        {
            ScrollPane scrollPane = ScrollPane;
            return scrollPane.ScrollToChild(direction, locator);
        }

        /// <summary>
        /// Returns the maximum scroll position of the widget
        /// </summary>
        /// <param name="direction"> "x" or "y" for horizontal/vertical maximum </param>
        /// <returns>The maximum scroll position in pixels.</returns>
        public long? GetMaximum(string direction)
        {
            ScrollPane scrollPane = ScrollPane;
            return scrollPane.GetMaximum(direction);
        }

        /// <summary>
        /// Returns the current scroll position of the widget
        /// </summary>
        /// <param name="direction"> "x" or "y" for horizontal/vertical position </param>
        /// <returns>The scroll position in pixels.</returns>
        public long? GetScrollPosition(string direction)
        {
            ScrollPane scrollPane = ScrollPane;
            return scrollPane.GetScrollPosition(direction);
        }
    }
}