using System.Collections.Generic;

namespace ChessLib.Models.Figures
{
    public class Castle : ChessBase
    {
        public Castle(ChessPosition startPosition, ChessColor color) : base(startPosition, color)
        {
        }

        public override List<ChessPosition> GetPossibleSteps(GameBoard gameBoard)
        {
            List<ChessPosition> nextSteps = new List<ChessPosition>();

            for (int i = 1; i <= 8; i++)
            {
                if (i != CurrentPosition.Horizontal)
                {
                    if (gameBoard.BoardCells[i - 1, CurrentPosition.Vertical - 1].Chess is null)
                        nextSteps.Add(new ChessPosition(i, CurrentPosition.Vertical));
                    else
                        break;
                }
            }

            for (int i = 1; i <= 8; i++)
            {
                if (i != CurrentPosition.Vertical)
                {
                    if (gameBoard.BoardCells[CurrentPosition.Horizontal - 1, i - 1].Chess is null)
                        nextSteps.Add(new ChessPosition(CurrentPosition.Horizontal, i));
                    else
                        break;
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
