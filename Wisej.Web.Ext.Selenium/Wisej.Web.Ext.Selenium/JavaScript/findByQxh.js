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

qxwebdriver.findByQxh = function() {
return (function(args) {

  if (typeof window.console == "undefined") {
    window.console = {
      log : function() {},
      debug : function() {},
      info : function() {},
      warn : function() {},
      error : function() {}
    };
  }

  var Qxh = function(locator, findOnlySeeable, rootElement) {
    var app = qx.core.Init.getApplication();
    if (qx.application.Standalone && app instanceof qx.application.Standalone) {
      this.appType = "desktop";
    } else if (qx.application.Mobile && app instanceof qx.application.Mobile) {
      this.appType = "mobile";
    } else if (qx.application.Inline && app instanceof qx.application.Inline) {
      this.appType = "inline";
    }

    this.qxhParts = locator.split('/');
    this.findOnlySeeable = findOnlySeeable;
    if (this.findOnlySeeable) {
      console.log("Qxh searching for seeable widgets only.");
    } else {
      console.log("Qxh searching for seeable and non-seeable widgets.");
    }
    this.root = this.getRoot(rootElement);
    /* this._iframeQxObject = null; */
    this.seenNodes = [];
  };

  Qxh.IDENTIFIER = new RegExp('^[a-z$][a-z0-9_\\.$]*$', 'i');
  Qxh.NTHCHILD = /^child\[-?\d+\]$/i;
  Qxh.ATTRIB = /^\[.*\]$/;

  Qxh.prototype.findElement = function() {
    resultObject = this.searchQxObjectByQxHierarchy(this.root, this.qxhParts);

    if (resultObject) {
      return this.getDomElementFromWidget(resultObject);
    }

    return null;
  };

  Qxh.prototype.getRoot = function(rootArg) {
    var root;
    if (rootArg.nodeType && rootArg.nodeType == 1) {
      if (this.appType == "desktop") {
        root = qx.ui.core.Widget.getWidgetByElement(rootArg);
      } else if (this.appType == "mobile" && rootArg.id) {
        root = qx.ui.mobile.core.Widget.getWidgetByElement(rootArg.id);
      } else if (this.appType == "inline") {
        root = qx.ui.core.Widget.getWidgetByElement(rootArg);
        if (!root && rootArg.firstChild) {
          /* If the inline root is configured to respect the DOM
             element's original dimensions, an additional div is created: */
          root = qx.ui.core.Widget.getWidgetByElement(rootArg.firstChild);
        }
      }
    }

    if (rootArg == "qx.ui.root.Application") {
      root = qx.core.Init.getApplication().getRoot();
    }

    if (!rootArg) {
      throw new Error("Unable to find application for argument '" + rootArg + "!'");
    }

    console.log("Qxh starting with root " + root.toString());
    return root;
  };

  Qxh.prototype.arrayContainsObject = function(array, object) {
    for (var i=0, l=array.length; i<l; i++) {
      if (object.toHashCode() === array[i].toHashCode()) {
        return true;
      }
    }
    return false;
  };

  Qxh.prototype.getDomElementFromWidget = function(widget) {
    if (
      (this.appType == "desktop" && !(widget instanceof qx.ui.core.Widget)) ||
      (this.appType == "mobile" && !(widget instanceof qx.ui.mobile.core.Widget))
      ) {
      console.error("Qxh: Object '" + widget.toString() + "' is not a Widget!");
      return null;
    }

    var contentElement = widget.getContentElement();
    if (contentElement && contentElement.nodeType && contentElement.nodeType === 1) {
      return contentElement;
    }

    var domElement = contentElement.getDomElement();
    if (!domElement) {
      console.error("Qxh: Widget '" + widget.toString() + "' is not rendered!");
      return null;
    }

    return domElement;
  };

  Qxh.prototype.getQxNodeDescendants = function(node) {
    var descArr = [];
    var c;

     /* If the node is one of the qooxdoo Iframes (html or ui.embed) containing
        another qooxdoo application, try to retrieve its root widget */
    if ( node.classname && (node.classname.indexOf("Iframe") + 6 == node.classname.length) && node.getWindow) {
      console.log("getQxNodeDescendants: using getWindow() to retrieve descendants");
      try {
        /* store a reference to the iframe's qx object. This is used by
           Selenium.getQxWidgetByLocator
           this_iframeQxObject = node.getWindow().qx; */
        descArr.push(node.getWindow().qx.core.Init.getApplication().getRoot());
      }
      catch (ex) {
      }
    }

    else {
      /* check external widget children (built with w.add()) */
      if (node.getChildren) {
        console.log("getQxNodeDescendants: using getChildren() to retrieve descendants of " + node);
        /* Workaround for qx bug #3161 */
        try {
          c = node.getChildren();
        } catch(ex) {
          c = [];
        }

        for (var i=0; i<c.length; i++) {
          descArr.push(c[i]);
        }
      }

      /* check TreeFolder items: Only necessary for qooxdoo versions < 0.8.3 */
      else {
        if (node.getItems) {
          console.log("getQxNodeDescendants: using getItems() to retrieve descendants");
          c = node.getItems();
          for (var j=0; j<c.length; j++) {
            descArr.push(c[j]);
          }
        }
      }

      if (node.getMenu) {
        console.log("Getting child menu");
        descArr.push(node.getMenu());
      }

      /* check internal children (e.g. child controls) */
      if (node._getChildren) {
        console.log("getQxNodeDescendants: using _getChildren() to retrieve descendants of " + node);
        c = node._getChildren();
        for (var k=0; k<c.length; k++) {
          descArr.push(c[k]);
        }
      }

      /* use JS object members */
      if (!(node.getChildren || node._getChildren)) {
        console.log("getQxNodeDescendants: using JS properties to retrieve descendants");
        for (var m in node) {
          var objMember = node[m];
          if (!objMember || typeof objMember !== "object" ||
          !node.hasOwnProperty(m) || !objMember.toHashCode) {
            continue;
          }
          descArr.push(objMember);
        }
      }

    }

    /* only select useful subnodes (only objects, no circular refs, etc.)
       TODO: circular refs which are *not* immediate! */
    var descArr1 = [];
    for (var l=0; l<descArr.length; l++)
    {
      var curr = descArr[l];
      if ((typeof(curr) == "object") && (curr != node) && (curr !== null)) {
        if (curr.wrappedJSObject) {
          curr = curr.wrappedJSObject;
        }
        if (!curr.isSeeable) {
          console.log(curr.classname + "has no method isSeeable");
          if (!this.arrayContainsObject(descArr1, curr)) {
            descArr1.push(curr);
          }
        }
        else if (!this.findOnlySeeable || (this.findOnlySeeable && curr.isSeeable())) {
          /* if findOnlySeeable is active, check the subnode's seeable property */
          if (!this.arrayContainsObject(descArr1, curr)) {
            descArr1.push(curr);
          }
        }
      }
    }

    console.log("getQxNodeDescendants: returning for node immediate children: "+descArr1.length);
    return descArr1;
  };

  Qxh.prototype.searchQxObjectByQxHierarchy = function(root, path) {
    /* recursively traverse the path
       currently we only return single elements, not sets of matching elements */
    if (path.length === 0) {
      return null;
    }
    if (typeof(root) != "object") { /* can only traverse (qooxdoo) objects */
      return null;
    }
    if (root === null) {
      throw new Error("Qxh Locator: Cannot determine descendant from null root for: " + path);
    }

    var el = null;
    var step = path[0];
    var npath = path.slice(1);

    console.log("Qxh Locator: Inspecting current step: " + step);

    /* get a suitable element from the current step, dispatching on step type */
    if (step == '*')                 /* this is like '//' in XPath */
    {
      /* this means we have to recursively look for rest of path among descendants
         console.log("Qxh Locator: ... identified as wildcard (*) step"); */
      var res = null;

      /* first check if current element matches already */
      if (npath === 0)
      {
        /* no more location specifiers, * matches all, so return current element */
        return root;
      }
      else
      {
        /* there is something to match against */
        try
        {
          console.log("Qxh Locator: recursing with root: "+root+", path: "+npath.join('/'));
          res = this.searchQxObjectByQxHierarchy(root, npath);
        }
        catch (e)
        {
          if (e.a instanceof Array)
          {
            /* it's an exception thrown by myself - just continue search */
          }
          else
          {
            throw e;
          }
        }
      }
      /* check what we've got - can't be null */
      if (res !== null)
      {
        return res;
      }

      /* then recurse with children, using original path */
      var childs = this.getQxNodeDescendants(root);

      for (var i=0; i<childs.length; i++)
      {
        try
        {
          console.log("Qxh Locator: recursing with root: "+childs[i]+", path: "+path.join('/'));
          if (this.arrayContainsObject(this.seenNodes, childs[i])) {
            continue;
          }
          this.seenNodes.push(childs[i]);
          res = this.searchQxObjectByQxHierarchy(childs[i], path);
        }
        catch (e)
        {
          if (e.a instanceof Array)
          {
            /* it's an exception thrown by a descendant - just continue search */
            continue;
          }
          else
          {
            throw e;
          }
        }
        /* when we reach this we have a hit */
        return res;
      }

      /* let's see how we came out of the loop
         all recursion is already done, so we can terminate here */
      if (res === null)
      {
        var e = new Error("Qxh Locator: Error resolving qxh path");
        e.a = [ step ]; /* since we lost the e from deeper recursions just report current */
        throw e;
      }
      else
      {
        return res; /* this should be superfluous */
      }
    }

    else if (step.match(Qxh.IDENTIFIER))
    {
      if (step.indexOf('.') == -1)  /* 'foo' format */
      {
        console.log("Qxh Locator: ... identified as general identifier");
        el = this.getQxElementFromStep1(root, step);
      }
      else
      {  /* 'qx....' format */
        console.log("Qxh Locator: ... identified as qooxdoo class name");
        el = this.getQxElementFromStep2(root, step);
      }
    }

    else if (step.match(Qxh.NTHCHILD))  /* 'child[n]' format */
    {
      console.log("Qxh Locator: ... identified as indexed child");
      el = this.getQxElementFromStep3(root, step);
    }

    else if (step.match(Qxh.ATTRIB))  /* '[@..=...]' format */
    {
      console.log("Qxh Locator: ... identified as attribute specifier");
      el = this.getQxElementFromStep4(root, step);
    }

    else  /* unknown step format */
    {
      throw new Error("Qxh Locator: Illegal path step: " + step);
    }

    /* check result */
    if (el === null)
    {
      var ex = new Error("Qxh Locator: Error resolving qxh path");
      ex.a = [ step ];
      throw ex;
    }

    /* recurse */
    if (npath.length === 0) {
      console.log("Qxh Locator: Terminating search, found match; last step :"+step+", element: "+el);
      return el;
    }
    else
    {
      /* basically we tail recurse, but catch exceptions */
      try {
        console.log("Qxh Locator: found step (" + step + "), moving on to (" +
                  npath[0] + ")" );
        res = this.searchQxObjectByQxHierarchy(el, npath);
      }
      catch(e)
      {
        if (e.a instanceof Array)
        {
          /* prepend the current step */
          e.a.unshift(step);
          console.log("Qxh Locator: ... nothing found in this branch; going up");
          throw e;
        }
        else
        {  /* re-raise */
          throw e;
        }
      }
    }

    return res;
  };


  Qxh.prototype.getQxElementFromStep1 = function(root, step) {
    /* find an object member of root with name 'step' */
    console.log("Qxh Locator: in getQxElementFromStep1");
    var member;

    for (member in root)
    {
      if (member == step) {
        console.log("Qxh Locator: getQxElementFromStep1 returning object");
        return root[member];
      }
    }

    console.log("Qxh Locator: getQxElementFromStep1 returning null");
    return null;
  };


  Qxh.prototype.getQxElementFromStep2 = function(root, qxclass) {
    /* find a child of root with qooxdoo type 'qxclass' */
    console.log("Qxh Locator: in getQxElementFromStep2");
    var childs;
    var curr;

    var myClass = qx.Class.getByName(qxclass);
    if (!myClass) {
      return null;
    }

    childs = this.getQxNodeDescendants(root);

    for (var i=0; i<childs.length; i++)
    {
      curr = childs[i];
      if (!curr.classname) {
        continue;
      }
      console.log("Qxh Locator: Comparing found child " + curr.classname + " to wanted class " + qxclass);
      try {
        if (curr instanceof myClass) {
          return curr;
        }
      } catch(ex) {
        throw new Error("instanceof failed for operand " + myClass.toString());
      }
    }

    return null;
  };


  Qxh.prototype.getQxElementFromStep3 = function(root, childspec) {
    /* find a child of root by index */
    console.log("Qxh Locator: in getQxElementFromStep3");
    var childs;
    var idx;
    var m;

    /* extract child index */
    m = /child\[(-?\d+)\]/i.exec(childspec);

    if ((m instanceof Array) && m.length > 1) {
      idx = parseInt(m[1], 10);
    } else {
      return null;
    }

    childs = this.getQxNodeDescendants(root);

    /* Negative index value: Reverse access */
    if (idx < 0 ) {
      if (Math.abs(idx) > childs.length) {
        return null;
      } else {
        var index = (childs.length + idx);
        return childs[index];
      }
    }

    if (idx >= childs.length) {
      return null;
    } else {
      return childs[idx];
    }
  };


  Qxh.prototype.getQxElementFromStep4 = function(root, attribspec) {
    /* find a child of root by attribute */
    console.log("Qxh Locator: in getQxElementFromStep4");
    var childs;
    var attrib;
    var attval;
    var rattval;
    var actobj;
    var m;

    /* extract attribute and value */
    m = /\[@([^=]+)(?:=(.+))?\]$/.exec(attribspec);

    if ((m instanceof Array) && m.length > 1)
    {
      console.log("Qxh Locator: getQxElementFromStep4: parsed spec into: "+m);
      attrib = m[1];
      if (m.length > 2 && m[2]!=null && m[2] != "")
      {
        attval = m[2];

        /* strip possible quotes from attval */
        if (attval.match(/^['"].*['"]$/)) {
          attval = attval.slice(1, attval.length - 1);
        }

        /* it's nice to match against regexp's */
        rattval = new RegExp(attval);

      }
    }
    else
    {
      return null;
    }

    if (attval == null) /* no compare value -> attrib on root must contain obj ref */
    {
      actobj = this.getGeneralProperty(root, attrib);
      if (typeof(actobj) == "object")
      {
        return actobj; /* only return an obj ref */
      } else
      {
        return null;
      }
    }

    childs = this.getQxNodeDescendants(root);

    for (var i=0; i<childs.length; i++)
    {
      /* For every child, we check various ways where it might match with the step
         specifier (generally using regexp match to compare strings) */
      actobj = childs[i];

      /* check properties first */
      if (actobj.constructor)
      {
        var hasProp = qx.Class.hasProperty(actobj.constructor, attrib);  /* see qx.Class API */

        if (hasProp)
        {
          var currval = actobj.get(attrib);
          if (currval) {
            console.log("Qxh Locator: Attribute Step: Checking for qooxdoo property ('" + attrib + "' is: " + currval + ")");
            if (typeof currval !== "string") {
              if (currval.translate) {
                currval = currval.translate().toString();
              } else if (currval.toString) {
                currval = currval.toString();
              }
            }

            if (currval.match(rattval)) {
              return actobj;
            }
          }
        }
      }

      /* check for userData using special key:value syntax */
      if (attrib.indexOf("userData") === 0 && attval.indexOf(":") > 0 ) {
        var keyval = attval.split(":");
        console.log("Qxh Locator: Attribute Step: Checking for userData field " + keyval[0] + " with value " + keyval[1]);

        currval = actobj.getUserData(keyval[0]);

        var urattval = new RegExp(keyval[1]);
        if (currval && currval.match(urattval)) {
          return actobj;
        }
      }

      /* then, check normal JS attribs */
      if ((attrib in actobj) && ((String(actobj[attrib])).match(rattval)))
      {
        console.log("Qxh Locator: Attribute Step: Checking for JS object property");
        return actobj;
      }
      else
      {
        console.log("Qxh Locator: Attribute Step: No match for current child");
      }
    }

    return null;
  };

  Qxh.prototype.getGeneralProperty = function(actobj, attrib)
  {
    /* check properties first
       var qxclass = qx.Class.getByName(actobj.classname); */
    if (actobj.constructor)
    {
      var hasProp = qx.Class.hasProperty(actobj.constructor, attrib);  /* see qx.Class API */

      if (hasProp)
      {
        var currval = actobj.get(attrib);
        if (currval) {
          return currval;
        }
      }
    }

    /* then, check normal JS attribs */
    if (attrib in actobj)
    {
      return actobj[attrib];
    }

    return null;
  };

  var locator = args[0];
  var findOnlySeeable = typeof args[1] == "undefined" ? true : args[1];
  var rootElement = args[2] ? args[2] : "qx.ui.root.Application";
  var qxh = new Qxh(locator, findOnlySeeable, rootElement);
  return qxh.findElement();

})(arguments);
};
