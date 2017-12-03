///////////////////////////////////////////////////////////////////////////////
//
// (C) 2017 ICE TEA GROUP LLC - ALL RIGHTS RESERVED
//
//
//
// ALL INFORMATION CONTAINED HEREIN IS, AND REMAINS
// THE PROPERTY OF ICE TEA GROUP LLC AND ITS SUPPLIERS, IF ANY.
// THE INTELLECTUAL PROPERTY AND TECHNICAL CONCEPTS CONTAINED
// HEREIN ARE PROPRIETARY TO ICE TEA GROUP LLC AND ITS SUPPLIERS
// AND MAY BE COVERED BY U.S. AND FOREIGN PATENTS, PATENT IN PROCESS, AND
// ARE PROTECTED BY TRADE SECRET OR COPYRIGHT LAW.
//
// DISSEMINATION OF THIS INFORMATION OR REPRODUCTION OF THIS MATERIAL
// IS STRICTLY FORBIDDEN UNLESS PRIOR WRITTEN PERMISSION IS OBTAINED
// FROM ICE TEA GROUP LLC.
//
///////////////////////////////////////////////////////////////////////////////

/*************************************************************************

   qxwebdriver-java

   http://github.com/qooxdoo/qxwebdriver-java

   Copyright:
     2012-2013 1&1 Internet AG, Germany, http://www.1und1.de

   License:
     LGPL: http://www.gnu.org/licenses/lgpl.html
     EPL: http://www.eclipse.org/org/documents/epl-v10.php
     See the license.txt file in the project's top-level directory for details.

   Authors:
     * Daniel Wagner (danielwagner)

*************************************************************************/

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Opera;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Safari;
using OpenQA.Selenium.Support.UI;
using Qooxdoo.WebDriver.Resources;
using Qooxdoo.WebDriver.UI;

namespace Qooxdoo.WebDriver
{
    /// <summary>
    /// A Decorator that wraps a <see cref="IWebDriver"/> object,  adding qooxdoo-specific features.
    /// Note that the WebDriver used <strong>must</strong> implement the <see cref="IJavaScriptExecutor"/> interface.
    /// </summary>
    /// <exclude/>
    public class QxWebDriver : IWebDriver, IJavaScriptExecutor, ITakesScreenshot
    {
        #region Fields & Properties

        private IWebDriver _driver;
        internal TimeSpan? ImplictWait;

        /// <summary>
        /// Gets the widget factory used by the QxWebDriver
        /// </summary>
        protected internal IWidgetFactory WidgetFactory { get; set; }

        /// <summary>
        /// Gets the JavaScript executor.
        /// </summary>
        /// <value>
        /// The JavaScript executor.
        /// </value>
        public IJavaScriptExecutor JsExecutor { get; private set; }

        /// <summary>
        /// Gets the JavaScript runner.
        /// </summary>
        /// <value>
        /// The JavaScript runner.
        /// </value>
        public JavaScriptRunner JsRunner { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="QxWebDriver"/> class.
        /// </summary>
        /// <param name="browser">The browser of the webdriver to wrap.</param>
        public QxWebDriver(Browser browser)
        {
            var webdriver = GetWrappedDriver(browser);
            ConstructorCore(webdriver, new DefaultWidgetFactory(this), 4);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QxWebDriver" /> class.
        /// </summary>
        /// <param name="browser">The browser of the webdriver to wrap.</param>
        /// <param name="implicitWaitSeconds">The implicit wait duration in seconds.</param>
        public QxWebDriver(Browser browser, int implicitWaitSeconds)
        {
            var webdriver = GetWrappedDriver(browser);
            ConstructorCore(webdriver, new DefaultWidgetFactory(this), implicitWaitSeconds);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QxWebDriver"/> class.
        /// </summary>
        /// <param name="browser">The browser of the webdriver to wrap.</param>
        /// <param name="widgetFactory">The widget factory to use.</param>
        public QxWebDriver(Browser browser, IWidgetFactory widgetFactory)
        {
            var webdriver = GetWrappedDriver(browser);
            ConstructorCore(webdriver, widgetFactory, 4);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QxWebDriver" /> class.
        /// </summary>
        /// <param name="browser">The browser of the webdriver to wrap.</param>
        /// <param name="widgetFactory">The widget factory to use.</param>
        /// <param name="implicitWaitSeconds">The implicit wait duration in seconds.</param>
        public QxWebDriver(Browser browser, IWidgetFactory widgetFactory, int implicitWaitSeconds)
        {
            var webdriver = GetWrappedDriver(browser);
            ConstructorCore(webdriver, widgetFactory, implicitWaitSeconds);
        }

        private IWebDriver GetWrappedDriver(Browser browser)
        {
            switch (browser)
            {
                case Browser.Chrome: return new ChromeDriver();
                case Browser.Edge: return new EdgeDriver();
                case Browser.Firefox: return new FirefoxDriver();
                case Browser.IE: return new InternetExplorerDriver();
                case Browser.Opera: return new OperaDriver();
                case Browser.PhantomJS: return new PhantomJSDriver();
                default: return new SafariDriver();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QxWebDriver"/> class.
        /// </summary>
        /// <param name="webdriver">The webdriver to wrap.</param>
        public QxWebDriver(IWebDriver webdriver)
        {
            ConstructorCore(webdriver, new DefaultWidgetFactory(this), 4);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QxWebDriver" /> class.
        /// </summary>
        /// <param name="webdriver">The webdriver to wrap.</param>
        /// <param name="implicitWaitSeconds">The implicit wait duration in seconds.</param>
        public QxWebDriver(IWebDriver webdriver, int implicitWaitSeconds)
        {
            ConstructorCore(webdriver, new DefaultWidgetFactory(this), implicitWaitSeconds);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QxWebDriver"/> class.
        /// </summary>
        /// <param name="webdriver">The webdriver to wrap.</param>
        /// <param name="widgetFactory">The widget factory to use.</param>
        public QxWebDriver(IWebDriver webdriver, IWidgetFactory widgetFactory)
        {
            ConstructorCore(webdriver, widgetFactory, 4);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QxWebDriver" /> class.
        /// </summary>
        /// <param name="webdriver">The webdriver to wrap.</param>
        /// <param name="widgetFactory">The widget factory to use.</param>
        /// <param name="implicitWaitSeconds">The implicit wait duration in seconds.</param>
        public QxWebDriver(IWebDriver webdriver, IWidgetFactory widgetFactory, int implicitWaitSeconds)
        {
            ConstructorCore(webdriver, widgetFactory, implicitWaitSeconds);
        }

        private void ConstructorCore(IWebDriver webdriver, IWidgetFactory widgetFactory, int implicitWaitSeconds)
        {
            if (webdriver == null)
                throw new ArgumentNullException(nameof(webdriver));

            _driver = webdriver;
            JsExecutor = (IJavaScriptExecutor) _driver;
            SetImplicitWait(implicitWaitSeconds);
            WidgetFactory = widgetFactory;
            By.SetQxWebDriver(this);
        }

        private void SetImplicitWait(int implicitWaitSeconds)
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(implicitWaitSeconds);
            try
            {
                var seconds = _driver.Manage().Timeouts().ImplicitWait;
            }
            catch (Exception)
            {
                ImplictWait = TimeSpan.FromSeconds(implicitWaitSeconds);
            }
        }

        #endregion

        /// <summary>
        /// A condition that waits until the qooxdoo application in the browser is
        /// ready (<code>qx.core.Init.getApplication()</code> returns anything truthy).
        /// </summary>
        public Func<IWebDriver, bool> QxAppIsReady()
        {
            return driver =>
            {
                object result = null;
#if !DEBUGJS
                string script = JavaScript.Instance.GetValue("isApplicationReady");
                try
                {
                    result = JsExecutor.ExecuteScript(script);
                }
                catch (WebDriverException)
                {
                }
#else
                try
                {
                    result = JsRunner.RunScript("isApplicationReady");
                }
                catch (WebDriverException)
                {
                }
#endif
                var isReady = result != null && (bool) result;
                return isReady;
            };
        }

        /// <summary>
        /// Gets the browser WebDriver instance
        /// </summary>
        public virtual IWebDriver WebDriver
        {
            get { return _driver; }
        }

        /// <summary>
        /// Find the first matching <see cref="IWidget"/> using the specifyed method.
        /// </summary>
        /// <param name="by">The locating mechanism to use.</param>
        /// <param name="timeoutInSeconds">The number of seconds to wait for the widget.</param>
        /// <returns>The first matching widget on the current page.</returns>
        /// <exception cref="NoSuchElementException"> If no matching widget was found before the timeout elapsed </exception>
        /// <seealso cref="By"/>
        internal virtual IWidget FindWidget(OpenQA.Selenium.By by, long timeoutInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.IgnoreExceptionTypes(typeof(InvalidOperationException));
            IWebElement element;
            try
            {
                element = wait.Until(ExpectedConditions.ElementExists(by));
            }
            catch (WebDriverTimeoutException e)
            {
                throw new NoSuchElementException("Unable to find element for locator: " + by, e);
            }
            return GetWidgetForElement(element);
        }

        /// <summary>
        /// Find the first matching <see cref="IWidget"/> using the specifyed method. Retry for up to <see cref="ITimeouts.ImplicitWait"/> seconds
        /// before throwing.
        /// </summary>
        /// <param name="by">The locating mechanism to use.</param>
        /// <returns>The first matching element on the current page.</returns>
        /// <exception cref="NoSuchElementException"> If no matching widget was found before the timeout elapsed </exception>
        /// <seealso cref="By"/>
        public virtual IWidget FindWidget(OpenQA.Selenium.By by)
        {
            long implictWait;
            if (ImplictWait.HasValue)
                implictWait = ImplictWait.Value.Seconds;
            else
                implictWait = Manage().Timeouts().ImplicitWait.Seconds;

            return FindWidget(by, implictWait);
        }

        /// <summary>
        /// Waits until the specified condition is true.
        /// </summary>
        /// <param name="throwException">Throws the <see cref="WebDriverTimeoutException"/>.</param>
        /// <param name="condition">Callback condition function.</param>
        /// <param name="timeoutInSeconds">The number of seconds to wait for the condition.</param>
        public void Wait(Func<bool> condition, bool throwException = false, long timeoutInSeconds = 5)
        {
            if (condition == null)
                throw new ArgumentNullException(nameof(condition));

            WebDriverWait wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.IgnoreExceptionTypes(typeof(InvalidOperationException));
            try
            {
                wait.Until(_ => { return condition(); });
            }
            catch (WebDriverTimeoutException)
            {
                if (throwException)
                    throw;
            }
        }

        /// <summary>
        /// Waits to find the first matching <see cref="IWidget"/> using the specifyed locator.
        /// </summary>
        /// <param name="by">The locating mechanism to use.</param>
        /// <param name="timeoutInSeconds">The number of seconds to wait for the widget.</param>
        /// <returns>The first matching element on the current page.</returns>
        /// <exception cref="NoSuchElementException"> If no matching widget was found before the timeout elapsed </exception>
        /// <seealso cref="By"/>
        public virtual IWidget WaitForWidget(OpenQA.Selenium.By by, long timeoutInSeconds)
        {
            return FindWidget(by, timeoutInSeconds);
        }

        /// <summary>
        /// Returns an instance of <see cref="IWidget"/> or one of its subclasses that
        /// represents the qooxdoo widget containing the specifyed element. </summary>
        /// <param name="element"> A <see cref="IWebElement"/> representing a DOM element that is part of a
        /// qooxdoo widget </param>
        /// <returns>Widget object.</returns>
        public virtual IWidget GetWidgetForElement(IWebElement element)
        {
            return WidgetFactory.GetWidgetForElement(element);
        }

        /// <summary>
        /// Registers a new log appender with the AUT's logging system. Entries can be
        /// accessed using getLogEvents()
        /// </summary>
        public virtual void RegisterLogAppender()
        {
            JsRunner.RunScript("registerLogAppender");
        }

        /// <summary>
        /// Gets the AUT's qx log entries. registerLogAppender() *must* be called
        /// before this can be used.
        /// </summary>
        public virtual IList<Log.LogEntry> LogEvents
        {
            get
            {
                IList<Log.LogEntry> logEntries = new List<Log.LogEntry>();
                IList<string> jsonEntries = (IList<string>) JsRunner.RunScript("getAllLogEvents");
                using (IEnumerator<string> itr = jsonEntries.GetEnumerator())
                {
                    while (itr.MoveNext())
                    {
                        string json = itr.Current;
                        Log.LogEntry entry = new Log.LogEntry(json);
                        logEntries.Add(entry);
                    }
                }
                return logEntries;
            }
        }

        /// <summary>
        /// Registers a global error handler using qx.event.GlobalError.setErrorHandler
        /// Caught exceptions can be retrieved using getCaughtErrors
        /// </summary>
        public virtual void RegisterGlobalErrorHandler()
        {
            JsRunner.RunScript("registerGlobalErrorHandler");
        }

        /// <summary>
        /// Gets any exceptions caught by qooxdoo's global error handling.
        /// RegisterGlobalErrorHandler *must* be called before this can be used.
        /// </summary>
        public virtual IList<string> CaughtErrors
        {
            get { return (IList<string>) JsRunner.RunScript("getCaughtErrors"); }
        }

        /// <summary>
        /// Uses qooxdoo's localization support to get the currently active locale's translation for a string
        /// </summary>
        public virtual string GetTranslation(string @string)
        {
            string js = string.Format("return qx.locale.Manager.getInstance().translate('{0}', []).toString();",
                @string);
            return (string) JsExecutor.ExecuteScript(js, @string);
        }

        /// <summary>
        /// Uses qooxdoo's localization support to get a specific locale's translation for a string
        /// </summary>
        public virtual string GetTranslation(string @string, string locale)
        {
            string js = string.Format("return qx.locale.Manager.getInstance().translate('{0}', [], '{1}').toString();",
                @string, locale);
            return (string) JsExecutor.ExecuteScript(js, @string);
        }

        /// <summary>
        /// Finds the first <see cref="IWebElement" /> using the specifyed method.
        /// </summary>
        /// <param name="by">The locating mechanism to use.</param>
        /// <returns>The first matching <see cref="IWebElement" /> on the current context.</returns>
        /// <exception cref="NoSuchElementException">If no element matches the criteria.</exception>
        public IWebElement FindElement(OpenQA.Selenium.By by)
        {
            return _driver.FindElement(by);
        }

        /// <summary>
        /// Finds all <see cref="IWebElement"/> within the current context
        /// using the specifyed mechanism.
        /// </summary>
        /// <param name="by">The locating mechanism to use.</param>
        /// <returns>A <see cref="ReadOnlyCollection{IWebElement}"/> of all <see cref="IWebElement"/>
        /// matching the current criteria, or an empty list if nothing matches.</returns>
        public ReadOnlyCollection<IWebElement> FindElements(OpenQA.Selenium.By by)
        {
            return _driver.FindElements(by);
        }

        /// <summary>
        /// Gets or sets the URL the browser is currently displaying.
        /// </summary>
        /// <remarks>
        /// Setting the <see cref="OpenQA.Selenium.IWebDriver.Url" /> property will load a new web page in the current browser window.
        /// This is done using an HTTP GET operation, and the method will block until the
        /// load is complete. This will follow redirects issued either by the server or
        /// as a meta-redirect from within the returned HTML. Should a meta-redirect "rest"
        /// for any duration of time, it is best to wait until this timeout is over, since
        /// should the underlying page change while your test is executing the results of
        /// future calls against this interface will be against the freshly loaded page.
        /// </remarks>
        /// <seealso cref="OpenQA.Selenium.INavigation.GoToUrl(System.String)" />
        /// <seealso cref="OpenQA.Selenium.INavigation.GoToUrl(System.Uri)" />
        public string Url
        {
            get { return _driver.Url; }
            set
            {
                _driver.Url = value;
#if !DEBUGJS
                WaitForQxApplication();
                Init();
#else
                Init();
                WaitForQxApplication();
#endif
            }
        }

        /// <summary>
        /// Waits until qx.core.Init.getApplication() returns something truthy.
        /// </summary>
        public virtual void WaitForQxApplication()
        {
            new WebDriverWait(_driver, TimeSpan.FromSeconds(30)).Until(QxAppIsReady());
        }

        /// <summary>
        /// Initializes the testing environment.
        /// </summary>
        public virtual void Init()
        {
            JsRunner = new JavaScriptRunner(JsExecutor);
#if !DEBUGJS
            // make sure getWidgetByElement is defined so other scripts can use it
            JsRunner.DefineFunction("getWidgetByElement");
#endif
        }

        /// <summary>
        /// Gets the source of the page last loaded by the browser.
        /// </summary>
        /// <remarks>
        /// If the page has been modified after loading (for example, by JavaScript)
        /// there is no guarantee that the returned text is that of the modified page.
        /// Please consult the documentation of the particular driver being used to
        /// determine whether the returned text reflects the current state of the page
        /// or the text last sent by the web server. The page source returned is a
        /// representation of the underlying DOM: do not expect it to be formatted
        /// or escaped in the same way as the response sent from the web server.
        /// </remarks>
        public string PageSource
        {
            get { return _driver.PageSource; }
        }

        /// <summary>
        /// Gets the title of the current browser window.
        /// </summary>
        public string Title
        {
            get { return _driver.Title; }
        }

        /// <summary>
        /// Gets the current window handle, which is an opaque handle to this
        /// window that uniquely identifies it within this driver instance.
        /// </summary>
        public string CurrentWindowHandle
        {
            get { return _driver.CurrentWindowHandle; }
        }

        /// <summary>Gets the window handles of open browser windows.</summary>
        public ReadOnlyCollection<string> WindowHandles
        {
            get { return _driver.WindowHandles; }
        }

        /// <summary>
        /// Instructs the driver to change its settings.
        /// </summary>
        /// <returns>An <see cref="OpenQA.Selenium.IOptions" /> object allowing the user to change
        /// the settings of the driver.</returns>
        public IOptions Manage()
        {
            return _driver.Manage();
        }

        /// <summary>
        /// Instructs the driver to navigate the browser to another location.
        /// </summary>
        /// <returns>An <see cref="OpenQA.Selenium.INavigation" /> object allowing the user to access
        /// the browser's history and to navigate to the specifyed URL.</returns>
        public INavigation Navigate()
        {
            return _driver.Navigate();
        }

        /// <summary>
        /// Instructs the driver to send future commands to a different frame or window.
        /// </summary>
        /// <returns>An <see cref="ITargetLocator" /> object which can be used to select
        /// a frame or window.</returns>
        public ITargetLocator SwitchTo()
        {
            return _driver.SwitchTo();
        }

        /// <summary>
        /// Executes JavaScript asynchronously in the context of the currently selected frame or window.
        /// </summary>
        /// <param name="script">The JavaScript code to execute.</param>
        /// <param name="args">The arguments to the script.</param>
        /// <returns>The value returned by the script.</returns>
        public object ExecuteAsyncScript(string script, params object[] args)
        {
            return JsExecutor.ExecuteAsyncScript(script, args);
        }

        /// <summary>
        /// Executes JavaScript in the context of the currently selected frame or window.
        /// </summary>
        /// <param name="script">The JavaScript code to execute.</param>
        /// <param name="args">The arguments to the script.</param>
        /// <returns>The value returned by the script.</returns>
        /// <remarks>
        ///     <para>
        /// The <see cref="IJavaScriptExecutor.ExecuteScript(string, object[])" />method executes JavaScript in the context of
        /// the currently selected frame or window. This means that "document" will refer
        /// to the current document. If the script has a return value, then the following
        /// steps will be taken:
        /// </para>
        ///     <para>
        ///         <list type="bullet">
        ///             <item>
        ///                 <description>For an HTML element, this method returns a <see cref="IWebElement" /></description>
        ///             </item>
        ///             <item>
        ///                 <description>For a number, a <see cref="long" /> is returned</description>
        ///             </item>
        ///             <item>
        ///                 <description>For a boolean, a <see cref="bool" /> is returned</description>
        ///             </item>
        ///             <item>
        ///                 <description>For all other cases a <see cref="string" /> is returned.</description>
        ///             </item>
        ///             <item>
        ///                 <description>For an array, we check the first element, and attempt to return a List of that type, 
        /// following the rules above. Nested lists are not supported.</description>
        ///             </item>
        ///             <item>
        ///                 <description>If the value is null or there is no return value,
        /// <see langword="null" /> is returned.</description>
        ///             </item>
        ///         </list>
        ///     </para>
        ///     <para>
        /// Arguments must be a number (which will be converted to a <see cref="long" />),
        /// a <see cref="bool" />, a <see cref="string" /> or a <see cref="IWebElement" />.
        /// An exception will be thrown if the arguments do not meet these criteria.
        /// The arguments will be made available to the JavaScript via the "arguments" magic
        /// variable, as if the function were called via "Function.apply"
        /// </para>
        /// </remarks>
        public object ExecuteScript(string script, params object[] args)
        {
            return JsExecutor.ExecuteScript(script, args);
        }

        #region Terminators

        /// <summary>
        /// Close the current window, quitting the browser if it is the last window currently open.
        /// </summary>
        public void Close()
        {
            _driver.Close();
        }

        /// <summary>
        /// Quits this driver, closing every associated window.
        /// </summary>
        public void Quit()
        {
            _driver.Quit();
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            _driver.Dispose();
            _driver = null;
        }

        #endregion

        #region TakesScreenshot

        /// <summary>
        /// Returns a OpenQA.Selenium.Screenshot object representing the image of the page on
        /// the screen.
        /// </summary>
        /// <returns>A OpenQA.Selenium.Screenshot object containing the image.</returns>
        public Screenshot GetScreenshot()
        {
            return ((ITakesScreenshot) WebDriver).GetScreenshot();
        }

        /// <summary>
        /// Saves a screen image to the specified <para>fileName</para> in the
        /// specified <para>format</para>.
        /// </summary>
        /// <param name="fileName">The file where to save the screen image.</param>
        /// <param name="format">The <see cref="ScreenshotImageFormat"/> format of the images.</param>
        public void SaveScreenshot(string fileName, ScreenshotImageFormat format = ScreenshotImageFormat.Png)
        {
            var screenshot = GetScreenshot();
            screenshot.SaveAsFile(fileName, format);
        }

        /// <summary>
        /// Returns an <see cref="Image"/> representing a screen image of the test browser.
        /// </summary>
        /// <param name="format">The <see cref="ScreenshotImageFormat"/> format of the images.</param>
        public Image GetScreenshot(ScreenshotImageFormat format = ScreenshotImageFormat.Png)
        {
            var screenshot = GetScreenshot();
            return Image.FromStream(new MemoryStream(screenshot.AsByteArray));
        }

        #endregion
    }
}