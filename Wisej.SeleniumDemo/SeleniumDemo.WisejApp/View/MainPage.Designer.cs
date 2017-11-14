namespace SeleniumDemo.WisejApp.View
{
    partial class MainPage
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
            this.buttonsWindow = new Wisej.Web.Button();
            this.sayGoodBye = new Wisej.Web.Button();
            this.helper = new Wisej.Web.Button();
            this.SuspendLayout();
            // 
            // buttonsWindow
            // 
            this.buttonsWindow.Location = new System.Drawing.Point(35, 30);
            this.buttonsWindow.Name = "buttonsWindow";
            this.buttonsWindow.Size = new System.Drawing.Size(180, 40);
            this.buttonsWindow.TabIndex = 0;
            this.buttonsWindow.Text = "Open Buttons Window";
            this.buttonsWindow.Click += new System.EventHandler(this.buttonsWindow_Click);
            // 
            // sayGoodBye
            // 
            this.sayGoodBye.Location = new System.Drawing.Point(35, 130);
            this.sayGoodBye.Name = "sayGoodBye";
            this.sayGoodBye.Size = new System.Drawing.Size(180, 40);
            this.sayGoodBye.TabIndex = 1;
            this.sayGoodBye.Text = "Say Good-bye";
            this.sayGoodBye.Click += new System.EventHandler(this.sayGoodBye_Click);
            // 
            // helper
            // 
            this.helper.Anchor = ((Wisej.Web.AnchorStyles)((Wisej.Web.AnchorStyles.Top | Wisej.Web.AnchorStyles.Right)));
            this.helper.Font = new System.Drawing.Font("default", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.helper.Location = new System.Drawing.Point(953, 30);
            this.helper.Name = "helper";
            this.helper.Size = new System.Drawing.Size(40, 40);
            this.helper.TabIndex = 2;
            this.helper.Text = "?";
            this.helper.Click += new System.EventHandler(this.helper_Click);
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = Wisej.Web.AutoScaleMode.Font;
            this.Controls.Add(this.helper);
            this.Controls.Add(this.sayGoodBye);
            this.Controls.Add(this.buttonsWindow);
            this.Name = "MainPage";
            this.Size = new System.Drawing.Size(1024, 548);
            this.Text = "Main Page";
            this.ResumeLayout(false);

        }

        #endregion

        private Wisej.Web.Button buttonsWindow;
        private Wisej.Web.Button sayGoodBye;
        private Wisej.Web.Button helper;
    }
}
