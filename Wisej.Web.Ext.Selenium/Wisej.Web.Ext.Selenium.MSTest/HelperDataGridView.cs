using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Qooxdoo.WebDriver.UI;
using Wisej.Web.Ext.Selenium.UI;

namespace Wisej.Web.Ext.Selenium.Tests
{
    /// <summary>
    /// Extension class with helper methods for handling <see cref="DataGridView"/>.
    /// </summary>
    public static class HelperDataGridView
    {
        #region RowText

        /// <summary>
        /// Asserts the DataGridView row text matches the specified string IEnumerable.
        /// </summary>
        /// <param name="dataGridView">The <see cref="DataGridView"/> widget.</param>
        /// <param name="values">The string IEnumerable to check.</param>
        /// <param name="rowIdx"> Row index from 0 </param>
        public static void AssertRowTextIs(this DataGridView dataGridView, IEnumerable<string> values, int rowIdx)
        {
            var colIdx = 0;
            foreach (var value in values)
            {
                AssertRowTextIsCore(dataGridView, value, colIdx, rowIdx);
                colIdx++;
            }
        }

        /// <summary>
        /// Asserts the DataGridView row text matches the specified string IEnumerable.
        /// </summary>
        /// <param name="dataGridView">The <see cref="DataGridView"/> widget.</param>
        /// <param name="values">The string IEnumerable to check.</param>
        /// <param name="firstColIdx"> Index from 0 of the first column to check </param>
        /// <param name="rowIdx"> Row index from 0 </param>
        public static void AssertRowTextIs(this DataGridView dataGridView, IEnumerable<string> values, int firstColIdx,
            int rowIdx)
        {
            var colIdx = firstColIdx;
            foreach (var value in values)
            {
                AssertRowTextIsCore(dataGridView, value, colIdx, rowIdx);
                colIdx++;
            }
        }

        /// <summary>
        /// Asserts the DataGridView row text matches the specified string IEnumerable.
        /// </summary>
        /// <param name="dataGridView">The <see cref="DataGridView"/> widget.</param>
        /// <param name="values">The string IEnumerable to check.</param>
        /// <param name="colIndexes"> The int IEnumerable of column indexes to check </param>
        /// <param name="rowIdx"> Row index from 0 </param>
        public static void AssertRowTextIs(this DataGridView dataGridView, IEnumerable<string> values,
            IEnumerable<int> colIndexes, int rowIdx)
        {
            var enumerable = colIndexes.ToList();
            var idx = 0;
            foreach (var value in values)
            {
                var colIdx = enumerable[idx];
                AssertRowTextIsCore(dataGridView, value, colIdx, rowIdx);
                idx++;
            }
        }

        private static void AssertRowTextIsCore(this DataGridView dataGridView, string value, int colIdx, int rowIdx)
        {
            Assert.AreEqual(value, dataGridView.GetCellText(colIdx, rowIdx));
        }

        #endregion

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
            long timeoutInSeconds = 5, bool assertIsDisplayed = true)
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
            string widgetType, long timeoutInSeconds = 5, bool assertIsDisplayed = true)
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
            long timeoutInSeconds = 5, bool assertIsDisplayed = true)
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
            long timeoutInSeconds = 5, bool assertIsDisplayed = true)
        {
            T widget = (T) CellEditorGetCore(dataGridView, text, colIdx, rowIdx, typeof(T).Name, true,
                timeoutInSeconds, assertIsDisplayed);
            return widget;
        }

        private static IWidget CellEditorGetCore(this DataGridView dataGridView, string text, int? colIdx, int? rowIdx,
            string widgetType, bool startEditing, long timeoutInSeconds, bool assertIsDisplayed)
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
                widget.AssertIsDisplayed("");
            return widget;
        }

        #endregion
    }
}