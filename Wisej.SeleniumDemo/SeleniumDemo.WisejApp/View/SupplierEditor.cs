using System;
using SeleniumDemo.WisejApp.Model;
using Wisej.Web;

namespace SeleniumDemo.WisejApp.View
{
    public partial class SupplierEditor : Form
    {
        private readonly Supplier _supplier;
        private string _originalSupplierName;

        public SupplierEditor(Supplier supplier) : this()
        {
            _supplier = supplier;
        }

        public SupplierEditor(int supplierId) : this()
        {
            _supplier = SupplierList.GetSupplier(supplierId);
        }

        private SupplierEditor()
        {
            InitializeComponent();
        }

        private void SupplierEditor_Load(object sender, EventArgs e)
        {
            suplierListBindingSource.DataSource = SupplierList.GetSupplierList();
            _originalSupplierName = _supplier.SupplierName;
            supplierBindingSource.DataSource = _supplier;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            _supplier.SupplierName = _originalSupplierName;
            _supplier.Cancel();
            Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            _supplier.Save();
            Close();
        }

        private void parentComboBox_ToolClick(object sender, ToolClickEventArgs e)
        {
            parentComboBox.SelectedIndex = -1;
        }
    }
}