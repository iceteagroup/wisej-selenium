using Wisej.Web.Ext.Selenium.UI;

namespace Wisej.Web.Ext.Selenium.Tests
{
    /// <summary>
    /// Extension class with helper methods for handling <see cref="Form"/>.
    /// </summary>
    public static class HelperForm
    {
        /// <summary>
        /// Closes a Form.
        /// </summary>
        /// <param name="driver">The <see cref="WisejWebDriver"/> to use.</param>
        /// <param name="name">The form name.</param>
        /// <param name="timeoutInSeconds">The number of seconds to wait for the Form.</param>
        public static void FormClose(this WisejWebDriver driver, string name, long timeoutInSeconds = 5)
        {
            Form form = driver.WidgetGet<Form>(name, timeoutInSeconds);
            form.AssertIsDisplayed(name);
            form.Close();
            form.AssertIsDisposed(name);
        }

        /// <summary>
        /// Maximizes a Form.
        /// </summary>
        /// <param name="driver">The <see cref="WisejWebDriver"/> to use.</param>
        /// <param name="name">The form name.</param>
        /// <param name="timeoutInSeconds">The number of seconds to wait for the Form.</param>
        public static void FormMaximize(this WisejWebDriver driver, string name, long timeoutInSeconds = 5)
        {
            Form form = driver.WidgetGet<Form>(name, timeoutInSeconds);
            form.Maximize();
        }

        /// <summary>
        /// Minimizes a Form.
        /// </summary>
        /// <param name="driver">The <see cref="WisejWebDriver"/> to use.</param>
        /// <param name="name">The form name.</param>
        /// <param name="timeoutInSeconds">The number of seconds to wait for the Form.</param>
        public static void FormMinimize(this WisejWebDriver driver, string name, long timeoutInSeconds = 5)
        {
            Form form = driver.WidgetGet<Form>(name, timeoutInSeconds);
            form.Minimize();
        }

        /// <summary>
        /// Restores a Form.
        /// </summary>
        /// <param name="driver">The <see cref="WisejWebDriver"/> to use.</param>
        /// <param name="name">The form name.</param>
        /// <param name="timeoutInSeconds">The number of seconds to wait for the Form.</param>
        public static void FormRestore(this WisejWebDriver driver, string name, long timeoutInSeconds = 5)
        {
            Form form = driver.WidgetGet<Form>(name, timeoutInSeconds);
            form.Restore();
        }
    }
}