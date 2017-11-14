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

namespace Qooxdoo.WebDriver.Resources
{
    /// <summary>
    /// Runs a JavaScript script
    /// </summary>
    public class JavaScriptRunner
    {
        /// <summary>
        /// The JavaScript executor
        /// </summary>
        protected internal IJavaScriptExecutor Executor;

        internal static string Namespace = "qxwebdriver";

#if !DEBUGJS
        internal IList<string> CreatedFunctions = new List<string>();
#endif
        /// <summary>
        /// Initializes a new instance of the <see cref="JavaScriptRunner"/> class.
        /// </summary>
        /// <param name="jsExecutor">The js executor.</param>
        public JavaScriptRunner(IJavaScriptExecutor jsExecutor)
        {
            Executor = jsExecutor;

#if !DEBUGJS
            string script;

            if (jsExecutor.GetType().Name != "FirefoxDriver")
            {
                script = Namespace + " = {};";
            }
            else
            {
                script =
                    "var new_script = document.createElement('script');" +
                    "new_script.type = 'text/javascript';" +
                    "new_script.text = '" + Namespace + " = {};';" +
                    "new_script.className = 'QxWorkAround';" +
                    "document.getElementsByTagName('head')[0].appendChild(new_script);";
            }

            Executor.ExecuteScript(script);

            /*// for all drivers, uses injection when simple method fails
            var result = Executor.ExecuteScript("return " + Namespace + ";");
            if (result != null)
            {
                script =
                    "var new_script = document.createElement('script');" +
                    "new_script.type = 'text/javascript';" +
                    "new_script.text = '" + Namespace + " = {};';" +
                    "new_script.className = 'QxWorkAround';" +
                    "document.getElementsByTagName('head')[0].appendChild(new_script);";
                Executor.ExecuteScript(script);
            }*/
#endif
        }

        /// <summary>
        /// Runs the script.
        /// </summary>
        /// <param name="scriptId">The script identifier.</param>
        /// <param name="args">The arguments.</param>
        /// <returns>The value returned by the script.</returns>
        public virtual object RunScript(string scriptId, params object[] args)
        {
#if !DEBUGJS
            if (!CreatedFunctions.Contains(scriptId))
            {
                DefineFunction(scriptId);
            }
#endif

            string fqFunctionName = Namespace + "." + scriptId;
            string call = "return " + fqFunctionName + ".apply(this, arguments);";
            return Executor.ExecuteScript(call, args);
        }

#if !DEBUGJS
        /// <summary>
        /// Defines a JavaScript function
        /// </summary>
        /// <param name="scriptId">The script identifier.</param>
        public virtual void DefineFunction(string scriptId)
        {
            string fqFunctionName = Namespace + "." + scriptId;
            string function = "function() {" + JavaScript.Instance.GetValue(scriptId) + "}";
            string script = fqFunctionName + " = " + function;
            Executor.ExecuteScript(script);
            CreatedFunctions.Add(scriptId);
        }
#endif
    }
}