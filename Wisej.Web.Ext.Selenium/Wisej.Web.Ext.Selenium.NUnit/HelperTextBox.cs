using Wisej.Web.Ext.Selenium.UI;

namespace Wisej.Web.Ext.Selenium.Tests
{
    /// <summary>
    /// Extension class with helper methods for handling <see cref="TextBox"/>.
    /// </summary>
    public static class HelperTextBox
    {
        /// <summary>
        /// Clear the <see cref="TextBox"/> contents.
        /// </summary>
        /// <param name="textBox">The TextBox.</param>
        public static void TextBoxClear(this TextBox textBox)
        {
            textBox.Value = string.Empty;
        }
    }
}