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

qxwebdriver.getItemFromSelectables = function() {
  var widget = qxwebdriver.getWidgetByElement(arguments[0]);
  if (typeof arguments[1] == "number") {
    /* var scrollBar = widget.getChildControl("scrollbar-" + arguments[2]).getContentElement().getDomElement(); */
    var scrollBar = widget.getChildControl("scrollbar-y");
    if (scrollBar !== null) {
      var singleStep = scrollBar.get("singleStep");
      scrollBar["scrollTo"](arguments[1] * singleStep);
    }
  }
  var selectables = widget.getSelectables();
  for (var i=0; i<selectables.length; i++) {
    if ((typeof arguments[1] == "number" && i === arguments[1]) ||
        (typeof arguments[1] == "string" && selectables[i].getLabel().match(new RegExp(arguments[1])))) {
      var contentElement = selectables[i].getContentElement();
      if (contentElement.nodeType && contentElement.nodeType === 1) {
        return contentElement;
      }
      return contentElement.getDomElement();
    }
  }
  return null;
};
