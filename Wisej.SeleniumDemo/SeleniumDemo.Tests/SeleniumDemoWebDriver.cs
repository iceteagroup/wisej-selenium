using OpenQA.Selenium;
using Wisej.Web.Ext.Selenium;

namespace SeleniumDemo.Tests
{
    public class SeleniumDemoWebDriver : WisejWebDriver
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SeleniumDemoWebDriver"/> class.
        /// </summary>
        /// <param name="browser">The <see cref="T:OpenQA.Selenium.Browser" /> of the webdriver to wrap.</param>
        public SeleniumDemoWebDriver(Browser browser)
            : base(browser)
        {
            ConstructorCore();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SeleniumDemoWebDriver"/> class.
        /// </summary>
        /// <param name="driver">The webdriver to use.</param>
        public SeleniumDemoWebDriver(IWebDriver driver)
            : base(driver)
        {
            ConstructorCore();
        }

        private void ConstructorCore()
        {
            Url = "http://localhost:7185/Default.html";
        }

        public void TearDown()
        {
            Quit();
        }
    }
}