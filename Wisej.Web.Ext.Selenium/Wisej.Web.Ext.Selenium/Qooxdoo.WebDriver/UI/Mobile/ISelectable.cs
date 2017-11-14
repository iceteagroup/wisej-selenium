namespace Qooxdoo.WebDriver.UI.Mobile
{
    /// <summary>
    /// This interface represents qx.Mobile widgets with selectable child items, e.g.
    /// qx.ui.mobile.list.List. For qx.Desktop widgets, please use
    /// Qooxdoo.WebDriver.UI.ISelectable instead.
    /// </summary>
    public interface ISelectable : IWidget
    {
        /// <summary>
        /// Locates a list item by its title (exact match) and taps it. </summary>
        /// <param name="title"> The list item's title text </param>
        void SelectItem(string title);

        /// <summary>
        /// Locates a list item by its position and taps it. </summary>
        /// <param name="index"> The list item's index </param>
        void SelectItem(int? index);
    }
}