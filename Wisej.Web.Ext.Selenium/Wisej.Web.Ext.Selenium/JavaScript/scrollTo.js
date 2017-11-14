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

qxwebdriver.scrollTo = function() {
  var methodName = "scrollTo";
  if (arguments[2]) {
    methodName += arguments[2].toUpperCase();
  }
  var widget = qxwebdriver.getWidgetByElement(arguments[0]);
  widget[methodName](arguments[1]);
};
