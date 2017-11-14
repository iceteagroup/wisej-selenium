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

namespace Qooxdoo.WebDriver.UI
{
    /// <summary>
    /// Widget factory interface
    /// </summary>
    public interface IWidgetFactory
    {
        /// <summary> Returns an instance of <seealso cref="IWidget"/> or one of its subclasses that
        /// represents the qooxdoo widget containing the given element. </summary>
        /// <param name="element"> A IWebElement representing a DOM element
        /// that is part of a qooxdoo widget </param>
        /// <returns>The Widget object.</returns>
        IWidget GetWidgetForElement(IWebElement element);
    }
}