using System;
using SeleniumDemo.WisejApp.Model;
using Wisej.Web;

namespace SeleniumDemo.WisejApp.View
{
    public partial class ProductTypeEditor : Form
    {
        private readonly ProductType _productType;
        private string _originalProductTypeName;

        public ProductTypeEditor(ProductType productType) : this()
        {
            _productType = productType;
        }

        public ProductTypeEditor(int productTypeId) : this()
        {
            _productType = ProductTypeList.GetProductType(productTypeId);
        }

        private ProductTypeEditor()
        {
            InitializeComponent();
        }

        private void ProductTypeEditor_Load(object sender, EventArgs e)
        {
            _originalProductTypeName = _productType.ProductTypeName;
            productTypeBindingSource.DataSource = _productType;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            _productType.ProductTypeName = _originalProductTypeName;
            _productType.Cancel();
            Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            _productType.Save();
            Close();
        }
    }
}