using System;
using System.IO;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace SeleniumDemo.Tests
{
    public abstract partial class SeleniumDemoBase
    {
        protected static string TestOutputFolder;

        public static void SetupTestOutputFolder()
        {
            var curDir =
                Directory.CreateDirectory(TestContext.CurrentContext.TestDirectory + @"\..\..\..\TestResults");
            if (!Directory.Exists(curDir.FullName))
                Directory.CreateDirectory(curDir.FullName);

            curDir = Directory.CreateDirectory(curDir.FullName + @"\Test-" +
                                               DateTime.Now.ToString("s").Replace("T", "-T-").Replace(":", "_"));

            Directory.CreateDirectory(curDir.FullName);

            TestOutputFolder = curDir.FullName;
        }

        public static void TearDownTestOutputFolder()
        {
            Directory.SetCurrentDirectory(TestContext.CurrentContext.TestDirectory);

            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Passed)
                Directory.Delete(TestOutputFolder, true);
        }
    }
}