namespace SeleniumDemo.WisejApp.View
{
    partial class CustomerEditor
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
            this.dataGridView = new Wisej.Web.DataGridView();
            this.colCustomerid = new Wisej.Web.DataGridViewTextBoxColumn();
            this.colFirstname = new Wisej.Web.DataGridViewTextBoxColumn();
            this.colLastname = new Wisej.Web.DataGridViewTextBoxColumn();
            this.colState = new Wisej.Web.DataGridViewTextBoxColumn();
            this.colFullname = new Wisej.Web.DataGridViewTextBoxColumn();
            this.customerListBindingSource = new Wisej.Web.BindingSource(this.components);
            this.customerBindingSource = new Wisej.Web.BindingSource(this.components);
            this.statesbindingSource = new Wisej.Web.BindingSource(this.components);
            this.newButton = new Wisej.Web.Button();
            this.saveButton = new Wisej.Web.Button();
            this.removeButton = new Wisej.Web.Button();
            this.idLabel = new Wisej.Web.Label();
            this.id = new Wisej.Web.Label();
            this.firstNameLabel = new Wisej.Web.Label();
            this.firstName = new Wisej.Web.TextBox();
            this.lastNameLabel = new Wisej.Web.Label();
            this.lastName = new Wisej.Web.TextBox();
            this.stateLabel = new Wisej.Web.Label();
            this.state = new Wisej.Web.ComboBox();
            this.fullNameLabel = new Wisej.Web.Label();
            this.fullName = new Wisej.Web.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statesbindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.Anchor = ((Wisej.Web.AnchorStyles)(((Wisej.Web.AnchorStyles.Top | Wisej.Web.AnchorStyles.Left) 
            | Wisej.Web.AnchorStyles.Right)));
            this.dataGridView.AutoGenerateColumns = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = Wisej.Web.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView.Columns.AddRange(new Wisej.Web.DataGridViewColumn[] {
            this.colCustomerid,
            this.colFirstname,
            this.colLastname,
            this.colState,
            this.colFullname});
            this.dataGridView.DataSource = this.customerListBindingSource;
            this.dataGridView.KeepSameRowHeight = true;
            this.dataGridView.Location = new System.Drawing.Point(10, 10);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersWidthSizeMode = Wisej.Web.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dataGridView.RowTemplate.Resizable = Wisej.Web.DataGridViewTriState.False;
            this.dataGridView.SelectionMode = Wisej.Web.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.ShowColumnVisibilityMenu = false;
            this.dataGridView.Size = new System.Drawing.Size(718, 280);
            this.dataGridView.TabIndex = 1;
            this.dataGridView.SelectionChanged += new System.EventHandler(this.dataGridView_SelectionChanged);
            // 
            // colCustomerid
            // 
            this.colCustomerid.DataPropertyName = "CustomerId";
            this.colCustomerid.HeaderText = "Id";
            this.colCustomerid.Name = "colCustomerid";
            this.colCustomerid.ReadOnly = true;
            this.colCustomerid.SortMode = Wisej.Web.DataGridViewColumnSortMode.NotSortable;
            this.colCustomerid.Width = 50;
            // 
            // colFirstname
            // 
            this.colFirstname.DataPropertyName = "FirstName";
            this.colFirstname.HeaderText = "First Name";
            this.colFirstname.Name = "colFirstname";
            this.colFirstname.ReadOnly = true;
            this.colFirstname.SortMode = Wisej.Web.DataGridViewColumnSortMode.NotSortable;
            // 
            // colLastname
            // 
            this.colLastname.DataPropertyName = "LastName";
            this.colLastname.HeaderText = "Last Name";
            this.colLastname.Name = "colLastname";
            this.colLastname.ReadOnly = true;
            // 
            // colState
            // 
            this.colState.DataPropertyName = "StateName";
            this.colState.HeaderText = "State";
            this.colState.Name = "colState";
            this.colState.ReadOnly = true;
            this.colState.Width = 150;
            // 
            // colFullname
            // 
            this.colFullname.AutoSizeMode = Wisej.Web.DataGridViewAutoSizeColumnMode.Fill;
            this.colFullname.DataPropertyName = "FullName";
            this.colFullname.HeaderText = "Full Name";
            this.colFullname.Name = "colFullname";
            this.colFullname.ReadOnly = true;
            // 
            // customerListBindingSource
            // 
            this.customerListBindingSource.DataSource = typeof(SeleniumDemo.WisejApp.Model.CustomerList);
            this.customerListBindingSource.RefreshValueOnChange = true;
            // 
            // customerBindingSource
            // 
            this.customerBindingSource.DataSource = typeof(SeleniumDemo.WisejApp.Model.Customer);
            this.customerBindingSource.RefreshValueOnChange = true;
            // 
            // statesbindingSource
            // 
            this.statesbindingSource.AllowNew = false;
            this.statesbindingSource.DataSource = typeof(SeleniumDemo.WisejApp.Model.States);
            this.statesbindingSource.RefreshValueOnChange = true;
            // 
            // newButton
            // 
            this.newButton.Anchor = ((Wisej.Web.AnchorStyles)((Wisej.Web.AnchorStyles.Top | Wisej.Web.AnchorStyles.Right)));
            this.newButton.Location = new System.Drawing.Point(624, 310);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(80, 26);
            this.newButton.TabIndex = 12;
            this.newButton.Text = "New";
            this.newButton.Click += new System.EventHandler(this.newButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((Wisej.Web.AnchorStyles)((Wisej.Web.AnchorStyles.Top | Wisej.Web.AnchorStyles.Right)));
            this.saveButton.Location = new System.Drawing.Point(624, 362);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(80, 26);
            this.saveButton.TabIndex = 11;
            this.saveButton.Text = "Save";
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // removeButton
            // 
            this.removeButton.Anchor = ((Wisej.Web.AnchorStyles)((Wisej.Web.AnchorStyles.Top | Wisej.Web.AnchorStyles.Right)));
            this.removeButton.Location = new System.Drawing.Point(624, 415);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(80, 26);
            this.removeButton.TabIndex = 12;
            this.removeButton.Text = "Remove";
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // idLabel
            // 
            this.idLabel.Location = new System.Drawing.Point(30, 310);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(70, 18);
            this.idLabel.TabIndex = 10;
            this.idLabel.Text = "Id";
            // 
            // id
            // 
            this.id.DataBindings.Add(new Wisej.Web.Binding("Text", this.customerBindingSource, "CustomerId", true));
            this.id.Location = new System.Drawing.Point(110, 310);
            this.id.Name = "id";
            this.id.Padding = new Wisej.Web.Padding(5, 0, 0, 0);
            this.id.Size = new System.Drawing.Size(210, 22);
            this.id.TabIndex = 1;
            // 
            // firstNameLabel
            // 
            this.firstNameLabel.Location = new System.Drawing.Point(30, 340);
            this.firstNameLabel.Name = "firstNameLabel";
            this.firstNameLabel.Size = new System.Drawing.Size(70, 18);
            this.firstNameLabel.TabIndex = 2;
            this.firstNameLabel.Text = "First Name";
            // 
            // firstName
            // 
            this.firstName.DataBindings.Add(new Wisej.Web.Binding("Text", this.customerBindingSource, "FirstName", true));
            this.firstName.Location = new System.Drawing.Point(110, 340);
            this.firstName.Name = "firstName";
            this.firstName.Size = new System.Drawing.Size(210, 22);
            this.firstName.TabIndex = 3;
            // 
            // lastNameLabel
            // 
            this.lastNameLabel.Location = new System.Drawing.Point(30, 370);
            this.lastNameLabel.Name = "lastNameLabel";
            this.lastNameLabel.Size = new System.Drawing.Size(70, 18);
            this.lastNameLabel.TabIndex = 4;
            this.lastNameLabel.Text = "Last Name";
            // 
            // lastName
            // 
            this.lastName.DataBindings.Add(new Wisej.Web.Binding("Text", this.customerBindingSource, "LastName", true));
            this.lastName.Location = new System.Drawing.Point(110, 370);
            this.lastName.Name = "lastName";
            this.lastName.Size = new System.Drawing.Size(210, 22);
            this.lastName.TabIndex = 5;
            // 
            // stateLabel
            // 
            this.stateLabel.Location = new System.Drawing.Point(30, 400);
            this.stateLabel.Name = "stateLabel";
            this.stateLabel.Size = new System.Drawing.Size(70, 18);
            this.stateLabel.TabIndex = 6;
            this.stateLabel.Text = "State";
            // 
            // state
            // 
            this.state.AutoCompleteMode = Wisej.Web.AutoCompleteMode.Suggest;
            this.state.DataBindings.Add(new Wisej.Web.Binding("SelectedValue", this.customerBindingSource, "State", true));
            this.state.FormattingEnabled = true;
            this.state.Location = new System.Drawing.Point(110, 400);
            this.state.Name = "state";
            this.state.Size = new System.Drawing.Size(210, 22);
            this.state.TabIndex = 7;
            this.state.Validated += new System.EventHandler(this.state_Validated);
            // 
            // fullNameLabel
            // 
            this.fullNameLabel.Location = new System.Drawing.Point(30, 430);
            this.fullNameLabel.Name = "fullNameLabel";
            this.fullNameLabel.Size = new System.Drawing.Size(60, 18);
            this.fullNameLabel.TabIndex = 8;
            this.fullNameLabel.Text = "Full Name";
            // 
            // fullName
            // 
            this.fullName.DataBindings.Add(new Wisej.Web.Binding("Text", this.customerBindingSource, "FullName", true));
            this.fullName.Location = new System.Drawing.Point(110, 430);
            this.fullName.Name = "fullName";
            this.fullName.Padding = new Wisej.Web.Padding(5, 0, 0, 0);
            this.fullName.Size = new System.Drawing.Size(210, 22);
            this.fullName.TabIndex = 9;
            // 
            // CustomerEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = Wisej.Web.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 461);
            this.Controls.Add(this.newButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.fullName);
            this.Controls.Add(this.fullNameLabel);
            this.Controls.Add(this.state);
            this.Controls.Add(this.stateLabel);
            this.Controls.Add(this.lastName);
            this.Controls.Add(this.lastNameLabel);
            this.Controls.Add(this.firstName);
            this.Controls.Add(this.firstNameLabel);
            this.Controls.Add(this.id);
            this.Controls.Add(this.idLabel);
            this.MinimumSize = new System.Drawing.Size(750, 505);
            this.Name = "CustomerEditor";
            this.Text = "Customer Editor";
            this.Load += new System.EventHandler(this.CustomerEditor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statesbindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Wisej.Web.DataGridView dataGridView;
        private Wisej.Web.BindingSource customerListBindingSource;
        private Wisej.Web.BindingSource customerBindingSource;
        private Wisej.Web.BindingSource statesbindingSource;
        private Wisej.Web.DataGridViewTextBoxColumn colCustomerid;
        private Wisej.Web.DataGridViewTextBoxColumn colFirstname;
        private Wisej.Web.DataGridViewTextBoxColumn colLastname;
        private Wisej.Web.DataGridViewTextBoxColumn colState;
        private Wisej.Web.DataGridViewTextBoxColumn colFullname;
        private Wisej.Web.Label idLabel;
        private Wisej.Web.Label id;
        private Wisej.Web.Label firstNameLabel;
        private Wisej.Web.TextBox firstName;
        private Wisej.Web.Label lastNameLabel;
        private Wisej.Web.TextBox lastName;
        private Wisej.Web.Label stateLabel;
        private Wisej.Web.ComboBox state;
        private Wisej.Web.Label fullNameLabel;
        private Wisej.Web.Label fullName;
        private Wisej.Web.Button newButton;
        private Wisej.Web.Button saveButton;
        private Wisej.Web.Button removeButton;
    }
}