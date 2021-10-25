namespace ChessLib.Models
{
    /// <summary>
    /// Method provides general vector2
    /// </summary>
    /// <typeparam name="T">Type of vector2</typeparam>
    public sealed class Vector2<T> where T : struct
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
    }
}
