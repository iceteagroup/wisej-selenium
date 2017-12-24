using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Wisej.Web.Ext.Selenium.UI;

namespace Wisej.Web.Ext.Selenium.Tests
{
    /// <summary>
    /// Extension class with helper methods for handling <see cref="DataGridView"/>.
    /// </summary>
    public static class HelperDataGridView
    {
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
    }
}