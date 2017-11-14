/*************************************************************************

   qxwebdriver-java

   http://github.com/qooxdoo/qxwebdriver-java

   Copyright:
     2014 1&1 Internet AG, Germany, http://www.1und1.de

   License:
     LGPL: http://www.gnu.org/licenses/lgpl.html
     EPL: http://www.eclipse.org/org/documents/epl-v10.php
     See the license.txt file in the project's top-level directory for details.

   Authors:
     * Daniel Wagner (danielwagner)

*************************************************************************/

namespace Qooxdoo.WebDriver.UI
{
    /// <summary>
    /// Touchable interface
    /// </summary>
    /// <seealso cref="IWidget" />
    public interface ITouchable : IWidget
    {
        /// <summary>
        /// Performs a single tap on this widget.
        /// </summary>
        void Tap();

        /// <summary>
        /// Performs a long tap on this widget.
        /// </summary>
        void Longtap();

        /// <summary>
        /// Tracks this widget by the given offsets </summary>
        /// <param name="x"> Amount of pixels to move horizontally </param>
        /// <param name="y"> Amount of pixels to move vertically </param>
        /// <param name="step"> Generate a move event every (step) pixels </param>
        void Track(int x, int y, int step);
    }
}