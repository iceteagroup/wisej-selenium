/* ************************************************************************

   qxwebdriver-java

   http://github.com/qooxdoo/qxwebdriver-java
   http://qooxdoo.org

   Copyright:
     2014 1&1 Internet AG, Germany, http://www.1und1.de

   License:
     LGPL: http://www.gnu.org/licenses/lgpl.html
     EPL: http://www.eclipse.org/org/documents/epl-v10.php
     See the license.txt file in the project's top-level directory for details.

   Authors:
     * Daniel Wagner (danielwagner)

************************************************************************ */

qxwebdriver.getAllLogEvents = function() {
  var ret = [];
  qxwebdriver.appender.getAllLogEvents().forEach(function(entry) {
    var jsonEntry = {
      clazz: entry.clazz ? entry.clazz.toString() : null,
      time: entry.time.toString(),
      level: entry.level,
      items: entry.items.map(function(item) {
        if (item.text instanceof Array) {
          return item.text.map(function(obj) {
            return obj.text;
          }).join(" ");
        } else {
          return item.text;
        }
      })
    };
    ret.push(JSON.stringify(jsonEntry));
  });
  return ret;
};
