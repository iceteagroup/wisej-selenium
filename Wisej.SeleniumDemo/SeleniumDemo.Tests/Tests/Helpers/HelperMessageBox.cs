using Microsoft.VisualStudio.TestTools.UnitTesting;
using Qooxdoo.WebDriver.UI;

namespace Wisej.Web.Ext.Selenium.Tests
{
    public static class HelperMessageBox
    {
        public static void MessageBoxClick(this WisejWebDriver driver, DialogResult result, long timeoutInSeconds = 5)
        {
            var messageBoxBy = HelperUI.QxhByString("wisej.web.MessageBox");
            var messageBox = driver.WaitForWidget(messageBoxBy, timeoutInSeconds);
            Assert.IsNotNull(messageBox, "MessageBox not found.");

            var buttonsPaneBy = HelperUI.QxhByString("qx.ui.container.Composite");
            var buttonsPane = messageBox.FindWidget(buttonsPaneBy);
            Assert.IsNotNull(buttonsPane, "MessageBox button's panel not found.");

            IWidget button = null;
            foreach (var child in buttonsPane.Children)
            {
                if (child.Text == result.ToString())
                {
                    button = child;
                    break;
                }
            }

            Assert.IsNotNull(button, string.Format("MessageBox Button {0} not found.", result.ToString()));
            Assert.IsTrue(button.Enabled, string.Format("MessageBox  {0} isn't enabled.", result.ToString()));
            button.Click();
        }

        // TODO: MessageBoxGetCaption
        // TODO: MessageBoxGetMessage
    }
}