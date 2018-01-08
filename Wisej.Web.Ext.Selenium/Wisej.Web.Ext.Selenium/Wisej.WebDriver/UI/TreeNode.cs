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
    /// Represents a <see cref="T:Wisej.Web.TreeNode"/> widget.
    /// </summary>
    public class TreeNode : QX.UI.Core.WidgetImpl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TreeNode"/> class.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="webDriver">The web driver.</param>
        public TreeNode(IWebElement element, QX.QxWebDriver webDriver) : base(element, webDriver)
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
                IWidget[] widgets = Call("getNodes") as IWidget[];
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
        /// Gets the TreeNode label.
        /// </summary>
        /// <value>
        /// The label.
        /// </value>
        public virtual QX.UI.Basic.Label Label
        {
            get { return GetChildControl("label") as QX.UI.Basic.Label; }
        }

        /// <summary>
        /// Starts the editor on the label of this tree node.
        /// </summary>
        public virtual void EditLabel()
        {
            Call("editLabel");
        }
    }
}