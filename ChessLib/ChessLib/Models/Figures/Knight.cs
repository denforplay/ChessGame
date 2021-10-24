using ChessLib.Models.Enums;
using ChessLib.Models.Figures.FigureMovements;
using System.Collections.Generic;

namespace ChessLib.Models.Figures
{
    /// <summary>
    /// Represents knight figure
    /// </summary>
    public sealed class Knight : ChessBase
    {
        /// <summary>
        /// Copy constructor to create knight from other pawn
        /// </summary>
        /// <param name="otherChess">Pawn from which copy info</param>
        public Knight(Pawn otherChess) : base(otherChess)
        {
            _movement = new AllDirectionStepFinder();
        }

        /// <summary>
        /// Knight constructor
        /// </summary>
        /// <param name="startPosition">Start position</param>
        /// <param name="color">Figure color</param>
        public Knight(ChessPosition startPosition, ChessColor color) : base(startPosition, color)
        {
            _movement = new AllDirectionStepFinder();
        }
        
        protected override void InitializeMoveDirections()
        {
            _moveDirections = new Vector2<int>[]
            {
                    new Vector2<int>(1, 2),
                    new Vector2<int>(2, 1),
                    new Vector2<int>(1, -2),
                    new Vector2<int>(-1, 2),
                    new Vector2<int>(-2, 1),
                    new Vector2<int>(2, -1),
                    new Vector2<int>(-1, -2),
                    new Vector2<int>(-2, -1)
            };
        }
    }
}
