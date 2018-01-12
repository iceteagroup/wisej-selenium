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

using System;
using OpenQA.Selenium;
using QX = Qooxdoo.WebDriver;

namespace Wisej.Web.Ext.Selenium.UI
{
    /// <summary>
    /// Represents a <see cref="T:Wisej.Web.ComboBox"/> widget.
    /// </summary>
    public class ComboBox : QX.UI.Form.ComboBox, QX.UI.IHaveValue
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ComboBox"/> class.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="webDriver">The web driver.</param>
        public ComboBox(IWebElement element, QX.QxWebDriver webDriver) : base(element, webDriver)
        {
        }

        /// <summary>
        /// Gets the value of a ComboBox value.</summary>
        /// <returns>The ComboBox value.</returns>
        public virtual string Value
        {
            get
            {
                return (string) ExecuteJavascript(
                    "return qx.ui.core.Widget.getWidgetByElement(arguments[0]).getValue().toString()");
            }
            set
            {
                throw new NotImplementedException("Setting the Value is not supported in ComboBox");
            }
        }

        /// <summary>
        /// Gets the value of a ComboBox's text </summary>
        /// <returns>The ComboBox value.</returns>
        public override string Text
        {
            get { return this.Value; }
        }

        /// <summary>
        /// Gets or sets the selected index.
        /// </summary>
        public int SelectedIndex
        {
            get { return (int) Call("getSelectedIndex"); }
            set { Call("setSelectedIndex", value); }
        }
    }
}