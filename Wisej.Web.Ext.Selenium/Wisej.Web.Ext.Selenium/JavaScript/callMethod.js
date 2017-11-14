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

qxwebdriver.callMethod = function () {

	var widget = qx.ui.core.Widget.getWidgetByElement(arguments[0]);
	if (widget) {
		var name = arguments[1];
		var args = arguments[2];
		console.log("callMethod: ", name, " args: ", args);

		var func = widget[name];
		if (func == null)
			throw new Error("Unable to find method " + widget.name + "." + name);

		return JSON.stringify(func.apply(widget, args));
	}
	else {
		throw new Error("Unable to find widget " + arguments[0]);
	}
	return null;
};
