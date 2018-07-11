using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Qooxdoo.WebDriver.UI;
using Wisej.Web.Ext.Selenium.UI;

namespace Wisej.Web.Ext.Selenium.Tests
{
    /// <summary>
    /// Extension class with helper methods for handling <see cref="DataGridView"/>.
    /// </summary>
    public static class HelperDataGridView
    {
        #region CellEditorGet

        /// <summary>
        /// Returns an <see cref="IWidget" /> matching the specified parameters.
        /// </summary>
        /// <param name="dataGridView">The DataGridView.</param>
        /// <param name="widgetType">The widget type name.</param>
        /// <param name="startEditing">if set to <c>true</c> starts editing the cell.</param>
        /// <param name="timeoutInSeconds">The number of seconds to wait for the widget (default is 5).</param>
        /// <param name="assertIsDisplayed">If set to <c>true</c>, asserts the widget is displayed (default is <c>true</c>).</param>
        /// <returns>
        /// An <see cref="IWidget" /> that matches the specified search parameters.
        /// </returns>
        public static IWidget CellEditorGet(this DataGridView dataGridView, string widgetType, bool startEditing = true,
            int timeoutInSeconds = 5, bool assertIsDisplayed = true)
        {
            return CellEditorGetCore(dataGridView, string.Empty, null, null, widgetType, startEditing, timeoutInSeconds,
                assertIsDisplayed);
        }

        /// <summary>
        /// Returns an <see cref="IWidget" /> matching the specified parameters.
        /// </summary>
        /// <param name="dataGridView">The DataGridView.</param>
        /// <param name="text">The text to initialize the editor with.</param>
        /// <param name="colIdx"> Column index from 0 </param>
        /// <param name="rowIdx"> Row index from 0 </param>
        /// <param name="widgetType">The widget type name.</param>
        /// <param name="timeoutInSeconds">The number of seconds to wait for the widget (default is 5).</param>
        /// <param name="assertIsDisplayed">If set to <c>true</c>, asserts the widget is displayed (default is <c>true</c>).</param>
        /// <returns>
        /// An <see cref="IWidget" /> that matches the specified search parameters.
        /// </returns>
        public static IWidget CellEditorGet(this DataGridView dataGridView, string text, int colIdx, int rowIdx,
            string widgetType, int timeoutInSeconds = 5, bool assertIsDisplayed = true)
        {
            return CellEditorGetCore(dataGridView, text, colIdx, rowIdx, widgetType, true, timeoutInSeconds,
                assertIsDisplayed);
        }

        /// <summary>
        /// Returns a widget of type <typeparamref name="T"/> that matches the specified parameters.
        /// </summary>
        /// <typeparam name="T">The type of the widget to return.</typeparam>
        /// <param name="dataGridView">The DataGridView.</param>
        /// <param name="startEditing">if set to <c>true</c> starts editing the cell.</param>
        /// <param name="timeoutInSeconds">The number of seconds to wait for the widget (default is 5).</param>
        /// <param name="assertIsDisplayed">If set to <c>true</c>, asserts the widget is displayed (default is <c>true</c>).</param>
        /// <returns>A widget of type <typeparamref name="T"/> that matches the specified parameters.</returns>
        public static T CellEditorGet<T>(this DataGridView dataGridView, bool startEditing = true,
            int timeoutInSeconds = 5, bool assertIsDisplayed = true)
        {
            T widget = (T) CellEditorGetCore(dataGridView, string.Empty, null, null, typeof(T).Name, startEditing,
                timeoutInSeconds, assertIsDisplayed);
            return widget;
        }

        /// <summary>
        /// Returns a widget of type <typeparamref name="T"/> that matches the specified parameters.
        /// </summary>
        /// <typeparam name="T">The type of the widget to return.</typeparam>
        /// <param name="dataGridView">The DataGridView.</param>
        /// <param name="text">The text to initialize the editor with.</param>
        /// <param name="colIdx"> Column index from 0 </param>
        /// <param name="rowIdx"> Row index from 0 </param>
        /// <param name="timeoutInSeconds">The number of seconds to wait for the widget (default is 5).</param>
        /// <param name="assertIsDisplayed">If set to <c>true</c>, asserts the widget is displayed (default is <c>true</c>).</param>
        /// <returns>A widget of type <typeparamref name="T"/> that matches the specified parameters.</returns>
        public static T CellEditorGet<T>(this DataGridView dataGridView, string text, int colIdx, int rowIdx,
            int timeoutInSeconds = 5, bool assertIsDisplayed = true)
        {
            T widget = (T) CellEditorGetCore(dataGridView, text, colIdx, rowIdx, typeof(T).Name, true,
                timeoutInSeconds, assertIsDisplayed);
            return widget;
        }

        private static IWidget CellEditorGetCore(this DataGridView dataGridView, string text, int? colIdx, int? rowIdx,
            string widgetType, bool startEditing, int timeoutInSeconds, bool assertIsDisplayed)
        {
            if (startEditing)
            {
                if (colIdx.HasValue && rowIdx.HasValue)
                    dataGridView.StartEditing(text, colIdx.Value, rowIdx.Value);
                else
                    dataGridView.StartEditing();
            }

            IWidget widget = dataGridView.WaitForCellEditor(timeoutInSeconds);
            Assert.IsNotNull(widget, string.Format("{0} not found.", widgetType));
            if (assertIsDisplayed)
                widget.CheckIsDisplayed("");

            return widget;
        }

        #endregion

        #region Row Text check

        /// <summary>
        /// Checks the DataGridView row text matches the specified string IEnumerable.
        /// </summary>
        /// <param name="dataGridView">The <see cref="DataGridView"/> widget.</param>
        /// <param name="values">The string IEnumerable to check.</param>
        /// <param name="rowIdx"> Row index from 0 </param>
        public static void CheckRowTextIs(this DataGridView dataGridView, IEnumerable<string> values, int rowIdx)
        {
            if (values == null)
                throw new ArgumentNullException(nameof(values));

            var colIdx = 0;
            foreach (var value in values)
            {
                CheckRowTextIsCore(dataGridView, value, colIdx, rowIdx);
                colIdx++;
            }
        }

        /// <summary>
        /// Checks the DataGridView row text matches the specified string IEnumerable.
        /// </summary>
        /// <param name="dataGridView">The <see cref="DataGridView"/> widget.</param>
        /// <param name="values">The string IEnumerable to check.</param>
        /// <param name="firstColIdx"> Index from 0 of the first column to check </param>
        /// <param name="rowIdx"> Row index from 0 </param>
        public static void CheckRowTextIs(this DataGridView dataGridView, IEnumerable<string> values, int firstColIdx,
            int rowIdx)
        {
            if (values == null)
                throw new ArgumentNullException(nameof(values));

            var colIdx = firstColIdx;
            foreach (var value in values)
            {
                CheckRowTextIsCore(dataGridView, value, colIdx, rowIdx);
                colIdx++;
            }
        }

        /// <summary>
        /// Checks the DataGridView row text matches the specified string IEnumerable.
        /// </summary>
        /// <param name="dataGridView">The <see cref="DataGridView"/> widget.</param>
        /// <param name="values">The string IEnumerable to check.</param>
        /// <param name="colIndexes"> The int IEnumerable of column indexes to check </param>
        /// <param name="rowIdx"> Row index from 0 </param>
        public static void CheckRowTextIs(this DataGridView dataGridView, IEnumerable<string> values,
            IEnumerable<int> colIndexes, int rowIdx)
        {
            if (values == null)
                throw new ArgumentNullException(nameof(values));
            if (colIndexes == null)
                throw new ArgumentNullException(nameof(colIndexes));

            var enumerable = colIndexes.ToList();
            var idx = 0;
            foreach (var value in values)
            {
                var colIdx = enumerable[idx];
                CheckRowTextIsCore(dataGridView, value, colIdx, rowIdx);
                idx++;
            }
        }

        private static void CheckRowTextIsCore(this DataGridView dataGridView, string value, int colIdx, int rowIdx)
        {
            Assert.AreEqual(value, dataGridView.GetCellText(colIdx, rowIdx));
        }

        #endregion

        #region Cell Text set & check

        /// <summary>
        /// Sets the text of the cell at the given grid coordinates, and waits until it matches..
        /// </summary>
        /// <param name="dataGridView">The parent DataGridView.</param>
        /// <param name="colIdx">Column index from 0</param>
        /// <param name="rowIdx">Row index from 0</param>
        /// <param name="text">The text to match.</param>
        /// <param name="widgetType">The widget type name.</param>
        /// <param name="timeoutInSeconds">The number of seconds to wait for the widget (default is 5).</param>
        public static void CellSetTextCheckResult(this DataGridView dataGridView, int colIdx, int rowIdx, string text,
            string widgetType, int timeoutInSeconds = 5)
        {
            CellSetTextCheckResultCore(dataGridView, colIdx, rowIdx, text, string.Empty, widgetType, timeoutInSeconds);
        }

        /// <summary>
        /// Sets the text of the cell at the given grid coordinates, and waits until it matches the result string.
        /// </summary>
        /// <param name="dataGridView">The parent DataGridView.</param>
        /// <param name="colIdx">Column index from 0</param>
        /// <param name="rowIdx">Row index from 0</param>
        /// <param name="text">The text to match.</param>
        /// <param name="result">The text to match.</param>
        /// <param name="widgetType">The widget type name.</param>
        /// <param name="timeoutInSeconds">The number of seconds to wait for the widget (default is 5).</param>
        public static void CellSetTextCheckResult(this DataGridView dataGridView, int colIdx, int rowIdx, string text,
            string result, string widgetType, int timeoutInSeconds = 5)
        {
            CellSetTextCheckResultCore(dataGridView, colIdx, rowIdx, text, result, widgetType, timeoutInSeconds);
        }

        /// <summary>
        /// Sets the text of the focused cell, and waits until it matches.
        /// </summary>
        /// <param name="dataGridView">The parent DataGridView.</param>
        /// <param name="text">The text to match.</param>
        /// <param name="widgetType">The widget type name.</param>
        /// <param name="timeoutInSeconds">The number of seconds to wait for the widget (default is 5).</param>
        public static void CellSetTextCheckResult(this DataGridView dataGridView, string text, string widgetType,
            int timeoutInSeconds = 5)
        {
            CellSetTextCheckResultCore(dataGridView, null, null, text, string.Empty, widgetType, timeoutInSeconds);
        }

        /// <summary>
        /// Sets the text of the focused cell, and waits until it matches the result string.
        /// </summary>
        /// <param name="dataGridView">The parent DataGridView.</param>
        /// <param name="text">The text to match.</param>
        /// <param name="result">The text to match.</param>
        /// <param name="widgetType">The widget type name.</param>
        /// <param name="timeoutInSeconds">The number of seconds to wait for the widget (default is 5).</param>
        public static void CellSetTextCheckResult(this DataGridView dataGridView, string text, string result,
            string widgetType, int timeoutInSeconds = 5)
        {
            CellSetTextCheckResultCore(dataGridView, null, null, text, result, widgetType, timeoutInSeconds);
        }

        private static void CellSetTextCheckResultCore(this DataGridView dataGridView, int? colIdx, int? rowIdx,
            string text, string result, string widgetType, int timeoutInSeconds)
        {
            IHaveValue cellEditor = null;

            var driver = ((IWidget) dataGridView).Driver as WisejWebDriver;
            if (driver != null)
            {
                if (colIdx.HasValue && rowIdx.HasValue)
                {
                    // wait for focus cell
                    driver.Wait(() =>
                    {
                        dataGridView.FocusCell(colIdx.Value, rowIdx.Value);
                        var focusedRow = dataGridView.GetFocusedRow();
                        var focusedColumn = dataGridView.GetFocusedColumn();

                        return (focusedColumn != colIdx.Value || focusedRow != rowIdx.Value);
                    }, false, timeoutInSeconds);
                }

                // wait for cell editor, start editing
                driver.Wait(() =>
                {
                    // get cell editor, start editing
                    IWidget iWidget = dataGridView.CellEditorGet(widgetType);

                    if (iWidget != null)
                    {
                        cellEditor = iWidget as IHaveValue;
                        if (cellEditor == null)
                            throw new ArgumentException(string.Format(
                                "Widget at column {0}, row {1} ({2}) does not support Value property", colIdx, rowIdx,
                                widgetType));

                        return true;
                    }

                    return false;
                }, false, timeoutInSeconds);

                if (cellEditor != null)
                {
                    // set value and check value on the cell editor
                    driver.Wait(() =>
                    {
                        cellEditor.Value = text;
                        return Equals(text, cellEditor.Text);
                    }, false, timeoutInSeconds);

                    // stop editing
                    dataGridView.StopEditing();
                }

                if (!string.IsNullOrEmpty(result))
                    Assert.AreEqual(result, dataGridView.WaitForCellText(result, timeoutInSeconds));
                else
                    Assert.AreEqual(text, dataGridView.WaitForCellText(text, timeoutInSeconds));
            }
        }

        #endregion
    }
}