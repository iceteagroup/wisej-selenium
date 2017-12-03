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

using System.Linq;
using OpenQA.Selenium;
using QX = Qooxdoo.WebDriver;

namespace Wisej.Web.Ext.Selenium.UI
{
    /// <summary>
    /// Represents a <see cref="T:Wisej.Web.MessageBox"/> widget.
    /// </summary>
    public class MessageBox : QX.UI.Core.WidgetImpl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MessageBox"/> class.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="webDriver">The web driver.</param>
        public MessageBox(IWebElement element, QX.QxWebDriver webDriver) : base(element, webDriver)
        {
        }

        /// <summary>
        /// Gets the icon name.
        /// </summary>
        public string Icon
        {
            get { return (string) GetPropertyValue("image"); }
        }

        /// <summary>
        /// Gets the title text.
        /// </summary>
        public string Title
        {
            get { return ((QX.UI.Basic.Label) GetChildControl("title"))?.Value ?? string.Empty; }
        }

        /// <summary>
        /// Gets the message text.
        /// </summary>
        public string Message
        {
            get { return ((QX.UI.Basic.Label) GetChildControl("message"))?.Value ?? string.Empty; }
        }

        /// <summary>
        /// Returns the button identified by the specified text.
        /// </summary>
        /// <param name="text">The text of the button to retrieve.</param>
        public QX.UI.Core.WidgetImpl GetButton(string text)
        {
            var buttons = GetChildControl("buttonsPane")?.Children;
            return buttons?.FirstOrDefault(b => b.Text == text) as QX.UI.Core.WidgetImpl;
        }
    }
}