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
    public class TreeNode : QX.UI.Tree.Core.AbstractItem, ISelectable
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
        /// Finds a selectable child widget by index and returns it
        /// </summary>
        /// <param name="index">The index of the item.</param>
        /// <returns>The found item.</returns>
        public virtual IWidget GetSelectableItem(int index)
        {
            // scroll is handled by getItemFromSelectables script
            object result = JsRunner.RunScript("getItemFromSelectables", ContentElement, index);
            IWebElement element = (IWebElement) result;
            return Driver.GetWidgetForElement(element);
        }

        /// <summary>
        /// Finds a selectable child widget by index and selects it
        /// </summary>
        /// <param name="index">The index of the item.</param>
        public virtual void SelectItem(int index)
        {
            GetSelectableItem(index).Click();
        }

        /// <summary>
        /// Finds the first selectable TreeNode widget with a label matching the regular
        /// expression and returns it
        /// </summary>
        /// <param name="regex">The regular expression to match.</param>
        /// <returns>The matching TreeNode.</returns>
        public virtual IWidget GetSelectableItem(string regex)
        {
            QX.By itemLocator = QX.By.Qxh("*/[@label=" + regex + "]");
            IWebElement target = null;
            try
            {
                target = ContentElement.FindElement(itemLocator);
            }
            catch (NoSuchElementException)
            {
            }

            if (target != null)
            {
                return Driver.GetWidgetForElement(target);
            }

            return null;
        }

        /// <summary>
        /// Finds the first selectable TreeNode widget with a label matching the regular
        /// expression and selects it
        /// </summary>
        /// <param name="regex">The regular expression to match.</param>
        public virtual void SelectItem(string regex)
        {
            IWidget item = GetSelectableItem(regex);
            item.Click();
        }

        /// <summary>
        /// Selects this TreeNode.
        /// </summary>
        public virtual void Select()
        {
            Click();
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
                IList<TreeNode> nodes = new List<TreeNode>();
                if (Children != null)
                {
                    foreach (var widget in Children)
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

        /// <summary>
        /// Expands this tree node.
        /// </summary>
        public virtual void Expand()
        {
            Call("expand");
        }

        /// <summary>
        /// Collapses this tree node.
        /// </summary>
        public virtual void Collapse()
        {
            Call("collapse");
        }

        /// <summary>
        /// Scrolls this tree node into view.
        /// </summary>
        public virtual void ScrollIntoView()
        {
            Call("scrollIntoView");
        }

        /// <summary>
        /// Scrolls this tree node into view.
        /// </summary>
        public virtual TreeNode GetParentNode()
        {
            return Call("getParentNode") as TreeNode;
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="TreeNode"/> can expand.
        /// </summary>
        /// <value>
        ///   <c>true</c> if can expand; otherwise, <c>false</c>.
        /// </value>
        public virtual bool CanExpand
        {
            get { return ((bool?) GetPropertyValue("canExpand")).Value; }
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="TreeNode"/> shows a check box.
        /// </summary>
        /// <value>
        ///   <c>true</c> if shows a check box; otherwise, <c>false</c>.
        /// </value>
        public virtual bool ShowCheckBox
        {
            get { return ((bool?) GetPropertyValue("checkBox")).Value; }
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="TreeNode"/> is checked.
        /// </summary>
        /// <value>
        ///   <c>true</c> if check state is checked; otherwise, <c>false</c>.
        /// </value>
        public virtual bool IsChecked
        {
            get { return ((bool?) GetPropertyValue("checkState")).Value; }
        }

        /// <summary>
        /// Gets a value indicating whether the position of this <see cref="TreeNode" />
        /// within the node collection it belongs to.
        /// </summary>
        /// <value>
        /// The index within the node collection it belongs to.
        /// </value>
        public virtual int Index
        {
            get { return ((int?) GetPropertyValue("index")).Value; }
        }
    }
}