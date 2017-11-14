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
    /// Represents a <a href="http://demo.qooxdoo.org/current/apiviewer/#qx.ui.form.ComboBox">ComboBox</a>
    /// widget
    /// </summary>
    public class ComboBox : SelectBox
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ComboBox"/> class.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="webDriver">The web driver.</param>
        public ComboBox(IWebElement element, QxWebDriver webDriver) : base(element, webDriver)
        {
        }

        /// <summary>
        /// Gets the button.
        /// </summary>
        /// <value>
        /// The button.
        /// </value>
        protected internal override IWidget Button
        {
            get
            {
                if (base.Button == null)
                {
                    base.Button = GetChildControl("button");
                }
                return base.Button;
            }
        }


        /// <summary>
        /// Clears the content of this element.
        /// </summary>
        public new virtual void Clear()
        {
            GetChildControl("textfield").ContentElement.Clear();
        }
    }
}