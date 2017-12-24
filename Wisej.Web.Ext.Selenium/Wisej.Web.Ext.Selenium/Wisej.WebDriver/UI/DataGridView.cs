///////////////////////////////////////////////////////////////////////////////
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
///////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using Qooxdoo.WebDriver.UI;
using QX = Qooxdoo.WebDriver;

namespace Wisej.Web.Ext.Selenium.UI
{
    /// <summary>
    /// Represents a <see cref="T:Wisej.Web.DataGridView"/> widget.
    /// </summary>
    /// <remarks>JavaScript class name is wisej.web.DataGrid</remarks>
    public class DataGridView : QX.UI.Table.Table
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataGridView"/> class.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="webDriver">The web driver.</param>
        public DataGridView(IWebElement element, QX.QxWebDriver webDriver) : base(element, webDriver)
        {
        }

        /// <summary>
        /// Gets a list of selected row indices.
        /// </summary>
        /// <value>
        /// The list of selected row indices.
        /// </value>
        public virtual int[] SelectedIndices
        {
            get
            {
                var indices = new List<int>();
                var ranges = SelectedRanges;
                foreach (var range in ranges)
                {
                    var min = range["minIndex"];
                    var max = range["maxIndex"];
                    for (; min <= max; min++)
                        indices.Add(min);
                }

                return indices.ToArray();
            }
        }

        /// <summary>
        /// Starts editing the currently focused cell. Does nothing if already editing
        /// or if the column is not editable
        /// </summary>
        /// <param name="text">The text to initialize the editor with.</param>
        /// <param name="colIdx">The index of the focused cell's column.</param>
        /// <param name="rowIdx">The index of the focused cell's row.</param>
        /// <param name="force">if set to <c>true</c> edit mode must be started at the specified cell.</param>
        /// <returns>Whether editing was started or not</returns>
        public virtual bool StartEditing(string text, int colIdx, int rowIdx, bool force = true)
        {
            string editMode = GetPropertyValue("editMode").ToString();

            switch (editMode)
            {
                case "editProgrammatically":
                    return EditProgrammatically(text, colIdx, rowIdx, force);
                default:
                    FocusCell(colIdx, rowIdx);
                    return StartEditing();
            }
        }

        /// <summary>
        /// Starts editing the currently focused cell. Does nothing if already editing
        /// or if the column is not editable
        /// </summary>
        /// <returns>Whether editing was started or not</returns>
        public virtual bool StartEditing()
        {
            string editMode = GetPropertyValue("editMode").ToString();

            switch (editMode)
            {
                case "editOnEnter":
                    SendKeys(Keys.Enter);
                    return true;
                case "editOnKeystroke":
                    SendKeys(Keys.Enter);
                    return true;
                case "editOnKeystrokeOrF2":
                    SendKeys(Keys.F2);
                    return true;
                case "editOnF2":
                    SendKeys(Keys.F2);
                    return true;
                case "editProgrammatically":
                    throw new ArgumentException(
                        "EditMode is EditProgrammatically. Must provide full set of parameters.");
            }

            return false;
        }

        private bool EditProgrammatically(string text, int? colIdx, int? rowIdx, bool force = true)
        {
            colIdx++;

            var obj = JsExecutor.ExecuteScript(
                "var widget = qx.ui.core.Widget.getWidgetByElement(arguments[0]);" +
                "return widget.startEditing(arguments[1], arguments[2], arguments[3], arguments[4]);",
                ContentElement, text, colIdx, rowIdx, force) as bool?;

            return obj.HasValue && obj.Value;
        }

        /// <summary>
        /// Stops editing and notify te server.
        /// </summary>
        public virtual void StopEditing()
        {
            JsExecutor.ExecuteScript(
                "var widget = qx.ui.core.Widget.getWidgetByElement(arguments[0]);" +
                "widget.stopEditing(true);",
                ContentElement);
        }

        /// <summary>
        /// Gets the cell editor.
        /// </summary>
        /// <value>
        /// The cell editor.
        /// </value>
        public new virtual IWidget CellEditor
        {
            get
            {
                var obj = JsExecutor.ExecuteScript(
                    "var widget = qx.ui.core.Widget.getWidgetByElement(arguments[0]);" +
                    "return widget.getCellEditor();",
                    ContentElement);

                return obj as IWidget;
            }
        }

        /// <summary>
        /// Returns the cell editor for a specified column of the selectd row.
        /// </summary>
        /// <param name="colIdx"> Column index from 0 </param>
        public virtual IWidget GetCellEditor(int colIdx)
        {
            FocusCell(colIdx);
            return CellEditor;
        }

        /// <summary>
        /// Focus the specified cell of the table..
        /// </summary>
        /// <param name="colIdx"> Column index from 0 </param>
        /// <param name="rowIdx"> Row index from 0 </param>
        public virtual void FocusCell(int colIdx, int rowIdx)
        {
            colIdx++;

            JsExecutor.ExecuteScript(
                "var widget = qx.ui.core.Widget.getWidgetByElement(arguments[0]);" +
                "widget.setFocusedCell(arguments[1], arguments[2], arguments[3]);",
                ContentElement, colIdx, rowIdx, true);
        }

        /// <summary>
        /// Sets the value in the specified column of the selectd row.
        /// </summary>
        /// <param name="colIdx"> Column index from 0 </param>
        public virtual void FocusCell(int colIdx)
        {
            colIdx++;

            JsExecutor.ExecuteScript(
                "var widget = qx.ui.core.Widget.getWidgetByElement(arguments[0]);" +
                "widget.setFocusedCell(arguments[1], arguments[2], arguments[3]);",
                ContentElement, colIdx, null, true);
        }

        /// <summary>
        /// Gets the column of currently focused cell.
        /// </summary>
        /// <returns>The index of the focused cell's column</returns>
        public virtual int? GetFocusedColumn()
        {
            return JsExecutor.ExecuteScript(
                "var widget = qx.ui.core.Widget.getWidgetByElement(arguments[0]);" +
                "return widget.getFocusedColumn();",
                ContentElement) as int?;
        }

        /// <summary>
        /// Gets the row of the currently focused cell.
        /// </summary>
        /// <returns>The index of the focused cell's row.</returns>
        public virtual int? GetFocusedRow()
        {
            return JsExecutor.ExecuteScript(
                "var widget = qx.ui.core.Widget.getWidgetByElement(arguments[0]);" +
                "return widget.getFocusedRow();",
                ContentElement) as int?;
        }

        /// <summary>
        /// Returns the value in the specified cell of the table.
        /// </summary>
        /// <param name="colIdx"> Column index from 0 (-1 is the row header) </param>
        /// <param name="rowIdx"> Row index from 0 </param>
        /// <returns> The cell value. </returns>
        public virtual object GetCellValue(int colIdx, int rowIdx)
        {
            colIdx++;

            return JsExecutor.ExecuteScript(
                "var widget = qx.ui.core.Widget.getWidgetByElement(arguments[0]);" +
                "return widget.getCellValue(arguments[1], arguments[2]);",
                ContentElement, colIdx, rowIdx);
        }

        /// <summary>
        /// Sets the value in the specified cell of the table.
        /// </summary>
        /// <param name="colIdx"> Column index from 0 (-1 is the row header) </param>
        /// <param name="rowIdx"> Row index from 0 </param>
        /// <param name="value"> The cell value to set. </param>
        public virtual void SetCellValue(int colIdx, int rowIdx, object value)
        {
            colIdx++;

            JsExecutor.ExecuteScript(
                "var widget = qx.ui.core.Widget.getWidgetByElement(arguments[0]);" +
                "widget.setCellValue(arguments[1], arguments[2], arguments[3]);" +
                "widget.fireEvent('focusin');",
                ContentElement, colIdx, rowIdx, value);
        }

        /// <summary>
        /// Returns the text in the specified cell of the table.
        /// </summary>
        /// <param name="colIdx"> Column index from 0 (-1 is the row header) </param>
        /// <param name="rowIdx"> Row index from 0 </param>
        /// <returns> The cell text. </returns>
        public virtual string GetCellText(int colIdx, int rowIdx)
        {
            return GetCellValue(colIdx, rowIdx).ToString();
        }

        /// <summary>
        /// Sets the text in the specified cell of the table.
        /// </summary>
        /// <param name="colIdx"> Column index from 0 (-1 is the row header) </param>
        /// <param name="rowIdx"> Row index from 0 </param>
        /// <param name="text"> The cell text to set. </param>
        public virtual void SetCellText(int colIdx, int rowIdx, string text)
        {
            SetCellValue(colIdx, rowIdx, text);
        }
    }
}