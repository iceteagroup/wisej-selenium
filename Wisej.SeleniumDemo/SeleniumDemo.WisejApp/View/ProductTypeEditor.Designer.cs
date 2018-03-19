namespace SeleniumDemo.WisejApp.View
{
    partial class ProductTypeEditor
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
            this.productTypeBindingSource = new Wisej.Web.BindingSource(this.components);
            this.productTypeIdLabel = new Wisej.Web.Label();
            this.productTypeNameTextBox = new Wisej.Web.TextBox();
            this.cancelButton = new Wisej.Web.Button();
            this.saveButton = new Wisej.Web.Button();
            ((System.ComponentModel.ISupportInitialize)(this.productTypeBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // productTypeBindingSource
            // 
            this.productTypeBindingSource.AllowNew = false;
            this.productTypeBindingSource.DataSource = typeof(SeleniumDemo.WisejApp.Model.ProductType);
            this.productTypeBindingSource.RefreshValueOnChange = true;
            // 
            // productTypeIdLabel
            // 
            this.productTypeIdLabel.AutoSize = true;
            this.productTypeIdLabel.DataBindings.Add(new Wisej.Web.Binding("Text", this.productTypeBindingSource, "ProductTypeId", true, Wisej.Web.DataSourceUpdateMode.Never));
            this.productTypeIdLabel.Location = new System.Drawing.Point(17, 17);
            this.productTypeIdLabel.Name = "productTypeIdLabel";
            this.productTypeIdLabel.Size = new System.Drawing.Size(15, 16);
            this.productTypeIdLabel.TabIndex = 1;
            this.productTypeIdLabel.Text = "0";
            // 
            // productTypeNameTextBox
            // 
            this.productTypeNameTextBox.DataBindings.Add(new Wisej.Web.Binding("Text", this.productTypeBindingSource, "ProductTypeName", true, Wisej.Web.DataSourceUpdateMode.OnPropertyChanged));
            this.productTypeNameTextBox.Location = new System.Drawing.Point(95, 15);
            this.productTypeNameTextBox.Name = "productTypeNameTextBox";
            this.productTypeNameTextBox.Size = new System.Drawing.Size(174, 22);
            this.productTypeNameTextBox.TabIndex = 2;
            // 
            // cancelButton
            // 
            this.cancelButton.DataBindings.Add(new Wisej.Web.Binding("Text", this.productTypeBindingSource, "CancelButtonText", true, Wisej.Web.DataSourceUpdateMode.Never));
            this.cancelButton.DialogResult = Wisej.Web.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(17, 100);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(100, 27);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.DataBindings.Add(new Wisej.Web.Binding("Enabled", this.productTypeBindingSource, "IsDirty", true, Wisej.Web.DataSourceUpdateMode.Never));
            this.saveButton.DialogResult = Wisej.Web.DialogResult.OK;
            this.saveButton.Location = new System.Drawing.Point(169, 100);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(100, 27);
            this.saveButton.TabIndex = 4;
            this.saveButton.Text = "Save";
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // ProductTypeEditor
            // 
            this.AcceptButton = this.saveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = Wisej.Web.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(298, 150);
            this.ControlBox = false;
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.productTypeNameTextBox);
            this.Controls.Add(this.productTypeIdLabel);
            this.MaximumSize = new System.Drawing.Size(300, 210);
            this.MinimumSize = new System.Drawing.Size(300, 210);
            this.Name = "ProductTypeEditor";
            this.StartPosition = Wisej.Web.FormStartPosition.CenterParent;
            this.Text = "Product Type Editor";
            this.Load += new System.EventHandler(this.ProductTypeEditor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.productTypeBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Wisej.Web.BindingSource productTypeBindingSource;
        private Wisej.Web.Label productTypeIdLabel;
        private Wisej.Web.TextBox productTypeNameTextBox;
        private Wisej.Web.Button cancelButton;
        private Wisej.Web.Button saveButton;
    }
}