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
            this.components = new System.ComponentModel.Container();
            this.tabControl = new Wisej.Web.TabControl();
            this.brands = new Wisej.Web.TabPage();
            this.brandsListBox = new Wisej.Web.ListBox();
            this.brandsBindingSource = new Wisej.Web.BindingSource(this.components);
            this.productTypes = new Wisej.Web.TabPage();
            this.productTypesTreeView = new Wisej.Web.TreeView();
            this.models = new Wisej.Web.TabPage();
            this.modelsDataGridView = new Wisej.Web.DataGridView();
            this.modelId = new Wisej.Web.DataGridViewTextBoxColumn();
            this.modelName = new Wisej.Web.DataGridViewTextBoxColumn();
            this.brandId = new Wisej.Web.DataGridViewComboBoxColumn();
            this.productTypeId = new Wisej.Web.DataGridViewComboBoxColumn();
            this.productTypesBindingSource = new Wisej.Web.BindingSource(this.components);
            this.modelsBindingSource = new Wisej.Web.BindingSource(this.components);
            this.newButton = new Wisej.Web.Button();
            this.removeButton = new Wisej.Web.Button();
            this.tabControl.SuspendLayout();
            this.brands.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.brandsBindingSource)).BeginInit();
            this.productTypes.SuspendLayout();
            this.models.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.modelsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productTypesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.modelsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((Wisej.Web.AnchorStyles)((((Wisej.Web.AnchorStyles.Top | Wisej.Web.AnchorStyles.Bottom) 
            | Wisej.Web.AnchorStyles.Left) 
            | Wisej.Web.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.brands);
            this.tabControl.Controls.Add(this.productTypes);
            this.tabControl.Controls.Add(this.models);
            this.tabControl.Location = new System.Drawing.Point(20, 20);
            this.tabControl.Name = "tabControl";
            this.tabControl.PageInsets = new Wisej.Web.Padding(1, 35, 1, 1);
            this.tabControl.Size = new System.Drawing.Size(572, 389);
            this.tabControl.TabIndex = 0;
            // 
            // brands
            // 
            this.brands.Controls.Add(this.brandsListBox);
            this.brands.Location = new System.Drawing.Point(1, 35);
            this.brands.Name = "brands";
            this.brands.Text = "Brands";
            // 
            // brandsListBox
            // 
            this.brandsListBox.DataSource = this.brandsBindingSource;
            this.brandsListBox.DisplayMember = "BrandName";
            this.brandsListBox.Dock = Wisej.Web.DockStyle.Fill;
            this.brandsListBox.Location = new System.Drawing.Point(0, 0);
            this.brandsListBox.Name = "brandsListBox";
            this.brandsListBox.Size = new System.Drawing.Size(570, 353);
            this.brandsListBox.TabIndex = 0;
            this.brandsListBox.ValueMember = "BrandId";
            this.brandsListBox.DoubleClick += new System.EventHandler(this.brandsListBox_DoubleClick);
            // 
            // brandsBindingSource
            // 
            this.brandsBindingSource.AllowNew = true;
            this.brandsBindingSource.DataSource = typeof(SeleniumDemo.WisejApp.Model.BrandList);
            this.brandsBindingSource.RefreshValueOnChange = true;
            // 
            // productTypes
            // 
            this.productTypes.Controls.Add(this.productTypesTreeView);
            this.productTypes.Location = new System.Drawing.Point(1, 35);
            this.productTypes.Name = "productTypes";
            this.productTypes.Text = "Product Types";
            // 
            // productTypesTreeView
            // 
            this.productTypesTreeView.Dock = Wisej.Web.DockStyle.Fill;
            this.productTypesTreeView.Location = new System.Drawing.Point(0, 0);
            this.productTypesTreeView.Name = "productTypesTreeView";
            this.productTypesTreeView.Size = new System.Drawing.Size(570, 353);
            this.productTypesTreeView.TabIndex = 0;
            this.productTypesTreeView.NodeMouseDoubleClick += new Wisej.Web.TreeNodeMouseClickEventHandler(this.productTypesTreeView_NodeMouseDoubleClick);
            // 
            // models
            // 
            this.models.Controls.Add(this.modelsDataGridView);
            this.models.Location = new System.Drawing.Point(1, 35);
            this.models.Name = "models";
            this.models.Text = "Models";
            this.models.Enter += new System.EventHandler(this.models_Enter);
            this.models.Leave += new System.EventHandler(this.models_Leave);
            // 
            // modelsDataGridView
            // 
            this.modelsDataGridView.AllowUserToAddRows = true;
            this.modelsDataGridView.AllowUserToDeleteRows = true;
            this.modelsDataGridView.AllowUserToResizeRows = false;
            this.modelsDataGridView.AutoGenerateColumns = false;
            this.modelsDataGridView.AutoSizeColumnsMode = Wisej.Web.DataGridViewAutoSizeColumnsMode.Fill;
            this.modelsDataGridView.Columns.AddRange(new Wisej.Web.DataGridViewColumn[] {
            this.modelId,
            this.modelName,
            this.brandId,
            this.productTypeId});
            this.modelsDataGridView.DataSource = this.modelsBindingSource;
            this.modelsDataGridView.Dock = Wisej.Web.DockStyle.Fill;
            this.modelsDataGridView.KeepSameRowHeight = true;
            this.modelsDataGridView.Location = new System.Drawing.Point(0, 0);
            this.modelsDataGridView.MultiSelect = false;
            this.modelsDataGridView.Name = "modelsDataGridView";
            this.modelsDataGridView.RowHeadersWidthSizeMode = Wisej.Web.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.modelsDataGridView.ShowColumnVisibilityMenu = false;
            this.modelsDataGridView.Size = new System.Drawing.Size(570, 353);
            this.modelsDataGridView.TabIndex = 0;
            // 
            // modelId
            // 
            this.modelId.DataPropertyName = "ModelId";
            this.modelId.FillWeight = 40F;
            this.modelId.HeaderText = "Id";
            this.modelId.Name = "modelId";
            this.modelId.ReadOnly = true;
            this.modelId.Width = 40;
            // 
            // modelName
            // 
            this.modelName.DataPropertyName = "ModelName";
            this.modelName.FillWeight = 200F;
            this.modelName.HeaderText = "Name";
            this.modelName.MinimumWidth = 80;
            this.modelName.Name = "modelName";
            this.modelName.Width = 200;
            // 
            // brandId
            // 
            this.brandId.DataPropertyName = "BrandId";
            this.brandId.DataSource = this.brandsBindingSource;
            this.brandId.DisplayMember = "BrandName";
            this.brandId.HeaderText = "Brand";
            this.brandId.MinimumWidth = 40;
            this.brandId.Name = "brandId";
            this.brandId.ValueMember = "BrandId";
            // 
            // productTypeId
            // 
            this.productTypeId.DataPropertyName = "ProductTypeId";
            this.productTypeId.DataSource = this.productTypesBindingSource;
            this.productTypeId.DisplayMember = "ProductTypeName";
            this.productTypeId.FillWeight = 200F;
            this.productTypeId.HeaderText = "Product Type";
            this.productTypeId.MinimumWidth = 80;
            this.productTypeId.Name = "productTypeId";
            this.productTypeId.ValueMember = "ProductTypeId";
            this.productTypeId.Width = 200;
            // 
            // productTypesBindingSource
            // 
            this.productTypesBindingSource.AllowNew = true;
            this.productTypesBindingSource.DataSource = typeof(SeleniumDemo.WisejApp.Model.ProductTypeList);
            this.productTypesBindingSource.RefreshValueOnChange = true;
            // 
            // modelsBindingSource
            // 
            this.modelsBindingSource.AllowNew = true;
            this.modelsBindingSource.DataSource = typeof(SeleniumDemo.WisejApp.Model.ModelList);
            this.modelsBindingSource.RefreshValueOnChange = true;
            // 
            // newButton
            // 
            this.newButton.Anchor = ((Wisej.Web.AnchorStyles)((Wisej.Web.AnchorStyles.Top | Wisej.Web.AnchorStyles.Right)));
            this.newButton.Location = new System.Drawing.Point(101, 434);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(80, 26);
            this.newButton.TabIndex = 13;
            this.newButton.Text = "New";
            this.newButton.Click += new System.EventHandler(this.newButton_Click);
            // 
            // removeButton
            // 
            this.removeButton.Anchor = ((Wisej.Web.AnchorStyles)((Wisej.Web.AnchorStyles.Top | Wisej.Web.AnchorStyles.Right)));
            this.removeButton.Location = new System.Drawing.Point(431, 434);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(80, 26);
            this.removeButton.TabIndex = 14;
            this.removeButton.Text = "Remove";
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
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
            this.Load += new System.EventHandler(this.ProductEditor_Load);
            this.tabControl.ResumeLayout(false);
            this.brands.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.brandsBindingSource)).EndInit();
            this.productTypes.ResumeLayout(false);
            this.models.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.modelsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productTypesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.modelsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Wisej.Web.TabControl tabControl;
        private Wisej.Web.TabPage brands;
        private Wisej.Web.TabPage productTypes;
        private Wisej.Web.TabPage models;
        private Wisej.Web.ListBox brandsListBox;
        private Wisej.Web.TreeView productTypesTreeView;
        private Wisej.Web.DataGridView modelsDataGridView;
        private Wisej.Web.Button newButton;
        private Wisej.Web.Button removeButton;
        private Wisej.Web.BindingSource brandsBindingSource;
        private Wisej.Web.DataGridViewTextBoxColumn modelId;
        private Wisej.Web.DataGridViewTextBoxColumn modelName;
        private Wisej.Web.DataGridViewComboBoxColumn brandId;
        private Wisej.Web.DataGridViewComboBoxColumn productTypeId;
        private Wisej.Web.BindingSource modelsBindingSource;
        private Wisej.Web.BindingSource productTypesBindingSource;
    }
}