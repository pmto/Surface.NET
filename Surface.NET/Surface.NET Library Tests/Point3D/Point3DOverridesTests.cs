using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Surface.NET_Library_Tests.Point3D {
    [TestCategory("Point3D Overrides")]
    [TestClass]
    public class Point3DOverridesTests {
        private SurfaceLib.Types.Point3D _point;

        [TestCategory("Point3D Overrides")]
        [TestInitialize]
        public void Initialize() {
            this._point = new SurfaceLib.Types.Point3D(3.2, 5.1, 4);
        }

        [TestCategory("Point3D Overrides")]
        [TestMethod]
        public void GetHashCodeTest() {
            var expected =
                this._point.XAxis.GetHashCode() ^
                this._point.YAxis.GetHashCode() ^
                this._point.ZAxis.GetHashCode();
            var actual = this._point.GetHashCode();

            Assert.AreEqual(expected, actual);
        }

        [TestCategory("Point3D Overrides")]
        [TestMethod]
        public void EqualsTest() {
            var temp = new SurfaceLib.Types.Point3D(2, 4.1, 5);
            var actual = this._point.Equals(temp);

            Assert.IsFalse(actual);
        }

        [TestCategory("Point3D Overrides")]
        [TestMethod]
        public void ToStringTest() {
            var expected = $"3.2,5.1,4";
            var actual = this._point.ToString();

            Assert.AreEqual(expected, actual);
        }
    }
}