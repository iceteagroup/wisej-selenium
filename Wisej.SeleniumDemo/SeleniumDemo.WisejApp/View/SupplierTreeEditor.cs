using System;
using SeleniumDemo.WisejApp.Model;
using Wisej.Web;

namespace SeleniumDemo.WisejApp.View
{
    public partial class SupplierTreeEditor : Form
    {
        public SupplierTreeEditor()
        {
            InitializeComponent();
        }

        private void SupplierEditor_Load(object sender, EventArgs e)
        {
            BuildTree();
        }

        private void BuildTree()
        {
            // TODO: To test, delete the next line and un-commnent the following line
#if NEGATE_TO_TEST_THIS_CODE
//#if !NEGATE_TO_TEST_THIS_CODE
            var wait = suppliersTreeView.Nodes.Count > 0;
            suppliersTreeView.Nodes.Clear();
            if (wait)
                System.Threading.Thread.Sleep(100);
#else
            suppliersTreeView.Nodes.Clear();
#endif

            foreach (var supplier in SupplierList.GetRootSuppliers())
            {
                var treeNode = new TreeNode();

                treeNode.Text = supplier.SupplierName;
                treeNode.Name = supplier.SupplierId.ToString();

                BuilChildNodes(treeNode);

                suppliersTreeView.Nodes.Add(treeNode);
            }

            suppliersTreeView.ExpandAll();
        }

        private void BuilChildNodes(TreeNode treeNode)
        {
            int parentSupplierId = Convert.ToInt32(treeNode.Name);

            var childList = SupplierList.GetChildSuppliers(parentSupplierId);

            if (childList.Length == 0)
            {
                treeNode.IsParent = false;
            }
            else
            {
                foreach (var supplier in SupplierList.GetChildSuppliers(parentSupplierId))
                {
                    var childTreeNode = new TreeNode();
                    childTreeNode.Text = supplier.SupplierName;
                    childTreeNode.Name = supplier.SupplierId.ToString();

                    BuilChildNodes(childTreeNode);

                    treeNode.Nodes.Add(childTreeNode);
                }
            }
        }

        private void productTypesTreeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            var localProductTypeId = int.Parse(e.Node.Name);

            using (var supplierEditor = new SupplierEditor(localProductTypeId))
            {
                var result = supplierEditor.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    BuildTree();
                }
            }
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            int? localSupplierId = null;
            Supplier supplier;

            var selectedNode = suppliersTreeView.SelectedNode;
            if (selectedNode != null)
                localSupplierId = int.Parse(selectedNode.Name);

            if (localSupplierId.HasValue)
                supplier = new Supplier {ParentSupplierId = localSupplierId.Value};
            else
                supplier = new Supplier();

            using (var supplierEditor = new SupplierEditor(supplier))
            {
                var result = supplierEditor.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    BuildTree();
                }
            }
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            var selectedNode = suppliersTreeView.SelectedNode;
            if (selectedNode == null)
                return;

            var localSupplierId = int.Parse(selectedNode.Name);
            var supplier = SupplierList.GetSupplier(localSupplierId);
            supplier.Delete();

            suppliersTreeView.SelectedNode = null;

            BuildTree();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int? localSupplierId = null;
            Supplier supplier;

            var selectedNode = suppliersTreeView.SelectedNode;
            if (selectedNode != null)
                localSupplierId = int.Parse(selectedNode.Name);

            if (localSupplierId.HasValue)
                supplier = new Supplier {ParentSupplierId = localSupplierId.Value};
            else
                supplier = new Supplier();

            supplier.SupplierName = "Abc " + supplier.SupplierId;
            supplier.Save();

            BuildTree();
        }

        private void refreshTree_Click(object sender, EventArgs e)
        {
            BuildTree();
        }
    }
}