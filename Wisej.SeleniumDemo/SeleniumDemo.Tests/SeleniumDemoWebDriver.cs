using OpenQA.Selenium;
using Wisej.Web.Ext.Selenium;

namespace SeleniumDemo.Tests
{
    public class SeleniumDemoWebDriver : WisejWebDriver
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SeleniumDemoWebDriver" /> class.
        /// </summary>
        /// <param name="browser">The <see cref="OpenQA.Selenium.Browser" /> of the webdriver to wrap.</param>
        /// <param name="options">The colection of options specific to a browser driver.</param>
        public SeleniumDemoWebDriver(Browser browser, object options)
            : base(browser, options)
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