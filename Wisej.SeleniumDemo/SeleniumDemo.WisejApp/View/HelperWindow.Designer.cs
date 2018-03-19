namespace SeleniumDemo.WisejApp.View
{
    partial class HelperWindow
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
            this.label1 = new Wisej.Web.Label();
            this.resetData = new Wisej.Web.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("default", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(233, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "This window will be minimized.";
            // 
            // resetData
            // 
            this.resetData.Font = new System.Drawing.Font("default", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.resetData.Location = new System.Drawing.Point(70, 80);
            this.resetData.Name = "resetData";
            this.resetData.Size = new System.Drawing.Size(150, 30);
            this.resetData.TabIndex = 1;
            this.resetData.Text = "Reset Data";
            this.resetData.Click += new System.EventHandler(this.resetData_Click);
            // 
            // HelperWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = Wisej.Web.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 150);
            this.Controls.Add(this.resetData);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(300, 210);
            this.MinimumSize = new System.Drawing.Size(300, 210);
            this.Name = "HelperWindow";
            this.StartPosition = Wisej.Web.FormStartPosition.Manual;
            this.Text = "User Help";
            this.VisibleChanged += new System.EventHandler(this.HelperWindow_VisibleChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Wisej.Web.Label label1;
        private Wisej.Web.Button resetData;
    }
}