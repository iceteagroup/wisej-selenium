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
                IList<ListItem> listItems = ListItems;

                foreach (var index in SelectedIndices)
                {
                    selectedItems.Add(listItems[index]);
                }

                return selectedItems.ToArray();
            }
        }

        #region Waiters

        /// <summary>
        /// Repeatedly checks for given number of selected <see cref="ListItem" />.
        /// </summary>
        /// <param name="numberOfItems">The expected number of items.</param>
        /// <param name="timeoutInSeconds">The number of seconds to wait for the selected items.</param>
        /// <returns>The list of selected <see cref="ListItem" />.</returns>
        public ListItem[] WaitForSelectedItems(int numberOfItems, int timeoutInSeconds = 5)
        {
            Driver.Wait(() => Equals(numberOfItems, SelectedItems.Length), false, timeoutInSeconds);

            return SelectedItems;
        }

        #endregion
    }
}