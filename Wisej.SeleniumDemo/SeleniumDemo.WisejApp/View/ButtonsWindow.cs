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

        private void productEditor_Click(object sender, EventArgs e)
        {
            using (var productEditorWindow = new ProductEditor())
            {
                productEditorWindow.ShowDialog(this);
            }
        }

        private void supplierEditor_Click(object sender, EventArgs e)
        {
            using (var supplierEditorWindow = new SupplierTreeEditor())
            {
                supplierEditorWindow.ShowDialog(this);
            }
        }

        private void orderEditor_Click(object sender, EventArgs e)
        {
            AlertBox.Show("Order Editor must be implemented", MessageBoxIcon.Error, true,
                ContentAlignment.BottomRight, 0);
            AlertBox.Show("Order Editor should be implemented", MessageBoxIcon.Warning, true,
                ContentAlignment.BottomRight, 0);
            AlertBox.Show("Order Editor will be implemented", MessageBoxIcon.Information, true,
                ContentAlignment.BottomRight, 0);
        }

        private void invoiceEditor_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Button \"invoiceEditor\" is disabled. This shoudn't show.", "Wisej bug",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}