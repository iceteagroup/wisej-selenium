/* ************************************************************************

   qxwebdriver-java

   http://github.com/qooxdoo/qxwebdriver-java
   http://qooxdoo.org

   Copyright:
     2012-2016 1&1 Internet AG, Germany, http://www.1und1.de

   License:
     LGPL: http://www.gnu.org/licenses/lgpl.html
     EPL: http://www.eclipse.org/org/documents/epl-v10.php
     See the license.txt file in the project's top-level directory for details.

   Authors:
     * Roel van Os (elentirmo)

************************************************************************ */

qxwebdriver.selectTableRow = function() {
  var rowIdx = arguments[1];   
  var widget = qx.ui.core.Widget.getWidgetByElement(arguments[0]);
  widget.getSelectionModel().setSelectionInterval(rowIdx, rowIdx);
};
