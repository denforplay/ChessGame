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
            Vector2[] directions =
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
                    try
                    {
                        nextPosition.Horizontal += (int)directions[i].X;
                        nextPosition.Vertical += (int)directions[i].Y;
                    }
                    catch
                    {
                        break;
                    }
                    
                    if (gameBoard.BoardCells[nextPosition.Horizontal - 1, nextPosition.Vertical - 1].Chess is null)
                        nextSteps.Add(new ChessPosition(nextPosition.Horizontal, nextPosition.Vertical));
                    else break;
                }
            }

            return nextSteps;
        }

        public override void Move(ChessPosition nextPosition, GameBoard gameBoard)
        {
            if (GetPossibleSteps(gameBoard).Contains(nextPosition))
            {
                gameBoard.BoardCells[CurrentPosition.Horizontal - 1, CurrentPosition.Vertical - 1].SetChess(null);
                gameBoard.BoardCells[nextPosition.Horizontal - 1, nextPosition.Vertical - 1].SetChess(this);
                CurrentPosition = nextPosition;
            }
        }
    }
}
