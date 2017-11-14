namespace SeleniumDemo.WisejApp.View
{
    partial class ProductEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Wisej Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Wisej.Web.TreeNode treeNode1 = new Wisej.Web.TreeNode();
            Wisej.Web.TreeNode treeNode2 = new Wisej.Web.TreeNode();
            Wisej.Web.TreeNode treeNode3 = new Wisej.Web.TreeNode();
            Wisej.Web.TreeNode treeNode4 = new Wisej.Web.TreeNode();
            Wisej.Web.TreeNode treeNode5 = new Wisej.Web.TreeNode();
            Wisej.Web.TreeNode treeNode6 = new Wisej.Web.TreeNode();
            Wisej.Web.TreeNode treeNode7 = new Wisej.Web.TreeNode();
            Wisej.Web.TreeNode treeNode8 = new Wisej.Web.TreeNode();
            this.tabControl = new Wisej.Web.TabControl();
            this.brands = new Wisej.Web.TabPage();
            this.models = new Wisej.Web.TabPage();
            this.brandsList = new Wisej.Web.ListBox();
            this.modelsTree = new Wisej.Web.TreeView();
            this.newButton = new Wisej.Web.Button();
            this.removeButton = new Wisej.Web.Button();
            this.tabControl.SuspendLayout();
            this.brands.SuspendLayout();
            this.models.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((Wisej.Web.AnchorStyles)((((Wisej.Web.AnchorStyles.Top | Wisej.Web.AnchorStyles.Bottom) 
            | Wisej.Web.AnchorStyles.Left) 
            | Wisej.Web.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.brands);
            this.tabControl.Controls.Add(this.models);
            this.tabControl.Location = new System.Drawing.Point(20, 20);
            this.tabControl.Name = "tabControl";
            this.tabControl.PageInsets = new Wisej.Web.Padding(1, 35, 1, 1);
            this.tabControl.Size = new System.Drawing.Size(572, 389);
            this.tabControl.TabIndex = 0;
            // 
            // brands
            // 
            this.brands.Controls.Add(this.brandsList);
            this.brands.Location = new System.Drawing.Point(1, 35);
            this.brands.Name = "brands";
            this.brands.Text = "Brands";
            // 
            // models
            // 
            this.models.Controls.Add(this.modelsTree);
            this.models.Location = new System.Drawing.Point(1, 35);
            this.models.Name = "models";
            this.models.Text = "Models";
            // 
            // brandsList
            // 
            this.brandsList.Dock = Wisej.Web.DockStyle.Fill;
            this.brandsList.Items.AddRange(new object[] {
            "Candy",
            "Electrolux",
            "Hoover",
            "Kunft",
            "LG",
            "Philips",
            "Samsung",
            "Siemens",
            "Whirlpool"});
            this.brandsList.Location = new System.Drawing.Point(0, 0);
            this.brandsList.Name = "brandsList";
            this.brandsList.Size = new System.Drawing.Size(570, 353);
            this.brandsList.TabIndex = 0;
            // 
            // modelsTree
            // 
            this.modelsTree.Dock = Wisej.Web.DockStyle.Fill;
            this.modelsTree.Location = new System.Drawing.Point(0, 0);
            this.modelsTree.Name = "modelsTree";
            treeNode1.Name = "DishWasher";
            treeNode1.Text = "Dish Washer";
            treeNode2.Name = "Dryer";
            treeNode2.Text = "Dryer";
            treeNode3.Name = "Radio";
            treeNode3.Text = "Radio";
            treeNode4.Name = "Refrigerator";
            treeNode4.Text = "Refrigerator";
            treeNode5.Name = "VacuumCleaner";
            treeNode5.Text = "Vacuum Cleaner";
            treeNode6.Name = "WashersDryer";
            treeNode6.Text = "Washers/Dryer";
            treeNode7.Name = "Washer";
            treeNode7.Text = "Washer";
            treeNode8.Name = "Tv";
            treeNode8.Text = "TV";
            this.modelsTree.Nodes.AddRange(new Wisej.Web.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6,
            treeNode7,
            treeNode8});
            this.modelsTree.Size = new System.Drawing.Size(570, 353);
            this.modelsTree.TabIndex = 0;
            // 
            // newButton
            // 
            this.newButton.Anchor = ((Wisej.Web.AnchorStyles)((Wisej.Web.AnchorStyles.Top | Wisej.Web.AnchorStyles.Right)));
            this.newButton.Location = new System.Drawing.Point(101, 434);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(80, 26);
            this.newButton.TabIndex = 13;
            this.newButton.Text = "New";
            // 
            // removeButton
            // 
            this.removeButton.Anchor = ((Wisej.Web.AnchorStyles)((Wisej.Web.AnchorStyles.Top | Wisej.Web.AnchorStyles.Right)));
            this.removeButton.Location = new System.Drawing.Point(431, 434);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(80, 26);
            this.removeButton.TabIndex = 14;
            this.removeButton.Text = "Remove";
            // 
            // ProductEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = Wisej.Web.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 480);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.newButton);
            this.Controls.Add(this.tabControl);
            this.Name = "ProductEditor";
            this.Text = "Product Editor";
            this.tabControl.ResumeLayout(false);
            this.brands.ResumeLayout(false);
            this.models.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Wisej.Web.TabControl tabControl;
        private Wisej.Web.TabPage brands;
        private Wisej.Web.TabPage models;
        private Wisej.Web.ListBox brandsList;
        private Wisej.Web.TreeView modelsTree;
        private Wisej.Web.Button newButton;
        private Wisej.Web.Button removeButton;
    }
}