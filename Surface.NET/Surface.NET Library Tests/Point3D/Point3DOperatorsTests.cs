using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Surface.NET_Library_Tests.Point3D {
    [TestCategory("Point3D Operators")]
    [TestClass]
    public class Point3DOperatorsTests {
        private SurfaceLib.Types.Point3D _pointLeft;
        private SurfaceLib.Types.Point3D _pointRight;

        [TestCategory("Point3D Operators")]
        [TestInitialize]
        public void Initialize() {
            this._pointLeft = new SurfaceLib.Types.Point3D(3.1, 4.2, 5);
            this._pointRight = new SurfaceLib.Types.Point3D(4.1, 4, 3);
        }

        [TestCategory("Point3D Operators")]
        [TestMethod]
        public void OperatorEqualObjectTest() {
            var actual = this._pointLeft == this._pointRight;

            Assert.IsFalse(actual);
        }

        [TestCategory("Point3D Operators")]
        [TestMethod]
        public void OperatorEqualNullTest() {
            SurfaceLib.Types.Point3D temp = null;
            var actual = this._pointLeft == temp;

            Assert.IsFalse(actual);
        }
    }
}