using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Surface.NET_Library_Tests.Point2D {
    [TestCategory("Point2D Operators")]
    [TestClass]
    public class Point2DOperatorsTests {
        [TestCategory("Point2D Operators")]
        [TestMethod]
        public void OperatorEqualTest() {
            var firstPoint = new SurfaceLib.Types.Point2D(2.3f, 1.5f);
            var secondPoint = new SurfaceLib.Types.Point2D(2.3f, 1.5f);
            var actual = firstPoint == secondPoint;

            Assert.IsTrue(actual);
        }

        [TestCategory("Point2D Operators")]
        [TestMethod]
        public void OperatorNotEqualTest() {
            var firstPoint = new SurfaceLib.Types.Point2D(2.6f, 1.3f);
            var secondPoint = new SurfaceLib.Types.Point2D(0.4f, 1.4f);
            var actual = firstPoint != secondPoint;

            Assert.IsTrue(actual);
        }
    }
}