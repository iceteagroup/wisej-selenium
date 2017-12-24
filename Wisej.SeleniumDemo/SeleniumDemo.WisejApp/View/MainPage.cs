using System;
using System.Drawing;
using Wisej.Base;
using Wisej.Web;

namespace SeleniumDemo.WisejApp.View
{
    public partial class MainPage : Page
    {
        private HelperWindow _helperForm;

        public MainPage()
        {
            InitializeComponent();

            AlertBox.Show("Place holder to show the application is present in the browser.", MessageBoxIcon.None, true,
                ContentAlignment.BottomRight, 0);
        }

        private void buttonsWindow_Click(object sender, EventArgs e)
        {
            using (var window = new ButtonsWindow())
            {
                window.ShowDialog();
            }
        }

        private void exit_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show("Do you want to exit now?", "Exit Application",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
                Application.Exit();
        }

        private void helper_Click(object sender, EventArgs e)
        {
            var positionX = ClientSize.Width - 300;
            _helperForm = new HelperWindow();
            _helperForm.Location = new Point(positionX, 0);
            _helperForm.Show();
        }
    }
}