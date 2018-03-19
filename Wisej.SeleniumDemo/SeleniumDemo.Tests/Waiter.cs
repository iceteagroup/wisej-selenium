namespace SeleniumDemo.Tests
{
    public static class Waiter
    {
        public static int BrowserUpdate { get; set; } = 500;
#if DEBUG
        public const int Duration = 500;
#else
        public const int Duration = 2000;
#endif
    }
}