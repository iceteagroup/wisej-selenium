using OpenQA.Selenium;
using Qooxdoo.WebDriver.UI.Mobile.Core;
using WidgetImpl = Qooxdoo.WebDriver.UI.Mobile.Core.WidgetImpl;

namespace Qooxdoo.WebDriver.UI.Mobile.List
{
    /// <summary>
    /// Mobile list widget
    /// </summary>
    /// <seealso cref="WidgetImpl" />
    /// <seealso cref="ISelectable" />
    public class List : Core.WidgetImpl, ISelectable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="List"/> class.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="webDriver">The web driver.</param>
        public List(IWebElement element, QxWebDriver webDriver) : base(element, webDriver)
        {
        }

        /// <summary>
        /// Returns the selectable item.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>The found item.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public IWidget GetSelectableItem(int? index)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Locates a list item by its position and taps it. </summary>
        /// <param name="index"> The list item's index </param>
        public virtual void SelectItem(int? index)
        {
            index++; //xpath's position() is 1-based
            var locator =
                OpenQA.Selenium.By.XPath("descendant::li[contains(@class, 'list-item') and position() = " + index + "]");
            IWebElement item = ContentElement.FindElement(locator);
            Tap(Driver.WebDriver, item);
        }

        /// <summary>
        /// Returns the selectable item.
        /// </summary>
        /// <param name="regex">The regular expression to match.</param>
        /// <returns>The found item.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public IWidget GetSelectableItem(string regex)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Locates a list item by its title (exact match) and taps it. </summary>
        /// <param name="title"> The list item's title text </param>
        public virtual void SelectItem(string title)
        {
            var locator = OpenQA.Selenium.By.XPath(
                "descendant::div[contains(@class, 'list-item-title') and text() = '" + title + "']/ancestor::li");
            IWebElement item = ContentElement.FindElement(locator);
            Tap(Driver.WebDriver, item);
        }
    }
}