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
// FILE: Surface.NET/Surface.NET Library/Point2D.cs
// MODIFIED: 22.02.2018 10:41
// DEVELOPER: MyCatShoegazer <mycatshoegazer@outlook.com>

using System;

#pragma warning disable 252,253

namespace SurfaceLib.Types {
    /// <summary>
    ///     Class defining 2D point on surface with coordinates <see cref="XAxis"/> and <see cref="YAxis"/>.
    /// </summary>
    public class Point2D {
        #region constructor

        /// <summary>
        ///     Create an instance of <see cref="Point2D" /> with passed arguments for X-axis and Y-axis.
        /// </summary>
        /// <param name="xAxis">X-coordinate of point as <see cref="double" />.</param>
        /// <param name="yAxis">Y-coordinate of point as <see cref="double" />.</param>
        public Point2D(double xAxis, double yAxis) {
            this.XAxis = xAxis;
            this.YAxis = yAxis;
        }

        #endregion

        #region properties

        /// <summary>
        ///     X-coordinate of point in <see cref="double"/>.
        /// </summary>
        public double XAxis { get; }

        /// <summary>
        ///     Y-coordinate of point in <see cref="double"/>.
        /// </summary>
        public double YAxis { get; }

        #endregion

        #region overrides

        /// <summary>
        ///     Creates a hash code for the current instance.
        /// </summary>
        /// <returns>
        ///     Returns hash code represented by <see cref="int" /> for this object
        /// </returns>
        public override int GetHashCode() {
            var xHash = this.XAxis.GetHashCode();
            var yHash = this.YAxis.GetHashCode();

            return xHash ^ yHash;
        }

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
            return this == (Point2D) obj;
        }

        /// <summary>
        ///     Represents current object as <see cref="string"/> like <code>""x","y""</code> as CSV line.
        /// </summary>
        /// <returns>
        ///     Returns <see cref="string"/> with <code>""x,y""</code> coordinates as CSV line.
        /// </returns>
        public override string ToString() => $"\"{this.XAxis}\",\"{this.YAxis}\"";

        #endregion

        #region operators

        /// <summary>
        ///     Operator == checks if left and right operand are equal.
        /// </summary>
        /// <param name="left">
        ///     Left operand of type <see cref="Point2D" />.
        /// </param>
        /// <param name="right">
        ///     Right operand of type <see cref="Point2D" />.
        /// </param>
        /// <returns>
        ///     Returns value <see langword="true" />, if passed objects left and right are equal; else - value
        ///     <see langword="false" />.
        /// </returns>
        public static bool operator ==(Point2D left, Point2D right) {
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
        ///     Left operand of type <see cref="Point2D" />.
        /// </param>
        /// <param name="right">
        ///     Right operand of type <see cref="Point2D" />.
        /// </param>
        /// <returns>
        ///     Returns value <see landword="true" />, if passed objects left and right are not equal; else - value
        ///     <see langword="false" />.
        /// </returns>
        public static bool operator !=(Point2D left, Point2D right) {
            return !(left == right);
        }

        #endregion
    }
}