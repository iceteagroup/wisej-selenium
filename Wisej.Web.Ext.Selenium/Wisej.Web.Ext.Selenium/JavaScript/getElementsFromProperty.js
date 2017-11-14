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

qxwebdriver.getElementsFromProperty = function() {
  var getDomElement = function(widget) {
    if (widget.getContentElement && widget.getContentElement()) {
      var contentElement = widget.getContentElement();
      if (contentElement.nodeType && contentElement.nodeType === 1) {
        return contentElement;
      }
      if (contentElement.getDomElement && contentElement.getDomElement()) {
        return contentElement.getDomElement();
      }
    }
    return null;
  };

  var widgets = [];
  var widget = qxwebdriver.getWidgetByElement(arguments[0]);
  var value = widget.get(arguments[1]);
  var isDataArray = value instanceof qx.data.Array;

  for (var i=0,l=value.length; i<l; i++) {
    var item = isDataArray ? value.getItem(i) : value[i];
    var result = getDomElement(item);
    if (result) {
      widgets.push(result);
    }
  }
  return widgets;
};
