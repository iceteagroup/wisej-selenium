using OpenQA.Selenium;
using Wisej.Web.Ext.Selenium;
using Wisej.Web.Ext.Selenium.UI;

namespace Wisej.SeleniumTestExample
{
    /// <summary>
    /// Represents the ProgressSample application and related
    /// object model to use in the tests.
    /// </summary>
    public class ProgressSampleWebDriver : WisejWebDriver
    {
        public ProgressSampleWebDriver(Browser browser)
            : base(browser)
        {
            Url = "http://demo.wisej.com/ProgressSample.html";
        }

        public Form Window1
        {
            get { return (Form) FindWidget("Desktop.Window1"); }
        }

        public Label LabelStep
        {
            get { return (Label) Window1.FindWidget("labelStep"); }
        }

        public void TearDown()
        {
            Quit();
        }
    }
}