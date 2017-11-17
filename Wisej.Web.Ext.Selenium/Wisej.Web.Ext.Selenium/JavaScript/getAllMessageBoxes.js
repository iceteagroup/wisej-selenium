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

qxwebdriver.getAllMessageBoxes = function () {

	var ret = [];
	var root = qx.core.Init.getApplication().getRoot();
	var windows = root.getWindows();
	var children = root.getChildren();
	if (children && children.length > 0) {
		for (var i = 0; i < children.length; i++) {
			if (children[i] instanceof wisej.web.Desktop) {
				windows = children[i].getWindows();
				break;
			}
		}
	}
	if (windows && windows.length > 0)
	{
		for (var i = 0; i < windows.length; i++) {
			if (windows[i] instanceof wisej.web.MessageBox)
				ret.push(windows[i].getContentElement().getDomElement());
		}

	}
	return ret;
};
