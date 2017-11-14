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

qxwebdriver.getCaughtErrors = function() {
  return qxwebdriver.globalErrors.map(function(ex) {
    var exString = "";
    if (typeof ex.getSourceException == "function") {
      ex = ex.getSourceException();
    }
    if (qx.core.WindowError && ex instanceof qx.core.WindowError) {
      exString = ex.toString() + " in " + ex.getUri() + " line " + ex.getLineNumber();
    }
    else {
      exString = ex.name + ": " + ex.message;
    }
    if (ex.fileName) {
      exString += " in file " + ex.fileName;
    }
    if (ex.lineNumber) {
      exString += " line " + ex.lineNumber;
    }
    if (ex.columnNumber) {
      exString += " column " + ex.columnNumber;
    }
    var stack = ex.stack || ex.stacktrace;
    if (!stack && qx.dev.StackTrace && qx.dev.StackTrace.getStackTraceFromError) {
      stack = qx.dev.StackTrace.getStackTraceFromError(ex).join("\n");
    }
    var lines = stack.split("\n");
    if (lines[0] == exString) {
      stack = lines.slice(1).join("\n");
    }
    if (stack) {
      exString += "\n" + stack;
    }

    return exString;
  });
};
