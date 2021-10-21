using ChessLib.Models.Enums;

namespace ChessLib.Models.Figures
{
    /// <summary>
    /// Represents bishop chess figure
    /// </summary>
    public sealed class Bishop : ChessBase
    {
        /// <summary>
        /// Copy constructor to create bishop from pawn
        /// </summary>
        /// <param name="otherChess">Pawn from which copy info</param>
        public Bishop(Pawn otherChess) : base(otherChess)
        {
            _moveDirections = new Vector2<int>[]
            {
                new Vector2<int>(1, 1),
                new Vector2<int>(1, -1),
                new Vector2<int>(-1, 1),
                new Vector2<int>(-1, -1)
            };
        }

        /// <summary>
        /// Bishop constructor
        /// </summary>
        /// <param name="startPosition">Start position</param>
        /// <param name="color">Figure color</param>
        public Bishop(ChessPosition startPosition, ChessColor color) : base(startPosition, color)
        {
            _moveDirections = new Vector2<int>[]
            {
                new Vector2<int>(1, 1),
                new Vector2<int>(1, -1),
                new Vector2<int>(-1, 1),
                new Vector2<int>(-1, -1)
            };
        }
    }
}
