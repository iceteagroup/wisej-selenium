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

namespace Qooxdoo.WebDriver.UI.Form
{
    /// <summary>
    /// Represents a <a href="http://demo.qooxdoo.org/current/apiviewer/#qx.ui.form.VirtualSelectBox">VirtualSelectBox</a>
    /// widget
    /// </summary>
    public class VirtualSelectBox : SelectBox
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VirtualSelectBox"/> class.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="driver">The driver.</param>
        public VirtualSelectBox(IWebElement element, QxWebDriver driver) : base(element, driver)
        {
        }

        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <value>
        /// The list.
        /// </value>
        protected internal override ISelectable List
        {
            get
            {
                if (base.List == null)
                {
                    IWidget dropdown = WaitForChildControl("dropdown", 3);
                    base.List = (ISelectable) dropdown.GetChildControl("list");
                }
                return base.List;
            }
        }
    }
}