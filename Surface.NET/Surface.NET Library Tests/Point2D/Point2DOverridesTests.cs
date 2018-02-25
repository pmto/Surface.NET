using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Surface.NET_Library_Tests.Point2D {
    [TestCategory("Point2D Overrides")]
    [TestClass]
    public class Point2DOverridesTests {
        private SurfaceLib.Types.Point2D _point;

        [TestCategory("Point2D Overrides")]
        [TestInitialize]
        public void Initialize() {
            this._point = new SurfaceLib.Types.Point2D(4, 3.1);
        }

        [TestCategory("Point2D Overrides")]
        [TestMethod]
        public void GetHashCodeTest() {
            var expected =
                this._point.XAxis.GetHashCode() ^
                this._point.YAxis.GetHashCode();
            var actual = this._point.GetHashCode();

            Assert.AreEqual(expected, actual);
        }

        [TestCategory("Point2D Overrides")]
        [TestMethod]
        public void EqualsTest() {
            var temp = new SurfaceLib.Types.Point2D(2.0, 3.2);
            var actual = this._point.Equals(temp);

            Assert.IsFalse(actual);
        }

        [TestCategory("Point2D Overrides")]
        [TestMethod]
        public void ToStringTest() {
            var expected = $"\"{this._point.XAxis}\",\"{this._point.YAxis}\"";
            var actual = this._point.ToString();

            Assert.AreEqual(expected, actual);
        }
    }
}