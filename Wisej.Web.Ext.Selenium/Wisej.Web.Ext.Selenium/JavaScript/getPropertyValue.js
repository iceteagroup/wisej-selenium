/* ************************************************************************

   qxwebdriver-java

   http://github.com/qooxdoo/qxwebdriver-java
   http://qooxdoo.org

   Copyright:
     2012-2013 1&1 Internet AG, Germany, http://www.1und1.de

   License:
     LGPL: http://www.gnu.org/licenses/lgpl.html
     EPL: http://www.eclipse.org/org/documents/epl-v10.php
     See the license.txt file in the project's top-level directory for details.

   Authors:
     * Daniel Wagner (danielwagner)

************************************************************************ */

qxwebdriver.getPropertyValue = function() {
  var widget = qxwebdriver.getWidgetByElement(arguments[0]);
  var result = widget.get(arguments[1]);
  if (qx.data && qx.data.Array && result instanceof qx.data.Array) {
    result = result.toArray();
  }
  if (result instanceof Array) {
    result = result.map(function(item) {
      return item instanceof qx.core.Object ? item.toString() : item;
    });
  }
  if (result instanceof qx.core.Object) {
    result = result.toString();
  }
  return result;
};
