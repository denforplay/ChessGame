using ChessLib.Models.Enums;
using ChessLib.Models.Figures.FigureMovements;
using System;
using System.Collections.Generic;

namespace ChessLib.Models.Figures
{
    /// <summary>
    /// Represents pawn figure
    /// </summary>
    public sealed class Pawn : ChessBase
    {
        public ChessPosition StartPosition { get; private set; }

        /// <summary>
        /// Copy constructor to create pawn from other pawn
        /// </summary>
        /// <param name="otherChess">Pawn from which copy info</param>
        public Pawn(Pawn otherChess) : base(otherChess)
        {
            _movement = new PawnMovement();
        }

        public void SetFirstStep(bool isFirstStep)
        {
            (_movement as PawnMovement).IsFirstStep = isFirstStep;
        }

        /// <summary>
        /// Pawn constructor
        /// </summary>
        /// <param name="startPosition">Start position</param>
        /// <param name="color">Figure color</param>
        public Pawn(ChessPosition startPosition, ChessColor color) : base(startPosition, color)
        {
            StartPosition = new ChessPosition(startPosition.Horizontal, startPosition.Vertical);
            _movement = new PawnMovement();
        }

        protected override void InitializeMoveDirections()
        {
            _moveDirections = new Vector2<int>[]
            {
                    new Vector2<int>(0, ChessColor == ChessColor.White ? 1 : -1),
                    new Vector2<int>(-1, ChessColor == ChessColor.White ? 1 : -1),
                    new Vector2<int>(1, ChessColor == ChessColor.White ? 1 : -1),
                    new Vector2<int>(0, ChessColor == ChessColor.White ? 2 : -2)
            };
        }
    }
}
