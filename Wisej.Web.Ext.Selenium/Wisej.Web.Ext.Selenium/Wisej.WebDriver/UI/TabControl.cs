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
using System.Text.RegularExpressions;
using OpenQA.Selenium;
using QX = Qooxdoo.WebDriver;

namespace Wisej.Web.Ext.Selenium.UI
{
    /// <summary>
    /// Represents a <see cref="T:Wisej.Web.TabControl"/> widget.
    /// </summary>
    public class TabControl : QX.UI.TabView.TabView
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TabControl"/> class.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="webDriver">The web driver.</param>
        public TabControl(IWebElement element, QX.QxWebDriver webDriver) : base(element, webDriver)
        {
        }

        /// <summary>
        /// Returns the collection of children <see cref="TabPage"/>.
        /// </summary>
        public TabPage[] TabPages
        {
            get { return Children.Cast<TabPage>().ToArray(); }
        }

        /// <summary>
        /// Returns the <see cref="TabPage"/> at the specified index.
        /// </summary>
        /// <param name="index">The index of the <see cref="TabPage"/> in the <see cref="TabPages"/> collection.</param>
        /// <returns>The TabPage at the specified index.</returns>
        public TabPage GetTabPage(int index)
        {
            return TabPages[index];
        }

        /// <summary>
        /// Returns the first <see cref="TabPage"/> with a label that matches the
        /// specified regular expression.
        /// </summary>
        /// <param name="regex">The regular expression to match.</param>
        /// <returns>The TabPage whose label matches the regular expression.</returns>
        public TabPage GetTabPage(string regex)
        {
            return TabPages.FirstOrDefault(o => Regex.IsMatch(o.Label, regex));
        }
    }
}