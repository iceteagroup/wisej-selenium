/*
//
// (C) 2017 ICE TEA GROUP LLC - ALL RIGHTS RESERVED
//
// 
//
// ALL INFORMATION CONTAINED HEREIN IS, AND REMAINS
// THE PROPERTY OF ICE TEA GROUP LLC AND ITS SUPPLIERS, IF ANY.
// THE INTELLECTUAL PROPERTY AND TECHNICAL CONCEPTS CONTAINED
// HEREIN ARE PROPRIETARY TO ICE TEA GROUP LLC AND ITS SUPPLIERS
// AND MAY BE COVERED BY U.S. AND FOREIGN PATENTS, PATENT IN PROCESS, AND
// ARE PROTECTED BY TRADE SECRET OR COPYRIGHT LAW.
//
// DISSEMINATION OF THIS INFORMATION OR REPRODUCTION OF THIS MATERIAL
// IS STRICTLY FORBIDDEN UNLESS PRIOR WRITTEN PERMISSION IS OBTAINED
// FROM ICE TEA GROUP LLC.
//
*/

qxwebdriver.getTreeViewNodes = function() {

    var widget = qx.ui.core.Widget.getWidgetByElement(arguments[0]);
    if (widget) {
        var rootNodes = widget.getChildren();
        if (rootNodes && rootNodes.length > 0) {
            var rootNode = rootNodes[0];
            var nodes = rootNode.getItems(false, false, true);
            for (var i = 0; i < nodes.length; i++) {
                if (nodes[i] instanceof qx.ui.core.Widget)
                    nodes[i] = nodes[i].getContentElement().getDomElement();
            }

            return nodes;
        } else {
            return [];
        }
    }
    return null;
};
