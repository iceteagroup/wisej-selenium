using System.Threading;

namespace Wisej.Web.Ext.Selenium.Tests
{
    /// <summary>
    /// Helper method for sleeping a thread when debugging.
    /// </summary>
    public static class HelperDebug
    {
        /// <summary>
        /// When debugging tests, suspends the current thread for a specified time..
        /// </summary>
        /// <param name="driver">The <see cref="WisejWebDriver"/> to use.</param>
        /// <param name="millisecondsTimeout">The number of milliseconds for which the thread is blocked.
        /// Defaults to 1000 milliseconds.</param>
        public static void SleepDebugTest(this WisejWebDriver driver, int millisecondsTimeout = 1000)
        {
            if (millisecondsTimeout == 0 || millisecondsTimeout == Timeout.Infinite)
                millisecondsTimeout = 1000;

            if (System.Diagnostics.Debugger.IsAttached)
                driver.Sleep(millisecondsTimeout);
        }
    }
}