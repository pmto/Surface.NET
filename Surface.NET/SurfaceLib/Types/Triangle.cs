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
// FILE: Surface.NET/Surface.NET Library/Triangle.cs
// MODIFIED: 26.02.2018 8:56
// DEVELOPER: MyCatShoegazer <mycatshoegazer@outlook.com>

using System;

namespace SurfaceLib.Types {
    /// <summary>
    ///     A class defining a triangle consisting of three vertices (aka points).
    /// </summary>
    public class Triangle {
        #region constructors

        /// <summary>
        ///     Constructs triangle from three vertices of type <see cref="Point3D" />.
        /// </summary>
        /// <param name="vertex1">
        ///     First vertex of triangle represented by <see cref="Point3D" />.
        /// </param>
        /// <param name="vertex2">
        ///     Second vertex of triangle represented by <see cref="Point3D" />.
        /// </param>
        /// <param name="vertex3">
        ///     Third vertex of triangle represented by <see cref="Point3D" />.
        /// </param>
        public Triangle(Point3D vertex1, Point3D vertex2, Point3D vertex3) {
            this.Vertex1 = vertex1;
            this.Vertex2 = vertex2;
            this.Vertex3 = vertex3;
        }

        #endregion

        #region properties

        /// <summary>
        ///     First vertex of triangle represented by <see cref="Point3D" />.
        /// </summary>
        public Point3D Vertex1 { get; }

        /// <summary>
        ///     Second vertex of triangle represented by <see cref="Point3D" />.
        /// </summary>
        public Point3D Vertex2 { get; }

        /// <summary>
        ///     Third vertex of triangle represented by <see cref="Point3D" />.
        /// </summary>
        public Point3D Vertex3 { get; }

        #endregion

        #region methods

        /// <summary>
        ///     Tests if a point lies in the circumcircle of the triangle.
        /// </summary>
        /// <param name="point">
        ///     A <see cref="Point3D" /> object to test.
        /// </param>
        /// <returns>
        ///     For a counterclockwise order of the vertices of the triangle, this test is
        ///     <list type="bullet">
        ///         <item>
        ///             positive if <paramref name="point" /> lies inside the circumcircle.
        ///         </item>
        ///         <item>
        ///             zero if <paramref name="point" /> lies on the circumference of the circumcircle.
        ///         </item>
        ///         <item>
        ///             negative if <paramref name="point" /> lies outside the circumcircle.
        ///         </item>
        ///     </list>
        /// </returns>
        /// <remarks>
        ///     The vertices of the triangle must be arranged in counterclockwise order or the result
        ///     of this test will be reversed. This test ignores the z-coordinate of the vertices.
        /// </remarks>
        public double ContainsInCircumcircle(Point3D point) {
            var ax = this.Vertex1.XAxis - point.XAxis;
            var ay = this.Vertex1.YAxis - point.YAxis;

            var bx = this.Vertex2.XAxis - point.XAxis;
            var by = this.Vertex2.YAxis - point.YAxis;

            var cx = this.Vertex3.XAxis - point.XAxis;
            var cy = this.Vertex3.YAxis - point.YAxis;

            var detAb = ax * by - bx * ay;
            var detBc = bx * cy - cx * by;
            var detCa = cx * ay - ax * cy;

            var aSquared = ax * ax + ay * ay;
            var bSquared = bx * bx + by * by;
            var cSquared = cx * cx + cy * cy;

            return aSquared * detBc + bSquared * detCa + cSquared * detAb;
        }

        /// <summary>
        ///     Tests if two triangles share at least one vertex of type <see cref="Point3D" />.
        /// </summary>
        /// <param name="triangle">
        ///     A <see cref="Triangle" /> object to test.
        /// </param>
        /// <returns>
        ///     Returns true if two triangles share at least one vertex, false otherwise.
        /// </returns>
        public bool SharesVertexWith(Triangle triangle) {
            const float tolerance = 0.001f;

            if (Math.Abs(this.Vertex1.XAxis - triangle.Vertex1.XAxis) < tolerance &&
                Math.Abs(this.Vertex1.YAxis - triangle.Vertex1.YAxis) < tolerance) return true;
            if (Math.Abs(this.Vertex1.XAxis - triangle.Vertex2.XAxis) < tolerance &&
                Math.Abs(this.Vertex1.YAxis - triangle.Vertex2.YAxis) < tolerance) return true;
            if (Math.Abs(this.Vertex1.XAxis - triangle.Vertex3.XAxis) < tolerance &&
                Math.Abs(this.Vertex1.YAxis - triangle.Vertex3.YAxis) < tolerance) return true;

            if (Math.Abs(this.Vertex2.XAxis - triangle.Vertex1.XAxis) < tolerance &&
                Math.Abs(this.Vertex2.YAxis - triangle.Vertex1.YAxis) < tolerance) return true;
            if (Math.Abs(this.Vertex2.XAxis - triangle.Vertex2.XAxis) < tolerance &&
                Math.Abs(this.Vertex2.YAxis - triangle.Vertex2.YAxis) < tolerance) return true;
            if (Math.Abs(this.Vertex2.XAxis - triangle.Vertex3.XAxis) < tolerance &&
                Math.Abs(this.Vertex2.YAxis - triangle.Vertex3.YAxis) < tolerance) return true;

            if (Math.Abs(this.Vertex3.XAxis - triangle.Vertex1.XAxis) < tolerance &&
                Math.Abs(this.Vertex3.YAxis - triangle.Vertex1.YAxis) < tolerance) return true;
            if (Math.Abs(this.Vertex3.XAxis - triangle.Vertex2.XAxis) < tolerance &&
                Math.Abs(this.Vertex3.YAxis - triangle.Vertex2.YAxis) < tolerance) return true;
            return Math.Abs(this.Vertex3.XAxis - triangle.Vertex3.XAxis) < tolerance &&
                   Math.Abs(this.Vertex3.YAxis - triangle.Vertex3.YAxis) < tolerance;
        }

        #endregion
    }
}