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

qxwebdriver.setTreeNodeOpened = function() {
  var widget = qx.ui.core.Widget.getWidgetByElement(arguments[0]);
  var rowIdx = arguments[1];
  var opened = arguments[2];
  var dm = widget.getDataModel();
  var node = dm.getNodeFromRow(rowIdx);
  widget.nodeSetOpened(node, opened);
};
