using OpenQA.Selenium;
using Qooxdoo.WebDriver.UI.Mobile.Core;

namespace Qooxdoo.WebDriver.UI.Mobile.Form
{
    /// <summary>
    /// Mobile sloder widget
    /// </summary>
    /// <seealso cref="WidgetImpl" />
    public class Slider : Core.WidgetImpl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Slider"/> class.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="webDriver">The web driver.</param>
        public Slider(IWebElement element, QxWebDriver webDriver) : base(element, webDriver)
        {
        }

        /// <summary>
        /// Drags this widget by the given offsets </summary>
        /// <param name="x"> Amount of pixels to move horizontally </param>
        /// <param name="y"> Amount of pixels to move vertically </param>
        /// <param name="step"> Generate a move event every (step) pixels </param>
        public override void Track(int x, int y, int step)
        {
            IWebElement element = ContentElement.FindElement(OpenQA.Selenium.By.XPath("div"));
            Track(Driver.WebDriver, element, x, y, step);
        }
    }
}