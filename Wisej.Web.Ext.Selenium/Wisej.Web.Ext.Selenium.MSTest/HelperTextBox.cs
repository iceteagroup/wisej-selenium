using Wisej.Web.Ext.Selenium.UI;

namespace Wisej.Web.Ext.Selenium.Tests
{
    public static class HelperTextBox
    {
        public static void TextBoxClear(this TextBox textBox)
        {
            textBox.Value = string.Empty;
            ;
        }
    }
}