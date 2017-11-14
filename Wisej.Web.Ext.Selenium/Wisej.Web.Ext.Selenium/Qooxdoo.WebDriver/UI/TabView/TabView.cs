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
using System.Text.RegularExpressions;
using OpenQA.Selenium;
using Qooxdoo.WebDriver.UI.Core;

namespace Qooxdoo.WebDriver.UI.TabView
{
    /// <summary>
    /// Represents a <a href="http://demo.qooxdoo.org/current/apiviewer/#qx.ui.tabview.TabView">TabView</a>
    /// widget
    /// </summary>
    public class TabView : WidgetImpl, ISelectable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TabView"/> class.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="webDriver">The web driver.</param>
        public TabView(IWebElement element, QxWebDriver webDriver) : base(element, webDriver)
        {
        }

        /// <summary>
        /// Finds a selectable child widget by index and returns it
        /// </summary>
        /// <param name="index">The index of the item.</param>
        /// <returns>
        /// The found item.
        ///.</returns>
        public IWidget GetSelectableItem(int? index)
        {
            IWidget bar = GetChildControl("bar");
            IList<IWidget> buttons = bar.Children;
            return buttons[index.Value];
        }

        /// <summary>
        /// Finds a selectable child widget by index and selects it
        /// </summary>
        /// <param name="index">The index of the item.</param>
        public void SelectItem(int? index)
        {
            GetSelectableItem(index).Click();
        }

        /// <summary>
        /// Finds the first selectable child widget with a label matching the regular
        /// expression and returns it
        /// </summary>
        /// <param name="regex">The regular expression to match.</param>
        /// <returns>
        /// The matching item.
        ///.</returns>
        public IWidget GetSelectableItem(string regex)
        {
            IWidget bar = GetChildControl("bar");
            IList<IWidget> buttons = bar.Children;
            IWidget button = null;

            using (IEnumerator<IWidget> iter = buttons.GetEnumerator())
            {
                while (iter.MoveNext())
                {
                    button = iter.Current;
                    string buttonLabel = (string) button.GetPropertyValue("label");
                    if (Regex.IsMatch(buttonLabel, regex))
                    {
                        break;
                    }
                }
            }

            return button;
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
    }
}