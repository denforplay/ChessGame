using ChessLib.Models.Enums;
using System;
using System.Collections.Generic;

namespace ChessLib.Models.Figures
{
    /// <summary>
    /// Represents pawn figure
    /// </summary>
    public sealed class Pawn : ChessBase
    {
        private bool _isFirstStep = true;

        /// <summary>
        /// Copy constructor to create pawn from other pawn
        /// </summary>
        /// <param name="otherChess">Pawn from which copy info</param>
        public Pawn(Pawn otherChess) : base(otherChess)
        {
        }

        /// <summary>
        /// Pawn constructor
        /// </summary>
        /// <param name="startPosition">Start position</param>
        /// <param name="color">Figure color</param>
        public Pawn(ChessPosition startPosition, ChessColor color) : base(startPosition, color)
        {
        }

        public override List<ChessPosition> GetPossibleSteps(GameBoard gameBoard)
        {
            List<ChessPosition> nextSteps = new();

            if (gameBoard.BoardCells[CurrentPosition.Horizontal - 1 + _moveDirections[0].X, CurrentPosition.Vertical - 1 + _moveDirections[0].Y].Chess is EmptyChess)
                nextSteps.Add(new ChessPosition(CurrentPosition.Horizontal + _moveDirections[0].X, CurrentPosition.Vertical + _moveDirections[0].Y));

            for (int i = 1; i <= 2; i++)
            {
                if (gameBoard.IsPositionOnBoard(CurrentPosition.Horizontal - 1 + _moveDirections[i].X, CurrentPosition.Vertical - 1 + _moveDirections[i].Y) &&
           gameBoard.BoardCells[CurrentPosition.Horizontal - 1 + _moveDirections[i].X, CurrentPosition.Vertical - 1 + _moveDirections[i].Y].Chess is not EmptyChess)
                    nextSteps.Add(new ChessPosition(CurrentPosition.Horizontal + _moveDirections[i].X, CurrentPosition.Vertical + _moveDirections[i].Y));
            }
           
            if (_isFirstStep && gameBoard.BoardCells[CurrentPosition.Horizontal - 1 + _moveDirections[3].X, CurrentPosition.Vertical - 1 + _moveDirections[3].Y].Chess is EmptyChess)
                nextSteps.Add(new ChessPosition(CurrentPosition.Horizontal + _moveDirections[3].X, CurrentPosition.Vertical + _moveDirections[3].Y));

            return nextSteps;
        }

        public override void Move(ChessPosition nextPosition, GameBoard gameBoard)
        {
            if (GetPossibleSteps(gameBoard).Contains(nextPosition))
            {
                if (_isFirstStep)
                    _isFirstStep = false;

                gameBoard.BoardCells[CurrentPosition.Horizontal - 1, CurrentPosition.Vertical - 1].SetChess(new EmptyChess(CurrentPosition, ChessColor.None));

                if (gameBoard.BoardCells[nextPosition.Horizontal - 1, nextPosition.Vertical - 1].Chess is not EmptyChess)
                {
                    gameBoard.RemoveChess(gameBoard.BoardCells[nextPosition.Horizontal - 1, nextPosition.Vertical - 1]);
                }

                gameBoard.BoardCells[nextPosition.Horizontal - 1, nextPosition.Vertical - 1].SetChess(this);
                CurrentPosition = nextPosition;
            }
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
