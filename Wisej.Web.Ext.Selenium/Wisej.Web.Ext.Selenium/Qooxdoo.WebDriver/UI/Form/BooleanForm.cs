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
    /// Boolena form widget
    /// </summary>
    /// <seealso cref="WidgetImpl" />
    public class BooleanForm : Core.WidgetImpl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BooleanForm"/> class.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="webDriver">The web driver.</param>
        public BooleanForm(IWebElement element, QxWebDriver webDriver) : base(element, webDriver)
        {
        }

        /// <summary>Gets a value indicating whether or not this element is selected. </summary>
        public new virtual bool Selected
        {
            get { return ((bool?) GetPropertyValue("value")).Value; }
        }
    }
}