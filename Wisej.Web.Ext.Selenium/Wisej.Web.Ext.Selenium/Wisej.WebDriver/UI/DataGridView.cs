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
using OpenQA.Selenium.Support.UI;
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
        /// Starts editing the specified cell, using the specified initial text. Does nothing if already editing
        /// or if the column is not editable.
        /// </summary>
        /// <param name="text">The text to initialize the editor with.</param>
        /// <param name="colIdx">The index of the focused cell's column.</param>
        /// <param name="rowIdx">The index of the focused cell's row.</param>
        public virtual void StartEditing(string text, int colIdx, int rowIdx)
        {
            Call("startEditing", text, colIdx + 1, rowIdx); // TODO: this doesn't work.
        }

        /// <summary>
        /// Starts editing the currently focused cell. Does nothing if already editing
        /// or if the column is not editable.
        /// </summary>
        public virtual void StartEditing()
        {
            Call("startEditing");
        }

        /// <summary>
        /// Stops editing the cell.
        /// </summary>
        public virtual void StopEditing()
        {
            Call("stopEditing", true);
        }

        /// <summary>
        /// Gets the cell editor.
        /// </summary>
        /// <value>
        /// The cell editor.
        /// </value>
        public new virtual IWidget CellEditor
        {
            get { return (IWidget) Call("getCellEditor"); }
        }

        /// <summary>
        /// Focus the specified cell.
        /// </summary>
        /// <param name="colIdx"> Column index from 0 </param>
        /// <param name="rowIdx"> Row index from 0 </param>
        public virtual void FocusCell(int colIdx, int rowIdx)
        {
            Call("setFocusedCell", colIdx + 1, rowIdx, true);
        }

        /// <summary>
        /// Gets the column of currently focused cell.
        /// </summary>
        /// <returns>The index of the focused cell's column</returns>
        public virtual int GetFocusedColumn()
        {
            var value = (long?) Call("getFocusedColumn");
            var colIdx = (int) (value ?? 0);
            return colIdx - 1;
        }

        /// <summary>
        /// Gets the row of the currently focused cell.
        /// </summary>
        /// <returns>The index of the focused cell's row.</returns>
        public virtual int GetFocusedRow()
        {
            var value = (long?) Call("getFocusedRow");
            var rowIdx = (int) (value ?? -1);
            return rowIdx;
        }

        /// <summary>
        /// Returns the value in the specified cell.
        /// </summary>
        /// <param name="colIdx"> Column index from 0 (-1 is the row header) </param>
        /// <param name="rowIdx"> Row index from 0 </param>
        /// <returns> The cell value. </returns>
        public virtual object GetCellValue(int colIdx, int rowIdx)
        {
            return Call("getCellValue", colIdx + 1, rowIdx);
        }

        /// <summary>
        /// Returns the value in the focused cell.
        /// </summary>
        /// <returns> The cell value. </returns>
        public virtual object GetCellValue()
        {
            var rowIdx = GetFocusedRow();
            var colIdx = GetFocusedColumn();
            return GetCellValue(colIdx, rowIdx);
        }

        /// <summary>
        /// Returns the text in the specified cell.
        /// </summary>
        /// <param name="colIdx"> Column index from 0 (-1 is the row header) </param>
        /// <param name="rowIdx"> Row index from 0 </param>
        /// <returns> The cell text. </returns>
        public virtual string GetCellText(int colIdx, int rowIdx)
        {
            return GetCellValue(colIdx, rowIdx).ToString();
        }

        /// <summary>
        /// Returns the text in the focused cell.
        /// </summary>
        /// <returns> The cell text. </returns>
        public virtual string GetCellText()
        {
            return GetCellValue().ToString();
        }

        /// <summary>
        /// Returns the value in the specified cell.
        /// </summary>
        /// <param name="rowIdx"> Row index from 0 </param>
        /// <returns> The cell value. </returns>
        public virtual object DeleteRow(int rowIdx)
        {
            return Call("deleteRow", rowIdx);
        }

        #region Waiters

        /// <summary>
        /// Repeatedly checks the cell text at the specified position.
        /// </summary>
        /// <param name="colIdx">Column index from 0</param>
        /// <param name="rowIdx">Row index from 0</param>
        /// <param name="expectedText">The expected text.</param>
        /// <param name="timeoutInSeconds">The number of seconds to wait for the cell text.</param>
        /// <returns>The actual cell text.</returns>
        public string WaitForCellText(int colIdx, int rowIdx, string expectedText, int timeoutInSeconds = 5)
        {
            Driver.Wait(() => Equals(expectedText, GetCellText(colIdx, rowIdx)), false, timeoutInSeconds);

            return GetCellText(colIdx, rowIdx);
        }

        /// <summary>
        /// Repeatedly checks the cell text at the focused cell.
        /// </summary>
        /// <param name="expectedText">The expected text.</param>
        /// <param name="timeoutInSeconds">The number of seconds to wait for the cell text.</param>
        /// <returns>The actual cell text.</returns>
        public string WaitForCellText(string expectedText, int timeoutInSeconds = 5)
        {
            Driver.Wait(() => Equals(expectedText, GetCellText()), false, timeoutInSeconds);

            return GetCellText();
        }

        /// <summary>
        /// Repeatedly checks for a CellEditor to be displayed.
        /// Returns the CellEditor if successful.
        /// </summary>
        /// <param name="timeoutInSeconds">The number of seconds to wait for the CellEditor.</param>
        /// <returns>The cell editor.</returns>
        public IWidget WaitForCellEditor(int timeoutInSeconds = 5)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeoutInSeconds));
            return wait.Until(CellEditorIsDisplayed());
        }

        /// <summary>
        /// A condition that waits until a CellEditor is displayed, then returns it.
        /// </summary>
        /// <returns>The displayed cell editor.</returns>
        private Func<IWebDriver, IWidget> CellEditorIsDisplayed()
        {
            return driver =>
            {
                var cellEditor = this.CellEditor;
                if (cellEditor != null && cellEditor.Displayed)
                {
                    return cellEditor;
                }

                return null;
            };
        }

        #endregion
    }
}