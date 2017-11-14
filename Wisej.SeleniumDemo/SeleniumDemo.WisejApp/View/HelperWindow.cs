using System;
using Wisej.Web;

namespace SeleniumDemo.WisejApp.View
{
    public partial class HelperWindow : Form
    {
        private bool _wasMinimized;

        public HelperWindow()
        {
            InitializeComponent();
        }

        private void HelperWindow_VisibleChanged(object sender, EventArgs e)
        {
            if (!_wasMinimized)
                _wasMinimized = true;
            else
                label1.Text = "Minimized and restored back.";
        }

        private void resetData_Click(object sender, EventArgs e)
        {
            Model.CustomerList.ResetData();
            label1.Text = "Data reset to factory settings.";
        }
    }
}