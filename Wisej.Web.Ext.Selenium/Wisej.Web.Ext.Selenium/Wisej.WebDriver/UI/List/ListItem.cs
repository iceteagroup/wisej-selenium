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

using OpenQA.Selenium;
using Qooxdoo.WebDriver.UI;
using Qooxdoo.WebDriver.UI.Core;
using QX = Qooxdoo.WebDriver;

namespace Wisej.Web.Ext.Selenium.UI.List
{
    /// <summary>
    /// Represents a <see cref="T:wisej.web.list.ListItem"/> widget.
    /// </summary>
    public class ListItem : WidgetImpl, IHaveValue
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ListBox"/> class.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="webDriver">The web driver.</param>
        public ListItem(IWebElement element, QX.QxWebDriver webDriver) : base(element, webDriver)
        {
        }

        /// <summary>
        /// Gets the <see cref="QX.UI.Basic.Label"/> child control.
        /// </summary>
        /// <value>
        /// The label child control.
        /// </value>
        public virtual QX.UI.Basic.Label Label
        {
            get { return (QX.UI.Basic.Label) GetChildControl("label"); }
        }

        /// <summary>
        /// Gets the value of a ListItem value.</summary>
        /// <returns>The ListItem value.</returns>
        public virtual string Value
        {
            get { return Label.Value; }
        }
    }
}