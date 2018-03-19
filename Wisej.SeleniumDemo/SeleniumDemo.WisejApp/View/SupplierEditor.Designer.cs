namespace SeleniumDemo.WisejApp.View
{
    partial class SupplierEditor
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
            Wisej.Web.ComponentTool componentTool1 = new Wisej.Web.ComponentTool();
            this.supplierBindingSource = new Wisej.Web.BindingSource(this.components);
            this.supplierIdTextBox = new Wisej.Web.TextBox();
            this.supplierNameTextBox = new Wisej.Web.TextBox();
            this.cancelButton = new Wisej.Web.Button();
            this.saveButton = new Wisej.Web.Button();
            this.parentComboBox = new Wisej.Web.ComboBox();
            this.suplierListBindingSource = new Wisej.Web.BindingSource(this.components);
            this.parentLabel = new Wisej.Web.Label();
            this.idLabel = new Wisej.Web.Label();
            this.nameLabel = new Wisej.Web.Label();
            ((System.ComponentModel.ISupportInitialize)(this.supplierBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.suplierListBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // supplierBindingSource
            // 
            this.supplierBindingSource.AllowNew = false;
            this.supplierBindingSource.DataSource = typeof(SeleniumDemo.WisejApp.Model.Supplier);
            this.supplierBindingSource.RefreshValueOnChange = true;
            // 
            // supplierIdTextBox
            // 
            this.supplierIdTextBox.DataBindings.Add(new Wisej.Web.Binding("Text", this.supplierBindingSource, "SupplierId", true));
            this.supplierIdTextBox.Location = new System.Drawing.Point(103, 15);
            this.supplierIdTextBox.Name = "supplierIdTextBox";
            this.supplierIdTextBox.Size = new System.Drawing.Size(100, 22);
            this.supplierIdTextBox.TabIndex = 1;
            this.supplierIdTextBox.Text = "0";
            // 
            // supplierNameTextBox
            // 
            this.supplierNameTextBox.DataBindings.Add(new Wisej.Web.Binding("Text", this.supplierBindingSource, "SupplierName", true));
            this.supplierNameTextBox.Location = new System.Drawing.Point(103, 65);
            this.supplierNameTextBox.Name = "supplierNameTextBox";
            this.supplierNameTextBox.Size = new System.Drawing.Size(198, 22);
            this.supplierNameTextBox.TabIndex = 2;
            // 
            // cancelButton
            // 
            this.cancelButton.DataBindings.Add(new Wisej.Web.Binding("Text", this.supplierBindingSource, "CancelButtonText", true, Wisej.Web.DataSourceUpdateMode.Never));
            this.cancelButton.DialogResult = Wisej.Web.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(26, 190);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(100, 27);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.DataBindings.Add(new Wisej.Web.Binding("Enabled", this.supplierBindingSource, "IsDirty", true, Wisej.Web.DataSourceUpdateMode.Never));
            this.saveButton.DialogResult = Wisej.Web.DialogResult.OK;
            this.saveButton.Location = new System.Drawing.Point(201, 190);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(100, 27);
            this.saveButton.TabIndex = 4;
            this.saveButton.Text = "Save";
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // parentComboBox
            // 
            this.parentComboBox.AutoSize = false;
            this.parentComboBox.DataBindings.Add(new Wisej.Web.Binding("SelectedValue", this.supplierBindingSource, "ParentSupplierId", true));
            this.parentComboBox.DataSource = this.suplierListBindingSource;
            this.parentComboBox.DisplayMember = "SupplierName";
            this.parentComboBox.Location = new System.Drawing.Point(103, 105);
            this.parentComboBox.Name = "parentComboBox";
            this.parentComboBox.Size = new System.Drawing.Size(198, 22);
            this.parentComboBox.TabIndex = 5;
            componentTool1.ImageSource = "Resources/close-button.svg?color=Red";
            componentTool1.Name = "clearParentId";
            componentTool1.ToolTipText = "Clear parent supplier";
            this.parentComboBox.Tools.AddRange(new Wisej.Web.ComponentTool[] {
            componentTool1});
            this.parentComboBox.ValueMember = "SupplierId";
            this.parentComboBox.Watermark = "Select a parent supplier";
            this.parentComboBox.ToolClick += new Wisej.Web.ToolClickEventHandler(this.parentComboBox_ToolClick);
            // 
            // suplierListBindingSource
            // 
            this.suplierListBindingSource.AllowNew = false;
            this.suplierListBindingSource.DataSource = typeof(SeleniumDemo.WisejApp.Model.SupplierList);
            this.suplierListBindingSource.RefreshValueOnChange = true;
            // 
            // parentLabel
            // 
            this.parentLabel.AutoSize = true;
            this.parentLabel.Location = new System.Drawing.Point(26, 107);
            this.parentLabel.Name = "parentLabel";
            this.parentLabel.Size = new System.Drawing.Size(47, 16);
            this.parentLabel.TabIndex = 6;
            this.parentLabel.Text = "Parent";
            // 
            // idLabel
            // 
            this.idLabel.AutoSize = true;
            this.idLabel.Location = new System.Drawing.Point(26, 17);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(19, 16);
            this.idLabel.TabIndex = 7;
            this.idLabel.Text = "Id";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(26, 67);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(44, 16);
            this.nameLabel.TabIndex = 8;
            this.nameLabel.Text = "Name";
            // 
            // SupplierEditor
            // 
            this.AcceptButton = this.saveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = Wisej.Web.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(328, 240);
            this.ControlBox = false;
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.idLabel);
            this.Controls.Add(this.parentLabel);
            this.Controls.Add(this.parentComboBox);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.supplierNameTextBox);
            this.Controls.Add(this.supplierIdTextBox);
            this.MaximumSize = new System.Drawing.Size(330, 300);
            this.MinimumSize = new System.Drawing.Size(330, 300);
            this.Name = "SupplierEditor";
            this.StartPosition = Wisej.Web.FormStartPosition.CenterParent;
            this.Text = "Supplier Editor";
            this.Load += new System.EventHandler(this.SupplierEditor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.supplierBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.suplierListBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Wisej.Web.BindingSource supplierBindingSource;
        private Wisej.Web.TextBox supplierIdTextBox;
        private Wisej.Web.TextBox supplierNameTextBox;
        private Wisej.Web.Button cancelButton;
        private Wisej.Web.Button saveButton;
        private Wisej.Web.ComboBox parentComboBox;
        private Wisej.Web.Label parentLabel;
        private Wisej.Web.Label idLabel;
        private Wisej.Web.Label nameLabel;
        private Wisej.Web.BindingSource suplierListBindingSource;
    }
}