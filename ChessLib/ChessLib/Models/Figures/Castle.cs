using ChessLib.Models.Enums;

namespace ChessLib.Models.Figures
{
    /// <summary>
    /// Represents castle chess figure
    /// </summary>
    public sealed class Castle : ChessBase
    {
        /// <summary>
        /// Copy constructor to create castle from pawn
        /// </summary>
        /// <param name="otherChess">Pawn from which copy info</param>
        public Castle(Pawn otherChess) : base(otherChess)
        {
            _moveDirections = new Vector2<int>[]
            {
                 new Vector2<int>(0, 1),
                 new Vector2<int>(0, -1),
                 new Vector2<int>(1, 0),
                 new Vector2<int>(-1, 0)
            };
        }

        /// <summary>
        /// Castle constructor
        /// </summary>
        /// <param name="startPosition">Start position</param>
        /// <param name="color">Figure color</param>
        public Castle(ChessPosition startPosition, ChessColor color) : base(startPosition, color)
        {
            _moveDirections = new Vector2<int>[]
            {
                 new Vector2<int>(0, 1),
                 new Vector2<int>(0, -1),
                 new Vector2<int>(1, 0),
                 new Vector2<int>(-1, 0)
            };
        }
    }
}