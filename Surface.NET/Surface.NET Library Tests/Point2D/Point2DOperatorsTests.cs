using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Surface.NET_Library_Tests.Point2D {
    [TestCategory("Point2D Operators")]
    [TestClass]
    public class Point2DOperatorsTests {
        [TestCategory("Point2D Operators")]
        [TestMethod]
        public void OperatorEqualTest() {
            var firstPoint = new SurfaceLib.Types.Point2D(2.3, 1.5);
            var secondPoint = new SurfaceLib.Types.Point2D(2.3, 1.5);
            var actual = firstPoint == secondPoint;

            Assert.IsTrue(actual);
        }

        [TestCategory("Point2D Operators")]
        [TestMethod]
        public void OperatorNotEqualTest() {
            var firstPoint = new SurfaceLib.Types.Point2D(2.6, 1.3);
            var secondPoint = new SurfaceLib.Types.Point2D(0.4, 1.4);
            var actual = firstPoint != secondPoint;

            Assert.IsTrue(actual);
        }
    }
}