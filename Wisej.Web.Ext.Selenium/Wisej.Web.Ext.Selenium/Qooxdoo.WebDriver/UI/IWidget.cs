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

/*************************************************************************

   qxwebdriver-java

   http://github.com/qooxdoo/qxwebdriver-java

   Copyright:
     2012-2013 1&1 Internet AG, Germany, http://www.1und1.de

   License:
     LGPL: http://www.gnu.org/licenses/lgpl.html
     EPL: http://www.eclipse.org/org/documents/epl-v10.php
     See the license.txt file in the project's top-level directory for details.

   Authors:
     * Daniel Wagner (danielwagner)

*************************************************************************/

using System.Collections.Generic;
using OpenQA.Selenium;

namespace Qooxdoo.WebDriver.UI
{
    /// <summary>
    /// Represents a qx.Desktop widget. <seealso cref="OpenQA.Selenium.IWebElement"/>
    /// methods are forwarded to the widget's content element. Click() and SendKeys()
    /// will generally workFor simple widgets that contain only one button and/or
    /// text field.
    ///
    /// For more advanced interactions on composite widgets such as qx.ui.formComboBox
    /// or qx.ui.tree.Tree, see the other interfaces in this namespace.
    /// </summary>
    /// <seealso cref="IScrollable"/>
    /// <seealso cref="ISelectable"/>
    public interface IWidget : IWebElement
    {
        /// <summary>
        /// Gets this widget's qooxdoo object registry ID
        /// </summary>
        string QxHash { get; }

        /// <summary>
        /// Gets this widget's qooxdoo class name
        /// </summary>
        string ClassName { get; }

        /// <summary>
        /// Gets the name of the widget.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets a value indicating whether the widget has been disposed.
        /// </summary>
        bool IsDisposed { get; }

        /// <summary>
        /// Gets the <see cref="IWebDriver"/> associated to this widget.
        /// </summary>
        IWebDriver Driver { get; }

        /// <summary>
        /// Gets the IWebElement representing this widget's content element
        /// </summary>
        IWebElement ContentElement { get; }

        /// <summary>
        /// Returns a <seealso cref="IWidget" /> representing a child control of this widget.
        /// </summary>
        /// <param name="childControlId">The child control identifier.</param>
        /// <returns> The matching child widget or <c>null</c> if the child control doesn't exist.</returns>
        IWidget GetChildControl(string childControlId);

        /// <summary>
        /// Repeatedly checks if the child control with the given id is visible.
        /// Returns the child control if successful.
        /// </summary>
        /// <param name="childControlId">The child control identifier.</param>
        /// <param name="timeoutInSeconds">The time to wait for the child control in seconds.</param>
        /// <returns>The matching child widget.</returns>
        IWidget WaitForChildControl(string childControlId, int? timeoutInSeconds);

        /// <summary>
        /// Gets a <seealso cref="IWidget"/> representing the layout parent.
        /// </summary>
        IWidget LayoutParent { get; }

        /// <summary>
        /// Calls IJavaScriptExecutor.ExecuteScript. The first argument is the widget's content element.
        /// </summary>
        /// <param name="script">The script to execute.</param>
        /// <returns>The value returned by the execution.</returns>
        /// <seealso cref="IJavaScriptExecutor" />
        object ExecuteJavascript(string script);

        /// <summary>
        /// Returns the value of a qooxdoo property on this widget, serialized in JSON  format.
        /// <strong>NOTE:</strong> Never use this for property values that are instances
        /// of qx.core.Object. Circular references in qooxdoo's OO system will lead to
        /// JavaScript errors.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns>The property value as JSON string.</returns>
        string GetPropertyValueAsJson(string propertyName);

        /// <summary>
        /// Returns the value of a qooxdoo property on this widget. See the <seealso cref="OpenQA.Selenium.IJavaScriptExecutor" />
        /// documentation for details on how JavaScript types are represented.
        /// <strong>NOTE:</strong> Never use this for property values that are instances
        /// of qx.core.Object. Circular references in qooxdoo's OO system will lead to
        /// JavaScript errors.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns>The property value.</returns>
        object GetPropertyValue(string propertyName);

        /// <summary>
        /// Returns a List of <seealso cref="IWidget" />s representing the value of a widget list property,
        /// e.g. <a href="http://demo.qooxdoo.org/current/apiviewer/#qx.ui.core.MMultiSelectionHandling~getSelection">MMultiSelectionHandling.getSelection</a>
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns>The List of <seealso cref="IWidget" />s property value.</returns>
        IList<IWidget> GetWidgetListFromProperty(string propertyName);

        /// <summary>
        /// Returns a <seealso cref="IWidget" /> representing the value of a widget property,
        /// e.g. <a href="http://demo.qooxdoo.org/current/apiviewer/#qx.ui.form.MenuButton~menu!property">the
        /// MenuButton's menu property</a>
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns>The <seealso cref="IWidget" /> property value.</returns>
        IWidget GetWidgetFromProperty(string propertyName);

        /// <summary>
        /// Gets a list of <seealso cref="IWidget"/> objects representing this widget's children
        /// as defined using <a href="http://demo.qooxdoo.org/current/apiviewer/#qx.ui.core.MChildrenHandling~add!method_public">parent.add(child);</a> in the application code.
        /// </summary>
        IList<IWidget> Children { get; }

        /// <summary>
        /// Finds a widget relative to the current one by traversing the qooxdoo
        /// widget hierarchy.
        /// </summary>
        /// <param name="by">The locating mechanism to use.</param>
        /// <returns>The found widget.</returns>
        IWidget FindWidget(OpenQA.Selenium.By by);

        /// <summary>
        /// Waits to find a widget relative to the current one by traversing the qooxdoo
        /// widget hierarchy.
        /// </summary>
        /// <param name="by">The locating mechanism to use.</param>
        /// <param name="timeoutInSeconds">The time to wait for the widget in seconds.</param>
        /// <returns>The matching widget.</returns>
        IWidget WaitForWidget(OpenQA.Selenium.By by, long timeoutInSeconds);

        /// <summary>
        /// Drag and drop this widget onto another widget
        /// </summary>
        /// <param name="target">The target.</param>
        void DragToWidget(IWidget target);

        /// <summary>
        /// Drag over this widget to another widget
        /// </summary>
        /// <param name="target">The target.</param>
        void DragOver(IWidget target);

        /// <summary>
        /// Drag and drop this widget onto another widget
        /// </summary>
        /// <param name="target">The target.</param>
        void Drop(IWidget target);
    }
}