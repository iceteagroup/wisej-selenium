using Wisej.Web.Ext.Selenium.UI;

namespace Wisej.Web.Ext.Selenium.Tests
{
    public static class HelperForm
    {
        public static void FormClose(this WisejWebDriver driver, string name, long timeoutInSeconds = 5)
        {
            var form = driver.WidgetGet<Form>(name, timeoutInSeconds);
            form.AssertIsDisplayed(name);
            form.Close();
            form.AssertIsDisposed(name);
        }

        public static void FormMaximize(this WisejWebDriver driver, string name, long timeoutInSeconds = 5)
        {
            var form = driver.WidgetGet<Form>(name, timeoutInSeconds);
            form.Maximize();
        }

        public static void FormMinimize(this WisejWebDriver driver, string name, long timeoutInSeconds = 5)
        {
            var form = driver.WidgetGet<Form>(name, timeoutInSeconds);
            form.Minimize();
        }

        public static void FormRestore(this WisejWebDriver driver, string name, long timeoutInSeconds = 5)
        {
            var form = driver.WidgetGet<Form>(name, timeoutInSeconds);
            form.Restore();
        }
    }
}