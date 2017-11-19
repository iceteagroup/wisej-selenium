using System;
using System.Drawing;
using Wisej.Web;

namespace SeleniumDemo.WisejApp.View
{
    public partial class ButtonsWindow : Form
    {
        public ButtonsWindow()
        {
            InitializeComponent();
        }

        private void customerEditor_Click(object sender, EventArgs e)
        {
            using (var customerEditorWindow = new CustomerEditor())
            {
                customerEditorWindow.ShowDialog(this);
            }
        }

        private void supplierEditor_Click(object sender, EventArgs e)
        {
            AlertBox.Show("Supplier Editor must be implemented", MessageBoxIcon.Error, true,
                ContentAlignment.BottomRight, 0);
            AlertBox.Show("Supplier Editor should be implemented", MessageBoxIcon.Warning, true,
                ContentAlignment.BottomRight, 0);
            AlertBox.Show("Supplier Editor will be implemented", MessageBoxIcon.Information, true,
                ContentAlignment.BottomRight, 0);
        }

        private void productEditor_Click(object sender, EventArgs e)
        {
            using (var productEditorWindow = new ProductEditor())
            {
                productEditorWindow.ShowDialog(this);
            }
        }
    }
}