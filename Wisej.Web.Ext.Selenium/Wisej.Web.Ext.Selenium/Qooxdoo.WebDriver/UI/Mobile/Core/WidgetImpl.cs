/*************************************************************************

   qxwebdriver-java

   http://github.com/qooxdoo/qxwebdriver-java

   Copyright:
     2014 1&1 Internet AG, Germany, http://www.1und1.de

   License:
     LGPL: http://www.gnu.org/licenses/lgpl.html
     EPL: http://www.eclipse.org/org/documents/epl-v10.php
     See the license.txt file in the project's top-level directory for details.

   Authors:
     * Daniel Wagner (danielwagner)

*************************************************************************/

using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Interactions.Internal;
using Qooxdoo.WebDriver.UI.Core;

namespace Qooxdoo.WebDriver.UI.Mobile.Core
{
    /// <summary>
    /// Base mobile widget implementation
    /// </summary>
    /// <seealso cref="UI.Core.WidgetImpl" />
    /// <seealso cref="ITouchable" />
    public class WidgetImpl : UI.Core.WidgetImpl, ITouchable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WidgetImpl"/> class.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="webDriver">The web driver.</param>
        public WidgetImpl(IWebElement element, QxWebDriver webDriver) : base(element, webDriver)
        {
            // workaround for https://github.com/selendroid/selendroid/issues/337
            ContentElement = element;
        }

        /// <summary>
        /// Determines if the widget is visible by querying the qooxdoo property
        /// <a href="http://demo.qooxdoo.org/current/apiviewer/#qx.ui.core.IWidget~isSeeable!method_public">seeable</a>.
        /// </summary>
        public override bool Displayed
        {
            get
            {
                if (ContentElement.Displayed)
                {
                    string script = "return arguments[0].offsetWidth > 0 || arguments[0].offsetHeight > 0";
                    return ((bool?) JsExecutor.ExecuteScript(script, ContentElement)).Value;
                }

                return false;
            }
        }

        /// <summary>
        /// Performs a single tap on this widget.
        /// </summary>
        public virtual void Tap()
        {
            Tap(Driver.WebDriver, ContentElement);
        }

        /// <summary>
        /// Performs a single tap on the element of the specified driver.
        /// </summary>
        /// <param name="driver">The driver.</param>
        /// <param name="element">The element.</param>
        public static void Tap(IWebDriver driver, IWebElement element)
        {
            if (driver is IHasTouchScreen)
            {
                TouchActions tap = (new TouchActions(driver)).SingleTap(element);
                tap.Perform();
            }
            else
            {
                element.Click();
            }
        }

        /// <summary>
        /// Performs a long tap on this widget.
        /// </summary>
        public virtual void Longtap()
        {
            Longtap(Driver.WebDriver, ContentElement);
        }

        /// <summary>
        /// Performs a long tap on the element of the specified driver.
        /// </summary>
        /// <param name="driver">The driver to use.</param>
        /// <param name="element">The element to long tap.</param>
        public static void Longtap(IWebDriver driver, IWebElement element)
        {
            if (driver is IHasTouchScreen)
            {
                TouchActions longtap = new TouchActions(driver);
                Point center = GetCenter(element);
                longtap.Down(center.X, center.Y);
                longtap.Perform();
                try
                {
                    Thread.Sleep(750);
                }
                catch (ThreadInterruptedException)
                {
                }
                longtap.Up(center.X, center.Y);
                longtap.Perform();
            }
            else
            {
                ILocatable locatable = (ILocatable) element;
                ICoordinates coords = locatable.Coordinates;
                IMouse mouse = ((IHasInputDevices) driver).Mouse;
                mouse.MouseDown(coords);
                try
                {
                    Thread.Sleep(750);
                }
                catch (ThreadInterruptedException)
                {
                }
                mouse.MouseUp(coords);
            }
        }

        /// <summary>
        /// Gets the center of a given element.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns>The center of the element.</returns>
        protected internal static Point GetCenter(IWebElement element)
        {
            Size size = element.Size;
            int halfWidth = size.Width / 2;
            int halfHeight = size.Height / 2;

            Point loc = element.Location;
            int posX = loc.X + halfWidth;
            int posY = loc.Y + halfHeight;

            Point point = new Point(posX, posY);
            return point;
        }

        /// <summary>
        /// Tracks this widget by the given offsets
        /// </summary>
        /// <param name="x">Amount of pixels to move horizontally</param>
        /// <param name="y">Amount of pixels to move vertically</param>
        /// <param name="step">Generate a move event every (step) pixels</param>
        public virtual void Track(int x, int y, int step)
        {
            Track(Driver.WebDriver, ContentElement, x, y, step);
        }

        /// <summary>
        /// Tracks the element of the specified driver by the given offsets
        /// </summary>
        /// <param name="driver">The driver to use.</param>
        /// <param name="element">The element to track.</param>
        /// <param name="x">Amount of pixels to move horizontally</param>
        /// <param name="y">Amount of pixels to move vertically</param>
        /// <param name="step">Generate a move event every (step) pixels</param>
        public static void Track(IWebDriver driver, IWebElement element, int x, int y, int step)
        {
            if (driver is IHasTouchScreen)
            {
                if (step == 0)
                {
                    step = 1;
                    // TODO: no move if step == 0
                }

                Point center = GetCenter(element);

                int posX = center.X;
                int posY = center.Y;

                int endX = posX + x;
                int endY = posY + y;

                TouchActions touchAction = new TouchActions(driver);
                touchAction.Down(posX, posY);

                while ((x < 0 && posX > endX || x > 0 && posX < endX) || (y < 0 && posY > endY || y > 0 && posY < endY))
                {
                    if (x > 0 && posX < endX)
                    {
                        if (posX + step > endX)
                        {
                            posX += endX - (posX + step);
                        }
                        else
                        {
                            posX += step;
                        }
                    }

                    else if (x < 0 && posX > endX)
                    {
                        if (posX - step < endX)
                        {
                            posX -= endX + (posX - step);
                        }
                        else
                        {
                            posX -= step;
                        }
                    }

                    if (y > 0 && posY < endY)
                    {
                        if (posY + step > endY)
                        {
                            posY += endY - (posY + step);
                        }
                        else
                        {
                            posY += step;
                        }
                    }

                    else if (y < 0 && posY > endY)
                    {
                        if (posY - step < endY)
                        {
                            posY -= endY + (posY - step);
                        }
                        else
                        {
                            posY -= step;
                        }
                    }

                    touchAction.Move(posX, posY);
                }

                touchAction.Up(posX, posY).Perform();
            }
            else
            {
                Actions mouseAction = new Actions(driver);
                mouseAction.DragAndDropToOffset(element, x, y);
            }
        }

        /// <summary>
        /// Scrolls the widget to a given position
        /// </summary>
        /// <param name="x">The x position (in pixels) to scroll to </param>
        /// <param name="y">The y position (in pixels) to scroll to </param>
        public virtual void ScrollTo(int x, int y)
        {
            string script = "qx.ui.mobile.core.Widget.getWidgetById(arguments[0].id).scrollTo(" + x + ", " + y + ")";
            IList<IWebElement> scrollContainers = Driver.FindElements(By.CssSelector(".Scroll"));

            using (var itr = scrollContainers.GetEnumerator())
            {
                while (itr.MoveNext())
                {
                    var scroller = itr.Current;
                    if (scroller != null && scroller.Displayed)
                    {
                        Driver.ExecuteScript(script, scroller);
                    }
                }
            }
        }
    }
}