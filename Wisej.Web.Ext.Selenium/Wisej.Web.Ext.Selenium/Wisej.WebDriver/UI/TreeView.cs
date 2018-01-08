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
using QX = Qooxdoo.WebDriver;

namespace Wisej.Web.Ext.Selenium.UI
{
    /// <summary>
    /// Represents a <see cref="T:Wisej.Web.TreeView"/> widget.
    /// </summary>
    public class TreeView : QX.UI.Tree.Tree
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TreeView"/> class.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="webDriver">The web driver.</param>
        public TreeView(IWebElement element, QX.QxWebDriver webDriver) : base(element, webDriver)
        {
        }

        /// <summary>
        /// Gets the (non-recursve) list of <see cref="TreeNode" />.
        /// </summary>
        /// <value>
        /// The list of <see cref="TreeNode" />.
        /// </value>
        public virtual TreeNode[] Nodes
        {
            get
            {
                IWidget[] widgets = Call("getItems", false, false) as IWidget[];
                IList<TreeNode> nodes = new List<TreeNode>();
                if (widgets != null)
                {
                    foreach (var widget in widgets)
                    {
                        nodes.Add(widget as TreeNode);
                    }
                }

                return nodes.ToArray();
            }
        }

        /// <summary>
        /// Gets a list of selected <see cref="TreeNode" />.
        /// </summary>
        /// <value>
        /// The list of selected <see cref="TreeNode" />.
        /// </value>
        public virtual TreeNode[] SelectedNodes
        {
            get
            {
                IList<IWidget> widgets = GetWidgetListFromProperty("selectedNodes");
                IList<TreeNode> nodes = new List<TreeNode>();
                foreach (var widget in widgets)
                {
                    nodes.Add(widget as TreeNode);
                }

                return nodes.ToArray();
            }
        }

        #region Waiters

        /// <summary>
        /// Repeatedly checks for given number of selected <see cref="TreeNode" />.
        /// </summary>
        /// <param name="expectedNodes">The expected number of nodes.</param>
        /// <param name="timeoutInSeconds">The number of seconds to wait for the selected nodes.</param>
        /// <returns>The list of selected <see cref="TreeNode" />.</returns>
        public TreeNode[] WaitForSelectedNodes(int expectedNodes, long timeoutInSeconds = 5)
        {
            Driver.Wait(() => Equals(expectedNodes, SelectedNodes.Length), false, timeoutInSeconds);

            return SelectedNodes;
        }

        #endregion
    }
}