﻿// Surface.NET, Surface.NET Library
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
// FILE: Surface.NET/Surface.NET Library/Delaunay.cs
// MODIFIED: 14.03.2018 19:02
// DEVELOPER: MyCatShoegazer <mycatshoegazer@outlook.com>

using System;
using System.Collections.Generic;
using System.Linq;
using SurfaceLib.Types;

namespace SurfaceLib.Filters {
    /// <summary>
    ///     A 2D Delaunay triangulation class.
    /// </summary>
    /// <remarks>
    ///     The triangulation doesn't support multiple points with identical x and y coordinates,
    ///     nor does it support dublicate points.
    ///     Vertex-lists with duplicate points may result in strange triangulations with intersecting edges or
    ///     may cause the algorithm to fail.
    ///     Uses a simple O(n**2) algorithm based on Paul Bourke's "An Algorithm for Interpolating
    ///     Irregularly-Spaced Data with Applications in Terrain Modelling".
    ///     Uses an enhanced incircle-predicate for counterclockwise orientated triangles.
    /// </remarks>
    public class DelaunayFilter2D {
        #region methods

        /// <summary>
        ///     Performs the 2D Delaunay triangulation on a set of n vertices in O(n**2) time.
        /// </summary>
        /// <param name="triangulationPoints">
        ///     The points to triangulate.
        /// </param>
        /// <returns>
        ///     A list of Delaunay-triangles.
        /// </returns>
        public IList<Triangle> Triangulate(ref IList<Point3D> triangulationPoints) {
            if (triangulationPoints.Count < 3)
                throw new ArgumentException("Can not triangulate less than three vertices!");

            // The triangle list
            var triangles = new List<Triangle>();

            /*
             * The "supertriangle" which encompasses all triangulation points.
             * This triangle initializes the algorithm and will be removed later.
             */
            var superTriangle = SuperTriangle(ref triangulationPoints);
            triangles.Add(superTriangle);

            /*
             * Include each point one at a time
             * into the existing triangulation.
             */
            foreach (var triangulationPoint in triangulationPoints) {
                // Initialize the edge buffer
                var edgeBuffer = new List<Edge>();

                /*
                 * If the actual vertex lies inside the circumcircle, then the three edges of the 
                 * triangle are added to the edge buffer and the triangle is removed from list.
                 */
                for (var j = triangles.Count - 1; j >= 0; j--) {
                    var triangle = triangles[j];
                    if (!(triangle.ContainsInCircumcircle(triangulationPoint) > 0)) continue;
                    edgeBuffer.Add(new Edge(triangle.Vertex1, triangle.Vertex2));
                    edgeBuffer.Add(new Edge(triangle.Vertex2, triangle.Vertex3));
                    edgeBuffer.Add(new Edge(triangle.Vertex3, triangle.Vertex1));
                    triangles.RemoveAt(j);
                }

                /*
                 * Remove duplicate edges. This leaves the convex hull of the edges.
                 * The edges in this convex hull are oriented counterclockwise!
                 */
                for (var j = edgeBuffer.Count - 2; j >= 0; j--)
                for (var k = edgeBuffer.Count - 1; k >= j + 1; k--) {
                    if (edgeBuffer[j] != edgeBuffer[k]) continue;
                    edgeBuffer.RemoveAt(k);
                    edgeBuffer.RemoveAt(j);
                    k--;
                }

                /*
                 * Generate new counterclockwise oriented triangles filling the "hole" in the existing triangulation.
                 * These triangles all share the actual vertex.
                 */
                triangles.AddRange(
                    edgeBuffer.Select(t => new Triangle(t.StartPoint3D, t.EndPoint3D, triangulationPoint)));
            }

            /*
             * We don't want the supertriangle in the triangulation,
             * so remove all triangles sharing a vertex with the supertriangle.
             */
            for (var i = triangles.Count - 1; i >= 0; i--)
                if (triangles[i].SharesVertexWith(superTriangle))
                    triangles.RemoveAt(i);

            // Return the triangles
            return triangles;
        }

        /// <summary>
        ///     Returns a triangle that encompasses all triangulation points.
        /// </summary>
        /// <param name="triangulationPoints">
        ///     A list of triangulation points.
        /// </param>
        /// <returns>
        ///     Returns a triangle that encompasses all triangulation points.
        /// </returns>
        private static Triangle SuperTriangle(ref IList<Point3D> triangulationPoints) {
            var m = triangulationPoints[0].XAxis;

            // Get the extremal x and y coordinates
            for (var i = 1; i < triangulationPoints.Count; i++) {
                var xAbs = Math.Abs(triangulationPoints[i].XAxis);
                var yAbs = Math.Abs(triangulationPoints[i].YAxis);
                if (xAbs > m) m = xAbs;
                if (yAbs > m) m = yAbs;
            }

            // Make a triangle
            var sp1 = new Point3D(10 * m, 0, 0);
            var sp2 = new Point3D(0, 10 * m, 0);
            var sp3 = new Point3D(-10 * m, -10 * m, 0);

            return new Triangle(sp1, sp2, sp3);
        }

        #endregion
    }
}