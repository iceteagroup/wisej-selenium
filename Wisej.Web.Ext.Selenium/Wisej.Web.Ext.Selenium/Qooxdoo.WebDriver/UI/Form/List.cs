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
using Qooxdoo.WebDriver.UI.Core.Scroll;

namespace Qooxdoo.WebDriver.UI.Form
{
    /// <summary>
    /// Represents a <a href="http://demo.qooxdoo.org/current/apiviewer/#qx.ui.form.List">List</a>
    /// widget
    /// </summary>
    public class List : AbstractScrollArea, ISelectable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="List"/> class.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="webDriver">The web driver.</param>
        public List(IWebElement element, QxWebDriver webDriver) : base(element, webDriver)
        {
        }

        /// <summary>
        /// Finds a selectable child widget by index and returns it
        /// </summary>
        /// <param name="index">The index of the item.</param>
        /// <returns>The found item.</returns>
        public virtual IWidget GetSelectableItem(int index)
        {
            // scroll is handled by getItemFromSelectables script
            object result = JsRunner.RunScript("getItemFromSelectables", ContentElement, index);
            IWebElement element = (IWebElement) result;
            return Driver.GetWidgetForElement(element);
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
        /// expression and returns it
        /// </summary>
        /// <param name="regex">The regular expression to match.</param>
        /// <returns>The matching item.</returns>
        public virtual IWidget GetSelectableItem(string regex)
        {
            ScrollTo("y", 0);
            By itemLocator = By.Qxh("*/[@label=" + regex + "]");
            return ScrollToChild("y", itemLocator);
        }

        /// <summary>
        /// Finds the first selectable child widget with a label matching the regular
        /// expression and selects it
        /// </summary>
        /// <param name="regex">The regular expression to match.</param>
        public virtual void SelectItem(string regex)
        {
            IWidget item = GetSelectableItem(regex);
            item.Click();
        }
    }
}