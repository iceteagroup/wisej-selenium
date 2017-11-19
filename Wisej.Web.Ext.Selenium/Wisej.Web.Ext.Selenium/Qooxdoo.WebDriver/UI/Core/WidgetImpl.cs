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

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Interactions.Internal;
using OpenQA.Selenium.Support.UI;
using Qooxdoo.WebDriver.Resources;

namespace Qooxdoo.WebDriver.UI.Core
{
    /// <summary>
    /// Base widget implementation
    /// </summary>
    /// <seealso cref="IWidget" />
    public class WidgetImpl : IWidget
    {
        protected string _qxHash;
        protected string _className;
        protected IWebElement _contentElement;

        /// <summary>
        /// The driver
        /// </summary>
        protected internal QxWebDriver Driver;

        /// <summary>
        /// The js executor
        /// </summary>
        protected internal IJavaScriptExecutor JsExecutor;

        /// <summary>
        /// The js runner
        /// </summary>
        protected internal JavaScriptRunner JsRunner;

        /// <summary>
        /// Initializes a new instance of the <see cref="WidgetImpl"/> class.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="webDriver">The web driver.</param>
        public WidgetImpl(IWebElement element, IWebDriver webDriver)
            : this(element, (QxWebDriver)webDriver)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WidgetImpl"/> class.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="webDriver">The web driver.</param>
        public WidgetImpl(IWebElement element, QxWebDriver webDriver)
        {
            Driver = webDriver;

            JsExecutor = Driver.JsExecutor;
            JsRunner = Driver.JsRunner;

            _contentElement = (IWebElement)JsRunner.RunScript("getContentElement", element);
        }

        /// <summary>
        /// Gets this widget's qooxdoo object registry ID
        /// </summary>
        public virtual string QxHash
        {
            get
            {
                if (ReferenceEquals(_qxHash, null))
                {
                    _qxHash = (string)JsRunner.RunScript("getObjectHash", _contentElement);
                }
                return _qxHash;
            }
        }

        /// <summary>
        /// Gets this widget's qooxdoo class name
        /// </summary>
        public virtual string ClassName
        {
            get
            {
                if (ReferenceEquals(_className, null))
                {
                    _className = (string)JsRunner.RunScript("getClassName", _contentElement);
                }
                return _className;
            }
        }

        /// <summary>
        /// Gets the IWebElement representing this widget's content element
        /// </summary>
        public virtual IWebElement ContentElement
        {
            get { return _contentElement; }
            protected set { _contentElement = value; }
        }

        /// <summary>
        /// Drag and drop this widget onto another widget
        /// </summary>
        /// <param name="target">The target.</param>
        public virtual void DragToWidget(IWidget target)
        {
            Actions actions = new Actions(Driver.WebDriver);
            actions.DragAndDrop(ContentElement, target.ContentElement);
            actions.Perform();
        }

        /// <summary>
        /// Drag over this widget to another widget
        /// </summary>
        /// <param name="target">The target.</param>
        public virtual void DragOver(IWidget target)
        {
            IMouse mouse = ((IHasInputDevices)Driver.WebDriver).Mouse;
            ILocatable root = (ILocatable)Driver.FindElement(By.TagName("body"));
            //cast IWebElement to ILocatable
            ILocatable sourceL = (ILocatable)_contentElement;
            ILocatable targetL = (ILocatable)target.ContentElement;

            ICoordinates coord = root.Coordinates;
            mouse.MouseDown(sourceL.Coordinates);

            //get source position (center,center)
            int sourceX = sourceL.Coordinates.LocationInDom.X + _contentElement.Size.Width / 2;
            int sourceY = sourceL.Coordinates.LocationInDom.Y + _contentElement.Size.Height / 2;

            // get target position (center, center)
            int targetX = targetL.Coordinates.LocationInDom.X + target.ContentElement.Size.Width / 2;
            int targetY = targetL.Coordinates.LocationInDom.Y + target.ContentElement.Size.Height / 2;

            //compute deltas between source and target position
            //delta must be positive, however
            //also we have to define the direction
            int directionX = 1; //move direction is right

            int directionY = 1; //move direction is bottom

            var deltaX = targetX - sourceX;
            if (deltaX < 0)
            {
                deltaX *= -1;
                directionX = -1; // move direction is left
            }

            var deltaY = targetY - sourceY;
            if (deltaY < 0)
            {
                deltaY *= -1;
                directionY = -1; // move direction is top
            }

            //define base delta, which must be the higher one

            int baseDelta = deltaX;
            if (deltaY > deltaX)
            {
                baseDelta = deltaY;
            }

            // iterate base delta, set mouse cursor in relation to delta x & delta y
            int x = 0;
            int y = 0;

            for (int i = 1; i <= baseDelta; i += 4)
            {
                if (i > baseDelta)
                {
                    i = baseDelta;
                }
                x = sourceX + deltaX * i / baseDelta * directionX;
                y = sourceY + deltaY * i / baseDelta * directionY;

                mouse.MouseMove(coord, x, y);
                //System.out.println(x +", "+ y);
                Thread.Sleep(1);
            }
            // source has the same coordinates as target
            if (sourceX == targetX && sourceY == targetY)
            {
                mouse.MouseMove(targetL.Coordinates, x++, y);
                Thread.Sleep(20);
            }
        }

        /// <summary>
        /// Drag and drop this widget onto another widget
        /// </summary>
        /// <param name="target">The target.</param>
        public virtual void Drop(IWidget target)
        {
            IMouse mouse = ((IHasInputDevices)Driver.WebDriver).Mouse;
            DragOver(target);

            ILocatable targetL = (ILocatable)target.ContentElement;
            mouse.MouseUp(targetL.Coordinates);
        }

        /// <summary>
        /// Clicks this element.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Click this element. If the click causes a new page to load, the <see cref="OpenQA.Selenium.IWebElement.Click" />
        /// method will attempt to block until the page has loaded. After calling the
        /// <see cref="OpenQA.Selenium.IWebElement.Click" /> method, you should discard all references to this
        /// element unless you know that the element and the page will still be present.
        /// Otherwise, any further operations performed on this element will have an undefined.
        /// behavior.
        /// </para>
        /// <para>
        /// If this element is not clickable, then this operation is ignored. This allows you to
        /// simulate a users to accidentally missing the target when clicking.
        /// </para>
        /// </remarks>
        /// <exception cref="OpenQA.Selenium.ElementNotVisibleException">Thrown when the target element is not visible.</exception>
        /// <exception cref="OpenQA.Selenium.StaleElementReferenceException">Thrown when the target element is no longer valid in the document DOM.</exception>
        public virtual void Click()
        {
            Actions actions = new Actions(Driver.WebDriver);
            actions.MoveToElement(ContentElement);
            actions.Click();
            actions.Perform();
        }

        /// <summary>Simulates typing text into the element.</summary>
        /// <param name="text">The text to type into the element.</param>
        /// <remarks>The text to be typed may include special characters like arrow keys,
        /// backspaces, function keys, and so on. Valid special keys are defined in
        /// <see cref="OpenQA.Selenium.Keys" />.</remarks>
        /// <seealso cref="OpenQA.Selenium.Keys" />
        /// <exception cref="OpenQA.Selenium.InvalidElementStateException">Thrown when the target element is not enabled.</exception>
        /// <exception cref="OpenQA.Selenium.ElementNotVisibleException">Thrown when the target element is not visible.</exception>
        /// <exception cref="OpenQA.Selenium.StaleElementReferenceException">Thrown when the target element is no longer valid in the document DOM.</exception>
        public virtual void SendKeys(string text)
        {
            if (text == null)
                throw new ArgumentNullException(nameof(text));

            _contentElement.SendKeys(text);
        }

        /// <summary>
        /// Repeatedly checks if the child control with the given id is visible.
        /// Returns the child control if successful.
        /// </summary>
        /// <param name="childControlId">The child control identifier.</param>
        /// <param name="timeoutInSeconds">The time to wait for the child control in seconds.</param>
        /// <returns>The matching child widget.</returns>
        public IWidget WaitForChildControl(String childControlId, int? timeoutInSeconds)
        {
            if (childControlId == null)
                throw new ArgumentNullException(nameof(childControlId));

            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeoutInSeconds.GetValueOrDefault(5)));
            return wait.Until(ChildControlIsVisible(childControlId));
        }

        /// <summary>
        /// A condition that waits until a child control has been rendered, then returns it.
        /// </summary>
        /// <param name="childControlId">The child control identifier.</param>
        /// <returns>.</returns>
        public Func<IWebDriver, IWidget> ChildControlIsVisible(string childControlId)
        {
            if (childControlId == null)
                throw new ArgumentNullException(nameof(childControlId));

            return driver =>
            {
                var childControl = GetChildControl(childControlId);
                if (childControl != null && childControl.Displayed)
                {
                    return childControl;
                }
                return null;
            };
        }

        /// <summary>
        /// Returns a <seealso cref="IWidget" /> representing a child control of this widget.
        /// </summary>
        /// <param name="childControlId">The child control identifier.</param>
        /// <returns>
        /// The matching child widget or <c>null</c> if the child control doesn't exist.
        ///.</returns>
        public virtual IWidget GetChildControl(string childControlId)
        {
            if (childControlId == null)
                throw new ArgumentNullException(nameof(childControlId));

            object result = JsRunner.RunScript("getChildControl", _contentElement, childControlId);
            IWebElement element = (IWebElement)result;
            if (element == null)
            {
                return null;
            }
            return Driver.GetWidgetForElement(element);
        }

        /// <summary>
        /// Determines whether [has child control] [the specified child control identifier].
        /// </summary>
        /// <param name="childControlId">The child control identifier.</param>
        /// <returns>
        ///   <value>true</value> if the widget has a child control; otherwise <value>false</value>
        ///.</returns>
        public virtual bool HasChildControl(string childControlId)
        {
            if (childControlId == null)
                throw new ArgumentNullException(nameof(childControlId));

            object result = JsRunner.RunScript("hasChildControl", _contentElement, childControlId);
            return result != null && (bool)result;
        }

        /// <summary>
        /// Gets a <seealso cref="IWidget" /> representing the layout parent.
        /// </summary>
        public virtual IWidget LayoutParent
        {
            get
            {
                object result = JsRunner.RunScript("getLayoutParent", _contentElement);
                IWebElement element = (IWebElement)result;
                if (element == null)
                {
                    return null;
                }
                return Driver.GetWidgetForElement(element);
            }
        }

        /// <summary>
        /// Calls IJavaScriptExecutor.ExecuteScript. The first argument is the widget's
        /// content element.
        /// </summary>
        /// <param name="script">The script to execute.</param>
        /// <returns>
        /// The value returned by the execution.
        ///.</returns>
        /// <seealso cref="OpenQA.Selenium.IJavaScriptExecutor" />
        public virtual object ExecuteJavascript(string script)
        {
            if (script == null)
                throw new ArgumentNullException(nameof(script));

            return JsExecutor.ExecuteScript(script, _contentElement);
        }

        /// <summary>
        /// Calls a method on this widget instance.
        /// </summary>
        /// <param name="name">The name of the method to call.</param>
        /// <param name="args">The variable arguments to pass to the method call.</param>
        /// <returns>
        /// The value returned by the execution.
        ///.</returns>
        /// <seealso cref="OpenQA.Selenium.IJavaScriptExecutor" />
        public virtual object Call(string name, params object[] args)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));

            object result = JsRunner.RunScript("callMethod", _contentElement, name, args);

            if (result is IWebElement)
                return Driver.GetWidgetForElement((IWebElement)result);

            if (result is IList<IWebElement>)
            {
                var i = 0;
                var array = (IList<IWebElement>)result;
                var widgets = new IWidget[array.Count];
                foreach (IWebElement el in array)
                {
                    widgets[i++] = Driver.GetWidgetForElement(el);
                }
                result = widgets;
            }

            return result;
        }

        /// <summary>
        /// Returns the value of a qooxdoo property on this widget, serialized in JSON
        /// format.
        /// <strong>NOTE:</strong> Never use this for property values that are instances
        /// of qx.core.Object. Circular references in qooxdoo's OO system will lead to
        /// JavaScript errors.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns>
        /// The property value as JSON string.
        ///.</returns>
        public virtual string GetPropertyValueAsJson(string propertyName)
        {
            if (propertyName == null)
                throw new ArgumentNullException(nameof(propertyName));

            object result = JsRunner.RunScript("getPropertyValueAsJson", _contentElement, propertyName);
            return (string)result;
        }

        /// <summary>
        /// Returns the value of a qooxdoo property on this widget. See the <seealso cref="OpenQA.Selenium.IJavaScriptExecutor" />
        /// documentation for details on how JavaScript types are represented.
        /// <strong>NOTE:</strong> Never use this for property values that are instances
        /// of qx.core.Object. Circular references in qooxdoo's OO system will lead to
        /// JavaScript errors.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns>
        /// The property value.
        ///.</returns>
        public virtual object GetPropertyValue(string propertyName)
        {
            if (propertyName == null)
                throw new ArgumentNullException(nameof(propertyName));

            object result = JsRunner.RunScript("getPropertyValue", _contentElement, propertyName);
            return result;
        }

        private IWebElement GetElementFromProperty(string propertyName)
        {
            object result = JsRunner.RunScript("getElementFromProperty", _contentElement, propertyName);
            return (IWebElement)result;
        }

        /// <summary>
        /// Returns a <seealso cref="IWidget" /> representing the value of a widget property,
        /// e.g. <a href="http://demo.qooxdoo.org/current/apiviewer/#qx.ui.form.MenuButton~menu!property">the
        /// MenuButton's menu property</a>
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns>
        /// The <seealso cref="IWidget" /> property value.
        ///.</returns>
        public virtual IWidget GetWidgetFromProperty(string propertyName)
        {
            if (propertyName == null)
                throw new ArgumentNullException(nameof(propertyName));

            return Driver.GetWidgetForElement(GetElementFromProperty(propertyName));
        }

        /// <summary>
        /// Returns a List of <seealso cref="IWidget" />s representing the value of a widget list property,
        /// e.g. <a href="http://demo.qooxdoo.org/current/apiviewer/#qx.ui.core.MMultiSelectionHandling~getSelection">MMultiSelectionHandling.getSelection</a>
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns>
        /// The List of <seealso cref="IWidget" />s property value.
        ///.</returns>
        public virtual IList<IWidget> GetWidgetListFromProperty(string propertyName)
        {
            if (propertyName == null)
                throw new ArgumentNullException(nameof(propertyName));

            IList<IWebElement> elements =
                (IList<IWebElement>)JsRunner.RunScript("getElementsFromProperty", _contentElement, propertyName);
            IList<IWidget> widgets = new List<IWidget>();

            using (IEnumerator<IWebElement> elemIter = elements.GetEnumerator())
            {
                while (elemIter.MoveNext())
                {
                    IWebElement element = elemIter.Current;
                    IWidget widget = Driver.GetWidgetForElement(element);
                    widgets.Add(widget);
                }
            }

            return widgets;
        }

        private IList<IWebElement> ChildrenElements
        {
            get
            {
                object result = JsRunner.RunScript("getChildrenElements", _contentElement);
                IList<IWebElement> children = (IList<IWebElement>)result;
                return children;
            }
        }

        /// <summary>
        /// Gets a list of <seealso cref="IWidget" /> objects representing this widget's children
        /// as defined using <a href="http://demo.qooxdoo.org/current/apiviewer/#qx.ui.core.MChildrenHandling~add!method_public">parent.add(child);</a> in the application code.
        /// </summary>
        public virtual IList<IWidget> Children
        {
            get
            {
                IList<IWebElement> childrenElements = ChildrenElements;
                IList<IWidget> children = new List<IWidget>();

                using (IEnumerator<IWebElement> iter = childrenElements.GetEnumerator())
                {
                    while (iter.MoveNext())
                    {
                        IWebElement child = iter.Current;
                        children.Add(Driver.GetWidgetForElement(child));
                    }
                }

                return children;
            }
        }

        /// <summary>
        /// A condition that checks if an element is rendered.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="by">The locating mechanism to use.</param>
        /// <returns>.</returns>
        public Func<IWebDriver, IWebElement> IsRendered(IWebElement element, OpenQA.Selenium.By by)
        {
            return (driver) => { return element.FindElement(by); };
        }

        /// <summary>
        /// Finds the first <see cref="OpenQA.Selenium.IWebElement" /> using the given method.
        /// </summary>
        /// <param name="by">The locating mechanism to use.</param>
        /// <returns>The first matching <see cref="OpenQA.Selenium.IWebElement" /> on the current context.</returns>
        /// <exception cref="OpenQA.Selenium.NoSuchElementException">If no element matches the criteria.</exception>
        public virtual IWebElement FindElement(OpenQA.Selenium.By by)
        {
            long implictWait = GetImplicitWait();

            return FindElement(by, implictWait);
        }

        private long GetImplicitWait()
        {
            if (Driver.ImplictWait.HasValue)
                return Driver.ImplictWait.Value.Seconds;

            return Driver.Manage().Timeouts().ImplicitWait.Seconds;
        }

        private IWebElement FindElement(OpenQA.Selenium.By by, long timeoutInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeoutInSeconds));
            return wait.Until(IsRendered(_contentElement, by));
        }

        /// <summary>
        /// Finds a widget relative to the current one by traversing the qooxdoo
        /// widget hierarchy.
        /// </summary>
        /// <param name="by">The locating mechanism to use.</param>
        /// <returns>The found widget.</returns>
        public virtual IWidget FindWidget(OpenQA.Selenium.By by)
        {
            IWebElement element = FindElement(by);
            return Driver.GetWidgetForElement(element);
        }

        /// <summary>
        /// Finds a widget relative to the current one by traversing the qooxdoo
        /// widget hierarchy.
        /// </summary>
        /// <param name="by">The locating mechanism to use.</param>
        /// <param name="timeoutInSeconds">The time to wait for the widget in seconds.</param>
        /// <returns>The matching widget.</returns>
        public virtual IWidget WaitForWidget(OpenQA.Selenium.By by, long timeoutInSeconds)
        {
            IWebElement element = FindElement(by, timeoutInSeconds);
            return Driver.GetWidgetForElement(element);
        }

        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return "QxWidget " + ClassName + "[" + QxHash + "]";
        }

        /// <summary>
        /// Not implemented for qooxdoo widgets.
        /// </summary>
        public virtual void Submit()
        {
            throw new Exception("Not implemented for qooxdoo widgets.");
        }

        /// <summary>Clears the content of this element.</summary>
        /// <remarks>If this element is a text entry element, the <see cref="OpenQA.Selenium.IWebElement.Clear" />
        /// method will clear the value. It has no effect on other elements. Text entry elements
        /// are defined as elements with INPUT or TEXTAREA tags.</remarks>
        /// <exception cref="OpenQA.Selenium.StaleElementReferenceException">Thrown when the target element is no longer valid in the document DOM.</exception>
        public void Clear()
        {
            _contentElement.Clear();
        }

        /// <summary>
        /// Gets the tag name of this element.
        /// </summary>
        /// <remarks>
        /// The <see cref="OpenQA.Selenium.IWebElement.TagName" /> property returns the tag name of the
        /// element, not the value of the name attribute. For example, it will return
        /// "input" for an element specified by the HTML markup &lt;input name="foo" /&gt;.
        /// </remarks>
        /// <exception cref="OpenQA.Selenium.StaleElementReferenceException">Thrown when the target element is no longer valid in the document DOM.</exception>
        public string TagName
        {
            get { return _contentElement.TagName; }
        }

        /// <summary>
        /// Returns the value of the specified attribute for this element.
        /// </summary>
        /// <param name="attributeName">The name of the attribute.</param>
        /// <returns>The attribute's current value. Returns a <see langword="null" /> if the
        /// value is not set.</returns>
        /// <remarks>The <see cref="OpenQA.Selenium.IWebElement.GetAttribute(System.String)" /> method will return the current value
        /// of the attribute, even if the value has been modified after the page has been
        /// loaded. Note that the value of the following attributes will be returned even if
        /// there is no explicit attribute on the element:
        /// <list type="table"><listheader><term>Attribute name</term><term>Value returned if not explicitly specified</term><term>Valid element types</term></listheader><item><description>checked</description><description>checked</description><description>Check Box</description></item><item><description>selected</description><description>selected</description><description>Options in Select elements</description></item><item><description>disabled</description><description>disabled</description><description>Input and other UI elements</description></item></list></remarks>
        /// <exception cref="OpenQA.Selenium.StaleElementReferenceException">Thrown when the target element is no longer valid in the document DOM.</exception>
        public string GetAttribute(string attributeName)
        {
            return _contentElement.GetAttribute(attributeName);
        }

        /// <summary>
        /// Returns the value of a JavaScript property of this element.
        /// </summary>
        /// <param name="propertyName">The name JavaScript the JavaScript property to get the value of.</param>
        /// <returns>The JavaScript property's current value. Returns a <see langword="null" /> if the
        /// value is not set or the property does not exist.</returns>
        /// <exception cref="OpenQA.Selenium.StaleElementReferenceException">Thrown when the target element is no longer valid in the document DOM.</exception>
        public string GetProperty(string propertyName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets a value indicating whether this element is selected.
        /// </summary>
        /// <remarks>This operation only applies to input elements such as checkboxes,
        /// options in a select element and radio buttons.</remarks>
        /// <exception cref="OpenQA.Selenium.StaleElementReferenceException">Thrown when the target element is no longer valid in the document DOM.</exception>
        public virtual bool Selected
        {
            get { return _contentElement.Selected; }
        }

        /// <summary>
        /// Gets a value indicating whether this element is enabled.
        /// </summary>
        /// <remarks>The <see cref="OpenQA.Selenium.IWebElement.Enabled" /> property will generally
        /// return <see langword="true" /> for everything except explicitly disabled input elements.</remarks>
        /// <exception cref="OpenQA.Selenium.StaleElementReferenceException">Thrown when the target element is no longer valid in the document DOM.</exception>
        public virtual bool Enabled
        {
            get { return _contentElement.Enabled; }
        }

        /// <summary>
        /// Gets the innerText of this element, without any leading or trailing whitespace,
        /// and with other whitespace collapsed.
        /// </summary>
        /// <exception cref="OpenQA.Selenium.StaleElementReferenceException">Thrown when the target element is no longer valid in the document DOM.</exception>
        public virtual string Text
        {
            get { return _contentElement.Text; }
        }

        /// <summary>
        /// Finds all <see cref="OpenQA.Selenium.IWebElement">IWebElements</see> within the current context
        /// using the given mechanism.
        /// </summary>
        /// <param name="by">The locating mechanism to use.</param>
        /// <returns>A <see cref="System.Collections.ObjectModel.ReadOnlyCollection`1" /> of all <see cref="OpenQA.Selenium.IWebElement">WebElements</see>
        /// matching the current criteria, or an empty list if nothing matches.</returns>
        public ReadOnlyCollection<IWebElement> FindElements(OpenQA.Selenium.By by)
        {
            return _contentElement.FindElements(by);
        }

        /// <summary>
        /// Gets a value indicating whether the widget is visible.
        /// <a href="http://demo.qooxdoo.org/current/apiviewer/#qx.ui.core.Widget~isSeeable!method_public">seeable</a>.
        /// </summary>
        public virtual bool Displayed
        {
            get
            {
                return ((bool?)ExecuteJavascript(
                    "return qx.ui.core.Widget.getWidgetByElement(arguments[0]).isSeeable()")).Value;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the widget has been disposed.
        /// </summary>
        public virtual bool IsDisposed
        {
            get
            {
                try
                {
                    object result = JsRunner.RunScript("isDisposed", _contentElement);
                    return result == null || (bool)result;
                }
                catch (StaleElementReferenceException)
                {
                    return true;
                }
            }
        }

        /// <summary>
        /// Gets the name of the widget.
        /// </summary>
        public string Name
        {
            get
            {
                try
                {
                    return (string)Call("getName");
                }
                catch
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets a <see cref="System.Drawing.Point" /> object containing the coordinates of the upper-left corner
        /// of this element relative to the upper-left corner of the page.
        /// </summary>
        /// <exception cref="OpenQA.Selenium.StaleElementReferenceException">Thrown when the target element is no longer valid in the document DOM.</exception>
        public virtual Point Location
        {
            get { return _contentElement.Location; }
        }

        /// <summary>
        /// Gets a <see cref="OpenQA.Selenium.IWebElement.Size" /> object containing the height and width of this element.
        /// </summary>
        /// <exception cref="OpenQA.Selenium.StaleElementReferenceException">Thrown when the target element is no longer valid in the document DOM.</exception>
        public virtual Size Size
        {
            get { return _contentElement.Size; }
        }

        /// <summary>
        /// Returns the value of a CSS property of this element.
        /// </summary>
        /// <param name="propertyName">The name of the CSS property to get the value of.</param>
        /// <returns>The value of the specified CSS property.</returns>
        /// <remarks>The value returned by the <see cref="OpenQA.Selenium.IWebElement.GetCssValue(System.String)" />
        /// method is likely to be unpredictable in a cross-browser environment.
        /// Color values should be returned as hex strings. For example, a
        /// "background-color" property set as "green" in the HTML source, will
        /// return "#008000" for its value.</remarks>
        /// <exception cref="OpenQA.Selenium.StaleElementReferenceException">Thrown when the target element is no longer valid in the document DOM.</exception>
        public string GetCssValue(string propertyName)
        {
            return _contentElement.GetCssValue(propertyName);
        }

        /// <summary>
        /// Gets the <see cref="IWebDriver"/> associated to this widget.
        /// </summary>
        IWebDriver IWidget.Driver
        {
            get { return this.Driver; }
        }
    }
}