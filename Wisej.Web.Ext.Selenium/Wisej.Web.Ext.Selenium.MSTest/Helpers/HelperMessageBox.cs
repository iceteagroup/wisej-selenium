using Microsoft.VisualStudio.TestTools.UnitTesting;
using Qooxdoo.WebDriver.UI;
using Wisej.Web.Ext.Selenium.UI;

namespace Wisej.Web.Ext.Selenium.Tests
{
    public static class HelperMessageBox
    {
        public static MessageBox GetMessageBoxWithTitle(this WisejWebDriver driver, string title,
            long timeoutInSeconds = 5)
        {
            MessageBox[] messageBoxes = driver.MessageBoxes(timeoutInSeconds);
            if (messageBoxes != null)
            {
                foreach (MessageBox messageBox in messageBoxes)
                {
                    if (messageBox.Title == title)
                    {
                        return messageBox;
                    }
                }
            }

            return null;
        }

        public static MessageBox GetMessageBoxWithMessage(this WisejWebDriver driver, string message,
            long timeoutInSeconds = 5)
        {
            MessageBox[] messageBoxes = driver.MessageBoxes(timeoutInSeconds);
            if (messageBoxes != null)
            {
                foreach (MessageBox messageBox in messageBoxes)
                {
                    if (messageBox.Message == message)
                    {
                        return messageBox;
                    }
                }
            }

            return null;
        }

        public static void MessageBoxWithTitleButtonClick(this WisejWebDriver driver, string title, DialogResult result,
            long timeoutInSeconds = 5)
        {
            MessageBox messageBox = driver.GetMessageBoxWithTitle(title, timeoutInSeconds);

            Assert.IsNotNull(messageBox, string.Format("MessageBox {0} not found.", result.ToString()));
            Assert.IsTrue(messageBox.Enabled, string.Format("MessageBox  {0} isn't enabled.", result.ToString()));

            messageBox.ButtonClick(result);
        }

        public static void MessageBoxWithMessageButtonClick(this WisejWebDriver driver, string message,
            DialogResult result,
            long timeoutInSeconds = 5)
        {
            MessageBox messageBox = driver.GetMessageBoxWithMessage(message, timeoutInSeconds);

            Assert.IsNotNull(messageBox, string.Format("MessageBox {0} not found.", result.ToString()));
            Assert.IsTrue(messageBox.Enabled, string.Format("MessageBox  {0} isn't enabled.", result.ToString()));

            messageBox.ButtonClick(result);
        }

        public static void ButtonClick(this MessageBox messageBox, DialogResult result)
        {
            IWidget button = messageBox.GetButton(result.ToString());

            Assert.IsNotNull(button, string.Format("MessageBox Button {0} not found.", result.ToString()));
            Assert.IsTrue(button.Enabled, string.Format("MessageBox  {0} isn't enabled.", result.ToString()));

            button.Click();
        }
    }
}