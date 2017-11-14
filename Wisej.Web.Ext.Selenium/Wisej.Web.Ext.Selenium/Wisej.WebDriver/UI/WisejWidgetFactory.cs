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

using System;
using System.Collections.Generic;
using Qooxdoo.WebDriver.UI;

namespace Wisej.Web.Ext.Selenium.UI
{
    /// <summary>
    /// Wisej widget factory. Matches widget js class names to existing
    /// selenium proxies.
    /// </summary>
    public class WisejWidgetFactory : DefaultWidgetFactory
    {
        private static Dictionary<string, string> _classMapper;

        internal WisejWidgetFactory()
        {
            BuildClassMapper();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WisejWidgetFactory"/> class.
        /// </summary>
        /// <param name="webDriver">The wrapper QxWebDriver.</param>
        public WisejWidgetFactory(WisejWebDriver webDriver) : base(webDriver)
        {
            BuildClassMapper();
        }

        private const string Namespace = "Wisej.Web.Ext.Selenium.UI";

        private void BuildClassMapper()
        {
            if (_classMapper == null)
            {
                _classMapper = new Dictionary<string, string>();
                PopulateClassMapper();
            }
        }

        private void PopulateClassMapper()
        {
            _classMapper.Add("wisej.web.DataGrid", "wisej.web.DataGridView");
            _classMapper.Add("wisej.web.ScrollablePage", "wisej.web.Page");
            _classMapper.Add("wisej.web.tabcontrol.TabPage", "wisej.web.TabPage");
            _classMapper.Add("wisej.web.toolbar.Button", "wisej.web.ToolBarButton");
        }

        /// <summary>
        /// Converts the Wisej/qooxdoo class name to a .NET class name.
        /// </summary>
        /// <param name="className">The Wisej/qooxdoo class name.</param>
        /// <returns>The .NET class name.</returns>
        protected override string GetWidgetClassName(string className)
        {
            if (className.StartsWith("wisej.web.", StringComparison.Ordinal))
            {
                var convertedClassName = className;
                if (_classMapper.ContainsKey(className))
                    convertedClassName = _classMapper[className];

                convertedClassName = convertedClassName.Substring("wisej.web.".Length);
                return Namespace + "." + convertedClassName;
            }

            return base.GetWidgetClassName(className);
        }
    }
}