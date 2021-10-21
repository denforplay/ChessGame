namespace ChessLib.Models
{
    public sealed class Vector2<T> where T : struct
    {
        public T X { get; set; }
        public T Y { get; set; }
        public Vector2(T x, T y)
        {
            X = x;
            Y = y;
        }
    }
}
