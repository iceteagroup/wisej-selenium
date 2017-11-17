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
using Qooxdoo.WebDriver.UI.Core;

namespace Qooxdoo.WebDriver.UI.Form
{
    /// <summary>
    /// Represents a <a href="http://demo.qooxdoo.org/current/apiviewer/#qx.ui.form.SelectBox">SelectBox</a>
    /// widget
    /// </summary>
    public class SelectBox : WidgetImpl, ISelectable
    {
        private IWidget _button;
        private ISelectable _list;

        /// <summary>
        /// Initializes a new instance of the <see cref="SelectBox"/> class.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="driver">The driver.</param>
        public SelectBox(IWebElement element, QxWebDriver driver) : base(element, driver)
        {
        }

        /// <summary>
        /// Finds a selectable child widget by index and returns it
        /// </summary>
        /// <param name="index">The index of the item.</param>
        /// <returns>The found item.</returns>
        public virtual IWidget GetSelectableItem(int? index)
        {
            return List.GetSelectableItem(index);
        }

        /// <summary>
        /// Finds a selectable child widget by index and selects it
        /// </summary>
        /// <param name="index">The index of the item.</param>
        public virtual void SelectItem(int? index)
        {
            Button?.Click();
            GetSelectableItem(index).Click();
        }

        /// <summary>
        /// Finds the first selectable child widget with a label matching the regular
        /// expression and returns it
        /// </summary>
        /// <param name="regex">The regular expression to match.</param>
        /// <returns>The found item.</returns>
        public virtual IWidget GetSelectableItem(string regex)
        {
            return List.GetSelectableItem(regex);
        }

        /// <summary>
        /// Finds the first selectable child widget with a label matching the regular
        /// expression and selects it
        /// </summary>
        /// <param name="regex">The regular expression to match.</param>
        public virtual void SelectItem(string regex)
        {
            Button?.Click();
            GetSelectableItem(regex).Click();
        }

        /// <summary>
        /// Gets the button.
        /// </summary>
        /// <value>
        /// The button.
        /// </value>
        protected internal virtual IWidget Button
        {
            get { return _button; }
            protected set { _button = value; }
        }

        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <value>
        /// The list.
        /// </value>
        protected internal virtual ISelectable List
        {
            get
            {
                if (_list == null)
                {
                    Call("open");
                    _list = (ISelectable) WaitForChildControl("list", 3);
                }
                return _list;
            }
            protected set { _list = value; }
        }
    }
}