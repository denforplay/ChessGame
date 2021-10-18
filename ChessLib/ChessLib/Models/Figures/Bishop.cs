using System;
using System.Collections.Generic;
using System.Numerics;

namespace ChessLib.Models.Figures
{
    public class Bishop : ChessBase
    {
        public Bishop(ChessPosition startPosition, ChessColor color) : base(startPosition, color)
        {
        }

        public override List<ChessPosition> GetPossibleSteps(GameBoard gameBoard)
        {
            Vector2[] directions = new Vector2[]
            {
                 new Vector2(-1, 1),
                 new Vector2(1, 1),
                 new Vector2(1, -1),
                 new Vector2(-1, -1)
            };

            List<ChessPosition> nextSteps = new List<ChessPosition>();

            for (int i = 0; i < directions.Length; i++)
            {
                var nextPosition = new ChessPosition(CurrentPosition.Horizontal, CurrentPosition.Vertical);
                while (nextPosition.Vertical <= 8 && nextPosition.Vertical >= 1
&& nextPosition.Horizontal >= 1 && nextPosition.Horizontal <= 8)
                {
                    if (!gameBoard.IsPositionOnBoard(nextPosition.Horizontal + (int)directions[i].X - 1, nextPosition.Vertical + (int)directions[i].Y - 1))
                        break;
                    nextPosition.Horizontal += (int)directions[i].X;
                    nextPosition.Vertical += (int)directions[i].Y;

                    ChessBase chess = gameBoard.BoardCells[nextPosition.Horizontal - 1, nextPosition.Vertical - 1].Chess;

                    if (chess is null)
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
