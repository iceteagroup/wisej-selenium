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

using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using Qooxdoo.WebDriver.UI;
using Wisej.Web.Ext.Selenium.UI.List;
using QX = Qooxdoo.WebDriver;


namespace Wisej.Web.Ext.Selenium.UI
{
    /// <summary>
    /// Represents a <see cref="T:Wisej.Web.ListBox"/> widget.
    /// </summary>
    public class ListBox : QX.UI.Form.List
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ListBox"/> class.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="webDriver">The web driver.</param>
        public ListBox(IWebElement element, QX.QxWebDriver webDriver) : base(element, webDriver)
        {
        }

        /// <summary>
        /// Gets a list of <seealso cref="ListItem" /> objects representing this widget children
        /// as defined using <a href="http://demo.qooxdoo.org/current/apiviewer/#qx.ui.core.MChildrenHandling~add!method_public">parent.add(child);</a> in the application code.
        /// </summary>
        public IList<ListItem> ListItems
        {
            get
            {
                IList<IWebElement> childrenElements = ChildrenElements;
                IList<ListItem> listItems = new List<ListItem>();

                using (IEnumerator<IWebElement> iter = childrenElements.GetEnumerator())
                {
                    while (iter.MoveNext())
                    {
                        IWebElement child = iter.Current;
                        listItems.Add((ListItem) Driver.GetWidgetForElement(child));
                    }
                }

                return listItems;
            }
        }

        /// <summary>
        /// Gets a list of selected <seealso cref="ListItem" /> indices.
        /// </summary>
        /// <value>
        /// The list of selected <seealso cref="ListItem" /> indices.
        /// </value>
        public virtual int[] SelectedIndices
        {
            get
            {
                // LUCA: Bug/features in Wisej. Some properties are wired
                // only from the server to the client. This one now is fixed
                // in the dev build to be always in sync.

                // TODO: this always returns 1 item with value 0 (zero)
                IList<object> objects = (IList<object>) GetPropertyValue("selectedIndices");
                List<int> selectedIndices = new List<int>();

                foreach (var o in objects)
                {
                    selectedIndices.Add(int.Parse(o.ToString()));
                }

                return selectedIndices.ToArray();
            }
        }

        /// <summary>
        /// Gets a list of selected <see cref="ListItem" />.
        /// </summary>
        /// <value>
        /// The list of selected <see cref="ListItem" />.
        /// </value>
        public virtual ListItem[] SelectedItems
        {
            get
            {
                IList<ListItem> selectedItems = new List<ListItem>();

                // LUCA: Can use the existing "getSelection()" method, it returns
                var items = Call("getSelection") as IWidget[];

                // the selected items array.
                if (items != null && items.Length > 0)
                {
                    foreach (var i in items)
                    {
                        selectedItems.Add((ListItem) i);
                    }
                }

                return selectedItems.ToArray();
            }
        }
    }
}