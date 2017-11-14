using SeleniumDemo.WisejApp.View;
using Wisej.Web;

namespace SeleniumDemo.WisejApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            Page mainPage = new MainPage();
            mainPage.Show();

            Application.SessionTimeout += Application_SessionTimeout;
        }

        private static void Application_SessionTimeout(object sender, System.ComponentModel.HandledEventArgs e)
        {
            // you can display a form and override the default session timeout dialog.
            e.Handled = true;
        }
    }
}