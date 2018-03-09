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
// FILE: Surface.NET/Surface.NET Library/Edge.cs
// MODIFIED: 09.03.2018 15:09
// DEVELOPER: MyCatShoegazer <mycatshoegazer@outlook.com>

namespace SurfaceLib.Types {
    /// <summary>
    ///     Defines edge for Delaunay triangulation.
    /// </summary>
    public class Edge {
        #region constructors

        /// <summary>
        ///     Constructs and edge from two <see cref="Point3D" /> objects.
        /// </summary>
        /// <param name="startPoint3D">
        ///     Start point of the edge.
        /// </param>
        /// <param name="endPoint3D">
        ///     End point of the edge.
        /// </param>
        public Edge(Point3D startPoint3D, Point3D endPoint3D) {
            this.StartPoint3D = startPoint3D;
            this.EndPoint3D = endPoint3D;
        }

        #endregion

        #region properties

        /// <summary>
        ///     Start <see cref="Point3D" /> of the edge.
        /// </summary>
        public Point3D StartPoint3D { get; }

        /// <summary>
        ///     End <see cref="Point3D" /> of the edge.
        /// </summary>
        public Point3D EndPoint3D { get; }

        #endregion

        #region overrides

        /// <summary>
        ///     A hash code for this edge.
        /// </summary>
        /// <returns>
        ///     Returns the hash code as <see cref="int" /> for this edge.
        /// </returns>
        public override int GetHashCode() {
            return this.StartPoint3D.GetHashCode() ^ this.EndPoint3D.GetHashCode();
        }

        /// <summary>
        ///     Tests if two edges are considered equal.
        /// </summary>
        /// <param name="obj">
        ///     An <see cref="Edge" /> object.
        /// </param>
        /// <returns>
        ///     Returns true if two edges are considered equal, false otherwise.
        /// </returns>
        /// <remarks>
        ///     Two edges are considered equal if they contain the same points.
        ///     This is, two equal edges may have interchanged start and end points.
        /// </remarks>
        public override bool Equals(object obj) {
            return this == (Edge) obj;
        }

        #endregion

        #region operators

        /// <summary>
        ///     Tests if two edges are equal.
        /// </summary>
        /// <param name="left">
        ///     A first <see cref="Edge" />.
        /// </param>
        /// <param name="right">
        ///     A second <see cref="Edge" />.
        /// </param>
        /// <returns>
        ///     Returns true if two edges are considered equal, false otherwise.
        /// </returns>
        /// <remarks>
        ///     Two edges are considered equal if they contain the same points.
        ///     This is, two equal edges may have interchanged start and end points.
        /// </remarks>
        public static bool operator ==(Edge left, Edge right) {
            if (left == (object) right) return true;

            if ((object) left == null || (object) right == null) return false;

            return left.StartPoint3D == right.StartPoint3D && left.EndPoint3D == right.EndPoint3D ||
                   left.StartPoint3D == right.EndPoint3D && left.EndPoint3D == right.StartPoint3D;
        }

        /// <summary>
        ///     Tests if two edges are considered equal.
        /// </summary>
        /// <param name="left">
        ///     A first <see cref="Edge" />.
        /// </param>
        /// <param name="right">
        ///     A second <see cref="Edge" />.
        /// </param>
        /// <returns>
        ///     Returns false if two edges are considered equal, true otherwise.
        /// </returns>
        /// <remarks>
        ///     Two edges are considered equal if they contain the same points.
        ///     This is, two equal edges may have interchanged start and end points.
        /// </remarks>
        public static bool operator !=(Edge left, Edge right) {
            return left != right;
        }

        #endregion
    }
}