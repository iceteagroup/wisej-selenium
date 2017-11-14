using OpenQA.Selenium;

namespace Qooxdoo.WebDriver
{
    internal static class DriverServer
    {
        public static string GetName(IWebDriver driver)
        {
            string result;

            var browserName = driver.GetType().Name;

            switch (browserName)
            {
                case "ChromeDriver":
                    result = "chromedriver";
                    break;
                case "EdgeDriver":
                    result = "MicrosoftWebDriver";
                    break;
                case "FirefoxDriver":
                    result = "geckodriver";
                    break;
                case "InternetExplorerDriver":
                    result = "IEDriverServer";
                    break;
                case "OperaDriver":
                    result = "operadriver";
                    break;
                case "PhantomJSDriver":
                    result = "PhantomJS";
                    break;
                default:
                    result = "SafariDriver"; // No EXE found anywhere. Not sure whether there is an actual process...
                    break;
            }

            return result;
        }
    }
}