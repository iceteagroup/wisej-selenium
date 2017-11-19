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
using System.IO;
using System.Text.RegularExpressions;

namespace Qooxdoo.WebDriver.Resources
{
    /// <summary>
    /// Handles JavaScript embedded as resource.
    /// </summary>
    public class JavaScript
    {
        /// <summary>
        /// The default instance
        /// </summary>
        public static readonly JavaScript Instance = new JavaScript("INSTANCE");

        private static readonly IList<JavaScript> ValueList = new List<JavaScript>();

        static JavaScript()
        {
            ValueList.Add(Instance);
        }

        private readonly string _nameValue;
        private readonly int _ordinalValue;
        private static int _nextOrdinal;

        private JavaScript(string name)
        {
            _nameValue = name;
            _ordinalValue = System.Threading.Interlocked.Increment(ref _nextOrdinal);
        }

        internal Dictionary<string, string> Resources = new Dictionary<string, string>();

        /// <summary>
        /// The JavaScript suffix
        /// </summary>
        /// <remarks>The suffix's default value is empty.</remarks>
        protected internal string Suffix = "";
        //protected internal string Suffix = "-min";

        /// <summary>
        /// The JavaScript file extension
        /// </summary>
        protected internal string FileExtension = ".js";

        /// <summary>
        /// Returns the JavaScript content of the resource.
        /// </summary>
        /// <param name="resourceId">The resource identifier.</param>
        /// <returns>The JavaScript content.</returns>
        public string GetValue(string resourceId)
        {
            if (!Resources.ContainsKey(resourceId))
            {
                string resourcePath = GetResourcePath(resourceId);
                AddResourceFromPath(resourceId, resourcePath);
            }

            return Resources[resourceId];
        }

        /// <summary>
        /// Adds a JavaScript resource if it doesn't exist in the dictionary.
        /// </summary>
        /// <param name="resourceId">The resource identifier.</param>
        /// <param name="resourcePath">The resource path.</param>
        public void AddResource(string resourceId, string resourcePath)
        {
            if (!Resources.ContainsKey(resourceId))
            {
                AddResourceFromPath(resourceId, resourcePath);
            }
        }

        /// <summary>
        /// Adds a JavaScript resource to the dictionary.
        /// </summary>
        /// <param name="resourceId">The resource identifier.</param>
        /// <param name="resourcePath">The resource path.</param>
        protected internal void AddResourceFromPath(string resourceId, string resourcePath)
        {
            string resource = ReadResource(resourcePath);
            resource = ManipulateResource(resource);
            Resources[resourceId] = resource;
        }

        /// <summary>
        /// Returns the full path of a JavaScript resource.
        /// </summary>
        /// <param name="resourceId">The resource identifier.</param>
        /// <returns>The full path of the resource.</returns>
        protected internal string GetResourcePath(string resourceId)
        {
            return GetBaseResourcePath() + resourceId + Suffix + FileExtension;
        }

        private string GetBaseResourcePath()
        {
            return "Wisej.Web.Ext.Selenium.JavaScript.";
        }

        /// <summary>
        /// Reads a JavaScript resource from the path.
        /// </summary>
        /// <param name="resourcePath">The resource path.</param>
        /// <returns>The raw resource content.</returns>
        /// <exception cref="System.Exception">Couldn't read resource file.</exception>
        protected internal string ReadResource(string resourcePath)
        {
            Stream @in = GetType().Assembly.GetManifestResourceStream(resourcePath);
            StreamReader br = new StreamReader(@in);

            string text = "";
            string line;

            try
            {
                while (!ReferenceEquals((line = br.ReadLine()), null))
                {
                    text += line;
                }
                br.Close();
            }
            catch (IOException e)
            {
                throw new Exception("Couldn't read resource file.", e);
            }

            return text;
        }

        /// <summary>
        /// Manipulates the JavaScript resource to get just the useful JavaScript code.
        /// </summary>
        /// <param name="resource">The resource.</param>
        /// <returns>The useful JavaScript code.</returns>
        protected internal string ManipulateResource(string resource)
        {
            Regex pattern = new Regex(@"function\s*\(\)\s*\{\s*(.*)\s*\};$",
                RegexOptions.Compiled | RegexOptions.Multiline);

            if (pattern.IsMatch(resource))
            {
                resource = pattern.Match(resource).Groups[1].Value;
            }

            return resource;
        }

        /// <summary>
        /// The list of the <see cref="JavaScript"/> instances.
        /// </summary>
        /// <returns>a list of <see cref="JavaScript"/> instances.</returns>
        public static IList<JavaScript> Values()
        {
            return ValueList;
        }

        /// <summary>
        /// Returns the ordinal number of this instance.
        /// </summary>
        /// <returns>The ordinal number of this instance.</returns>
        public int Ordinal()
        {
            return _ordinalValue;
        }

        /// <summary>
        /// Returns the name of this instance.
        /// </summary>
        /// <returns>The name of this instance.</returns>
        public override string ToString()
        {
            return _nameValue;
        }

        /// <summary>
        /// The named <see cref="JavaScript"/> instance.
        /// </summary>
        /// <param name="name">The instance name.</param>
        /// <returns>The named instance.</returns>
        /// <exception cref="System.ArgumentException"></exception>
        public static JavaScript ValueOf(string name)
        {
            foreach (JavaScript enumInstance in Values())
            {
                if (enumInstance._nameValue == name)
                {
                    return enumInstance;
                }
            }
            throw new ArgumentException(name);
        }
    }
}