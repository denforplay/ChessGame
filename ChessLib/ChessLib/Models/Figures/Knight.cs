using System;
using System.Collections.Generic;
using System.Numerics;

namespace ChessLib.Models.Figures
{
    public class Knight : ChessBase
    {
        public Knight(ChessPosition startPosition, ChessColor color) : base(startPosition, color)
        {
        }

        public override List<ChessPosition> GetPossibleSteps(GameBoard gameBoard)
        {
            Vector2[] directions = new Vector2[]
            {
                 new Vector2(1, 2),
                 new Vector2(1, -2),
                 new Vector2(-1, 2),
                 new Vector2(-1, -2)
            };

            List<ChessPosition> nextSteps = new List<ChessPosition>();

            for (int i = 0; i < directions.Length; i++)
            {
                var nextPosition = new ChessPosition(CurrentPosition.Horizontal, CurrentPosition.Vertical);
                try
                {
                    nextPosition.Horizontal += (int)directions[i].X;
                    nextPosition.Vertical += (int)directions[i].Y;
                }
                catch (ArgumentException ex)
                {
                    continue;
                }

                if (gameBoard.BoardCells[nextPosition.Horizontal - 1, nextPosition.Vertical - 1].Chess is null)
                    nextSteps.Add(new ChessPosition(nextPosition.Horizontal, nextPosition.Vertical));
                else break;
            }

            return nextSteps;
        }
    }
}
