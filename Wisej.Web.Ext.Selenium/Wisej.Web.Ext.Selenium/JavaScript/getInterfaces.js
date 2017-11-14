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

qxwebdriver.getInterfaces = function() {
  var widget = qxwebdriver.getWidgetByElement(arguments[0]);
  var iFaces = [];
  var clazz = widget.constructor;
  qx.Class.getInterfaces(clazz).forEach(function(item, i) {
    var match = /\[Interface (.*?)\]/.exec(item.toString());
    if (match && match.length > 1) {
      iFaces.push(match[1]);
    }
  });
  return iFaces;
};
