using System;
using SeleniumDemo.WisejApp.Model;
using Wisej.Web;

namespace SeleniumDemo.WisejApp.View
{
    public partial class ProductEditor : Form
    {
        private ProductType _productType;
        private Brand _brand;

        public ProductEditor()
        {
            InitializeComponent();
        }

        private void ProductEditor_Load(object sender, EventArgs e)
        {
            brandsBindingSource.DataSource = BrandList.GetBrandList();
            productTypesBindingSource.DataSource = ProductTypeList.GetProductTypeList();
            BindProductType();
            modelsBindingSource.DataSource = ModelList.GetModelList();
        }

        private void BindProductType()
        {
            productTypesTreeView.Nodes.Clear();
            foreach (var productType in ProductTypeList.GetProductTypeList())
            {
                var treeNode = new TreeNode();

                treeNode.Text = productType.ProductTypeName;
                treeNode.Name = productType.ProductTypeId.ToString();
                productTypesTreeView.Nodes.Add(treeNode);
            }
        }

        private void brandsListBox_DoubleClick(object sender, EventArgs e)
        {
            var locaBrandId = ((Brand) brandsBindingSource.Current).BrandId;

            using (var brandEditor = new BrandEditor(locaBrandId))
            {
                brandEditor.ShowDialog(this);
            }
        }

        private void productTypesTreeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            var localProductTypeId = int.Parse(e.Node.Name);

            using (var productTypeEditor = new ProductTypeEditor(localProductTypeId))
            {
                productTypeEditor.ShowDialog(this);
            }
        }

        private void models_Enter(object sender, EventArgs e)
        {
            newButton.Enabled = false;
            removeButton.Enabled = false;
        }

        private void models_Leave(object sender, EventArgs e)
        {
            newButton.Enabled = true;
            removeButton.Enabled = true;
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab.Name == "brands")
            {
                _brand = new Brand();
                using (var brandEditor = new BrandEditor(_brand))
                {
                    brandEditor.ShowDialog(this);
                }
                _brand = null;
            }
            else if (tabControl.SelectedTab.Name == "productTypes")
            {
                _productType = new ProductType();
                using (var productTypeEditor = new ProductTypeEditor(_productType))
                {
                    productTypeEditor.ShowDialog(this);
                    BindProductType();
                }
                _productType = null;
            }
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab.Name == "brands")
            {
                ((Brand) brandsBindingSource.Current).Delete();
            }
            else if (tabControl.SelectedTab.Name == "productTypes")
            {
                var selectedNode = productTypesTreeView.SelectedNode;

                var localProductTypeId = int.Parse(selectedNode.Name);
                var productType = ProductTypeList.GetProductType(localProductTypeId);
                productType.Delete();

                BindProductType();
            }
        }
    }
}