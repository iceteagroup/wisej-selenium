using System;
using System.ComponentModel;
using SeleniumDemo.WisejApp.Model;
using Wisej.Web;

namespace SeleniumDemo.WisejApp.View
{
    public partial class CustomerEditor : Form
    {
        private Customer _customer;

        public CustomerEditor()
        {
            InitializeComponent();
        }

        private void CustomerEditor_Load(object sender, System.EventArgs e)
        {
            // Bind ComboBox list datasources first
            statesbindingSource.EnumToDataSource(typeof(States));
            state.DataSource = statesbindingSource;
            state.DisplayMember = "Description";
            state.ValueMember = "Key";

            // AutoCompleteCustomSource isn't supported on Wisej
            //state.AutoCompleteCustomSource.AddRange(EnumExtension.EnumToArray(typeof(States)));

            customerListBindingSource.DataSource = CustomerList.GetCustomerList();
            dataGridView.Rows[0].Selected = true;
        }

        private void newButton_Click(object sender, System.EventArgs e)
        {
            ClearSelectedRows();
            GetNewCustomer();
        }

        private void ClearSelectedRows()
        {
            for (var index = 0; index < dataGridView.RowCount; index++)
            {
                dataGridView.Rows[index].Selected = false;
            }
        }

        private void saveButton_Click(object sender, System.EventArgs e)
        {
            bool isNew = _customer.IsNew;
            _customer.Save();

            if (isNew)
                dataGridView.Rows[dataGridView.Rows.Count - 1].Selected = true;
        }

        private void removeButton_Click(object sender, System.EventArgs e)
        {
            var deletedRowIndex = dataGridView.CurrentRow.ClientIndex;
            _customer.Delete();

            if (dataGridView.RowCount > deletedRowIndex)
            {
                dataGridView.Rows[deletedRowIndex].Selected = true;
            }
        }

        private void GetNewCustomer()
        {
            _customer = new Customer();
            customerBindingSource.DataSource = _customer;
        }

        private void dataGridView_SelectionChanged(object sender, System.EventArgs e)
        {
            BindLine();
        }

        private void state_Validated(object sender, EventArgs e)
        {
            if ((sender as ComboBox).SelectedIndex == -1)
                customerBindingSource.ResetBindings(false);
        }


        private void BindLine()
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                var id = (int) dataGridView.SelectedRows[0].Cells[0].Value;
                _customer = CustomerList.GetCustomer(id);
                customerBindingSource.DataSource = _customer;
            }
        }
    }
}