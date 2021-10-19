using ChessLib.Models.Enums;
using System;
using System.Collections.Generic;
using System.Numerics;

namespace ChessLib.Models.Figures
{
    public class Knight : ChessBase
    {
        public Knight(ChessPosition startPosition, ChessColor color) : base(startPosition, color)
        {
            _moveDirections = new Vector2<int>[]
                {
                    new Vector2<int>(1, 2),
                    new Vector2<int>(2, 1),
                    new Vector2<int>(1, -2),
                    new Vector2<int>(-2, 1),
                    new Vector2<int>(-1, 2),
                    new Vector2<int>(2, -1),
                    new Vector2<int>(-1, -2),
                    new Vector2<int>(-2, -1)
                };

        }

        public override List<ChessPosition> GetPossibleSteps(GameBoard gameBoard)
        {
            List<ChessPosition> nextSteps = new List<ChessPosition>();

            for (int i = 0; i < _moveDirections.Length; i++)
            {
                var nextPosition = new ChessPosition(CurrentPosition.Horizontal, CurrentPosition.Vertical);

                if (!gameBoard.IsPositionOnBoard(nextPosition.Horizontal + _moveDirections[i].X - 1, nextPosition.Vertical + _moveDirections[i].Y - 1))
                    continue;

                nextPosition.Horizontal += _moveDirections[i].X;
                nextPosition.Vertical += _moveDirections[i].Y;

                var chess = gameBoard.BoardCells[nextPosition.Horizontal - 1, nextPosition.Vertical - 1].Chess;

                if (chess is EmptyChess)
                    nextSteps.Add(new ChessPosition(nextPosition.Horizontal, nextPosition.Vertical));
                else if (chess.ChessColor != this.ChessColor)
                {
                    nextSteps.Add(new ChessPosition(nextPosition.Horizontal, nextPosition.Vertical));
                    break;
                }
                else
                    break;
            }

            return nextSteps;
        }
    }
}
