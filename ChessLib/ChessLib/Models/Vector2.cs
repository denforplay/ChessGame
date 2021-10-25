using System;

namespace ChessLib.Models
{
    /// <summary>
    /// Method provides general vector2
    /// </summary>
    /// <typeparam name="T">Type of vector2</typeparam>
    public sealed class Vector2<T> where T : struct, IComparable
    {
        /// <summary>
        /// Horizontal position
        /// </summary>
        public T X { get; set; }

        /// <summary>
        /// Vertical position
        /// </summary>
        public T Y { get; set; }

        /// <summary>
        /// Vector2 constructor
        /// </summary>
        /// <param name="x">Horizontal position</param>
        /// <param name="y">Vertical position</param>
        public Vector2(T x, T y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Check if this vector2 equals to other vector2
        /// </summary>
        /// <param name="obj">Object to compare</param>
        /// <returns>True if vectors are equals, other return false</returns>
        public override bool Equals(object obj)
        {
            if (obj is Vector2<T> vector)
            {
                return Y.CompareTo(vector.Y) == 0 && X.CompareTo(vector.X) == 0;
            }

            return false;
        }

        /// <summary>
        /// Hash code algorithm for vector2
        /// </summary>
        /// <returns>Hash code of vector2</returns>
        public override int GetHashCode()
        {
            int hash = 6688;
            hash += 12 * (X.GetHashCode() + Y.GetHashCode());
            return hash;
        }

        /// <summary>
        /// Returns a string that represents vector2.
        /// </summary>
        /// <returns>A string that represents vector2</returns>
        public override string ToString()
        {
            return $"Vector with coordinates: X{X}, Y{Y}";
        }
    }
}
