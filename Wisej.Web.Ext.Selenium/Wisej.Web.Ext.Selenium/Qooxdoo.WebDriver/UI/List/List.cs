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
using OpenQA.Selenium;

namespace Qooxdoo.WebDriver.UI.List
{
    /// <summary>
    /// Represents a <a href="http://demo.qooxdoo.org/current/apiviewer/#qx.ui.list.List">List</a>
    /// widget
    /// </summary>
    public class List : Form.List, ISelectable
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
        public new virtual IWidget GetSelectableItem(int? index)
        {
            throw new Exception(
                "GetSelectableItem(Integer index) is not implemented for qx.ui.list.List, use GetSelectableItem(String label) instead.");
        }
    }
}