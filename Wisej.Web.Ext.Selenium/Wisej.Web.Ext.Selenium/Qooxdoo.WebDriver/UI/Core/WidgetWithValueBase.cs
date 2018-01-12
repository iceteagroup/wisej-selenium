///////////////////////////////////////////////////////////////////////////////
//
// (C) 2017 ICE TEA GROUP LLC - ALL RIGHTS RESERVED
//
//
//
// ALL INFORMATION CONTAINED HEREIN IS, AND REMAINS
// THE PROPERTY OF ICE TEA GROUP LLC AND ITS SUPPLIERS, IF ANY.
// THE INTELLECTUAL PROPERTY AND TECHNICAL CONCEPTS CONTAINED
// HEREIN ARE PROPRIETARY TO ICE TEA GROUP LLC AND ITS SUPPLIERS
// AND MAY BE COVERED BY U.S. AND FOREIGN PATENTS, PATENT IN PROCESS, AND
// ARE PROTECTED BY TRADE SECRET OR COPYRIGHT LAW.
//
// DISSEMINATION OF THIS INFORMATION OR REPRODUCTION OF THIS MATERIAL
// IS STRICTLY FORBIDDEN UNLESS PRIOR WRITTEN PERMISSION IS OBTAINED
// FROM ICE TEA GROUP LLC.
//
///////////////////////////////////////////////////////////////////////////////

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

namespace Qooxdoo.WebDriver.UI.Core
{
    /// <summary>
    /// Base widget with value
    /// </summary>
    /// <seealso cref="IWidget" />
    public abstract class WidgetWithValueBase : WidgetImpl, IHaveValue
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WidgetWithValueBase"/> class.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="webDriver">The web driver.</param>
        public WidgetWithValueBase(IWebElement element, IWebDriver webDriver)
            : base(element, (QxWebDriver) webDriver)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WidgetWithValueBase"/> class.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="webDriver">The web driver.</param>
        public WidgetWithValueBase(IWebElement element, QxWebDriver webDriver)
            : base(element, webDriver)
        {
        }

        /// <summary>
        /// Gets or sets the value of a IHaveValue widget.</summary>
        /// <returns>The value.</returns>
        public virtual string Value
        {
            get
            {
                return (string) ExecuteJavascript(
                    "return qx.ui.core.Widget.getWidgetByElement(arguments[0]).getValue().toString()");
            }
            set
            {
                JsExecutor.ExecuteScript(
                    "var widget = qx.ui.core.Widget.getWidgetByElement(arguments[0]);" +
                    "widget.setValue(arguments[1]);" +
                    "widget.fireEvent('focusin');",
                    ContentElement, value);
            }
        }
    }
}