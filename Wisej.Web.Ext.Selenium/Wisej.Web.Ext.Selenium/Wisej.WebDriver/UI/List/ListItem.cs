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

        /// <summary>
        /// Gets a value indicating whether this element is selected.
        /// </summary>
        /// <remarks>This operation only applies to input elements such as checkboxes,
        /// options in a select element and radio buttons.</remarks>
        /// <exception cref="StaleElementReferenceException">Thrown when the target element is no longer valid in the document DOM.</exception>
        public override bool Selected
        {
            get
            {
                object parent = null;
                // TODO: one of these should get the parent ListBox

                try
                {
                    parent = GetPropertyValue("parent");
                }
                catch
                {
                }

                try
                {
                    parent = Call("getParent");
                }
                catch
                {
                }

                var listBox = (ListBox) parent;
                if (listBox == null)
                    return false;

                for (var index = 0; index < listBox.SelectedItems.Count; index++)
                {
                    ListItem listItem = listBox.SelectedItems[index];
                    if (listItem.QxHash == QxHash)
                        return true;
                }

                return false;
            }
        }
    }
}