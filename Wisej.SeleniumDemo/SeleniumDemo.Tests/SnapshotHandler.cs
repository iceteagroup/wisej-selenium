using System.Drawing.Imaging;
using System.IO;
using Microsoft.Test.VisualVerification;
using NUnit.Framework;

namespace SeleniumDemo.Tests
{
    public abstract partial class SeleniumDemoBase
    {
        private string Masters
        {
            get
            {
                return Path.GetFullPath(TestContext.CurrentContext.TestDirectory +
                                        $@"\..\..\..\Snapshots\{CurrentBrowser}\Masters\");
            }
        }

        private string ToleranceMaps
        {
            get
            {
                return Path.GetFullPath(TestContext.CurrentContext.TestDirectory +
                                        $@"\..\..\..\Snapshots\{CurrentBrowser}\ToleranceMaps\");
            }
        }

        private ImageFormat _currentImageFormat = ImageFormat.Png;

        public void MakeScreenshotCollection(string filename, ImageFormat currentImageFormat)
        {
            _currentImageFormat = currentImageFormat;
            MakeScreenshotCollection(filename);
        }

        public void MakeScreenshotCollection(string filename)
        {
            // if this the correct screenshot
            Snapshot actual = Snapshot.FromFile(filename + "." + _currentImageFormat);

            var master = Masters + filename + "." + _currentImageFormat;
            // duplicate as master, if it does not exist
            if (!File.Exists(master))
                actual.ToFile(master, _currentImageFormat);

            // compare with itself to get a tolerance map
            Snapshot tolerance = actual.CompareTo(actual);

            var toleranceMap = ToleranceMaps + filename + "." + _currentImageFormat;

            // save the tolerance map, if it does not exist
            if (!File.Exists(toleranceMap))
                tolerance.ToFile(toleranceMap, _currentImageFormat);
        }

        public void VerifyScreenshot(string filename, ImageFormat currentImageFormat)
        {
            _currentImageFormat = currentImageFormat;
            VerifyScreenshot(filename);
        }

        public void VerifyScreenshot(string filename)
        {
            Snapshot actual = Snapshot.FromFile(filename + "." + _currentImageFormat);
            Snapshot master = Snapshot.FromFile(Masters + filename + "." + _currentImageFormat);
            Snapshot toleranceMap = Snapshot.FromFile(ToleranceMaps + filename + "." + _currentImageFormat);
            Snapshot difference = actual.CompareTo(master);
            SnapshotVerifier verifier = new SnapshotToleranceMapVerifier(toleranceMap);
            Assert.AreEqual(VerificationResult.Pass, verifier.Verify(difference));
        }
    }
}