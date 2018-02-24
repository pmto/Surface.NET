using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Surface.NET_Library_Tests.Point2D {
    [TestCategory("Point2D Overrides")]
    [TestClass]
    public class Point2DOverridesTests {
        [TestCategory("Point2D Overrides")]
        [TestMethod]
        public void GetHashCodeTest() {
            var point = new SurfaceLib.Types.Point2D(2.0f, 3.2f);
            var expected = point.GetHashCode();
            var actual = point.GetHashCode();
            Assert.AreEqual(expected, actual);
        }

        [TestCategory("Point2D Overrides")]
        [TestMethod]
        public void EqualsTest() {
            var firstPoint = new SurfaceLib.Types.Point2D(2.0f, 3.2f);
            var secondPoint = new SurfaceLib.Types.Point2D(2.0f, 3.2f);
            var actual = firstPoint.Equals(secondPoint);

            Assert.IsTrue(actual);
        }

        [TestCategory("Point2D Overrides")]
        [TestMethod]
        public void NotEqualsTest() {
            var firstPoint = new SurfaceLib.Types.Point2D(2.0f, 3.2f);
            var secondPoint = new SurfaceLib.Types.Point2D(3.2f, 1.4f);
            var actual = firstPoint.Equals(secondPoint);

            Assert.IsFalse(actual);
        }

        [TestCategory("Point2D Overrides")]
        [TestMethod]
        public void ToStringTest() {
            var x = 5.1;
            var y = 4.3;
            var point = new SurfaceLib.Types.Point2D(5.1, 4.3);
            var expected = $"\"{x}\",\"{y}\"";
            var actual = point.ToString();

            Assert.AreEqual(expected, actual);
        }
    }
}