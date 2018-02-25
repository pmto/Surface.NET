// Surface.NET, Surface.NET Library
// Copyright (C) 2018  MyCatShoegazer
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
// FILE: Surface.NET/Surface.NET Library/Point3D.cs
// MODIFIED: 25.02.2018 21:39
// DEVELOPER: MyCatShoegazer <mycatshoegazer@outlook.com>

using System;
using System.Globalization;

namespace SurfaceLib.Types {
    /// <inheritdoc />
    /// <summary>
    ///     Class defining 3D point on surface with coordinates <see cref="!:XAxis" />, <see cref="!:YAxis" /> and
    ///     <see cref="ZAxis" />.
    /// </summary>
    public class Point3D : Point2D {
        #region constructors

        /// <inheritdoc />
        /// <summary>
        ///     Create an instance of <see cref="T:SurfaceLib.Types.Point3D" /> with passed arguments for X-axis, Y-axis and
        ///     Z-axis.
        /// </summary>
        /// <param name="xAxis">X-coordinate of point as <see cref="T:System.Double" />.</param>
        /// <param name="yAxis">Y-coordinate of point as <see cref="T:System.Double" />.</param>
        /// <param name="zAxis">Z-coordinate of point as <see cref="T:System.Double" />.</param>
        public Point3D(double xAxis, double yAxis, double zAxis) : base(xAxis, yAxis) {
            this.ZAxis = zAxis;
        }

        #endregion

        #region properties

        /// <summary>
        ///     Z-coordinate of point in <see cref="double" />.
        /// </summary>
        public double ZAxis { get; }

        #endregion

        #region overrides

        /// <inheritdoc />
        /// <summary>
        ///     Creates a hash code for the current instance.
        /// </summary>
        /// <returns>
        ///     Returns hash code represented by <see cref="T:System.Int32" /> for this object
        /// </returns>
        public override int GetHashCode() {
            var zHash = this.ZAxis.GetHashCode();

            return base.GetHashCode() ^ zHash;
        }

        /// <inheritdoc />
        /// <summary>
        ///     Determines passed object equal to current.
        /// </summary>
        /// <param name="obj">
        ///     Object which should be equal.
        /// </param>
        /// <returns>
        ///     Returns value <see langword="true" />, if passed object is equal to current; else - value <see langword="false" />.
        /// </returns>
        public override bool Equals(object obj) {
            return this == (Point3D) obj;
        }

        /// <inheritdoc />
        /// <summary>
        ///     Represents current object as <see cref="T:System.String" /> like <code>""x","y","z""</code> as CSV line.
        /// </summary>
        /// <returns>
        ///     Returns <see cref="T:System.String" /> with <code>""x,y""</code> coordinates as CSV line.
        /// </returns>
        public override string ToString() {
            return $"{base.ToString()},{this.ZAxis.ToString(CultureInfo.InvariantCulture)}";
        }

        #endregion

        #region operators

        /// <summary>
        ///     Operator == checks if left and right operand are equal.
        /// </summary>
        /// <param name="left">
        ///     Left operand of type <see cref="Point3D" />.
        /// </param>
        /// <param name="right">
        ///     Right operand of type <see cref="Point3D" />.
        /// </param>
        /// <returns>
        ///     Returns value <see langword="true" />, if passed objects left and right are equal; else - value
        ///     <see langword="false" />.
        /// </returns>
        public static bool operator ==(Point3D left, Point3D right) {
            if (left == (object) right)
                return true;

            if ((object) left == null || (object) right == null)
                return false;

            const float tolerance = 0.001f;
            if (Math.Abs(left.XAxis - right.XAxis) > tolerance)
                return false;

            return !(Math.Abs(left.YAxis - right.YAxis) > tolerance);
        }

        /// <summary>
        ///     Operator != checks if left and right operand are not equal.
        /// </summary>
        /// <param name="left">
        ///     Left operand of type <see cref="Point3D" />.
        /// </param>
        /// <param name="right">
        ///     Right operand of type <see cref="Point3D" />.
        /// </param>
        /// <returns>
        ///     Returns value <see landword="true" />, if passed objects left and right are not equal; else - value
        ///     <see langword="false" />.
        /// </returns>
        public static bool operator !=(Point3D left, Point3D right) {
            return !(left == right);
        }

        #endregion
    }
}