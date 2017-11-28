using System;
using SeleniumDemo.WisejApp.Model;
using Wisej.Web;

namespace SeleniumDemo.WisejApp.View
{
    public partial class BrandEditor : Form
    {
        private readonly Brand _brand;
        private string _originalBrandName;

        public BrandEditor(Brand brand) : this()
        {
            _brand = brand;
        }

        public BrandEditor(int brandId) : this()
        {
            _brand = BrandList.GetBrand(brandId);
        }

        private BrandEditor()
        {
            InitializeComponent();
        }

        private void BrandEditor_Load(object sender, EventArgs e)
        {
            _originalBrandName = _brand.BrandName;
            brandBindingSource.DataSource = _brand;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            _brand.BrandName = _originalBrandName;
            _brand.Cancel();
            Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            _brand.Save();
            Close();
        }
    }
}