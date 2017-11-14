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

using OpenQA.Selenium;
using Qooxdoo.WebDriver.UI.List;

namespace Qooxdoo.WebDriver.UI.Tree
{
    /// <summary>
    /// Virtual tree widget
    /// </summary>
    /// <seealso cref="List" />
    public class VirtualTree : List.List
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VirtualTree"/> class.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="webDriver">The web driver.</param>
        public VirtualTree(IWebElement element, QxWebDriver webDriver) : base(element, webDriver)
        {
        }
    }
}