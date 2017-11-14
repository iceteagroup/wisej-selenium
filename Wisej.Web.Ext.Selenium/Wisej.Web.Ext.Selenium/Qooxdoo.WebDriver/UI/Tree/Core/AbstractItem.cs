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

namespace Qooxdoo.WebDriver.UI.Tree.Core
{
    /// <summary>
    /// Tree item
    /// </summary>
    /// <seealso cref="WidgetImpl" />
    public class AbstractItem : UI.Core.WidgetImpl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AbstractItem"/> class.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="webDriver">The web driver.</param>
        public AbstractItem(IWebElement element, QxWebDriver webDriver) : base(element, webDriver)
        {
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="AbstractItem"/> is open.
        /// </summary>
        /// <value>
        ///   <c>true</c> if open; otherwise, <c>false</c>.
        /// </value>
        public virtual bool Open
        {
            get { return ((bool?) GetPropertyValue("open")).Value; }
        }

        /// <summary>
        /// Clicks the open close button.
        /// </summary>
        public virtual void ClickOpenCloseButton()
        {
            IWidget button = GetChildControl("open");
            if (button != null)
            {
                button.Click();
            }
        }
    }
}