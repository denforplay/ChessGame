using ChessLib.Models.Enums;
using System;

namespace ChessLib.Models.Figures
{
    /// <summary>
    /// Represents empty chess figure
    /// </summary>
    public sealed class EmptyChess : ChessBase
    {
        /// <summary>
        /// Copy constructor to create empty chess from other empty chess
        /// </summary>
        /// <param name="otherChess">Empty chess from which copy info</param>
        public EmptyChess(EmptyChess otherChess) : base(otherChess)
        {
            _moveDirections = Array.Empty<Vector2<int>>();
        }

        /// <summary>
        /// Empty chess constructor
        /// </summary>
        /// <param name="startPosition">Start position</param>
        /// <param name="color">Figure color</param>
        public EmptyChess(ChessPosition startPosition, ChessColor color) : base(startPosition, color)
        {
            _moveDirections = Array.Empty<Vector2<int>>();
        }
    }
}
