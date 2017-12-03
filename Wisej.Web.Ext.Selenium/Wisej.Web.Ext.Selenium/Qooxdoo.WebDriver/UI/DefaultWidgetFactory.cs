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
using System.Linq;
using System.Reflection;
using OpenQA.Selenium;

namespace Qooxdoo.WebDriver.UI
{
    /// <summary>
    /// The default widget factory
    /// </summary>
    /// <seealso cref="IWidgetFactory" />
    public class DefaultWidgetFactory : IWidgetFactory
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultWidgetFactory"/> class.
        /// </summary>
        protected internal DefaultWidgetFactory()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultWidgetFactory"/> class.
        /// </summary>
        /// <param name="qxWebDriver">The wrapper QxWebDriver.</param>
        public DefaultWidgetFactory(QxWebDriver qxWebDriver)
        {
            Driver = qxWebDriver;
        }


        private const string Namespace = "Qooxdoo.WebDriver.UI";
        private readonly Dictionary<IWebElement, IWidget> _elements = new Dictionary<IWebElement, IWidget>();
        private QxWebDriver _driver;

        /// <summary>
        /// Gets or sets the QxWebDriver/WisejWebDriver used.
        /// </summary>
        protected internal QxWebDriver Driver
        {
            get
            {
                if (_driver == null)
                    throw new Exception("WisdgetFactory is missing the Driver parameter.");
                return _driver;
            }
            set { _driver = value; }
        }

        /// <summary>
        /// Returns a list of qooxdoo interfaces implemented by the widget containing
        /// the specifyed element.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns>.</returns>
        public virtual IList<string> GetWidgetInterfaces(IWebElement element)
        {
            //IList<object> resultList = (IList<object>) Driver.JsRunner.RunScript("getInterfaces", element);
            //return resultList.Cast<string>().ToList();

            return ((IList<object>) Driver.JsRunner.RunScript("getInterfaces", element)).Cast<string>().ToList();
        }

        /// <summary>
        /// Returns the inheritance hierarchy of the widget containing the specifyed element.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns>.</returns>
        public virtual IList<string> GetWidgetInheritance(IWebElement element)
        {
            //IList<object> resultList = (IList<object>) Driver.JsRunner.RunScript("getInheritance", element);
            //return resultList.Cast<string>().ToList();

            return ((IList<object>) Driver.JsRunner.RunScript("getInheritance", element)).Cast<string>().ToList();
        }

        /// <summary>
        /// Returns an instance of <seealso cref="IWidget" /> or one of its subclasses that
        /// represents the qooxdoo widget containing the specifyed element.
        /// </summary>
        /// <param name="element">A IWebElement representing a DOM element
        /// that is part of a qooxdoo widget</param>
        /// <returns>
        /// The Widget object
        ///.</returns>
        public virtual IWidget GetWidgetForElement(IWebElement element)
        {
            if (_elements.ContainsKey(element))
            {
                return _elements[element];
            }

            IList<string> interfaces = GetWidgetInterfaces(element);
            IList<string> classes = GetWidgetInheritance(element);

            ((List<string>) classes).AddRange(interfaces);

            if (classes.Remove("qx.ui.core.Widget"))
            {
                classes.Add("qx.ui.core.WidgetImpl");
            }

            if (classes.Remove("qx.ui.mobile.core.Widget"))
            {
                classes.Add("qx.ui.mobile.core.WidgetImpl");
            }

            IWidget widget = null;

            using (IEnumerator<string> classIter = classes.GetEnumerator())
            {
                while (classIter.MoveNext())
                {
                    string className = classIter.Current;
                    string widgetClassName = GetWidgetClassName(className);
                    if (!ReferenceEquals(widgetClassName, null))
                    {
                        ConstructorInfo constr = GetConstructorByClassName(widgetClassName);
                        if (constr != null)
                        {
                            try
                            {
                                //widget = (IWidget) constr.newInstance(element, driver);
                                widget = (IWidget) constr.Invoke(new object[] {element, Driver});
                                _elements[element] = widget;
                                //return widget;
                                break;
                            }
                            catch (Exception e)
                            {
                                Console.Error.WriteLine("Could not instantiate '" + widgetClassName + "': " +
                                                        e.Message);
                                Console.WriteLine(e.ToString());
                                Console.Write(e.StackTrace);
                            }
                        }
                    }
                }
            }

            return widget;
        }

        /// <summary>
        /// Converts the qooxdoo class name to a .NET class name.
        /// </summary>
        /// <param name="qxClassName">The qooxdoo class name.</param>
        /// <returns>The .NET class name.</returns>
        protected virtual string GetWidgetClassName(string qxClassName)
        {
            if (qxClassName.StartsWith("qx.ui.", StringComparison.Ordinal))
            {
                var convertedClassName = ConvertClassName(qxClassName.Substring(6));
                return Namespace + "." + convertedClassName;
            }

            return null;
        }

        /// <summary>
        /// Translate the JavaScript lowercase namespace to a .NET cased namespace.
        /// </summary>
        /// <param name="className">The JavaScript lowercase namespace.</param>
        /// <returns>The .NET cased namespace.</returns>
        protected string ConvertClassName(string className)
        {
            var classNameParts = className.Split('.');
            for (var index = 0; index < classNameParts.Length; index++)
            {
                classNameParts[index] =
                    char.ToUpper(classNameParts[index][0]) +
                    classNameParts[index].Substring(1, classNameParts[index].Length - 1);
            }
            className = string.Join(".", classNameParts);

            return className;
        }

        private ConstructorInfo GetConstructorByClassName(string widgetClassName)
        {
            try
            {
                Type widgetClass = Type.GetType(widgetClassName);
                if (widgetClass != null)
                {
                    var cnst = widgetClass.GetConstructors();
                    if (cnst.Length > 0)
                    {
                        return cnst[0];
                    }
                }
            }
            //catch (ClassNotFoundException)
            catch (ReflectionTypeLoadException)
            {
                //System.out.println("No class for " + widgetClassName);
            }
            return null;
        }
    }
}