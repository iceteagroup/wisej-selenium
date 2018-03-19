namespace SeleniumDemo.WisejApp.View
{
    partial class SupplierTreeEditor
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
            this.removeButton = new Wisej.Web.Button();
            this.newButton = new Wisej.Web.Button();
            this.suppliersTreeView = new Wisej.Web.TreeView();
            this.SuspendLayout();
            // 
            // removeButton
            // 
            this.removeButton.Anchor = ((Wisej.Web.AnchorStyles)((Wisej.Web.AnchorStyles.Top | Wisej.Web.AnchorStyles.Right)));
            this.removeButton.Location = new System.Drawing.Point(431, 434);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(80, 26);
            this.removeButton.TabIndex = 16;
            this.removeButton.Text = "Remove";
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // newButton
            // 
            this.newButton.Anchor = ((Wisej.Web.AnchorStyles)((Wisej.Web.AnchorStyles.Top | Wisej.Web.AnchorStyles.Right)));
            this.newButton.Location = new System.Drawing.Point(101, 434);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(80, 26);
            this.newButton.TabIndex = 15;
            this.newButton.Text = "New";
            this.newButton.Click += new System.EventHandler(this.newButton_Click);
            // 
            // suppliersTreeView
            // 
            this.suppliersTreeView.Location = new System.Drawing.Point(20, 20);
            this.suppliersTreeView.Name = "suppliersTreeView";
            this.suppliersTreeView.Size = new System.Drawing.Size(572, 389);
            this.suppliersTreeView.TabIndex = 17;
            this.suppliersTreeView.NodeMouseDoubleClick += new Wisej.Web.TreeNodeMouseClickEventHandler(this.productTypesTreeView_NodeMouseDoubleClick);
            // 
            // SupplierTreeEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = Wisej.Web.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 480);
            this.Controls.Add(this.suppliersTreeView);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.newButton);
            this.Name = "SupplierTreeEditor";
            this.Text = "Supplier Tree Editor";
            this.Load += new System.EventHandler(this.SupplierEditor_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Wisej.Web.Button removeButton;
        private Wisej.Web.Button newButton;
        private Wisej.Web.TreeView suppliersTreeView;
    }
}