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

using System;
using System.Linq;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace Qooxdoo.WebDriver
{
    /// <summary>
    /// Provides a mechanism by which to find elements within a document.
    /// </summary>
    public partial class By : OpenQA.Selenium.By
    {
        /// <summary>
        /// The QxWebDriver to use
        /// </summary>
        protected static QxWebDriver Driver;

        /// <summary>
        /// Sets the QxWebDriver to use.
        /// </summary>
        /// <param name="driver">The QxWebDriver.</param>
        public static void SetQxWebDriver(QxWebDriver driver)
        {
            Driver = driver;
        }

        /// <summary>
        /// Searches for elements by traversing the qooxdoo application's widget hierarchy.
        /// See the <a href="TODO">Qxh locator manual page</a> for details.
        /// This strategy will ignore any widgets that are not currently visible, as
        /// determined by checking the qooxdoo property <a href="http://demo.qooxdoo.org/current/apiviewer/#qx.ui.Core.Widget~isSeeable!method_public">seeable</a>.
        /// </summary>
        /// <param name="locator">Locator specification</param>
        /// <param name="driver">The QxWebDriver to use.</param>
        /// <returns>By.ByQxh.</returns>
        public static By Qxh(string locator, QxWebDriver driver)
        {
            Driver = driver;

            return Qxh(locator);
        }

        /// <summary>
        /// Searches for elements by traversing the qooxdoo application's widget hierarchy.
        /// See the <a href="TODO">Qxh locator manual page</a> for details.
        /// This strategy will ignore any widgets that are not currently visible, as
        /// determined by checking the qooxdoo property <a href="http://demo.qooxdoo.org/current/apiviewer/#qx.ui.Core.Widget~isSeeable!method_public">seeable</a>.
        /// </summary>
        /// <param name="locator"> Locator specification </param>
        /// <returns>By.ByQxh.</returns>
        public static By Qxh(string locator)
        {
            if (ReferenceEquals(locator, null))
            {
                throw new ArgumentException("Can't find elements without a locator string.");
            }

            return new ByQxh(locator, true);
        }

        /// <summary>
        /// Searches for elements by traversing the qooxdoo application's widget
        /// hierarchy. See the <a href="https://github.com/iceteagroup/wisej-selenium">Qxh locator manual page</a> for details.
        /// </summary>
        /// <param name="locator">Locator specification</param>
        /// <param name="onlySeeable"><code>false</code> if invisible widgets should be
        /// traversed. Note that this can considerably increase execution time.</param>
        /// <param name="driver">The QxWebDriver to use.</param>
        /// <returns>configured ByQxh instance.</returns>
        public static By Qxh(string locator, bool? onlySeeable, QxWebDriver driver)
        {
            Driver = driver;

            return Qxh(locator, onlySeeable);
        }

        /// <summary>
        /// Searches for elements by traversing the qooxdoo application's widget
        /// hierarchy. See the <a href="https://github.com/iceteagroup/wisej-selenium">Qxh locator manual page</a> for details.
        /// </summary>
        /// <param name="locator"> Locator specification </param>
        /// <param name="onlySeeable"> <code>false</code> if invisible widgets should be
        /// traversed. Note that this can considerably increase execution time. </param>
        /// <returns>configured ByQxh instance.</returns>
        public static By Qxh(string locator, bool? onlySeeable)
        {
            if (ReferenceEquals(locator, null))
            {
                throw new ArgumentException("Can't find elements without a locator string.");
            }

            return new ByQxh(locator, onlySeeable);
        }

        /// <summary>
        /// Convert a widget namespace (including the widget name) to a <see cref="ByQxh"/> locator string.
        /// </summary>
        /// <param name="namespace">The locator string.</param>
        /// <returns>The converted locator string.</returns>
        public static string Namespace(string @namespace)
        {
            var parts = @namespace.Split('.');
            var result = string.Join(@"/", parts.Select(part => string.Format("[@name=^{0}$]", part)).ToArray());
            return result;
        }

        /// <summary>
        /// Mechanisms used to locate elements within a qooxdoo Desktop application.
        /// </summary>
        public class ByQxh : By
        {
            internal readonly string Locator;
            internal bool? OnlySeeable;

            /// <summary>
            /// Searches for elements by traversing the qooxdoo application's widget hierarchy.
            /// </summary>
            /// <param name="locator"> Locator specification </param>
            /// <param name="onlySeeable"> <code>false</code> if invisible widgets should be
            /// traversed. Note that this can considerably increase execution time. </param>
            public ByQxh(string locator, bool? onlySeeable)
            {
                Locator = locator;
                OnlySeeable = onlySeeable;
            }

            /// <summary>
            /// Finds all elements matching the criteria.
            /// </summary>
            /// <param name="context">An <see cref="ISearchContext"/> object to use to search for the elements.</param>
            /// <returns>A <see cref="ReadOnlyCollection{T}"/> of all <see cref="IWebElement"/>
            /// matching the current criteria, or an empty list if nothing matches.</returns>
            public override ReadOnlyCollection<IWebElement> FindElements(ISearchContext context)
            {
                //TODO: findByQxh only returns the first match
                throw new Exception("ByQxh.FindElements is not yet implemented.");
            }

            /// <summary>
            /// Finds the first element matching the criteria.
            /// </summary>
            /// <param name="context">An <see cref="ISearchContext"/> object to use to search for the elements.</param>
            /// <returns>The first matching <see cref="IWebElement"/> on the current context.</returns>
            public override IWebElement FindElement(ISearchContext context)
            {
                if (Driver == null)
                {
                    throw new Exception("QxWebDriver must be specified.");
                }

                RemoteWebElement contextElement = null;

                if (context is RemoteWebElement)
                {
                    contextElement = (RemoteWebElement) context;
                }

                try
                {
                    object result;

                    if (contextElement == null)
                    {
                        // OperaDriver.ExecuteScript won't accept null as an argument
                        result = Driver.JsRunner.RunScript("findByQxh", Locator, OnlySeeable);
                    }
                    else
                    {
                        try
                        {
                            result = Driver.JsRunner.RunScript("findByQxh", Locator, OnlySeeable, contextElement);
                        }
                        // TODO: catch (com.opera.Core.systems.scope.exceptions.ScopeException)
                        catch (Exception)
                        {
                            // OperaDriver will sometimes throw a ScopeException if ExecuteScript is called
                            // with an OperaWebElement as argument
                            return null;
                        }
                    }

                    return (IWebElement) result;
                }
                catch (WebDriverException e)
                {
                    string msg = e.Message;
                    /*if (msg.Contains("Error resolving qxh path") || msg.Contains("JavaScript error"))
                    {
                        // IEDriver doesn't include the original JS exception's message :(
                        return null;
                    }*/

                    if (msg.Contains("Illegal path step"))
                    {
                        string reason = "Invalid Qxh selector " + Locator;
                        throw new InvalidSelectorException(reason, e);
                    }
                    else
                    {
                        string reason = "Error while processing selector " + Locator;
                        throw new WebDriverException(reason, e);
                    }
                }
                catch (InvalidOperationException e)
                {
                    string msg = e.Message;
                    if (msg.Contains("Error resolving qxh path") || msg.Contains("JavaScript error"))
                    {
                        // IEDriver doesn't include the original JS exception's message :(
                        return null;
                    }

                    string reason = "Error while processing selector " + Locator;
                    throw new WebDriverException(reason, e);
                }
            }

            /// <summary>
            /// Returns a string representation of the finder.
            /// </summary>
            /// <returns>The string displaying the finder content.</returns>
            public override string ToString()
            {
                return "By.Qxh: " + Locator;
            }
        }
    }
}