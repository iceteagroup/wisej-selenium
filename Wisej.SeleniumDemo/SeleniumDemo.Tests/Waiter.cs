namespace SeleniumDemo.Tests
{
    public static class Waiter
    {
        public static int BrowserUpdate = 500;
#if DEBUG
        public static int Duration = 2000;
#else
        public static int Duration = 200;
#endif
    }
}