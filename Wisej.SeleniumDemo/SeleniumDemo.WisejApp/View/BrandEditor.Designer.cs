namespace SeleniumDemo.WisejApp.View
{
    partial class BrandEditor
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
            this.brandBindingSource = new Wisej.Web.BindingSource(this.components);
            this.brandIdLabel = new Wisej.Web.Label();
            this.brandNameTextBox = new Wisej.Web.TextBox();
            this.cancelButton = new Wisej.Web.Button();
            this.saveButton = new Wisej.Web.Button();
            ((System.ComponentModel.ISupportInitialize)(this.brandBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // brandBindingSource
            // 
            this.brandBindingSource.AllowNew = false;
            this.brandBindingSource.DataSource = typeof(SeleniumDemo.WisejApp.Model.Brand);
            this.brandBindingSource.RefreshValueOnChange = true;
            // 
            // brandIdLabel
            // 
            this.brandIdLabel.AutoSize = true;
            this.brandIdLabel.DataBindings.Add(new Wisej.Web.Binding("Text", this.brandBindingSource, "BrandId", true, Wisej.Web.DataSourceUpdateMode.Never));
            this.brandIdLabel.Location = new System.Drawing.Point(17, 17);
            this.brandIdLabel.Name = "brandIdLabel";
            this.brandIdLabel.Size = new System.Drawing.Size(15, 16);
            this.brandIdLabel.TabIndex = 1;
            this.brandIdLabel.Text = "0";
            // 
            // brandNameTextBox
            // 
            this.brandNameTextBox.DataBindings.Add(new Wisej.Web.Binding("Text", this.brandBindingSource, "BrandName", true, Wisej.Web.DataSourceUpdateMode.OnPropertyChanged));
            this.brandNameTextBox.Location = new System.Drawing.Point(95, 15);
            this.brandNameTextBox.Name = "brandNameTextBox";
            this.brandNameTextBox.Size = new System.Drawing.Size(174, 22);
            this.brandNameTextBox.TabIndex = 2;
            // 
            // cancelButton
            // 
            this.cancelButton.DataBindings.Add(new Wisej.Web.Binding("Text", this.brandBindingSource, "CancelButtonText", true, Wisej.Web.DataSourceUpdateMode.Never));
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
            this.saveButton.DataBindings.Add(new Wisej.Web.Binding("Enabled", this.brandBindingSource, "IsDirty", true, Wisej.Web.DataSourceUpdateMode.Never));
            this.saveButton.DialogResult = Wisej.Web.DialogResult.OK;
            this.saveButton.Location = new System.Drawing.Point(169, 100);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(100, 27);
            this.saveButton.TabIndex = 4;
            this.saveButton.Text = "Save";
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // BrandEditor
            // 
            this.AcceptButton = this.saveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = Wisej.Web.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(288, 156);
            this.ControlBox = false;
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.brandNameTextBox);
            this.Controls.Add(this.brandIdLabel);
            this.MaximumSize = new System.Drawing.Size(300, 200);
            this.MinimumSize = new System.Drawing.Size(300, 200);
            this.Name = "BrandEditor";
            this.StartPosition = Wisej.Web.FormStartPosition.CenterParent;
            this.Text = "Brand Editor";
            this.Load += new System.EventHandler(this.BrandEditor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.brandBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Wisej.Web.BindingSource brandBindingSource;
        private Wisej.Web.Label brandIdLabel;
        private Wisej.Web.TextBox brandNameTextBox;
        private Wisej.Web.Button cancelButton;
        private Wisej.Web.Button saveButton;
    }
}