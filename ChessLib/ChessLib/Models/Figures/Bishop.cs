using ChessLib.Models.Enums;
using System;
using System.Collections.Generic;
using System.Numerics;

namespace ChessLib.Models.Figures
{
    public class Bishop : ChessBase
    {
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

        public override List<ChessPosition> GetPossibleSteps(GameBoard gameBoard)
        {
            List<ChessPosition> nextSteps = new List<ChessPosition>();

            for (int i = 0; i < _moveDirections.Length; i++)
            {
                var nextPosition = new ChessPosition(CurrentPosition.Horizontal, CurrentPosition.Vertical);
                while (nextPosition.Vertical <= 8 && nextPosition.Vertical >= 1
&& nextPosition.Horizontal >= 1 && nextPosition.Horizontal <= 8)
                {
                    if (!gameBoard.IsPositionOnBoard(nextPosition.Horizontal + _moveDirections[i].X - 1, nextPosition.Vertical + _moveDirections[i].Y - 1))
                        break;
                    nextPosition.Horizontal += _moveDirections[i].X;
                    nextPosition.Vertical += _moveDirections[i].Y;

                    ChessBase chess = gameBoard.BoardCells[nextPosition.Horizontal - 1, nextPosition.Vertical - 1].Chess;

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
            }

            return nextSteps;
        }
    }
}
